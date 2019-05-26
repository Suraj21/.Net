using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfAppMVVM.Helper;

namespace WpfAppMVVM.ViewModel
{
    public class ReusableComponentViewModel: INPCBase
    {
        public ReusableComponentViewModel()
        {
            _name = "Suraj";
            _address = "B-403 Saarthi Signor Society.";
            _shoeSize = 12;
            Height = 34.5;
            JobDone = true;
        }

        //private void PressMeCommand_CanExecuteChanged(object sender, EventArgs e)
        //{
        //    //MessageBox.Show("PressMeCommand_CanExecuteChanged");
        //}

        //public void PressMe_Executed(object sender, EventArgs eventArgs)
        //{
        //    MessageBox.Show("PressMe_Executed");
        //}

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; SetProp(ref _name, value); }
        }

        private string _address;

        public string Address
        {
            get { return _address; }
            set { _address = value; SetProp(ref _address, value); }
        }

        private int _shoeSize;

        public int ShoeSize
        {
            get { return _shoeSize; }
            set { _shoeSize = value; SetProp(ref _shoeSize, value); }
        }

        private double _height;

        public double Height
        {
            get { return _height; }
            set { _height = value; SetProp(ref _height, value); }
        }

        private bool _jobDone;

        public bool JobDone
        {
            get { return _jobDone; }
            set { _jobDone = value; SetProp(ref _jobDone, value); }
        }


        public static RoutedUICommand _pressMeCommand = new RoutedUICommand("Press Me", "PressMe", typeof(ReusableComponentViewModel));
        public static RoutedUICommand PressMeCommand
        {
            get { return _pressMeCommand; }
        }

        public void PressMe_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        public void PressMe_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Howdy howdy I'm a cowboy");
        }
    }
}
