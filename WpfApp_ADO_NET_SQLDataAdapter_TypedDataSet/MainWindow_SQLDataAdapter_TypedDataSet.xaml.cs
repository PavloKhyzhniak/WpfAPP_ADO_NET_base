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

namespace WpfApp_ADO_NET_SQLDataAdapter_TypedDataSet
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection connectionManufacturerAirplane;
        DataSet_ManufacturerAirplane dsTypedManufacturerAirplane = new DataSet_ManufacturerAirplane();
        SqlDataAdapter adapterManufacturer;
        SqlDataAdapter adapterAirplane;

        SqlConnection connectionProjectsEmployees;
        DataSet_ProjectsEmployees dsTypedProjectsEmployees = new DataSet_ProjectsEmployees();
        SqlDataAdapter adapterProjects;
        SqlDataAdapter adapterProjectsEmployees;
        SqlDataAdapter adapterEmployees;

        public MainWindow()
        {
            InitializeComponent();

            connectionManufacturerAirplane
               = SqlDatabase.CreateSqlConnection_ConfigurationManager("WpfApp_ADO_NET_SQLDataAdapter_TypedDataSet.Properties.Settings.WpfApp_ADO_NET_CodeFirst_Model_ManufacturerAirplaneConnectionString");
            connectionProjectsEmployees
                = SqlDatabase.CreateSqlConnection_ConfigurationManager("WpfApp_ADO_NET_SQLDataAdapter_TypedDataSet.Properties.Settings.WpfApp_ADO_NET_CodeFirst_Model_ProjectsEmployeesConnectionString");

            PrepareManufactureAirplane();
            PrepareProjectsEmployees();
        }

        public void PrepareManufactureAirplane()
        {        

            using (adapterManufacturer = new SqlDataAdapter(
                "select * from Manufacturers"
               , connectionManufacturerAirplane))
            {
                adapterManufacturer.MissingSchemaAction = MissingSchemaAction.AddWithKey;//with PrimaryKey
                // Заполнение таблиц с сервера 
                adapterManufacturer.Fill(dsTypedManufacturerAirplane, "Manufacturers");
            }

            using (adapterAirplane = new SqlDataAdapter(
                            "select a.*, m.BrandTitle Vendor" +
                            " from Airplanes a, Manufacturers m" +
                            " where a.VendorId = m.VendorId"
                       , connectionManufacturerAirplane))
            {
                adapterAirplane.MissingSchemaAction = MissingSchemaAction.AddWithKey;//with PrimaryKey
                // Заполнение таблиц с сервера 
                adapterAirplane.Fill(dsTypedManufacturerAirplane, "Airplanes");
            }

            string commandString;
            SqlCommand command;
            // настройка синхронизации с сервером
            commandString = "insert into Manufacturers(BrandTitle, Address, Phone) values (@BrandTitle, @Address, @Phone)";
            command = new SqlCommand(commandString, connectionManufacturerAirplane);
            command.Parameters.Add("@BrandTitle", SqlDbType.VarChar, 50, "BrandTitle");
            command.Parameters.Add("@Address", SqlDbType.VarChar, 50, "Address");
            command.Parameters.Add("@Phone", SqlDbType.VarChar, 20, "Phone");
            adapterManufacturer.InsertCommand = command;

            commandString = "delete from Manufacturers where VendorId=@VendorId";
            command = new SqlCommand(commandString, connectionManufacturerAirplane);
            command.Parameters.Add("@VendorId", SqlDbType.Int, 4, "VendorId");
            adapterManufacturer.DeleteCommand = command;

            commandString = "update Manufacturers set BrandTitle=@BrandTitle, Address=@Address, Phone=@Phone where VendorId=@VendorId";
            command = new SqlCommand(commandString, connectionManufacturerAirplane);
            command.Parameters.Add("@VendorId", SqlDbType.Int, 4, "VendorId");
            command.Parameters.Add("@BrandTitle", SqlDbType.VarChar, 50, "BrandTitle");
            command.Parameters.Add("@Address", SqlDbType.VarChar, 50, "Address");
            command.Parameters.Add("@Phone", SqlDbType.VarChar, 20, "Phone");
            adapterManufacturer.UpdateCommand = command;

            // настройка синхронизации с сервером
            commandString = "insert into Airplanes(Model, Price, Speed, VendorId) values (@Model, @Price, @Speed, @VendorId)";
            command = new SqlCommand(commandString, connectionManufacturerAirplane);
            command.Parameters.Add("@Model", SqlDbType.VarChar, 50, "Model");
            command.Parameters.Add("@Price", SqlDbType.Float, 20, "Price");
            command.Parameters.Add("@Speed", SqlDbType.Int, 20, "Speed");
            command.Parameters.Add("@VendorId", SqlDbType.Int, 4, "VendorId");
            adapterAirplane.InsertCommand = command;

            commandString = "delete from Airplanes where Id=@Id";
            command = new SqlCommand(commandString, connectionManufacturerAirplane);
            command.Parameters.Add("@Id", SqlDbType.Int, 4, "Id");
            adapterAirplane.DeleteCommand = command;

            commandString = "update Airplanes set Model=@Model, Price=@Price, Speed=@Speed, VendorId=@VendorId where Id=@Id";
            command = new SqlCommand(commandString, connectionManufacturerAirplane);
            command.Parameters.Add("@Id", SqlDbType.Int, 4, "Id");
            command.Parameters.Add("@Model", SqlDbType.VarChar, 50, "Model");
            command.Parameters.Add("@Price", SqlDbType.Float, 20, "Price");
            command.Parameters.Add("@Speed", SqlDbType.Int, 20, "Speed");
            command.Parameters.Add("@VendorId", SqlDbType.Int, 4, "VendorId");
            adapterAirplane.UpdateCommand = command;                       
        }
                
        public void PrepareProjectsEmployees()
        {
            using (adapterProjects = new SqlDataAdapter())
            {
                adapterProjects.SelectCommand = new SqlCommand(
                "select * from Projects"
               , connectionProjectsEmployees);

                adapterProjects.MissingSchemaAction = MissingSchemaAction.AddWithKey;//with PrimaryKey
                // Заполнение таблиц с сервера 
                adapterProjects.Fill(dsTypedProjectsEmployees, "Projects");
            }

            using (adapterProjectsEmployees = new SqlDataAdapter())
            {
                adapterProjectsEmployees.SelectCommand = new SqlCommand(
                "select * from ProjectEmployees"
               , connectionProjectsEmployees);

                adapterProjectsEmployees.MissingSchemaAction = MissingSchemaAction.AddWithKey;//with PrimaryKey
                // Заполнение таблиц с сервера 
                adapterProjectsEmployees.Fill(dsTypedProjectsEmployees, "ProjectEmployees");
            }

            using (adapterEmployees = new SqlDataAdapter())
            {
                adapterEmployees.SelectCommand = new SqlCommand(
                "select * from Employees"
               , connectionProjectsEmployees);

                adapterEmployees.MissingSchemaAction = MissingSchemaAction.AddWithKey;//with PrimaryKey
                // Заполнение таблиц с сервера 
                adapterEmployees.Fill(dsTypedProjectsEmployees, "Employees");
            }                       

            string commandString;
            SqlCommand command;
            // настройка синхронизации с сервером
            commandString = "insert into Projects(Title, StartDate, EndDate, Description) values (@Title, @StartDate, @EndDate, @Description)";
            command = new SqlCommand(commandString, connectionProjectsEmployees);
            command.Parameters.Add("@Title", SqlDbType.VarChar, 50, "Title");
            command.Parameters.Add("@StartDate", SqlDbType.DateTime, 50, "StartDate");
            command.Parameters.Add("@EndDate", SqlDbType.DateTime, 50, "EndDate");
            command.Parameters.Add("@Description", SqlDbType.VarChar, 200, "Description");
            adapterProjects.InsertCommand = command;

            commandString = "delete from Projects where Id=@Id";
            command = new SqlCommand(commandString, connectionProjectsEmployees);
            command.Parameters.Add("@Id", SqlDbType.Int, 4, "Id");
            adapterProjects.DeleteCommand = command;

            commandString = "update Projects set Title=@Title, StartDate=@StartDate, EndDate=@EndDate, Description=@Description where Id=@Id";
            command = new SqlCommand(commandString, connectionProjectsEmployees);
            command.Parameters.Add("@Id", SqlDbType.Int, 4, "Id");
            command.Parameters.Add("@Title", SqlDbType.VarChar, 50, "Title");
            command.Parameters.Add("@StartDate", SqlDbType.DateTime, 50, "StartDate");
            command.Parameters.Add("@EndDate", SqlDbType.DateTime, 50, "EndDate");
            command.Parameters.Add("@Description", SqlDbType.VarChar, 200, "Description");
            adapterProjects.UpdateCommand = command;

            // настройка синхронизации с сервером
            commandString = "insert into ProjectEmployees(ProjectId, EmployeeId) values (@ProjectId, @EmployeeId)";
            command = new SqlCommand(commandString, connectionProjectsEmployees);
            command.Parameters.Add("@ProjectId", SqlDbType.Int, 4, "ProjectId");
            command.Parameters.Add("@EmployeeId", SqlDbType.Int, 4, "EmployeeId");
            adapterProjectsEmployees.InsertCommand = command;

            //    commandString = "delete from ProjectEmployees where VendorId=@VendorId";
            //    command = new SqlCommand(commandString, connectionProjectsEmployees);
            //    command.Parameters.Add("@VendorId", SqlDbType.Int, 4, "VendorId");
            //    adapterProjectsEmployees.DeleteCommand = command;
            //
            //    commandString = "update ProjectEmployees set ProjectId=@ProjectId, EmployeeId=@EmployeeId where VendorId=@VendorId";
            //    command = new SqlCommand(commandString, connectionProjectsEmployees);
            //    command.Parameters.Add("@ProjectId", SqlDbType.Int, 4, "ProjectId");
            //    command.Parameters.Add("@EmployeeId", SqlDbType.Int, 4, "EmployeeId");
            //    adapterProjectsEmployees.UpdateCommand = command;

            // настройка синхронизации с сервером
            commandString = "insert into Employees(FirstName, LastName, Age, Address, FotoPath) values (@FirstName, @LastName, @Age, @Address, @FotoPath)";
            command = new SqlCommand(commandString, connectionProjectsEmployees);
            command.Parameters.Add("@FirstName", SqlDbType.VarChar, 50, "FirstName");
            command.Parameters.Add("@LastName", SqlDbType.VarChar, 50, "LastName");
            command.Parameters.Add("@Age", SqlDbType.Int, 3, "Age");
            command.Parameters.Add("@Address", SqlDbType.VarChar, 50, "Address");
            command.Parameters.Add("@FotoPath", SqlDbType.VarChar, 20, "FotoPath");
            adapterEmployees.InsertCommand = command;

            commandString = "delete from Employees where Id=@Id";
            command = new SqlCommand(commandString, connectionProjectsEmployees);
            command.Parameters.Add("@Id", SqlDbType.Int, 4, "Id");
            adapterEmployees.DeleteCommand = command;

            commandString = "update Employees set FirstName=@FirstName, LastName=@LastName, Age=@Age, Address=@Address, FotoPath=@FotoPath where Id=@Id";
            command = new SqlCommand(commandString, connectionProjectsEmployees);
            command.Parameters.Add("@Id", SqlDbType.Int, 4, "Id");
            command.Parameters.Add("@FirstName", SqlDbType.VarChar, 50, "FirstName");
            command.Parameters.Add("@LastName", SqlDbType.VarChar, 50, "LastName");
            command.Parameters.Add("@Age", SqlDbType.Int, 3, "Age");
            command.Parameters.Add("@Address", SqlDbType.VarChar, 50, "Address");
            command.Parameters.Add("@FotoPath", SqlDbType.VarChar, 20, "FotoPath");
            adapterEmployees.UpdateCommand = command;           
        }

        public void RefreshManufacturer()
        {
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
            var result = dsTypedManufacturerAirplane.Airplanes.AsEnumerable().Select(i => new Airplane
            {
                Id = (int)(i["Id"]),
                Model = (string)(i["Model"]),
                Price = (double)(i["Price"]),
                Speed = (int)(i["Speed"]),
                VendorId = (int)(i["VendorId"]),
                Vendor = (string)(i["Vendor"])
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

            dsTypedManufacturerAirplane.Manufacturers.AddManufacturersRow(manufacturer.BrandTitle,manufacturer.Address,manufacturer.Phone);

            // синхронизация данных с сервером
            adapterManufacturer.Update(dsTypedManufacturerAirplane, "Manufacturers");

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
                adapterManufacturer.Update(dsTypedManufacturerAirplane, "Manufacturers");

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
            adapterAirplane.Update(dsTypedManufacturerAirplane, "Airplanes");

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
                adapterAirplane.Update(dsTypedManufacturerAirplane, "Airplanes");

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
            DataTable current_table = new DataTable();

            try
            {
                using (var adapter = new SqlDataAdapter("select * from GetAirplaineWithSpeedLess(@Speed)", connectionManufacturerAirplane))
                {
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    adapter.SelectCommand.Parameters.Add("@Speed", SqlDbType.Int).Value = 600;

                    // Заполнение таблиц с сервера 
                    adapter.Fill(current_table);
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //Logger.Error("Error occured while fetching records from SQL server", ex);
            }

            var result = current_table.AsEnumerable().Select(i => new
            {
                Id = (int)(i["Id"]),
                Model = (string)(i["Model"]),
                Price = (double)(i["Price"]),
                Speed = (int)(i["Speed"]),
                Vendor = (string)(i["BrandTitle"])
            });

            Window DataGridPresent = new Window_DataGrid(result.ToList());

            DataGridPresent.Show();
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
            DataTable current_table = new DataTable();

            try
            {
                using (var adapter = new SqlDataAdapter("select * from GetManufacturerWithAirplaneMore(@Count)", connectionManufacturerAirplane))
                {
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    adapter.SelectCommand.Parameters.Add("@Count", SqlDbType.Int).Value = 3;

                    // Заполнение таблиц с сервера 
                    adapter.Fill(current_table);
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //Logger.Error("Error occured while fetching records from SQL server", ex);
            }

            var result = current_table.AsEnumerable().Select(i => new
            {
                BrandTitle = (string)(i["BrandTitle"])
            });

            Window DataGridPresent = new Window_DataGrid(result.ToList());

            DataGridPresent.Show();
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
            DataTable current_table = new DataTable();

            try
            {
                using (var adapter = new SqlDataAdapter("select * from GetManufacturerNameWithLengthLess(@Count)", connectionManufacturerAirplane))
                {
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    adapter.SelectCommand.Parameters.Add("@Count", SqlDbType.Int).Value = 7;

                    // Заполнение таблиц с сервера 
                    adapter.Fill(current_table);
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //Logger.Error("Error occured while fetching records from SQL server", ex);
            }

            var result = current_table.AsEnumerable().Select(i => new
            {
                BrandTitle = (string)(i["BrandTitle"])
            });

            Window DataGridPresent = new Window_DataGrid(result.ToList());

            DataGridPresent.Show();
        }




        public void RefreshProjects()
        {
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
            adapterProjects.Update(dsTypedProjectsEmployees, "Projects");

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
                adapterProjects.Update(dsTypedProjectsEmployees, "Projects");

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
            adapterProjects.Update(dsTypedProjectsEmployees, "Employees");

            dsTypedProjectsEmployees.Projects.AcceptChanges();

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
                adapterEmployees.Update(dsTypedProjectsEmployees, "Employees");

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
            DataTable current_table = new DataTable();

            try
            {
                using (var adapter = new SqlDataAdapter("select * from GetProjectWithMaxEmployees()", connectionProjectsEmployees))
                {
                    adapter.SelectCommand.CommandType = CommandType.Text;

                    // Заполнение таблиц с сервера 
                    adapter.Fill(current_table);
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //Logger.Error("Error occured while fetching records from SQL server", ex);
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
            DataTable current_table = new DataTable();

            try
            {
                using (var adapter = new SqlDataAdapter("select * from GetEmployeerWithAgeLess(@Count)", connectionProjectsEmployees))
                {
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    adapter.SelectCommand.Parameters.Add("@Count", SqlDbType.Int).Value = 35;

                    // Заполнение таблиц с сервера 
                    adapter.Fill(current_table);
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //Logger.Error("Error occured while fetching records from SQL server", ex);
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
            DataTable current_table = new DataTable();

            try
            {
                using (var adapter = new SqlDataAdapter("select * from GetEmployeerWithLastNameLengthMoreOrEqual(@Count)", connectionProjectsEmployees))
                {
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    adapter.SelectCommand.Parameters.Add("@Count", SqlDbType.Int).Value = 5;

                    // Заполнение таблиц с сервера 
                    adapter.Fill(current_table);
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //Logger.Error("Error occured while fetching records from SQL server", ex);
            }

            var result = current_table.AsEnumerable().Select(i => new
            {
                FirstName = (string)(i["FirstName"]),
                LastName = (string)(i["LastName"])
            });

            Window DataGridPresent = new Window_DataGrid(result.ToList());

            DataGridPresent.Show();
        }
    }
}
