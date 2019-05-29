using EventAggregator.Core;
using Model;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRegistration.ViewModel
{
    public class EmployeeRegistrationViewModel : BindableBase
    {
        public DelegateCommand SubmitCommand { get; private set; }
        public DelegateCommand<string> NavigateCommand { get; private set; }

        private readonly IRegionManager _regionManager;

        IEventAggregator eventAggregator;

        public Employee Employee { get; set; }

        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }

        private string employementType;
        public string EmployementType
        {
            get { return employementType; }
            set { SetProperty(ref employementType, value); }
        }

        private string company;
        public string Company
        {
            get { return company; }
            set { SetProperty(ref company, value); }
        }

        private int yearsOfExp;
        public int YearsOfExp
        {
            get { return yearsOfExp; }
            set { SetProperty(ref yearsOfExp, value); }
        }

        private string technology;
        public string Technology
        {
            get { return technology; }
            set { SetProperty(ref technology, value); }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }

        public EmployeeRegistrationViewModel(IEventAggregator eventAggregator, IRegionManager regionManager)
        {
            SubmitCommand = new DelegateCommand(ExecuteSubmit, CanExecute);
            NavigateCommand = new DelegateCommand<string>(NavigateToEmployeeDetails, CanExecute);
            this.eventAggregator = eventAggregator;
            _regionManager = regionManager;
        }

        /// <summary>
        /// Navigate To EmployeeDetails
        /// </summary>
        private void NavigateToEmployeeDetails(string navigatePath)
        {
            if (navigatePath != null)
                _regionManager.RequestNavigate("ContentRegion", navigatePath);
        }

        /// <summary>
        /// Publish the Event on click of Submit Button
        /// </summary>
        private void ExecuteSubmit()
        {
            Employee = new Employee
            {
                Name = this.name,
                Email = this.Email,
                Company = this.Company,
                EmployementType = this.EmployementType,
                Description = this.Description,
                Technology = this.Technology,
                YearsOfExp = this.YearsOfExp
            };

            this.eventAggregator.GetEvent<EmployeeData>().Publish(Employee);
        }

        private bool CanExecute()
        {
            return true;
        }

        private bool CanExecute(string navigatePath)
        {
            return true;
        }
    }
}
