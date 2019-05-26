using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfAppMVVM.Enums;
using WpfAppMVVM.Helper;

namespace WpfAppMVVM.ViewModel
{
    public class BitRateViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<BitRate> bitRates = new ObservableCollection<BitRate>();
        private BitRate bitRate = BitRate.Sixteen;
        //public ObservableCollection<string> ComboBoxItemsource { get; set; }
        //public ObservableCollection<string> ComboBoxItemsource = null;
        private ObservableCollection<string> comboBoxItemsource;

        public ObservableCollection<string> ComboBoxItemsource
        {
            get { return comboBoxItemsource; }
            set
            {
                if (comboBoxItemsource != value)
                {
                    comboBoxItemsource = value; RaisePropertyChanged("ComboBoxItemsource");
                }
            }
        }


        public RelayCommand clickCommand { get; set; }

        public BitRateViewModel()
        {
            bitRates.FillWithMembers();
            clickCommand = new RelayCommand(GetData, CanGetData);

            ComboBoxItemsource = new ObservableCollection<string>();
            ComboBoxItemsource.Add("Item1");
            ComboBoxItemsource.Add("Item2");
            ComboBoxItemsource.Add("Item3");
            ComboBoxItemsource.Add("Item4");
        }


        public void GetData()
        {
            ComboBoxItemsource = null;
            ComboBoxItemsource = new ObservableCollection<string>();
            ComboBoxItemsource.Add("Item5");
            ComboBoxItemsource.Add("Item6");
            ComboBoxItemsource.Add("Item7");
            ComboBoxItemsource.Add("Item8");
        }

        public bool CanGetData()
        {
            return true;
        }

        public ObservableCollection<BitRate> BitRates
        {
            get { return bitRates; }
            set { if (bitRates != value) bitRates = value;
                RaisePropertyChanged("BitRates");
            }
        }

        public BitRate BitRate
        {
            get { return bitRate; }
            set
            {
                if (bitRate != value)
                {
                    bitRate = value;
                    RaisePropertyChanged("BitRate");
                }
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }
    }
}
