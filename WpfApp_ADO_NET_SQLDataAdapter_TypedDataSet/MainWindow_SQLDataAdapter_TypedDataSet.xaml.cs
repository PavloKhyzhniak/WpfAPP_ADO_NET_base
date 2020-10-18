using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
using WpfApp_ADO_NET_SQLDataAdapter_TypedDataSet.Classes_SqlDataAdapter;
using WpfApp_ADO_NET_SQLDataAdapter_TypedDataSet.DataSet_ManufacturerAirplaneTableAdapters;
using WpfApp_ADO_NET_SQLDataAdapter_TypedDataSet.DataSet_ProjectsEmployeesTableAdapters;

namespace WpfApp_ADO_NET_SQLDataAdapter_TypedDataSet
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection connectionManufacturerAirplane;
        DataSet_ManufacturerAirplane dsTypedManufacturerAirplane = new DataSet_ManufacturerAirplane();
        ManufacturersTableAdapter adapterManufacturer = new ManufacturersTableAdapter();
        AirplanesTableAdapter adapterAirplane = new AirplanesTableAdapter();

        SqlConnection connectionProjectsEmployees;
        DataSet_ProjectsEmployees dsTypedProjectsEmployees = new DataSet_ProjectsEmployees();
        ProjectsTableAdapter adapterProjects = new ProjectsTableAdapter();
        ProjectEmployeesTableAdapter adapterProjectsEmployees = new ProjectEmployeesTableAdapter();
        EmployeesTableAdapter adapterEmployees = new EmployeesTableAdapter();

        public MainWindow()
        {
            InitializeComponent();

            connectionManufacturerAirplane
               = SqlDatabase.CreateSqlConnection_ConfigurationManager("WpfApp_ADO_NET_SQLDataAdapter_TypedDataSet.Properties.Settings.WpfApp_ADO_NET_CodeFirst_Model_ManufacturerAirplaneConnectionString");
            connectionProjectsEmployees
                = SqlDatabase.CreateSqlConnection_ConfigurationManager("WpfApp_ADO_NET_SQLDataAdapter_TypedDataSet.Properties.Settings.WpfApp_ADO_NET_CodeFirst_Model_ProjectsEmployeesConnectionString");
        }   

        public void RefreshManufacturer()
        {
            // очистка локальной таблицы
            dsTypedManufacturerAirplane.Manufacturers.Clear();

            adapterManufacturer.Fill(dsTypedManufacturerAirplane.Manufacturers);

            var result = dsTypedManufacturerAirplane.Manufacturers.AsEnumerable().Select(i => new Manufacturer
            {
                VendorId = (int)(i["VendorId"]),
                BrandTitle = (string)(i["BrandTitle"]),
                Address = (string)(i["Address"]),
                Phone = (string)(i["Phone"])
            }).ToList<Manufacturer>();

            ObservableCollection<Manufacturer> observableCollection = new ObservableCollection<Manufacturer>(result);

            CollectionViewSource collection = new CollectionViewSource() { Source = observableCollection };
            collection.GroupDescriptions.Add(new PropertyGroupDescription("Address"));
            //collection.GroupDescriptions.Add(new PropertyGroupDescription("City"));
            //collection.SortDescriptions.Add(new SortDescription("City", ListSortDirection.Ascending));
            //collection.Filter += Collection_Filter;

            dataGrid_Main.Style = (Style)FindResource("dataGridManufacturer");

            dataGrid_Main.ItemsSource = collection.View;
        }

        public void RefreshAirplane()
        {
            // очистка локальной таблицы
            dsTypedManufacturerAirplane.Airplanes.Clear();

            adapterAirplane.Fill(dsTypedManufacturerAirplane.Airplanes);

            var result = dsTypedManufacturerAirplane.Airplanes.AsEnumerable().Select(i => new Airplane
            {
                Id = (int)(i["Id"]),
                Model = (string)(i["Model"]),
                Price = (double)(i["Price"]),
                Speed = (int)(i["Speed"]),
                VendorId = (int)(i["VendorId"]),
                Vendor = (string)dsTypedManufacturerAirplane.Manufacturers.AsEnumerable().Where(t => t.VendorId == i.VendorId).Select(t => t.BrandTitle).SingleOrDefault()
            }).ToList<Airplane>();

            ObservableCollection<Airplane> observableCollection = new ObservableCollection<Airplane>(result);

            CollectionViewSource collection = new CollectionViewSource() { Source = observableCollection };
            collection.GroupDescriptions.Add(new PropertyGroupDescription("Vendor"));
            //collection.GroupDescriptions.Add(new PropertyGroupDescription("City"));
            //collection.SortDescriptions.Add(new SortDescription("City", ListSortDirection.Ascending));
            //collection.Filter += Collection_Filter;

            dataGrid_Main.Style = (Style)FindResource("dataGridAirplane");

            dataGrid_Main.ItemsSource = collection.View;
        }

        private void ShowManufacturer_Click(object sender, RoutedEventArgs e)
        {
            RefreshManufacturer();
        }

        private void AddManufacturer_Click(object sender, RoutedEventArgs e)
        {
            Manufacturer manufacturer = new Manufacturer
            {
                BrandTitle = "Fokker",
                Phone = "(099) 322-45-33",
                Address = "Голландия"
            };

            dsTypedManufacturerAirplane.Manufacturers.AddManufacturersRow(manufacturer.BrandTitle, manufacturer.Address, manufacturer.Phone);

            // синхронизация данных с сервером
            adapterManufacturer.Update(dsTypedManufacturerAirplane.Manufacturers);

            //Подтвердить изминения(закрепить)
            dsTypedManufacturerAirplane.Manufacturers.AcceptChanges();

            RefreshManufacturer();
        }

        private void DeleteManufacturer_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid_Main.SelectedItem != null)
            {
                // Получить выделенного автора
                Manufacturer selectedManufacturerRow = dataGrid_Main.SelectedItem as Manufacturer;

                // Получить ID выделенного автора
                int selectedId = selectedManufacturerRow.VendorId;

                dsTypedManufacturerAirplane.Manufacturers.Rows.Find(selectedId.ToString()).Delete();//delete on server

                // синхронизация данных с сервером
                adapterManufacturer.Update(dsTypedManufacturerAirplane.Manufacturers);

                //Подтвердить изминения(закрепить)
                dsTypedManufacturerAirplane.Manufacturers.AcceptChanges();

                // Обновить таблицу
                RefreshManufacturer();
            }
        }

        private void ShowAirplane_Click(object sender, RoutedEventArgs e)
        {
            RefreshAirplane();
        }

        private void AddAirplane_Click(object sender, RoutedEventArgs e)
        {
            Airplane airplane = new Airplane
            {
                Model = "Airbus A220-100",
                Price = 345000000,
                Speed = 670,
                VendorId = 2
            };

            DataSet_ManufacturerAirplane.AirplanesRow row = dsTypedManufacturerAirplane.Airplanes.NewAirplanesRow();
            row["Model"] = airplane.Model;
            row["Price"] = airplane.Price;
            row["Speed"] = airplane.Speed;
            row["VendorId"] = airplane.VendorId;
            row["Vendor"] = "";
        
            dsTypedManufacturerAirplane.Airplanes.AddAirplanesRow(row);

            // синхронизация данных с сервером
            adapterAirplane.Update(dsTypedManufacturerAirplane.Airplanes);

            //Подтвердить изминения(закрепить)
            dsTypedManufacturerAirplane.Airplanes.AcceptChanges();

            RefreshAirplane();
        }

        private void DeleteAirplane_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid_Main.SelectedItem != null)
            {
                // Получить выделенного автора
                Airplane selectedAirplaneRow = dataGrid_Main.SelectedItem as Airplane;

                // Получить ID выделенного автора
                int selectedId = selectedAirplaneRow.Id;

                dsTypedManufacturerAirplane.Airplanes.Rows.Find(selectedId.ToString()).Delete();//delete on server

                // синхронизация данных с сервером
                adapterAirplane.Update(dsTypedManufacturerAirplane.Airplanes);

                //Подтвердить изминения(закрепить)
                dsTypedManufacturerAirplane.Airplanes.AcceptChanges();

                // Обновить таблицу
                RefreshAirplane();
            }
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

            DataTable current_table = new DataTable();

            using (var adapter = new SqlDataAdapter(
                            "select a.Id,a.Model,a.Price,a.Speed,m.BrandTitle " +
                            " from Airplanes a, Manufacturers m" +
                            " where a.Speed < 600 and a.VendorId = m.VendorId"
                       , connectionManufacturerAirplane))
            {
                // Заполнение таблиц с сервера 
                adapter.Fill(current_table);
            }

            var result = current_table.AsEnumerable().Select(i => new
            {
                Id = (int)(i["Id"]),
                Model = (string)(i["Model"]),
                Price = (double)(i["Price"]),
                Speed = (int)(i["Speed"]),
                Vendor = (string)(i["BrandTitle"])
            });

            Window DataGridPresent = new Window_DataGrid(result);

            DataGridPresent.Show();
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

            DataTable current_table = new DataTable();

            using (var adapter = new SqlDataAdapter(
                            "select DISTINCT m.BrandTitle" +
                            " from Airplanes a, Manufacturers m" +
                            " where a.VendorId = m.VendorId " +
                            " and (select COUNT(a.Id) cnt from Airplanes a where a.VendorId = m.VendorId group by a.VendorId) > 3"
                       , connectionManufacturerAirplane))
            {
                // Заполнение таблиц с сервера 
                adapter.Fill(current_table);
            }

            var result = current_table.AsEnumerable().Select(i => new
            {
                BrandTitle = (string)(i["BrandTitle"])
            });

            Window DataGridPresent = new Window_DataGrid(result.ToList());

            DataGridPresent.Show();
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

            DataTable current_table = new DataTable();

            using (var adapter = new SqlDataAdapter(
                            "select m.BrandTitle" +
                            " from Manufacturers m" +
                            " where Len(m.BrandTitle) < 7"
                            , connectionManufacturerAirplane))
            {
                // Заполнение таблиц с сервера 
                adapter.Fill(current_table);
            }

            var result = current_table.AsEnumerable().Select(i => new
            {
                BrandTitle = (string)(i["BrandTitle"])
            });

            Window DataGridPresent = new Window_DataGrid(result.ToList());

            DataGridPresent.Show();
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
            try
            {
                var current_table = dsTypedManufacturerAirplane.GetAirplaineWithSpeedLess;

                using (var adapter = new GetAirplaineWithSpeedLessTableAdapter())
                { 
                    // Заполнение таблиц с сервера 
                    adapter.Fill(current_table, 600);
                };

                Window DataGridPresent = new Window_DataGrid(current_table);

                DataGridPresent.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //Logger.Error("Error occured while fetching records from SQL server", ex);
            }
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
            try
            {
                var current_table = dsTypedManufacturerAirplane.GetManufacturerWithAirplaneMore;

                using (var adapter = new GetManufacturerWithAirplaneMoreTableAdapter())
                {                 
                    // Заполнение таблиц с сервера 
                    adapter.Fill(current_table, 3);
                };

                Window DataGridPresent = new Window_DataGrid(current_table);

                DataGridPresent.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //Logger.Error("Error occured while fetching records from SQL server", ex);
            }
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
            try
            {
                var current_table = dsTypedManufacturerAirplane.GetManufacturerNameWithLengthLess;

                using (var adapter = new GetManufacturerNameWithLengthLessTableAdapter())
                {
                    // Заполнение таблиц с сервера 
                    adapter.Fill(current_table, 7);
                };

                Window DataGridPresent = new Window_DataGrid(current_table);

                DataGridPresent.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //Logger.Error("Error occured while fetching records from SQL server", ex);
            }
        }




        public void RefreshProjects()
        {
            // очистка локальной таблицы
            dsTypedProjectsEmployees.Projects.Clear();

            adapterProjects.Fill(dsTypedProjectsEmployees.Projects);

            var result = dsTypedProjectsEmployees.Projects.AsEnumerable().Select(i => new Project
            {
                Id = (int)(i["Id"]),
                Title = (string)(i["Title"]),
                StartDate = (DateTime)(i["StartDate"]),
                EndDate = (DateTime)(i["EndDate"]),
                Description = (string)(i["Description"])
            }).ToList<Project>();

            foreach (var item in result)
            {
                item.Employees =
                     (from pe in dsTypedProjectsEmployees.ProjectEmployees.AsEnumerable()
                      from e in dsTypedProjectsEmployees.Employees.AsEnumerable()
                      where (int)pe["EmployeeId"] == (int)e["Id"]
                      where (int)pe["ProjectId"] == item.Id
                      select new Employee
                      {
                          Id = (int)(e["Id"]),
                          FirstName = (string)(e["FirstName"]),
                          LastName = (string)(e["LastName"]),
                          Age = (int)(e["Age"]),
                          Address = (string)(e["Address"]),
                          FotoPath = (string)(e["FotoPath"])
                      }).ToList<Employee>();
            }

            ObservableCollection<Project> observableCollection = new ObservableCollection<Project>(result);

            CollectionViewSource collection = new CollectionViewSource() { Source = observableCollection };
            collection.GroupDescriptions.Add(new PropertyGroupDescription("StartDate"));
            //collection.GroupDescriptions.Add(new PropertyGroupDescription("City"));
            //collection.SortDescriptions.Add(new SortDescription("City", ListSortDirection.Ascending));
            //collection.Filter += Collection_Filter;

            dataGrid_Main.Style = (Style)FindResource("dataGridProjects");

            dataGrid_Main.ItemsSource = collection.View;
        }

        public void RefreshEmployees()
        {
            // очистка локальной таблицы
            dsTypedProjectsEmployees.Employees.Clear();

            adapterEmployees.Fill(dsTypedProjectsEmployees.Employees);

            var result = dsTypedProjectsEmployees.Employees.AsEnumerable().Select(i => new Employee
            {
                Id = (int)(i["Id"]),
                FirstName = (string)(i["FirstName"]),
                LastName = (string)(i["LastName"]),
                Age = (int)(i["Age"]),
                Address = (string)(i["Address"]),
                FotoPath = (string)(i["FotoPath"])
            }).ToList<Employee>();

            foreach (var item in result)
            {
                item.Projects =
                     (from pe in dsTypedProjectsEmployees.ProjectEmployees.AsEnumerable()
                      from p in dsTypedProjectsEmployees.Projects.AsEnumerable()
                      where (int)pe["ProjectId"] == (int)p["Id"]
                      where (int)pe["EmployeeId"] == item.Id
                      select new Project
                      {
                          Id = (int)(p["Id"]),
                          Title = (string)(p["Title"]),
                          StartDate = (DateTime)(p["StartDate"]),
                          EndDate = (DateTime)(p["EndDate"]),
                          Description = (string)(p["Description"])
                      }).ToList<Project>();
            }

            ObservableCollection<Employee> observableCollection = new ObservableCollection<Employee>(result);

            CollectionViewSource collection = new CollectionViewSource() { Source = observableCollection };
            collection.GroupDescriptions.Add(new PropertyGroupDescription("Age"));
            //collection.GroupDescriptions.Add(new PropertyGroupDescription("City"));
            //collection.SortDescriptions.Add(new SortDescription("City", ListSortDirection.Ascending));
            //collection.Filter += Collection_Filter;

            dataGrid_Main.Style = (Style)FindResource("dataGridEmployees");

            dataGrid_Main.ItemsSource = collection.View;
        }

        private void ShowProjects_Click(object sender, RoutedEventArgs e)
        {
            RefreshProjects();
        }

        private void AddProjects_Click(object sender, RoutedEventArgs e)
        {
            Project project = new Project
            {
                Title = "Creative System for Gratulation!!!",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Description = "New Funny Project"
            };

            DataSet_ProjectsEmployees.ProjectsRow row = dsTypedProjectsEmployees.Projects.NewProjectsRow();
            row["Titel"] = project.Title;
            row["StartDate"] = project.StartDate;
            row["EndDate"] = project.EndDate;
            row["Description"] = project.Description;

            dsTypedProjectsEmployees.Projects.AddProjectsRow(row);

            // синхронизация данных с сервером
            adapterProjects.Update(dsTypedProjectsEmployees.Projects);

            //Подтвердить изминения(закрепить)
            dsTypedProjectsEmployees.Projects.AcceptChanges();

            RefreshProjects();
        }

        private void DeleteProjects_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid_Main.SelectedItem != null)
            {
                // Получить выделенного автора
                Project selectedProjectRow = dataGrid_Main.SelectedItem as Project;

                // Получить ID выделенного автора
                int selectedId = selectedProjectRow.Id;

                dsTypedProjectsEmployees.Projects.Rows.Find(selectedId.ToString()).Delete();//delete on server

                // синхронизация данных с сервером
                adapterProjects.Update(dsTypedProjectsEmployees.Projects);

                // Обновить таблицу
                RefreshProjects();
            }
        }

        private void ShowEmployees_Click(object sender, RoutedEventArgs e)
        {
            RefreshEmployees();
        }

        private void AddEmployees_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = new Employee
            {
                FirstName = "Petr",
                LastName = "Lionesku",
                Age = 32,
                Address = "Большевитская улица, дом 14",
                FotoPath = "\\resources\\catBlue.jpg"
            };

            DataSet_ProjectsEmployees.EmployeesRow row = dsTypedProjectsEmployees.Employees.NewEmployeesRow();
            row["FirstName"] = employee.FirstName;
            row["LastName"] = employee.LastName;
            row["Age"] = employee.Age;
            row["Address"] = employee.Address;
            row["FotoPath"] = employee.FotoPath;

            dsTypedProjectsEmployees.Employees.AddEmployeesRow(row);

            // синхронизация данных с сервером
            adapterEmployees.Update(dsTypedProjectsEmployees.Employees);

            //Подтвердить изминения(закрепить)
            dsTypedProjectsEmployees.Employees.AcceptChanges();

            RefreshEmployees();
        }

        private void DeleteEmployees_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid_Main.SelectedItem != null)
            {
                // Получить выделенного автора
                Employee selectedEmployeeRow = dataGrid_Main.SelectedItem as Employee;

                // Получить ID выделенного автора
                int selectedId = selectedEmployeeRow.Id;

                dsTypedProjectsEmployees.Employees.Rows.Find(selectedId.ToString()).Delete();//delete on server

                // синхронизация данных с сервером
                adapterEmployees.Update(dsTypedProjectsEmployees.Employees);

                // Обновить таблицу
                RefreshEmployees();
            }
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
"\nWHERE p.Id IN (" +
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

            DataTable current_table = new DataTable();

            using (var adapter = new SqlDataAdapter(
                            "SELECT p.Id,p.Title" +
                            " FROM Projects p" +
                            " WHERE p.Id IN (" +
                            " SELECT pe.ProjectId" +
                            " FROM ProjectEmployees pe GROUP BY pe.ProjectId" +
                            " HAVING count(pe.ProjectId) =" +
                            " (" +
                            " SELECT MAX(g.cnt)" +
                            " FROM(SELECT COUNT(ppe.ProjectId) cnt" +
                            " FROM ProjectEmployees ppe" +
                            " GROUP BY ppe.ProjectId) g" +
                            " )" +
                            " )"
                       , connectionProjectsEmployees))
            {
                // Заполнение таблиц с сервера 
                adapter.Fill(current_table);
            }

            var result = current_table.AsEnumerable().Select(i => new
            {
                Id = (int)(i["Id"]),
                Title = (string)(i["Title"])
            });

            Window DataGridPresent = new Window_DataGrid(result.ToList());

            DataGridPresent.Show();
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

            DataTable current_table = new DataTable();

            using (var adapter = new SqlDataAdapter(
                            "select e.FirstName,e.LastName from Employees e " +
                            " where e.Age < 35"
                       , connectionProjectsEmployees))
            {
                // Заполнение таблиц с сервера 
                adapter.Fill(current_table);
            }

            var result = current_table.AsEnumerable().Select(i => new
            {
                FirstName = (string)(i["FirstName"]),
                LastName = (string)(i["LastName"])
            });

            Window DataGridPresent = new Window_DataGrid(result.ToList());

            DataGridPresent.Show();
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

            DataTable current_table = new DataTable();

            using (var adapter = new SqlDataAdapter(
                            "select e.FirstName,e.LastName from Employees e" +
                            " where Len(e.LastName) >= 5"
                       , connectionProjectsEmployees))
            {
                // Заполнение таблиц с сервера 
                adapter.Fill(current_table);
            }

            var result = current_table.AsEnumerable().Select(i => new
            {
                FirstName = (string)(i["FirstName"]),
                LastName = (string)(i["LastName"])
            });

            Window DataGridPresent = new Window_DataGrid(result.ToList());

            DataGridPresent.Show();
        }


        /*
         
create function GetProjectWithMaxEmployees()
returns table
as
return 
SELECT p.Id,p.Title
FROM Projects p 
WHERE p.Id IN (
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
            try
            {
                var current_table = dsTypedProjectsEmployees.GetProjectWithMaxEmployees;

                using (var adapter = new GetProjectWithMaxEmployeesTableAdapter())
                {
                    // Заполнение таблиц с сервера 
                    adapter.Fill(current_table);
                };

                Window DataGridPresent = new Window_DataGrid(current_table);

                DataGridPresent.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //Logger.Error("Error occured while fetching records from SQL server", ex);
            }
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
            try
            {
                var current_table = dsTypedProjectsEmployees.GetEmployeerWithAgeLess;

                using (var adapter = new GetEmployeerWithAgeLessTableAdapter())
                {
                    // Заполнение таблиц с сервера 
                    adapter.Fill(current_table, 35);
                };

                Window DataGridPresent = new Window_DataGrid(current_table);

                DataGridPresent.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //Logger.Error("Error occured while fetching records from SQL server", ex);
            }
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
            try
            {
                var current_table = dsTypedProjectsEmployees.GetEmployeerWithLastNameLengthMoreOrEqual;

                using (var adapter = new GetEmployeerWithLastNameLengthMoreOrEqualTableAdapter())
                {
                    // Заполнение таблиц с сервера 
                    adapter.Fill(current_table, 5);
                };

                Window DataGridPresent = new Window_DataGrid(current_table);

                DataGridPresent.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //Logger.Error("Error occured while fetching records from SQL server", ex);
            }
        }

        private void dataGrid_Main_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dataGrid_Main.SelectedItem != null)
            {
                if (dataGrid_Main.SelectedItem is Manufacturer manufacturer)
                {
                    // Получить выделенного автора

                    // Получить ID выделенного автора
                    int selectedId = manufacturer.VendorId;

                    Window_Change window_change = new Window_Change(manufacturer);

                    Manufacturer changedManufacturer = null;//ожидаем изминенный обьект
                    window_change.ReturnObject += res => changedManufacturer = res as Manufacturer;//по событию забираем изминенный объект

                    if (window_change.ShowDialog() == true)
                    {
                        if (changedManufacturer.VendorId == -1)//создание новой записи
                        {
                            dsTypedManufacturerAirplane.Manufacturers.AddManufacturersRow(manufacturer.BrandTitle, manufacturer.Address, manufacturer.Phone);
                        }
                        else
                        {
                            //    Manufacturer selectedManufacturerDB = (from m in dsTypedManufacturerAirplane.Manufacturers.AsEnumerable()
                            //                                           where (int)(m["VendorId"]) == selectedId
                            //                                           select new Manufacturer
                            //                                           {
                            //                                               VendorId = (int)(m["VendorId"]),
                            //                                               BrandTitle = (string)(m["BrandTitle"]),
                            //                                               Address = (string)(m["Address"]),
                            //                                               Phone = (string)(m["Phone"])
                            //                                           })?.First();
                            //
                            //    selectedManufacturerDB.VendorId = changedManufacturer.VendorId;
                            //    selectedManufacturerDB.BrandTitle = changedManufacturer.BrandTitle;
                            //    selectedManufacturerDB.Address = changedManufacturer.Address;
                            //    selectedManufacturerDB.Phone = changedManufacturer.Phone;

                            var row = dsTypedManufacturerAirplane.Manufacturers.Rows.Find(selectedId.ToString());
                            row.BeginEdit();
                            row["BrandTitle"] = changedManufacturer.BrandTitle;
                            row["Address"] = changedManufacturer.Address;
                            row["Phone"] = changedManufacturer.Phone;
                            row.EndEdit();
                        }
                        // синхронизация данных с сервером
                        adapterManufacturer.Update(dsTypedManufacturerAirplane.Manufacturers);

                        //Подтвердить изминения(закрепить)
                        dsTypedManufacturerAirplane.Manufacturers.AcceptChanges();
                         
                        // Обновить таблицу
                        RefreshManufacturer();
                    }
                }

                if (dataGrid_Main.SelectedItem is Airplane airplane)
                {
                    // Получить выделенного автора

                    // Получить ID выделенного автора
                    int selectedId = airplane.Id;

                    Window_Change window_change = new Window_Change(airplane);

                    var dictVendorIdBrandTitle =
                    (from m in dsTypedManufacturerAirplane.Manufacturers.AsEnumerable()
                     select new
                     {
                         Key = (int)(m["VendorId"]),
                         Value = (string)(m["BrandTitle"])
                     }).AsEnumerable().ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

                    window_change.DictionaryVendorIdBrandTitle = dictVendorIdBrandTitle;

                    Airplane changedAirplane = null;//ожидаем изминенный обьект
                    window_change.ReturnObject += res => changedAirplane = res as Airplane;//по событию забираем изминенный объект

                    if (window_change.ShowDialog() == true)
                    {
                        if (changedAirplane.Id == -1)//создание новой записи
                        {
                            DataSet_ManufacturerAirplane.AirplanesRow row = dsTypedManufacturerAirplane.Airplanes.NewAirplanesRow();
                            row["Model"] = airplane.Model;
                            row["Price"] = airplane.Price;
                            row["Speed"] = airplane.Speed;
                            row["VendorId"] = airplane.VendorId;
                            //row["Vendor"] = "";

                            dsTypedManufacturerAirplane.Airplanes.AddAirplanesRow(row);
                        }
                        else
                        {
                            //    Airplane selectedAirplaneDB = (from a in dsTypedManufacturerAirplane.Airplanes.AsEnumerable()
                            //                                   where (int)(a["Id"]) == selectedId
                            //                                   select new Airplane
                            //                                   {
                            //                                       Id = (int)(a["Id"]),
                            //                                       Model = (string)(a["Model"]),
                            //                                       Price = (double)(a["Price"]),
                            //                                       Speed = (int)(a["Speed"]),
                            //                                       VendorId = (int)(a["VendorId"]),
                            //                                   //    Vendor = (string)(a["Vendor"])
                            //                                   })?.First();
                            //
                            //    selectedAirplaneDB.Id = changedAirplane.Id;
                            //    selectedAirplaneDB.Model = changedAirplane.Model;
                            //    selectedAirplaneDB.Price = changedAirplane.Price;
                            //    selectedAirplaneDB.Speed = changedAirplane.Speed;
                            //    selectedAirplaneDB.VendorId = changedAirplane.VendorId;

                            var row = dsTypedManufacturerAirplane.Airplanes.Rows.Find(selectedId.ToString());
                            row.BeginEdit();
                            row["Model"] = changedAirplane.Model;
                            row["Price"] = changedAirplane.Price;
                            row["Speed"] = changedAirplane.Speed;
                            row["VendorId"] = changedAirplane.VendorId;
                            row.EndEdit();
                        }

                        // синхронизация данных с сервером
                        adapterAirplane.Update(dsTypedManufacturerAirplane);

                        //Подтвердить изминения(закрепить)
                        dsTypedManufacturerAirplane.AcceptChanges();

                        // Обновить таблицу
                        RefreshAirplane();
                    }
                }

                if (dataGrid_Main.SelectedItem is Project project)
                {
                    // Получить выделенного автора

                    // Получить ID выделенного автора
                    int selectedId = project.Id;

                    Window_Change window_change = new Window_Change(project);

                    Project changedProject = null;//ожидаем изминенный обьект
                    window_change.ReturnObject += res => changedProject = res as Project;//по событию забираем изминенный объект

                    if (window_change.ShowDialog() == true)
                    {
                        if (changedProject.Id == -1)//создание новой записи
                        {
                            DataSet_ProjectsEmployees.ProjectsRow row = dsTypedProjectsEmployees.Projects.NewProjectsRow();
                            row["Title"] = project.Title;
                            row["StartDate"] = project.StartDate;
                            row["EndDate"] = project.EndDate;
                            row["Description"] = project.Description;

                            dsTypedProjectsEmployees.Projects.AddProjectsRow(row);
                        }
                        else
                        {
                            //    Project selectedProjectDB = (from p in dsTypedProjectsEmployees.Projects.AsEnumerable()
                            //                                 where (int)p["Id"] == selectedId
                            //                                 select new Project
                            //                                 {
                            //                                     Id = (int)(p["Id"]),
                            //                                     Title = (string)(p["Title"]),
                            //                                     StartDate = (DateTime)(p["StartDate"]),
                            //                                     EndDate = (DateTime)(p["EndDate"]),
                            //                                     Description = (string)(p["Description"])
                            //                                 })?.First();
                            //
                            //    selectedProjectDB.Id = changedProject.Id;
                            //    selectedProjectDB.Title = changedProject.Title;
                            //    selectedProjectDB.StartDate = changedProject.StartDate;
                            //    selectedProjectDB.EndDate = changedProject.EndDate;
                            //    selectedProjectDB.Description = changedProject.Description;

                            var row = dsTypedProjectsEmployees.Projects.Rows.Find(selectedId.ToString());
                            row.BeginEdit();
                            row["Title"] = changedProject.Title;
                            row["StartDate"] = changedProject.StartDate;
                            row["EndDate"] = changedProject.EndDate;
                            row["Description"] = changedProject.Description;
                            row.EndEdit();
                        }

                        // синхронизация данных с сервером
                        adapterProjects.Update(dsTypedProjectsEmployees);

                        //Подтвердить изминения(закрепить)
                        dsTypedProjectsEmployees.Projects.AcceptChanges();

                        // Обновить таблицу
                        RefreshProjects();
                    }
                }

                if (dataGrid_Main.SelectedItem is Employee employee)
                {
                    // Получить выделенного автора

                    // Получить ID выделенного автора
                    int selectedId = employee.Id;

                    Window_Change window_change = new Window_Change(employee);

                    Employee changedEmployee = null;//ожидаем изминенный обьект
                    window_change.ReturnObject += res => changedEmployee = res as Employee;//по событию забираем изминенный объект

                    if (window_change.ShowDialog() == true)
                    {                   
                        if (changedEmployee.Id == -1)//создание новой записи
                        {
                            DataSet_ProjectsEmployees.EmployeesRow row = dsTypedProjectsEmployees.Employees.NewEmployeesRow();
                            row["FirstName"] = employee.FirstName;
                            row["LastName"] = employee.LastName;
                            row["Age"] = employee.Age;
                            row["Address"] = employee.Address;
                            row["FotoPath"] = employee.FotoPath;

                            dsTypedProjectsEmployees.Employees.AddEmployeesRow(row);
                        }
                        else
                        {
                            //    Employee selectedEmployeeDB = (from emp in dsTypedProjectsEmployees.Employees.AsEnumerable()
                            //                                   where (int)emp["Id"] == selectedId
                            //                                   select new Employee
                            //                                   {
                            //                                       Id = (int)(emp["Id"]),
                            //                                       FirstName = (string)(emp["FirstName"]),
                            //                                       LastName = (string)(emp["LastName"]),
                            //                                       Age = (int)(emp["Age"]),
                            //                                       Address = (string)(emp["Address"]),
                            //                                       FotoPath = (string)(emp["FotoPath"])
                            //                                   })?.First();
                            //
                            //    selectedEmployeeDB.Id = changedEmployee.Id;
                            //    selectedEmployeeDB.FirstName = changedEmployee.FirstName;
                            //    selectedEmployeeDB.LastName = changedEmployee.LastName;
                            //    selectedEmployeeDB.Age = changedEmployee.Age;
                            //    selectedEmployeeDB.Address = changedEmployee.Address;
                            //    selectedEmployeeDB.FotoPath = changedEmployee.FotoPath;

                            var row = dsTypedProjectsEmployees.Employees.Rows.Find(selectedId.ToString());
                            row.BeginEdit();
                            row["FirstName"] = changedEmployee.FirstName;
                            row["LastName"] = changedEmployee.LastName;
                            row["Age"] = changedEmployee.Age;
                            row["Address"] = changedEmployee.Address;
                            row["FotoPath"] = changedEmployee.FotoPath;
                            row.EndEdit();
                       }

                        // синхронизация данных с сервером
                        adapterEmployees.Update(dsTypedProjectsEmployees);

                        dsTypedProjectsEmployees.Employees.AcceptChanges();

                        // Обновить таблицу
                        RefreshEmployees();
                    }
                }

            }
        }
    }
}
