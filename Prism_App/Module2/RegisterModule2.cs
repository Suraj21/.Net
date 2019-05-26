using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2
{
    public class RegisterModule2 : IModule
    {
        private IRegionManager _regionManager;

        public RegisterModule2(IRegionManager regionManager)
        {
            this._regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            _regionManager.RegisterViewWithRegion("Module2", typeof(Views.Module2View1));            
        }
    }
}
