using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationJournal
{
    public class NavigationJournalModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RequestNavigate("NavigationJournalView", "PersonList");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }
    }
}
