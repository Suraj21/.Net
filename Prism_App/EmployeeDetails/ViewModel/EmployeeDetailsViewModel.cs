using Prism.Mvvm;

namespace EmployeeDetails.ViewModel
{
    public class EmployeeDetailsViewModel :BindableBase
    {
        private string _title = "Employee Details ViewModel";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public EmployeeDetailsViewModel()
        {
            Title = "Employee Details ViewModel";
        }
    }
}
