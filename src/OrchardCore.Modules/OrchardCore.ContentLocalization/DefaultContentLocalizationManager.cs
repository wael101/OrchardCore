using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OrchardCore.ContentLocalization.Handlers;
using OrchardCore.ContentLocalization.Models;
using OrchardCore.ContentLocalization.Records;
using OrchardCore.ContentManagement;
using OrchardCore.Modules;
using OrchardCore.Settings;
using YesSql;

namespace OrchardCore.ContentLocalization
{
    public class DefaultContentLocalizationManager : IContentLocalizationManager
    {
        private readonly IContentManager _contentManager;
        private readonly ISession _session;
        private readonly ISiteService _siteService;
        private readonly ILogger<DefaultContentLocalizationManager> _logger;
        private readonly Entities.IIdGenerator _iidGenerator;

        public IEnumerable<IContentLocalizationHandler> Handlers { get; private set; }
        public IEnumerable<IContentLocalizationHandler> ReversedHandlers { get; private set; }

        public DefaultContentLocalizationManager(
            IContentManager contentManager,
            ISession session,
            ISiteService siteService,
            ILogger<DefaultContentLocalizationManager> logger,
            IEnumerable<IContentLocalizationHandler> handlers,
            Entities.IIdGenerator iidGenerator)
        {
            _contentManager = contentManager;
            _session = session;
            _siteService = siteService;
            Handlers = handlers;
            _iidGenerator = iidGenerator;
            ReversedHandlers = handlers.Reverse().ToArray();
            _logger = logger;
        }

        public async Task<ContentItem> GetContentItem(string localizationSet, string culture)
        {
            var invariantCulture = culture.ToLowerInvariant();
            var indexValue = await _session.Query<ContentItem, LocalizedContentItemIndex>(o =>
                    o.LocalizationSet == localizationSet &&
                    o.Culture == invariantCulture
                ).FirstOrDefaultAsync();

            return indexValue;
        }

        public Task<IEnumerable<ContentItem>> GetItemsForSet(string localizationSet)
        {
            return _session.Query<ContentItem, LocalizedContentItemIndex>(o => o.LocalizationSet == localizationSet).ListAsync();
        }

        public async Task<ContentItem> LocalizeAsync(ContentItem content, string targetCulture)
        {
            var localizationPart = content.As<LocalizationPart>();
            var siteSettings = await _siteService.GetSiteSettingsAsync();

            // not sure if this is redundant or not. The check is also done in the Admin controller
            if (!siteSettings.GetConfiguredCultures().Any(c => String.Equals(c, targetCulture, StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException("Cannot localize an unsupported culture");
            }

            if (String.IsNullOrEmpty(localizationPart.LocalizationSet))
            {
                // If the source content item is not yet localized, define its defaults

                localizationPart.LocalizationSet = _iidGenerator.GenerateUniqueId();
                localizationPart.Culture = await GetDefaultCultureNameAsync();
                _session.Save(content);
            }
            else
            {
                var existingContent = await GetContentItem(localizationPart.LocalizationSet, targetCulture);

                if (existingContent != null)
                {
                    // already localized
                    return existingContent;
                }
            }

            // Cloning the content item
            var cloned = await _contentManager.CloneAsync(content);
            var clonedPart = cloned.As<LocalizationPart>();
            clonedPart.Culture = targetCulture;
            clonedPart.LocalizationSet = localizationPart.LocalizationSet;
            clonedPart.Apply();

            var context = new LocalizationContentContext(content, localizationPart.LocalizationSet, targetCulture);

            await Handlers.InvokeAsync(async handler => await handler.LocalizingAsync(context), _logger);
            await ReversedHandlers.InvokeAsync(async handler => await handler.LocalizedAsync(context), _logger);

            _session.Save(cloned);
            return cloned;
        }

        private async Task<string> GetDefaultCultureNameAsync()
        {
            var setting = await _siteService.GetSiteSettingsAsync();

            if (!String.IsNullOrEmpty(setting.Culture))
            {
                return CultureInfo.GetCultureInfo(setting.Culture).Name;
            }

            return CultureInfo.InstalledUICulture.Name;
        }
    }
}
