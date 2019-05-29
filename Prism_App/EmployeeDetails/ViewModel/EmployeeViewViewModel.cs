using EventAggregator.Core;
using Model;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDetails.ViewModel
{
    public class EmployeeViewViewModel : BindableBase
    {

        private string _title = "Employee View";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public Employee Employee { get; set; }

        private ObservableCollection<Employee> employees;

        public ObservableCollection<Employee> Employees
        {
            get { return employees; }
            set { SetProperty(ref employees, value); }
        }


        IEventAggregator eventAggregator;

        public EmployeeViewViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            this.eventAggregator.GetEvent<EmployeeData>().Subscribe(EmployeeData);
            //Subscription of an event can be controlled with the below format of subscieb method
            this.eventAggregator.GetEvent<EmployeeData>().Subscribe(EmployeeDataWithFilteringEvents, ThreadOption.PublisherThread, false, (filter) => filter.YearsOfExp > 3);
            Employees = new ObservableCollection<Employee>
            {
                new Employee{ Name = "Suraj1", Company="Siemens",  Description=".Net Dev", Email="suraj.thepions@gmail.com",
                              EmployementType="Permanent", Technology=".Net", YearsOfExp= 5}
            };
        }

        private void EmployeeData(Employee employee)
        {
            Employees.Add(employee);
        }

        private void EmployeeDataWithFilteringEvents(Employee employee)
        {
            Employees.Add(employee);
        }

    }
}
