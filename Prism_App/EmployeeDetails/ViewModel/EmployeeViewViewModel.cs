using EventAggregator.Core;
using Model;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
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
        private readonly IRegionManager _regionManager;
        public DelegateCommand<string> EmpProjectDetailsCommand { get; private set; }
        public DelegateCommand<string> CompanyDetailsCommand { get; private set; }

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

        public EmployeeViewViewModel(IEventAggregator eventAggregator, IRegionManager regionManager)
        {
            this.eventAggregator = eventAggregator;
            this.eventAggregator.GetEvent<EmployeeData>().Subscribe(EmployeeData);
            //Subscription of an event can be controlled with the below format of subscieb method
            this.eventAggregator.GetEvent<EmployeeData>().Subscribe(EmployeeDataWithFilteringEvents, ThreadOption.PublisherThread, false, (filter) => filter.YearsOfExp > 3);
            _regionManager = regionManager;

            EmpProjectDetailsCommand = new DelegateCommand<string>(NavigateToEmployeeProjectView);
            CompanyDetailsCommand = new DelegateCommand<string>(NavigateToCompanyDetailsView);


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

        /// <summary>
        /// Navigation to region Implementation
        /// </summary>
        /// <param name="navigatePath"></param>
        private void NavigateToEmployeeProjectView(string navigatePath)
        {
            if (navigatePath != null)
            {
                //_regionManager.RequestNavigate("EmployeeProjectRegion", navigatePath); 
                _regionManager.RequestNavigate("DetailsRegion", navigatePath);
            }
        }

        /// <summary>
        ///  Navigation to region Implementation
        /// </summary>
        /// <param name="navigatePath"></param>
        private void NavigateToCompanyDetailsView(string navigatePath)
        {
            if (navigatePath != null)
            {
                //_regionManager.RequestNavigate("CompanyDetailsRegion", navigatePath);
                //_regionManager.RequestNavigate("DetailsRegion", navigatePath); //OR below implementation with Navigation Complete Implementation
                _regionManager.RequestNavigate("DetailsRegion", navigatePath, NavigationComplete); //Navigation Call Back Implementation

            }
        }

        /// <summary>
        /// //Navigation Call Back Implementation
        /// </summary>
        /// <param name="result"></param>
        private void NavigationComplete(NavigationResult result)
        {
            System.Windows.MessageBox.Show(string.Format("Navigation to {0} complete. ", result.Context.Uri));
        }

    }
}
