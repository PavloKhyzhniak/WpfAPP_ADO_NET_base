using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp_ADO_NET_SQLDataAdapter
{
    public partial class Window_Change : Window
    {
        public Employee Employee { get; set; }

        public Window_Change(Employee employee)
           : this()
        {
            this.Width = 400;
            this.Height = 440;

            Employee = new Employee
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Age = employee.Age,
                Address = employee.Address,
                FotoPath = employee.FotoPath
            };
            ValidateID += e => (e as Employee).Id = -1;

            this.DataContext = Employee;

            this.mainGrid.Style = (Style)FindResource("styleChange_Employee");

            CurrentObject = Employee;
        }
    }
}
