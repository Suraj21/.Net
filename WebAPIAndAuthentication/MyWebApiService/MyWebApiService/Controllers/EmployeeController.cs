using MyWebApiService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyWebApiService.Controllers
{
    public class EmployeeController : ApiController
    {
        public IEnumerable<Employee> Get()
        {
            return new List<Employee>
           {
               new Employee() { code = "emp100", name = "Employee", gender = "Male", annualSalary = 650000, DOB = "05/09/1991" },
               new Employee() { code = "emp101", name = "Employee2", gender = "Male", annualSalary = 650000, DOB = "05/09/1992" },
               new Employee() { code = "emp102", name = "Employee3", gender = "Female", annualSalary = 650000, DOB = "05/09/1993" },
               new Employee() { code = "emp103", name = "Employee4", gender = "Female", annualSalary = 650000, DOB = "05/09/1994" },
               new Employee() { code = "emp104", name = "Employee5", gender = "Male", annualSalary = 650000, DOB = "05/09/1995" },
               new Employee() { code = "emp105", name = "Employee6", gender = "Female", annualSalary = 650000, DOB = "05/09/1996" },
               new Employee() { code = "emp106", name = "Employee7", gender = "Male", annualSalary = 650000, DOB = "05/09/1997" },
           };
        }

        public Employee Get(string code)
        {
            List<Employee> employeeList = new List<Employee>
            {
               new Employee() { code = "emp100", name = "Employee", gender = "Male", annualSalary = 650000, DOB = "05/09/1991" },
               new Employee() { code = "emp101", name = "Employee2", gender = "Male", annualSalary = 650000, DOB = "05/09/1992" },
               new Employee() { code = "emp102", name = "Employee3", gender = "Female", annualSalary = 650000, DOB = "05/09/1993" },
               new Employee() { code = "emp103", name = "Employee4", gender = "Female", annualSalary = 650000, DOB = "05/09/1994" },
               new Employee() { code = "emp104", name = "Employee5", gender = "Male", annualSalary = 650000, DOB = "05/09/1995" },
               new Employee() { code = "emp105", name = "Employee6", gender = "Female", annualSalary = 650000, DOB = "05/09/1996" },
               new Employee() { code = "emp106", name = "Employee7", gender = "Male", annualSalary = 650000, DOB = "05/09/1997" },
            };

            Employee employee = employeeList.Where(e => e.code == code.ToLower()).FirstOrDefault();
            return employee;
        }
    }
}
