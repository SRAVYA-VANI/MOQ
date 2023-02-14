using EmployeeApp.Repositories;
using EmployeeApp.Services;
using System;

namespace EmployeeApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEmployeeRepository repository = new EmployeeRepository();
           ITaxService taxService = new TaxService();
            IEmployeeService employeeService = new EmployeeService(taxService,repository);
            Console.WriteLine("enter the empid to calculate tax");
            int empid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(employeeService.CalculateTax(empid, DateTime.Parse(Console.ReadLine())));

        }
    }
}
