using System;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;

namespace PluralsightPrismDemo.Services
{
    public class ServicesModule : IModule
    {
        IUnityContainer _container;

        public ServicesModule(IUnityContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {
           
        }
    }
}
