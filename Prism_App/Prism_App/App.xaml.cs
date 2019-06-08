using Prism.Ioc;
using Prism.Unity;
using System.Windows;
using Prism.Modularity;
using Prism.Mvvm;
using System.Reflection;
using System;
using CompositeCommands.Core;

namespace Prism_App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IApplicationCommands, ApplicationCommands>();
            containerRegistry.RegisterForNavigation<EmployeeDetails.Views.CompanyDetailView>();
            containerRegistry.RegisterForNavigation<EmployeeDetails.Views.EmployeeProjectView>();
            containerRegistry.RegisterForNavigation<NavigationParticipation.Views.UserView1>();
            containerRegistry.RegisterForNavigation<NavigationParticipation.Views.UserView2>();
            containerRegistry.RegisterForNavigation<NavigationJournal.Views.PersonList>();
            containerRegistry.RegisterForNavigation<NavigationJournal.Views.PersonDetail>();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
            //return new DirectoryModuleCatalog() { ModulePath = @".\Modules" }; To be Used while Loading the modules via directory

            //Loading the Modules Manually
            //var moduleAType = typeof(ModuleAModule);
            //moduleCatalog.AddModule(new ModuleInfo()
            //{
            //    ModuleName = moduleAType.Name,
            //    ModuleType = moduleAType.AssemblyQualifiedName,
            //    InitializationMode = InitializationMode.OnDemand
            //});
        }

        /// <summary>
        /// Configure ViewModel Locator
        /// </summary>
        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            //change convention technique
            //ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) =>
            //{
            //    var viewName = viewType.FullName;
            //    var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            //    var viewModelName = $"{viewName}ViewModel, {viewAssemblyName}";
            //    return Type.GetType(viewModelName);
            //});

            //Custom Registrations of View Model Locator
            // type / type
            //ViewModelLocationProvider.Register(typeof(MainWindow).ToString(), typeof(CustomViewModel));

            // type / factory
            //ViewModelLocationProvider.Register(typeof(MainWindow).ToString(), () => Container.Resolve<CustomViewModel>());

            // generic factory
            //ViewModelLocationProvider.Register<MainWindow>(() => Container.Resolve<CustomViewModel>());

            // generic type
            ViewModelLocationProvider.Register<EmployeeRegistration.Views.EmployeeRegistrationView, EmployeeRegistration.ViewModel.EmployeeRegistrationViewModel>();
            ViewModelLocationProvider.Register<EmployeeDetails.Views.EmployeeView, EmployeeDetails.ViewModel.EmployeeViewViewModel>();
            ViewModelLocationProvider.Register<EmployeeDetails.Views.EmployeeDetailsView, EmployeeDetails.ViewModel.EmployeeDetailsViewModel>();
            ViewModelLocationProvider.Register<DelegateCommandExample.Views.DelCommandView, DelegateCommandExample.ViewModel.DelCommandViewModel>();
            ViewModelLocationProvider.Register<CompositeCommandExample.Views.CompositeCommandView, CompositeCommandExample.ViewModel.CompositeCommandViewModel>();
            ViewModelLocationProvider.Register<CompositeCommandExample.Views.View1, CompositeCommandExample.ViewModel.View1ViewModel>();
            ViewModelLocationProvider.Register<CompositeCommandExample.Views.View2, CompositeCommandExample.ViewModel.View2ViewModel>();
            ViewModelLocationProvider.Register<CompositeCommandExample.Views.View3, CompositeCommandExample.ViewModel.View3ViewModel>();
            ViewModelLocationProvider.Register<EmployeeDetails.Views.CompanyDetailView, EmployeeDetails.ViewModel.CompanyDetailViewViewModel>();
            ViewModelLocationProvider.Register<EmployeeDetails.Views.EmployeeProjectView, EmployeeDetails.ViewModel.EmployeeProjectViewViewModel>();
            ViewModelLocationProvider.Register<NavigationParticipation.Views.UserView1, NavigationParticipation.ViewModel.UserView1ViewModel>();
            ViewModelLocationProvider.Register<NavigationParticipation.Views.UserView2, NavigationParticipation.ViewModel.UserView2ViewModel>();
            ViewModelLocationProvider.Register<NavigationParticipation.Views.NavigationParticipationView, NavigationParticipation.ViewModel.NavigationParticipationViewViewModel>();
            ViewModelLocationProvider.Register<NavigationParticipation.Views.ItemsSelectionView, NavigationParticipation.ViewModel.ItemSelectionViewModel>();
            ViewModelLocationProvider.Register<NavigationJournal.Views.PersonList, NavigationJournal.ViewModel.PersonListViewModel>();
            ViewModelLocationProvider.Register< NavigationJournal.Views.PersonDetail, NavigationJournal.ViewModel.PersonDetailViewModel>();
            ViewModelLocationProvider.Register< NavigationJournal.Views.NavigationJournalView, NavigationJournal.ViewModel.NavigationJournalViewViewModel>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
            moduleCatalog.AddModule<NavigationJournal.NavigationJournalModule>();
        }
    }
}
