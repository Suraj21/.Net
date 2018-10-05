using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using WpfAppMVVM.Helper;
using WpfAppMVVM.Model;

namespace WpfAppMVVM.ViewModel
{
    public class UserViewModel: INPCBase
    {
        //private ObservableCollection<User> Users;
        private List<int> hours = new List<int> { 12};
        public List<int> Hours
        {
            get { return hours; }
            set { SetProp(ref hours, value); hours = value; }
        }
        User user = new User();
        private SolidColorBrush myColor;

        public SolidColorBrush MyColor
        {
            get { return MyColor1; }
            set { MyColor1 = value; }
        }

        private string tempColor = "#009999";

        public string TempColor 
        {
            get { return tempColor; }
            set { tempColor = value; }
        }



        public UserViewModel()
        {
            hours.AddRange(Enumerable.Range(1, 11));
            //MyColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffaacc"));
            Users = new ObservableCollection<User>
            {
                new User{UserId = 1,FirstName="Raj",LastName="Beniwal",City="Delhi",State="DEL",Country="INDIA"},
                new User{UserId=2,FirstName="Mark",LastName="henry",City="New York", State="NY", Country="USA"},
                new User{UserId=3,FirstName="Mahesh",LastName="Chand",City="Philadelphia", State="PHL", Country="USA"},
                new User{UserId=4,FirstName="Vikash",LastName="Nanda",City="Noida", State="UP", Country="INDIA"},
                new User{UserId=5,FirstName="Harsh",LastName="Kumar",City="Ghaziabad", State="UP", Country="INDIA"},
                new User{UserId=6,FirstName="Reetesh",LastName="Tomar",City="Mumbai", State="MP", Country="INDIA"},
                new User{UserId=7,FirstName="Deven",LastName="Verma",City="Palwal", State="HP", Country="INDIA"},
                new User{UserId=8,FirstName="Ravi",LastName="Taneja",City="Delhi", State="DEL", Country="INDIA"}
            };
        }

        public void LoadData()
        {
            Users = new ObservableCollection<User>
            {
                new User{UserId = 1,FirstName="Raj",LastName="Beniwal",City="Delhi",State="DEL",Country="INDIA"},
                new User{UserId=2,FirstName="Mark",LastName="henry",City="New York", State="NY", Country="USA"},
                new User{UserId=3,FirstName="Mahesh",LastName="Chand",City="Philadelphia", State="PHL", Country="USA"},
                new User{UserId=4,FirstName="Vikash",LastName="Nanda",City="Noida", State="UP", Country="INDIA"},
                new User{UserId=5,FirstName="Harsh",LastName="Kumar",City="Ghaziabad", State="UP", Country="INDIA"},
                new User{UserId=6,FirstName="Reetesh",LastName="Tomar",City="Mumbai", State="MP", Country="INDIA"},
                new User{UserId=7,FirstName="Deven",LastName="Verma",City="Palwal", State="HP", Country="INDIA"},
                new User{UserId=8,FirstName="Ravi",LastName="Taneja",City="Delhi", State="DEL", Country="INDIA"}
            };
        }

        public bool IsValid()
        {
            return true;
        }

        private ObservableCollection<User> _UsersList;
        public ObservableCollection<User> Users
        {
            get { return _UsersList; }
            set { _UsersList = value; }
        }

        private ICommand _getDataCommand;
        public ICommand GetDataCommand
        {
            get
            {
                return _getDataCommand ?? (_getDataCommand = new RelayCommand(() => LoadData(), IsValid));
            }
        }

        private ICommand _updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                return _updateCommand ?? (_updateCommand = new RelayCommand(() => LoadData(), IsValid));
            }
        }

        public SolidColorBrush MyColor1 { get => myColor; set => myColor = value; }
        
    }
}
