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
using WpfAppHierAndNav;
using WpfAppHierAndNav.ViewModel;
using WpfAppMVVM.ViewModel;

namespace WpfAppMVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    //public class MainWindowViewModel : BindableBase
    //{

    //    public MainWindowViewModel()
    //    {
    //        NavCommand = new MyICommand<string>(OnNav);
    //    }

    //    private CustomerListViewModel custListViewModel = new CustomerListViewModel();

    //    private OrderViewModel orderViewModelModel = new OrderViewModel();

    //    private BindableBase _CurrentViewModel;

    //    public BindableBase CurrentViewModel
    //    {
    //        get { return _CurrentViewModel; }
    //        set { SetProperty(ref _CurrentViewModel, value); }
    //    }

    //    public MyICommand<string> NavCommand { get; private set; }

    //    private void OnNav(string destination)
    //    {

    //        switch (destination)
    //        {
    //            case "orders":
    //                CurrentViewModel = orderViewModelModel;
    //                break;
    //            case "customers":
    //            default:
    //                CurrentViewModel = custListViewModel;
    //                break;
    //        }
    //    }
    //}
}
