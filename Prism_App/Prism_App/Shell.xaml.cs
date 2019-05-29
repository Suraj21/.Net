using Prism.Regions;
using System.Windows;

namespace Prism_App
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    public partial class Shell : Window
    {
        public Shell(IRegionManager regionManager)
        {
            InitializeComponent();
            regionManager.RegisterViewWithRegion("EmployeeRegistrationView", typeof(EmployeeRegistration.Views.EmployeeRegistrationView));
            regionManager.RegisterViewWithRegion("EmployeeView", typeof(EmployeeDetails.Views.EmployeeView));
            regionManager.RegisterViewWithRegion("DelCommandView", typeof(DelegateCommandExample.Views.DelCommandView));
            regionManager.RegisterViewWithRegion("CompositeCommandView", typeof(CompositeCommandExample.Views.CompositeCommandView));
            regionManager.RegisterViewWithRegion("CompositeCommandView1", typeof(CompositeCommandExample.Views.View1));
            regionManager.RegisterViewWithRegion("CompositeCommandView2", typeof(CompositeCommandExample.Views.View2));
            regionManager.RegisterViewWithRegion("CompositeCommandView3", typeof(CompositeCommandExample.Views.View3));
            regionManager.RegisterViewWithRegion("EmployeeDetailsView", typeof(EmployeeDetails.Views.EmployeeDetailsView));
            regionManager.RegisterViewWithRegion("EmployeeProjectView", typeof(EmployeeDetails.Views.EmployeeProjectView));
            regionManager.RegisterViewWithRegion("CompanyDetailView", typeof(EmployeeDetails.Views.CompanyDetailView));
        }
    }
}
