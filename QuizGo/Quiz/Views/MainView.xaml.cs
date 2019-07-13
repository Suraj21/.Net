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

namespace Quiz.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        IContainerExtension _container;
        IRegionManager _regionManager;
        IRegion _region;
        Quiz quizView;
        //Login loginView;

        public MainView(IContainerExtension container, IRegionManager regionManager)
        {
            InitializeComponent();
            _container = container;
            _regionManager = regionManager;
            this.Loaded += MainView_Loaded;
        }

        private void MainView_Loaded(object sender, RoutedEventArgs e)
        {
            quizView = _container.Resolve<Quiz>();
            //loginView = _container.Resolve<Login>();
            _region = _regionManager.Regions["MainView"];
            _region.Add(quizView);
            //_region.Add(loginView);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtNotify.Text = string.Empty;
            if (!string.IsNullOrEmpty(txtUserName.Text))
            {
                IsLoginView = false;
                //_region.Deactivate(loginView);
                _region.Activate(quizView);
            }
            else
            {
                txtNotify.Text = "Please Enter User Name";
            }
        }



        public bool IsLoginView
        {
            get { return (bool)GetValue(IsLoginViewProperty); }
            set { SetValue(IsLoginViewProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsLoginView.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsLoginViewProperty =
            DependencyProperty.Register("IsLoginView", typeof(bool), typeof(MainView), new PropertyMetadata(true));


    }
}
