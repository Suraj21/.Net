using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfAppMVVM.ViewModel
{
    class MultibindingAndConverterViewModel : INotifyPropertyChanged
    {
        public MultibindingAndConverterViewModel()
        {
            FirstName = "Sachidanand";
            MiddleName = "Suraj";
            LastName = "Pandit";
            MyCommand = new RelayCommand(execute, canexecute);
        }

        public ICommand MyCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;


        private void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        private decimal amount;

        public decimal Amount
        {
            get { return amount; }
            set
            {
                amount = value;
                OnPropertyChanged("Amount");
            }
        }
        private decimal discount;

        public decimal Discount
        {
            get { return discount; }
            set
            {
                discount = value;
                OnPropertyChanged("Discount");
            }
        }

        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; OnPropertyChanged("FirstName"); }
        }

        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; OnPropertyChanged("LastName"); }
        }

        private string _middleName;

        public string MiddleName
        {
            get { return _middleName; }
            set { _middleName = value; OnPropertyChanged("MiddleName"); }
        }


        private int _number1;
        public int Number1
        {
            get { return _number1; }
            set { _number1 = value; OnPropertyChanged("Number1"); }
        }


        private int _number2;
        public int Number2
        {
            get { return _number2; }
            set { _number2 = value; OnPropertyChanged("Number2"); }
        }


        private int nubersum;

        public int NumberSum
        {
            get { return nubersum; }
            set { nubersum = value; OnPropertyChanged("NumberSum"); }
        }


        private bool canexecute(object parameter)
        {
            return true;
        }

        private void execute(object parameter)
        {
            var values = (object[])parameter;
            int num1 = Convert.ToInt32((string)values[0]);
            int num2 = Convert.ToInt32((string)values[1]);
            NumberSum = num1 + num2;
        }
    }
}
