using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using HackCompany.Data;

namespace HackCompany.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeUtility utility = new EmployeeUtility();

            // Employee employee = new Employee() { Name = "Gosho Goshev", Id = 55, BirthDate = DateTime.Now.AddYears(-15), Email = "peshev@abv.bg", ManagerId = 2, DepartmentId = 1 };

            // string test = employee.GetType().Name;
            // Console.WriteLine(test);

            //utility.AddToData(employee);

            //Console.WriteLine(employee.Id);

            HackCompanyUtility myUtility = new HackCompanyUtility();

            var list = myUtility.Employees.GetAllEmplyees();
            foreach (var emp in list)
            {
                Console.WriteLine(emp.Name);
            }
            Console.WriteLine();

            var employee = myUtility.Employees.GetEmployeeById(3);
            Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5}",employee.Id,employee.Name,employee.Email,employee.BirthDate.ToShortDateString(),employee.ManagerId,employee.DepartmentId);
        }
    }
}
