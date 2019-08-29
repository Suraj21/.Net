using System;

namespace TaskManagementApp.Model
{
    class Tasks
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string StartDate { get; set; }
        public string DueDate { get; set; }
        public string DateAdded { get; set; }
    }
}
