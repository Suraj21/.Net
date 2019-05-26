using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EmployeeDetails.Views
{
    /// <summary>
    /// Interaction logic for EmployeeView.xaml
    /// </summary>
    public partial class EmployeeView : UserControl
    {
        IContainerExtension _container;
        IRegionManager _regionManager;
        IRegion _region;

        EmployeeDetailsView employeeDetailsView;

        public EmployeeView(IContainerExtension container, IRegionManager regionManager)
        {
            InitializeComponent();
            _container = container;
            _regionManager = regionManager;
            this.Loaded += EmployeeView_Loaded;
        }

        /// <summary>
        ///  View Injection on button click setup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmployeeView_Loaded(object sender, RoutedEventArgs e)
        {
            employeeDetailsView = _container.Resolve<EmployeeDetailsView>();
            _region = _regionManager.Regions["EmployeeDetailsRegion"];
            _region.Add(employeeDetailsView);
            //So that the Region should not automatically get activated as soon as it gets added
            //It should get activated only on show button click 
            //_region.Deactivate(employeeDetailsView);
        }

        /// <summary>
        /// Activating the Employee Details on button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Show_Employee_Details(object sender, RoutedEventArgs e)
        {
            _region.Activate(employeeDetailsView);
        }

        /// <summary>
        /// Deactivating the Employee Details on button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hide_Employee_Click(object sender, RoutedEventArgs e)
        {
            _region.Deactivate(employeeDetailsView);
        }
    }
}
