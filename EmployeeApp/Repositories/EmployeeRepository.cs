using EmployeeApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApp.Repositories
{
    public interface IRepository<out T> where T : DomainObject
    {
        T Get(int id);
    }
    public interface   IEmployeeRepository : IRepository<Employee>
    {

    }
    internal class EmployeeRepository : IEmployeeRepository
    {
        public static List<Employee> Employees = new List<Employee>()
        {
            new Employee{Id = 1, Name = "Sravya", Doj=DateTime.Parse("14-02-2023"),Salary=50000},
            new Employee{Id = 2, Name = "viky", Doj=DateTime.Parse("15-02-2023"),Salary=50000},
            new Employee{Id = 3, Name = "pogo", Doj=DateTime.Parse("16-02-2023"),Salary=50000},

            new Employee{Id = 4, Name = "cartoons", Doj=DateTime.Parse("17-02-2023"),Salary=50000},


        };
        public Employee Get(int id)
        {
            return Employees.Find(emp => emp.Id == id);
        }


    }
}
