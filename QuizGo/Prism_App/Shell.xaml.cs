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
            regionManager.RegisterViewWithRegion("Questions", typeof(Quiz.Views.Quiz));
            regionManager.RegisterViewWithRegion("MainView", typeof(Quiz.Views.MainView));
        }
    }
}
