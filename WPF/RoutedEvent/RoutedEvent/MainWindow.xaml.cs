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

namespace RoutedEventControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //AddHandler(Button.ClickEvent, new RoutedEventHandler(Window_Click),true);
        }

        /// <summary>
        /// After creating the new custom user MyRoutedEventArgs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomControlLib_Click(object sender, MyRoutedEventArgs e)
        {
           var data = e.Param;
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void StackPanel_Click(object sender, RoutedEventArgs e)
        //{
        //    e.Handled = true;
        //}

        //private void Window_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        //{

        //}

        //private void StackPanel_PreviewKeyDown(object sender, KeyEventArgs e)
        //{
        //    e.Handled = true;
        //}

        //private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        //{

        //}

        //private void CustomControlLib_Click(object sender, RoutedEventArgs e)
        //{

        //}
    }
}
