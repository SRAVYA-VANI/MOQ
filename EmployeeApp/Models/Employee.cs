﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApp.Models
{
    public class DomainObject { }
    public  class Employee: DomainObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Doj { get; set; }
        public int Salary { get; set; }

    }
}
