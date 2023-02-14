using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NUnit.Framework;
using EmployeeApp.Services;
using EmployeeApp.Repositories;


namespace EmployeeApp.TestProject
{
    [TestFixture]
    internal class EmployeeServiceTest
    {
        private IEmployeeService _service;
        private Mock<IEmployeeRepository> _mockrepository;
        private Mock<ITaxService> _mocktaxService;

        public void setup()
        {
            _mockrepository = new Mock<IEmployeeRepository>(MockBehavior.Strict);
            _mocktaxService = new Mock<ITaxService>(MockBehavior.Strict);
            _service = new EmployeeService(_mocktaxService.Object,_mockrepository.Object);
        }
        [Test]
        public void CalculateTax()
        {
            _mockrepository.Setup(r => r.Get(It.IsAny<int>())).Returns(new Models.Employee
            {
                Id = 1,
                Name = "sravya",
                Doj = DateTime.Parse("14-02-2023"),
                Salary = 50000
            });
            _mocktaxService.Setup(t =>t. GetTaxRate()).Returns(0.25);
            var actualResult = _service.CalculateTax(1, DateTime.Parse("14-02-2023"));
           // Assert.AreEqual(416.666,actualResult);
        }
    }
}
