﻿using System.Collections.Generic;

namespace WpfApp_ADO_NET_SQLDataAdapter
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string FotoPath { get; set; }

        public IEnumerable<Project> Projects { get; set; }
    }
}