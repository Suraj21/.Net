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

namespace WpfAppMVVM.View.GeneralViews
{
    /// <summary>
    /// Interaction logic for ReusableComponentView2.xaml
    /// </summary>
    public partial class ReusableComponentView2 : UserControl
    {
        public ReusableComponentView2()
        {
            InitializeComponent();
        }

        //public static RoutedUICommand _pressMeCommand = new RoutedUICommand("Press Me", "PressMe", typeof(ReusableComponentView2));
        //public static RoutedUICommand PressMeCommand
        //{
        //    get { return _pressMeCommand; }
        //}

        public void PressMe_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        public void PressMe_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Howdy howdy I'm a cowboy");
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("toggle button checked");
        }
    }
}
