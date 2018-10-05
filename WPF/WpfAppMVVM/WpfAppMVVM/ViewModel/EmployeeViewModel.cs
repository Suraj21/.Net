using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppMVVM.Helper;
using WpfAppMVVM.Model;
using WpfAppDAL.DataAccessLayer;
using System.Data;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace WpfAppMVVM.ViewModel
{
    public class EmployeeViewModel:INPCBase
    {
        public ObservableCollection<EmployeeModel> EmployeeData { get; set; }
        public ObservableCollection<City> cities { get; set; }
        public object param = 1;
        DataAccessLayer DALayer;
        public RelayCommand GetEmployee { get; set; }
        public RelayCommand GetCityData { get; set; }

        //public ICommand GetCityCommnad
        //{
        //    get
        //    {
        //        return _getCityCommnad ?? (_getCityCommnad = new RelayCommand(param => GetCity(param),param => CanGetCityData(param)));
        //    }
        //}

        private Dictionary<string, object> _items;
        private Dictionary<string, object> _selectedItems;

        public Dictionary<string, object> Items
        {
            get
            {
                return _items;
            }
            set
            {
                SetProp(ref _items, value);
                _items = value;
            }
        }

        public Dictionary<string, object> SelectedItems
        {
            get
            {
                return _selectedItems;
            }
            set
            {
                SetProp(ref _selectedItems, value);
                _selectedItems = value;
            }
        }


        public EmployeeViewModel()
        {
            EmployeeData = new ObservableCollection<EmployeeModel>();
            cities = new ObservableCollection<City>();
            DALayer = new DataAccessLayer();
            GetEmployee = new RelayCommand(GetData, CanGetData);
            GetCityData = new RelayCommand(GetCity, CanGetData);
            Initialize();
        }

        public void Initialize()
        {
            Items = new Dictionary<string, object>();
            Items.Add("Ranchi", "RNC");
            Items.Add("Patna", "pat");
            Items.Add("Nagpur", "ngp");
            Items.Add("Pune", "pun");

            SelectedItems = new Dictionary<string, object>();
            SelectedItems.Add("Ranchi", "RNC");
        }

        public void GetData()
        {
            DataTable data = DALayer.GetEmployeeData();
            EmployeeModel employeeModel;
            foreach (DataRow row in data.Rows)
            {
                employeeModel  = new EmployeeModel();
                employeeModel.EmployeeId = Convert.ToInt32(row["EmployeeId"].ToString());
                employeeModel.FirstName = row["FirstName"].ToString();
                employeeModel.LastName = row["LastName"].ToString();
                employeeModel.Address = row["Address"].ToString();
                employeeModel.IsPermanentEmployee = Convert.ToChar(row["IsPermanentEmployee"]);
                EmployeeData.Add(employeeModel);
            }

        }

        public void GetCity()
        {
            int no = 1;
            DataTable data = DALayer.GetCity(Convert.ToInt32(no));
            City city;
            foreach (DataRow row in data.Rows)
            {
                city = new City();
                city.Id = Convert.ToInt32(row["Id"].ToString());
                city.Name = row["Name"].ToString();
                cities.Add(city);
            }
        }

        public bool CanGetData()
        {
            return true;
        }

        public bool CanGetCityData(object param)
        {
            return true;
        }
    }
}
