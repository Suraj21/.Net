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
using System.Windows.Shapes;
using WpfAppMVVM.ViewModel;

namespace WpfAppMVVM.View
{
    /// <summary>
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class GeneralView 
    {
        public GeneralView()
        {
            InitializeComponent();
            //UserViewModel userViewModel = new UserViewModel();
            //this.DataContext = userViewModel;
        }
    }
}
