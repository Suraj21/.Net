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
    public class CustomControlLib : Control
    {
        static CustomControlLib()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomControlLib), new FrameworkPropertyMetadata(typeof(CustomControlLib)));
        }


        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var button = GetTemplateChild("PART_Button") as Button;
            if (button != null)
            {
                button.Click += Button_Click;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
            RaiseClickEvent();
        }

        //public static readonly RoutedEvent ClickEvent = EventManager.RegisterRoutedEvent("Click", RoutingStrategy.Bubble,
        //    typeof(RoutedEventHandler), typeof(CustomControlLib));

        //public event RoutedEventHandler Click
        //{
        //    add { AddHandler(ClickEvent, value); }
        //    remove { RemoveHandler(ClickEvent, value); }
        //}

        //protected virtual void RaiseClickEvent()
        //{
        //    RoutedEventArgs args = new RoutedEventArgs(CustomControlLib.ClickEvent);
        //    RaiseEvent(args);
        //}

        public static readonly RoutedEvent ClickEvent = EventManager.RegisterRoutedEvent("Click", RoutingStrategy.Bubble,
           typeof(MyRoutedEventHandler), typeof(CustomControlLib));

        public event MyRoutedEventHandler Click
        {
            add { AddHandler(ClickEvent, value); }
            remove { RemoveHandler(ClickEvent, value); }
        }

        protected virtual void RaiseClickEvent()
        {
            MyRoutedEventArgs args = new MyRoutedEventArgs(CustomControlLib.ClickEvent, "Test");
            RaiseEvent(args);
        }
    }

    public delegate void MyRoutedEventHandler(object sender, MyRoutedEventArgs e);

    public class MyRoutedEventArgs:RoutedEventArgs
    {
        public string Param { get; set; }
        public MyRoutedEventArgs(RoutedEvent routedEvent, string param):base(routedEvent)
        {
            Param = param;
        }
    }
}
