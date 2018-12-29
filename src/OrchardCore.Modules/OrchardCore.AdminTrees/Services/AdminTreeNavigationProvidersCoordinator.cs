using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OrchardCore.AdminTrees.Models;
using OrchardCore.Navigation;
using YesSql;

namespace OrchardCore.AdminTrees.Services
{
    // Retrieves all instances of "IAdminNodeNavigationBuilder"
    // Those are classes that add new "AdminNodes" to a "NavigationBuilder" using custom logic specific to the module that register them.
    // This class handles their inclusion on the admin menu.
    // This class is itself one more INavigationProvider so it can be called from this module's AdminMenu.cs
    public class AdminTreeNavigationProvidersCoordinator : INavigationProvider
    {
        private readonly IAdminTreeService _adminTreeService;
        private readonly IEnumerable<IAdminNodeNavigationBuilder> _nodeBuilders;
        private readonly ILogger Logger;

        public AdminTreeNavigationProvidersCoordinator(
            IAdminTreeService adminTreeService,
            IEnumerable<IAdminNodeNavigationBuilder> nodeBuilders,
            ILogger<AdminTreeNavigationProvidersCoordinator> logger)
        {
            _adminTreeService = adminTreeService;
            _nodeBuilders = nodeBuilders;
            Logger = logger;
        }

        // We only add them if the caller uses the string "admintree").
        // todo: use a public constant for the string
        public async Task BuildNavigationAsync(string name, NavigationBuilder builder)
        {
            if (!String.Equals(name, "admintree", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            var trees = (await _adminTreeService.GetAsync())
                                    .Where(x => x.Enabled == true)
                                    .Where( x => x.MenuItems.Count > 0);


            trees.ToList().ForEach( async p => await BuildTreeAsync(p, builder));
        }

        private async Task BuildTreeAsync(AdminTree tree, NavigationBuilder builder)
        {
            foreach (MenuItem node in tree.MenuItems)
            {
                var nodeBuilder = _nodeBuilders.Where(x => x.Name == node.GetType().Name).FirstOrDefault();
                if (nodeBuilder != null)
                {
                    await nodeBuilder.BuildNavigationAsync(node, builder, _nodeBuilders);
                }
                else
                {
                    Logger.LogError("No Builder registered for admin node of type '{TreeNodeName}'", node.GetType().Name);
                }
            }
        }

    }
}
