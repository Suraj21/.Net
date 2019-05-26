using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module1
{
    public class RegisterModule : IModule
    {
        private IRegionManager _regionManager;
        public RegisterModule(IRegionManager regionManager)
        {
            this._regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            //throw new NotImplementedException();
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            _regionManager.RegisterViewWithRegion("Module1", typeof(Views.Module1View1));
        }
    }
}
