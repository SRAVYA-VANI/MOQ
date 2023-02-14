using EmployeeApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApp.Services
{
    public interface IEmployeeService
    {
        double CalculateTax(int empid, DateTime to);
    }
    public interface ITaxService
    {
        double GetTaxRate();
    }
    public class TaxService : ITaxService
    {
        const double _taxRate = 0.25;
        public double GetTaxRate()
        {
            return _taxRate;
        }
    }
    public class EmployeeService : IEmployeeService
    {
        private ITaxService _taxService;
        private IEmployeeRepository _repository;

        public EmployeeService(ITaxService taxService, IEmployeeRepository repository)
        {
            _taxService = taxService;
            _repository = repository;
        }
        public double CalculateTax(int empid, DateTime to)
        {
            var employee = _repository.Get(empid);
            var totalMonth = ((to - employee.Doj).TotalDays + 1) / 30;
            var totalSalary = totalMonth * employee.Salary;
            return totalSalary * _taxService.GetTaxRate();
        }
    }
   
}
