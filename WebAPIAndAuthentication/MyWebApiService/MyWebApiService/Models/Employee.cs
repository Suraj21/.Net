using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebApiService.Models
{
    public class Employee
    {
        public string code { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public int annualSalary { get; set; }
        public string DOB { get; set; }
    }
}