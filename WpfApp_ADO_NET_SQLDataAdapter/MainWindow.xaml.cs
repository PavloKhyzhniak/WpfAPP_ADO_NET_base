using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp_ADO_NET_SQLDataAdapter.Classes_SqlDataAdapter;

namespace WpfApp_ADO_NET_SQLDataAdapter
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection connectionManufacturerAirplane;
        SqlConnection connectionProjectsEmployees;

        public MainWindow()
        {
            InitializeComponent();

            connectionManufacturerAirplane
                = SqlDatabase.CreateSqlConnection_ConfigurationManager("WpfApp_ADO_NET_SQLDataAdapter.Properties.Settings.ManufacturerAirplaneConnectionString");
            connectionProjectsEmployees
                = SqlDatabase.CreateSqlConnection_ConfigurationManager("WpfApp_ADO_NET_SQLDataAdapter.Properties.Settings.ProjectsEmployeesConnectionString");
        }

        //    EventHandler<DataGridCellEditEndingEventArgs> eventCellEditEnding;
        //    EventHandler<DataGridAutoGeneratingColumnEventArgs> eventAutoGeneratingColumn;
        public void RefreshManufacturer()
        {
//            List<Manufacturer> result = new List<Manufacturer>();
//            SqlDatabase.Select(connectionManufacturerAirplane, ref result);
//
//            ObservableCollection<Manufacturer> observableCollection = new ObservableCollection<Manufacturer>(result);
//
//            CollectionViewSource collection = new CollectionViewSource() { Source = observableCollection };
//            collection.GroupDescriptions.Add(new PropertyGroupDescription("Address"));
//            //collection.GroupDescriptions.Add(new PropertyGroupDescription("City"));
//            //collection.SortDescriptions.Add(new SortDescription("City", ListSortDirection.Ascending));
//            //collection.Filter += Collection_Filter;
//
//            dataGrid_Main.Style = (Style)FindResource("dataGridManufacturer");
//
//            dataGrid_Main.ItemsSource = collection.View;
        }

        public void RefreshAirplane()
        {
//            List<Airplane> result = new List<Airplane>();
//            SqlDatabase.Select(connectionManufacturerAirplane, ref result);
//
//            ObservableCollection<Airplane> observableCollection = new ObservableCollection<Airplane>(result);
//
//            CollectionViewSource collection = new CollectionViewSource() { Source = observableCollection };
//            collection.GroupDescriptions.Add(new PropertyGroupDescription("Vendor"));
//            //collection.GroupDescriptions.Add(new PropertyGroupDescription("City"));
//            //collection.SortDescriptions.Add(new SortDescription("City", ListSortDirection.Ascending));
//            //collection.Filter += Collection_Filter;
//
//            dataGrid_Main.Style = (Style)FindResource("dataGridAirplane");
//
//            dataGrid_Main.ItemsSource = collection.View;
        }

        private void ShowManufacturer_Click(object sender, RoutedEventArgs e)
        {
            RefreshManufacturer();
        }

        private void AddManufacturer_Click(object sender, RoutedEventArgs e)
        {
//            Manufacturer manufacturer = new Manufacturer
//            {
//                BrandTitle = "Fokker",
//                Phone = "(099) 322-45-33",
//                Address = "Голландия"
//            };
//
//            SqlDatabase.Insert(connectionManufacturerAirplane, manufacturer);
//
//            RefreshManufacturer();
        }

        private void DeleteManufacturer_Click(object sender, RoutedEventArgs e)
        {
//            if (dataGrid_Main.SelectedItem != null)
//            {
//                // Получить выделенного автора
//                Manufacturer selectedManufacturerRow = dataGrid_Main.SelectedItem as Manufacturer;
//
//                // Получить ID выделенного автора
//                int selectedId = selectedManufacturerRow.VendorId;
//
//                Manufacturer manufacturer = new Manufacturer
//                {
//                    VendorId = selectedId
//                };
//
//                SqlDatabase.Delete(connectionManufacturerAirplane, manufacturer);
//
//                // Обновить таблицу
//                RefreshManufacturer();
//            }
        }

        private void ShowAirplane_Click(object sender, RoutedEventArgs e)
        {
            RefreshAirplane();
        }

        private void AddAirplane_Click(object sender, RoutedEventArgs e)
        {
//            Airplane airplane = new Airplane
//            {
//                Model = "Airbus A220-100",
//                Price = 345000000,
//                Speed = 670,
//                VendorId = 2
//            };
//
//            SqlDatabase.Insert(connectionManufacturerAirplane, airplane);
//
//            RefreshAirplane();
        }

        private void DeleteAirplane_Click(object sender, RoutedEventArgs e)
        {
//            if (dataGrid_Main.SelectedItem != null)
//            {
//                // Получить выделенного автора
//                Airplane selectedAirplaneRow = dataGrid_Main.SelectedItem as Airplane;
//
//                // Получить ID выделенного автора
//                int selectedId = selectedAirplaneRow.Id;
//
//                Airplane airplane = new Airplane
//                {
//                    Id = selectedId
//                };
//
//                SqlDatabase.Delete(connectionManufacturerAirplane, airplane);
//
//                // Обновить таблицу
//                RefreshAirplane();
//            }
        }

        /*

select * from Airplanes
select * from Manufacturers

select a.Id,a.Model,a.Price,a.Speed,m.BrandTitle from Airplanes a, Manufacturers m
where a.Speed<600 and a.VendorId=m.VendorId

     */
        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
"\tShow Airplane with Speed<600" +
"\n\nselect a.Id,a.Model,a.Price,a.Speed,m.BrandTitle from Airplanes a, Manufacturers m" +
"\nwhere a.Speed < 600 and a.VendorId = m.VendorId"
                , "SQL Query");

//            var result = SqlDatabase.Select_AiplaneWithSpeedLess(connectionManufacturerAirplane, 600);
//
//            Window DataGridPresent = new Window_DataGrid(result);
//
//            DataGridPresent.Show();
        }

        /*

select * from Airplanes
select * from Manufacturers

select DISTINCT m.BrandTitle from Airplanes a, Manufacturers m
where a.VendorId=m.VendorId and (select COUNT(a.Id) cnt from Airplanes a where a.VendorId=m.VendorId group by a.VendorId)>3

         */
        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
"\tShow Manufacture BrandTitle with Count(Airplane)>3" +
"\n\nselect DISTINCT m.BrandTitle from Airplanes a, Manufacturers m" +
"\nwhere a.VendorId = m.VendorId and(select COUNT(a.Id) cnt from Airplanes a where a.VendorId = m.VendorId group by a.VendorId) > 3"
             , "SQL Query");

//            var result = SqlDatabase.Select_ManufacturerWithAiplaneCountMore(connectionManufacturerAirplane, 3);
//
//            Window DataGridPresent = new Window_DataGrid(result.ToList());
//
//            DataGridPresent.Show();
        }

        /*

select * from Airplanes
select * from Manufacturers

select m.BrandTitle from Manufacturers m
where Len(m.BrandTitle)<7
        */
        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
"\tShow Manufacture BrandTitle with Len(BrandTitle)<7" +
"\n\nselect m.BrandTitle from Manufacturers m" +
"\nwhere Len(m.BrandTitle) < 7"
           , "SQL Query");

//            var result = SqlDatabase.Select_ManufacturerWithLengthBrandTitleLess(connectionManufacturerAirplane, 7);
//
//            Window DataGridPresent = new Window_DataGrid(result.ToList());
//
//            DataGridPresent.Show();
        }


        /*

create function GetAirplaineWithSpeedLess(@st int)
returns table
as
return 
select a.Id,a.Model,a.Price,a.Speed,m.BrandTitle from Airplanes a, Manufacturers m
where a.Speed<@st and a.VendorId=m.VendorId
GO

    */
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
//            // Параметризированный запрос, состоящий из LINQ и SQL, вызывающий хранимую функцию
//            var result = SqlDatabase.SP_GetAirplaineWithSpeedLess(connectionManufacturerAirplane, 600);
//
//            Window DataGridPresent = new Window_DataGrid(result.ToList());
//
//            DataGridPresent.Show();
        }


        /*
        
create function GetManufacturerWithAirplaneMore(@st int)
returns table
as
return 
select DISTINCT m.BrandTitle from Airplanes a, Manufacturers m
where a.VendorId=m.VendorId and (select COUNT(a.Id) cnt from Airplanes a where a.VendorId=m.VendorId group by a.VendorId)>@st
GO
        */
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
//            // Параметризированный запрос, состоящий из LINQ и SQL, вызывающий хранимую функцию
//            var result = SqlDatabase.SP_GetManufacturerWithAirplaneMore(connectionManufacturerAirplane, 3);
//
//            Window DataGridPresent = new Window_DataGrid(result.ToList());
//
//            DataGridPresent.Show();
        }

        /*
          
create function GetManufacturerNameWithLengthLess(@st int)
returns table
as
return 
select m.BrandTitle from Manufacturers m
where Len(m.BrandTitle)<@st
GO
         */
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
//            // Параметризированный запрос, состоящий из LINQ и SQL, вызывающий хранимую функцию
//            var result = SqlDatabase.SP_GetManufacturerNameWithLengthLess(connectionManufacturerAirplane, 7);
//
//            Window DataGridPresent = new Window_DataGrid(result.ToList());
//
//            DataGridPresent.Show();
        }




        public void RefreshProjects()
        {
//            List<Project> result = new List<Project>();
//            SqlDatabase.Select(connectionProjectsEmployees, ref result);
//
//            ObservableCollection<Project> observableCollection = new ObservableCollection<Project>(result);
//
//            CollectionViewSource collection = new CollectionViewSource() { Source = observableCollection };
//            collection.GroupDescriptions.Add(new PropertyGroupDescription("StartDate"));
//            //collection.GroupDescriptions.Add(new PropertyGroupDescription("City"));
//            //collection.SortDescriptions.Add(new SortDescription("City", ListSortDirection.Ascending));
//            //collection.Filter += Collection_Filter;
//
//            dataGrid_Main.Style = (Style)FindResource("dataGridProjects");
//
//            dataGrid_Main.ItemsSource = collection.View;
        }

        public void RefreshEmployees()
        {
//            List<Employee> result = new List<Employee>();
//            SqlDatabase.Select(connectionProjectsEmployees, ref result);
//
//            ObservableCollection<Employee> observableCollection = new ObservableCollection<Employee>(result);
//
//            CollectionViewSource collection = new CollectionViewSource() { Source = observableCollection };
//            collection.GroupDescriptions.Add(new PropertyGroupDescription("Age"));
//            //collection.GroupDescriptions.Add(new PropertyGroupDescription("City"));
//            //collection.SortDescriptions.Add(new SortDescription("City", ListSortDirection.Ascending));
//            //collection.Filter += Collection_Filter;
//
//            dataGrid_Main.Style = (Style)FindResource("dataGridEmployees");
//
//            dataGrid_Main.ItemsSource = collection.View;
        }

        private void ShowProjects_Click(object sender, RoutedEventArgs e)
        {
            RefreshProjects();
        }

        private void AddProjects_Click(object sender, RoutedEventArgs e)
        {
//            Project project = new Project
//            {
//                Title = "Creative System for Gratulation!!!",
//                StartDate = DateTime.Now,
//                EndDate = DateTime.Now,
//                Description = "New Funny Project"
//            };
//
//            SqlDatabase.Insert(connectionProjectsEmployees, project);
//
//            RefreshProjects();
        }

        private void DeleteProjects_Click(object sender, RoutedEventArgs e)
        {
//            if (dataGrid_Main.SelectedItem != null)
//            {
//                // Получить выделенного автора
//                Project selectedProjectRow = dataGrid_Main.SelectedItem as Project;
//
//                // Получить ID выделенного автора
//                int selectedId = selectedProjectRow.Id;
//
//                Project project = new Project
//                {
//                    Id = selectedId
//                };
//
//                SqlDatabase.Delete(connectionProjectsEmployees, project);
//
//                // Обновить таблицу
//                RefreshProjects();
//            }
        }

        private void ShowEmployees_Click(object sender, RoutedEventArgs e)
        {
            RefreshEmployees();
        }

        private void AddEmployees_Click(object sender, RoutedEventArgs e)
        {
//            Employee employee = new Employee
//            {
//                FirstName = "Petr",
//                LastName = "Lionesku",
//                Age = 32,
//                Address = "Большевитская улица, дом 14",
//                FotoPath = "\\resources\\catBlue.jpg"
//            };
//
//            SqlDatabase.Insert(connectionProjectsEmployees, employee);
//
//            RefreshEmployees();
        }

        private void DeleteEmployees_Click(object sender, RoutedEventArgs e)
        {
//            if (dataGrid_Main.SelectedItem != null)
//            {
//                // Получить выделенного автора
//                Employee selectedEmployeeRow = dataGrid_Main.SelectedItem as Employee;
//
//                // Получить ID выделенного автора
//                int selectedId = selectedEmployeeRow.Id;
//
//                Employee employee = new Employee
//                {
//                    Id = selectedId
//                };
//
//                SqlDatabase.Delete(connectionProjectsEmployees, employee);
//
//                // Обновить таблицу
//                RefreshEmployees();
//            }
        }
        /*
         
select * from Projects
select * from Employees
select * from ProjectEmployees

SELECT p.Id,p.Title
FROM Projects p 
WHERE p.Id = (
    SELECT pe.ProjectId
    FROM ProjectEmployees pe GROUP BY pe.ProjectId
    HAVING count(pe.ProjectId)=
		(
    SELECT MAX(g.cnt)
    FROM (SELECT COUNT(ppe.ProjectId) cnt 
	FROM ProjectEmployees ppe 
	GROUP BY ppe.ProjectId) g
	)
	)

         */
        private void MenuItem_Click_13(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
"\tShow Project with Max Employees" +
"\n\nSELECT p.Id,p.Title" +
"\nFROM Projects p" +
"\nWHERE p.Id = (" +
"\n\tSELECT pe.ProjectId" +
"\n\tFROM ProjectEmployees pe GROUP BY pe.ProjectId" +
"\n\tHAVING count(pe.ProjectId) =" +
"\n\t(" +
"\n\tSELECT MAX(g.cnt)" +
"\n\tFROM(SELECT COUNT(ppe.ProjectId) cnt" +
"\n\tFROM ProjectEmployees ppe" +
"\n\tGROUP BY ppe.ProjectId) g" +
"\n\t)" +
"\n\t)"
          , "SQL Query");

//            var result = SqlDatabase.Select_ProjectWithMaxEmployees(connectionProjectsEmployees);
//
//            Window DataGridPresent = new Window_DataGrid(result.ToList());
//
//            DataGridPresent.Show();
        }

        /*
         
select * from Projects
select * from Employees
select * from ProjectEmployees

select e.FirstName,e.LastName from Employees e
where e.Age<35

        */
        private void MenuItem_Click_14(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
"\tShow Employees with Age<35" +
"\n\nselect e.FirstName,e.LastName from Employees e" +
"\nwhere e.Age < 35"
          , "SQL Query");

//            var result = SqlDatabase.Select_EmployeerWithAgeLess(connectionProjectsEmployees, 35);
//
//            Window DataGridPresent = new Window_DataGrid(result.ToList());
//
//            DataGridPresent.Show();
        }

        /*
        
select * from Projects
select * from Employees
select * from ProjectEmployees

select e.FirstName,e.LastName from Employees e
where Len(e.LastName)>=5

         */
        private void MenuItem_Click_15(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
"\tShow Employees with Len(LastName)>=5" +
"\n\nselect e.FirstName,e.LastName from Employees e" +
"\nwhere Len(e.LastName) >= 5"
          , "SQL Query");

//            var result = SqlDatabase.Select_EmployeerWithLastNameLengthMoreOrEqual(connectionProjectsEmployees, 5);
//
//            Window DataGridPresent = new Window_DataGrid(result.ToList());
//
//            DataGridPresent.Show();
        }


        /*
         
create function GetProjectWithMaxEmployees()
returns table
as
return 
SELECT p.Id,p.Title
FROM Projects p 
WHERE p.Id = (
    SELECT pe.ProjectId
    FROM ProjectEmployees pe GROUP BY pe.ProjectId
    HAVING count(pe.ProjectId)=
		(
    SELECT MAX(g.cnt)
    FROM (SELECT COUNT(ppe.ProjectId) cnt 
	FROM ProjectEmployees ppe 
	GROUP BY ppe.ProjectId) g
	)
	)
GO
         */
        private void MenuItem_Click2(object sender, RoutedEventArgs e)
        {
//            // Параметризированный запрос, состоящий из LINQ и SQL, вызывающий хранимую функцию
//            var result = SqlDatabase.SP_GetProjectWithMaxEmployees(connectionProjectsEmployees);
//
//            Window DataGridPresent = new Window_DataGrid(result.ToList());
//
//            DataGridPresent.Show();
        }

        /*

create function GetEmployeerWithAgeLess(@st int)
returns table
as
return 
select e.FirstName,e.LastName from Employees e
where e.Age<@st
GO
*/
        private void MenuItem_Click_11(object sender, RoutedEventArgs e)
        {
//            // Параметризированный запрос, состоящий из LINQ и SQL, вызывающий хранимую функцию
//            var result = SqlDatabase.SP_GetEmployeerWithAgeLess(connectionProjectsEmployees, 35);
//
//            Window DataGridPresent = new Window_DataGrid(result.ToList());
//
//            DataGridPresent.Show();
        }


        /*

        create function GetEmployeerWithLastNameLengthMoreOrEqual(@st int)
        returns table
        as
        return 
        select e.FirstName,e.LastName from Employees e
        where Len(e.LastName)>=@st
        GO
        */
        private void MenuItem_Click_12(object sender, RoutedEventArgs e)
        {
//            // Параметризированный запрос, состоящий из LINQ и SQL, вызывающий хранимую функцию
//            var result = SqlDatabase.SP_GetEmployeerWithLastNameLengthMoreOrEqual(connectionProjectsEmployees, 5);
//
//            Window DataGridPresent = new Window_DataGrid(result.ToList());
//
//            DataGridPresent.Show();
        }
    }
}
