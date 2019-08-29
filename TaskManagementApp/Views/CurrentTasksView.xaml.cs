using System.Windows.Controls;
using TaskManagementApp.ViewModel;

namespace TaskManagementApp.Views
{
    /// <summary>
    /// Interaction logic for CurrentTasks.xaml
    /// </summary>
    public partial class CurrentTasksView : UserControl
    {
        public CurrentTasksView()
        {
            InitializeComponent();
            this.DataContext = new CurrentTasksViewModel();
        }
    }
}
