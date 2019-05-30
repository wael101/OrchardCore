using System.Globalization;
using System.Linq;

namespace OrchardCore.Settings
{
    public static class SiteExtensions
    {
        public static string[] GetConfiguredCultures(this ISite site)
        {
            return new[] { site.Culture ?? CultureInfo.InstalledUICulture.Name }.Union(site.SupportedCultures).ToArray();
        }
    }
}
