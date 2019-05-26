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

namespace WpfAppMVVM.View
{
    /// <summary>
    /// Interaction logic for ThumbView.xaml
    /// </summary>
    public partial class ThumbView : UserControl
    {
        public ThumbView()
        {
            InitializeComponent();
        }
        private void MyGridSplitter_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            LeftText.Text = "Dragging Started";
            MyGridSplitter.Background = Brushes.Red;
        }

        private void MyGridSplitter_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            LeftText.Text = string.Format("Dragging Completed, moving {0}", e.HorizontalChange);
            MyGridSplitter.Background = Brushes.Gray;
        }

        private void MyGridSplitter_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            if (e.HorizontalChange == 0)
                RightText.Text = "Not Moving";
            else if (e.HorizontalChange > 0)
                RightText.Text = "Moving Right";
            else
                RightText.Text = "Moving Left";
        }
    }
}
