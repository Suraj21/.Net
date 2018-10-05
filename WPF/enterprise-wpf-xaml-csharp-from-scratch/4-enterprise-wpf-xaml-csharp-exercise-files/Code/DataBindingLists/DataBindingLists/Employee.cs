using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataBindingLists
{
   class Employee : INotifyPropertyChanged
   {
        private bool _isSelected;

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                RaisePropertyChanged();
            }
        }

        private string _name;
      public string Name
      {
         get { return _name; }
         set
         {
            _name = value;
            RaisePropertyChanged();
         }
      }

      private string _title;
      public string Title
      {
         get { return _title; }
         set
         {
            _title = value;
            RaisePropertyChanged();
         }
      }

      public event PropertyChangedEventHandler PropertyChanged;
      private void RaisePropertyChanged(
          [CallerMemberName] string caller = "" )
      {
         if ( PropertyChanged != null )
         {
            PropertyChanged( this, new PropertyChangedEventArgs( caller ) );
         }
      }


      public static ObservableCollection<Employee> GetEmployees()
      {
         var employees = new ObservableCollection<Employee>();
         employees.Add( new Employee() {IsSelected = false,  Name = "Washington", Title = "President 1" } );
         employees.Add( new Employee() {IsSelected = false, Name = "Adams", Title = "President 2" } );
         employees.Add( new Employee() {IsSelected = false, Name = "Jefferson", Title = "President 3" } );
         employees.Add( new Employee() {IsSelected = false, Name = "Madison", Title = "President 4" } );
         employees.Add( new Employee() {IsSelected = false, Name = "Monroe", Title = "President 5" } );
         return employees;
      }

   }
}
