using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using TaskManagementApp.Model;
using TaskManagementApp.Reposistory;

namespace TaskManagementApp.ViewModel
{
    class CurrentTasksViewModel: ViewModelBase
    {
        private ObservableCollection<Tasks> tasks;

        public ObservableCollection<Tasks> TasksList
        {
            get { return tasks; }
            set
            {
                tasks = value;
                NotifyPropertyChanged("TasksList");
            }
        }
        public List<string> StatusList { get; set; }

        public string StartDate { get; set; }
        public string DueDate { get; set; }
        public string DateAdded { get; set; }

        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public string Status { get; set; }
        public string StartDateToAdd { get; set; }
        public string DueDateToAdd { get; set; }
        public string DateAddedToAdd { get; set; }

        public RelayCommand GetTaskDetailsCommand { get; set; }
        public RelayCommand AddTaskCommand { get; set; }

        public CurrentTasksViewModel()
        {
            GetTaskDetailsCommand = new RelayCommand(GetTasks, CanExecute);
            AddTaskCommand = new RelayCommand(AddTasks, CanExecute);
            SetData();
        }

        public void AddTasks(object parameter)
        {
            try
            {
                if (!string.IsNullOrEmpty(TaskName) && !string.IsNullOrEmpty(Status) && !string.IsNullOrEmpty(StartDate) && !string.IsNullOrEmpty(DueDate))
                {
                    Tasks tasks = new Tasks
                    {
                        TaskName = TaskName,
                        Description = TaskDescription,
                        Status = Status,
                        StartDate = StartDateToAdd,
                        DueDate = DueDateToAdd,
                        DateAdded = DateTime.Now.ToShortDateString()
                    };
                    int id = TasksList.Count + 1;
                    string insertSqlText = "Insert into Task([Id], [TaskName],[Description],[Status],[StartDate],[DueDate],[DateAdded]) Values('" +
                        id + "','" + TaskName + "','" + TaskDescription + "','" + Status + "','" + StartDateToAdd + "','"
                        + DueDateToAdd + "','" + DateTime.Now.ToShortDateString() + "')";

                    TaskRepository.Execute_SQL(insertSqlText);
                    LoadData();
                    SetDataToDefaultValues();
                }
                MessageBox.Show("Please Fill all the required fields");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetDataToDefaultValues()
        {
            DueDateToAdd = StartDateToAdd = Status = TaskDescription = TaskName = string.Empty;
        }

        public void GetTasks(object parameter)
        {
            LoadData();
        }                                   

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void SetData()
        {
            SetStatus();
            SetFilterDate();
            LoadData();
        }

        private void LoadData()
        {
            TasksList = new ObservableCollection<Tasks>();
            string sql = "Select * from Task";
            DataTable dataTable = TaskRepository.Get_DataTable(sql);
            foreach (DataRow row in dataTable.Rows)
            {
                Tasks task = new Tasks()
                {
                    Id = Convert.ToInt32(row["Id"]),
                    TaskName = row["TaskName"].ToString(),
                    Description = row["Description"].ToString(),
                    Status = row["Status"].ToString(),
                    StartDate = Convert.ToDateTime(row["StartDate"]).ToShortDateString(),
                    DueDate = Convert.ToDateTime(row["DueDate"]).ToShortDateString(),
                    DateAdded = Convert.ToDateTime(row["DateAdded"]).ToShortDateString()
                };
                TasksList.Add(task);
            }
        }

        private void SetFilterDate()
        {
            StartDate = DateTime.Now.ToShortDateString();
            DueDate = DateTime.Now.ToShortDateString();
            DateAdded = DateTime.Now.ToShortDateString();
        }

        private void SetStatus()
        {
            StatusList = new List<string>
            {
                "In Progress",
                "Complete",
                "Deferred",
                "To be Started"
            };
        }
    }
}
