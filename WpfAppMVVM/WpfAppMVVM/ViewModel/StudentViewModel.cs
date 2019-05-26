using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfAppMVVM.Model;

namespace WpfAppMVVM.ViewModel
{
    public class StudentViewModel
    {
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand GetStudents { get; set; }
        public ObservableCollection<Student> Students { get; set; }

        public StudentViewModel()
        {
            Initializer();
        }

        public void Initializer()
        {
            DeleteCommand = new RelayCommand(OnDelete, CanDelete);
            GetStudents = new RelayCommand(LoadStudents, IsValid);
            Students = new ObservableCollection<Student>();
        }

        public void LoadStudents()
        {
            Students.Add(new Student() { FirstName = "Suraj", LastName = "Sachidanand" });
            Students.Add(new Student() { FirstName = "Ram", LastName = "Manohar" });
            Students.Add(new Student() { FirstName = "Laxman", LastName = "Kumar" });
        }

        public bool IsValid()
        {
            return true;
        }

        private Student _selectedStudent;

        public Student SelectedStudent
        {
            get
            {
                return _selectedStudent;
            }

            set
            {
                _selectedStudent = value;
                DeleteCommand.CanExecuteChanged += DeleteCommand_CanExecuteChanged; ;
            }
        }

        private void DeleteCommand_CanExecuteChanged(object sender, EventArgs e)
        {
            OnDelete();
        }

        private void OnDelete()
        {
            Students.Remove(SelectedStudent);
        }

        private bool CanDelete()
        {
            return SelectedStudent != null;
        }

        //private ICommand _getStudents;

        //public ICommand GetStudents
        //{
        //    get
        //    {
        //        return _getStudents ??( _getStudents = new RelayCommand(() => LoadStudents(),IsValid));
        //    }
        //    //set { _getStudents = value; }
        //}

    }
}
