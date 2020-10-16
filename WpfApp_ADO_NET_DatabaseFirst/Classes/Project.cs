using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace WpfApp_ADO_NET_DatabaseFirst
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }

        public ICollection<Employees> Employees { get; set; }
    }
}
