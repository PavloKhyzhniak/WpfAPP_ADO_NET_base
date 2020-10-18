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
using WpfApp_ADO_NET_SQLDataAdapter.Classes_SqlDataAdapter;

namespace WpfApp_ADO_NET_SQLDataAdapter
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection connectionManufacturerAirplane;
        DataSet dsManufacturerAirplane;
        SqlDataAdapter adapterManufacturer;
        SqlDataAdapter adapterAirplane;

        SqlConnection connectionProjectsEmployees;
        DataSet dsProjectsEmployees;
        SqlDataAdapter adapterProjects;
        SqlDataAdapter adapterProjectsEmployees;
        SqlDataAdapter adapterEmployees;

        public MainWindow()
        {
            InitializeComponent();

            connectionManufacturerAirplane
                = SqlDatabase.CreateSqlConnection_ConfigurationManager("WpfApp_ADO_NET_SQLDataAdapter.Properties.Settings.ManufacturerAirplaneConnectionString");
            connectionProjectsEmployees
                = SqlDatabase.CreateSqlConnection_ConfigurationManager("WpfApp_ADO_NET_SQLDataAdapter.Properties.Settings.ProjectsEmployeesConnectionString");

            PrepareManufactureAirplane();
            PrepareProjectsEmployees();
        }

        public void FillManufacture()
        {
            using (adapterManufacturer = new SqlDataAdapter(
                "select * from Manufacturers"
               , connectionManufacturerAirplane))
            {
                adapterManufacturer.MissingSchemaAction = MissingSchemaAction.AddWithKey;//with PrimaryKey
                // Заполнение таблиц с сервера 
                adapterManufacturer.FillSchema(dsManufacturerAirplane, SchemaType.Source, "Manufacturers");
                adapterManufacturer.Fill(dsManufacturerAirplane, "Manufacturers");
            }
        }
        public void UpdateManufacture()
        {
            using (adapterManufacturer = new SqlDataAdapter(
                "select * from Manufacturers"
               , connectionManufacturerAirplane))
            {
                adapterManufacturer.MissingSchemaAction = MissingSchemaAction.AddWithKey;//with PrimaryKey
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

            adapterManufacturer.Update(dsManufacturerAirplane, "Manufacturers");
        }
        public void FillAirplane()
        {
            using (adapterAirplane = new SqlDataAdapter(
                            "select a.*, m.BrandTitle Vendor" +
                            " from Airplanes a, Manufacturers m" +
                            " where a.VendorId = m.VendorId"
                       , connectionManufacturerAirplane))
            {
                adapterAirplane.MissingSchemaAction = MissingSchemaAction.AddWithKey;//with PrimaryKey
                // Заполнение таблиц с сервера 
                adapterAirplane.FillSchema(dsManufacturerAirplane, SchemaType.Source, "Airplanes");
                adapterAirplane.Fill(dsManufacturerAirplane, "Airplanes");
            }
        }
        public void UpdateAirplane()
        {
            using (adapterAirplane = new SqlDataAdapter(
                                        "select a.*, m.BrandTitle Vendor" +
                                        " from Airplanes a, Manufacturers m" +
                                        " where a.VendorId = m.VendorId"
                                   , connectionManufacturerAirplane))
            {
                adapterAirplane.MissingSchemaAction = MissingSchemaAction.AddWithKey;//with PrimaryKey
            }

            string commandString;
            SqlCommand command;
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

            adapterAirplane.Update(dsManufacturerAirplane, "Airplanes");
        }


        public void PrepareManufactureAirplane()
        {
            dsManufacturerAirplane = new DataSet();

            FillManufacture();
            FillAirplane();
           
            // Поддержка отношений между локальными таблицами
            DataRelation newDSRelationManufacturerAirplane = 
                new DataRelation("relation_VendorId", dsManufacturerAirplane.Tables["Manufacturers"].Columns["VendorId"]
                , dsManufacturerAirplane.Tables["Airplanes"].Columns["VendorId"]);

            // Прикрепить взаимооотношение к набору таблиц
            dsManufacturerAirplane.Relations.Add(newDSRelationManufacturerAirplane);
        }

        private void ShowDataAdapterCommand(SqlCommandBuilder cmdBuilder)
        {
            //SqlCommandBuilder cmdBuilder;
            //cmdBuilder = new SqlCommandBuilder(adapterProjects);
            //ShowDataAdapterCommand(cmdBuilder);
            //cmdBuilder = new SqlCommandBuilder(adapterProjectsEmployees);
            //ShowDataAdapterCommand(cmdBuilder);
            //cmdBuilder = new SqlCommandBuilder(adapterEmployees);
            //ShowDataAdapterCommand(cmdBuilder);

            Console.WriteLine("Update command Generated by the Command Builder : ");
            Console.WriteLine("==================================================");
            Console.WriteLine(cmdBuilder.GetUpdateCommand().CommandText);
            Console.WriteLine("         ");

            Console.WriteLine("Insert command Generated by the Command Builder : ");
            Console.WriteLine("==================================================");
            Console.WriteLine(cmdBuilder.GetInsertCommand().CommandText);
            Console.WriteLine("         ");

            Console.WriteLine("Delete command Generated by the Command Builder : ");
            Console.WriteLine("==================================================");
            Console.WriteLine(cmdBuilder.GetDeleteCommand().CommandText);
            Console.WriteLine("         ");
        }

        public void FillProjects()
        {
            using (adapterProjects = new SqlDataAdapter())
            {
                adapterProjects.SelectCommand = new SqlCommand(
                "select * from Projects"
               , connectionProjectsEmployees);

                adapterProjects.MissingSchemaAction = MissingSchemaAction.AddWithKey;//with PrimaryKey
                 
                // Заполнение таблиц с сервера 
                adapterProjects.FillSchema(dsProjectsEmployees, SchemaType.Source, "Projects");
                adapterProjects.Fill(dsProjectsEmployees, "Projects");
            }

        }
        public void UpdateProjects()
        {
            using (adapterProjects = new SqlDataAdapter())
            {
                adapterProjects.SelectCommand = new SqlCommand(
                "select * from Projects"
               , connectionProjectsEmployees);

                adapterProjects.MissingSchemaAction = MissingSchemaAction.AddWithKey;//with PrimaryKey
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

            adapterProjects.Update(dsProjectsEmployees, "Projects");
        }
        public void FillProjectsEmployees()
        {
            using (adapterProjectsEmployees = new SqlDataAdapter())
            {
                adapterProjectsEmployees.SelectCommand = new SqlCommand(
                "select * from ProjectEmployees"
               , connectionProjectsEmployees);

                adapterProjectsEmployees.MissingSchemaAction = MissingSchemaAction.AddWithKey;//with PrimaryKey

                // Заполнение таблиц с сервера 
                adapterProjectsEmployees.FillSchema(dsProjectsEmployees, SchemaType.Source, "ProjectEmployees");
                adapterProjectsEmployees.Fill(dsProjectsEmployees, "ProjectEmployees");
            }

        }
        public void UpdateProjectsEmployees()
        {
            using (adapterProjectsEmployees = new SqlDataAdapter())
            {
                adapterProjectsEmployees.SelectCommand = new SqlCommand(
                "select * from ProjectEmployees"
               , connectionProjectsEmployees);

                adapterProjectsEmployees.MissingSchemaAction = MissingSchemaAction.AddWithKey;//with PrimaryKey
             }

            string commandString;
            SqlCommand command;
            // настройка синхронизации с сервером
            commandString = "insert into ProjectEmployees(ProjectId, EmployeeId) values (@ProjectId, @EmployeeId)";
            command = new SqlCommand(commandString, connectionProjectsEmployees);
            command.Parameters.Add("@ProjectId", SqlDbType.Int, 4, "ProjectId");
            command.Parameters.Add("@EmployeeId", SqlDbType.Int, 4, "EmployeeId");
            adapterProjectsEmployees.InsertCommand = command;

            commandString = "delete from ProjectEmployees where ProjectId=@ProjectId and EmployeeId=@EmployeeId";
            command = new SqlCommand(commandString, connectionProjectsEmployees);
            command.Parameters.Add("@ProjectId", SqlDbType.Int, 4, "ProjectId");
            command.Parameters.Add("@EmployeeId", SqlDbType.Int, 4, "EmployeeId");
            adapterProjectsEmployees.DeleteCommand = command;
            
            //    commandString = "update ProjectEmployees set ProjectId=@ProjectId, EmployeeId=@EmployeeId where VendorId=@VendorId";
            //    command = new SqlCommand(commandString, connectionProjectsEmployees);
            //    command.Parameters.Add("@ProjectId", SqlDbType.Int, 4, "ProjectId");
            //    command.Parameters.Add("@EmployeeId", SqlDbType.Int, 4, "EmployeeId");
            //    adapterProjectsEmployees.UpdateCommand = command;
        }
        public void FillEmployees()
        {
            using (adapterEmployees = new SqlDataAdapter())
            {
                adapterEmployees.SelectCommand = new SqlCommand(
                "select * from Employees"
               , connectionProjectsEmployees);

                adapterEmployees.MissingSchemaAction = MissingSchemaAction.AddWithKey;//with PrimaryKey

                // Заполнение таблиц с сервера 
                adapterEmployees.FillSchema(dsProjectsEmployees, SchemaType.Source, "Employees");
                adapterEmployees.Fill(dsProjectsEmployees, "Employees");
            }

        }
        public void UpdateEmployees()
        {
            using (adapterEmployees = new SqlDataAdapter())
            {
                adapterEmployees.SelectCommand = new SqlCommand(
                "select * from Employees"
               , connectionProjectsEmployees);

                adapterEmployees.MissingSchemaAction = MissingSchemaAction.AddWithKey;//with PrimaryKey
            }

            string commandString;
            SqlCommand command;
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

            adapterEmployees.Update(dsProjectsEmployees, "Employees");
        }

        public void PrepareProjectsEmployees()
        {
            dsProjectsEmployees = new DataSet();

            FillProjects();
            FillProjectsEmployees();
            FillEmployees();            

            // Поддержка отношений между локальными таблицами
            DataRelation newDSRelationProjectsToEmployees =
                new DataRelation("relation_ProjectsEmployees", dsProjectsEmployees.Tables["Projects"].Columns["Id"]
                , dsProjectsEmployees.Tables["ProjectEmployees"].Columns["ProjectId"]);
            DataRelation newDSRelationEmployeesToProjects =
                new DataRelation("relation_EmployeesProjects", dsProjectsEmployees.Tables["Employees"].Columns["Id"]
                , dsProjectsEmployees.Tables["ProjectEmployees"].Columns["EmployeeId"]);

            // Прикрепить взаимооотношение к набору таблиц
            dsProjectsEmployees.Relations.Add(newDSRelationProjectsToEmployees);
            dsProjectsEmployees.Relations.Add(newDSRelationEmployeesToProjects);
        }

        public void RefreshManufacturer()
        {
            FillManufacture();

            var result = dsManufacturerAirplane.Tables["Manufacturers"].AsEnumerable().Select(i => new Manufacturer
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
            FillAirplane();

            var result = dsManufacturerAirplane.Tables["Airplanes"].AsEnumerable().Select(i => new Airplane
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

            DataTable current_table = dsManufacturerAirplane.Tables["Manufacturers"];

            // добавление нового поля
            DataRow dr = current_table.NewRow();
            dr["BrandTitle"] = manufacturer.BrandTitle;
            dr["Phone"] = manufacturer.Phone;
            dr["Address"] = manufacturer.Address;
            current_table.Rows.Add(dr);

            // синхронизация данных с сервером
            UpdateManufacture();
        
            //Подтвердить изминения(закрепить)
            current_table.AcceptChanges();

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

                DataTable current_table = dsManufacturerAirplane.Tables["Manufacturers"];

                DataRow findRow = current_table.Rows.Find(selectedId.ToString());
                //DataRow findRow = current_table.AsEnumerable().SingleOrDefault(r => r.Field<int>("VendorId") == selectedId);
                //current_table.Rows.Remove(findRow);//delete on view(local)
                findRow.Delete();//delete on server

                // синхронизация данных с сервером
                UpdateManufacture();
           
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

            DataTable current_table = dsManufacturerAirplane.Tables["Airplanes"];

            // добавление нового поля
            DataRow dr = current_table.NewRow();
            dr["Model"] = airplane.Model;
            dr["Price"] = airplane.Price;
            dr["Speed"] = airplane.Speed;
            dr["VendorId"] = airplane.VendorId;
            dr["Vendor"] = "";//must be not NULL
            current_table.Rows.Add(dr);

            // синхронизация данных с сервером
            UpdateAirplane();
        
            //Подтвердить изминения(закрепить)
            current_table.AcceptChanges();

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

                DataTable current_table = dsManufacturerAirplane.Tables["Airplanes"];

                DataRow findRow = current_table.Rows.Find(selectedId.ToString());
                //DataRow findRow = current_table.AsEnumerable().SingleOrDefault(r => r.Field<int>("VendorId") == selectedId);
                //current_table.Rows.Remove(findRow);//delete on view(local)
                findRow.Delete();//delete on server

                // синхронизация данных с сервером
                UpdateAirplane();
             
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
            FillProjects();

            var result = dsProjectsEmployees.Tables["Projects"].AsEnumerable().Select(i => new Project
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
                     (from pe in dsProjectsEmployees.Tables["ProjectEmployees"].AsEnumerable()
                                           from e in dsProjectsEmployees.Tables["Employees"].AsEnumerable()
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
            FillEmployees();

            var result = dsProjectsEmployees.Tables["Employees"].AsEnumerable().Select(i => new Employee
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
                     (from pe in dsProjectsEmployees.Tables["ProjectEmployees"].AsEnumerable()
                      from p in dsProjectsEmployees.Tables["Projects"].AsEnumerable()
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

            DataTable current_table = dsProjectsEmployees.Tables["Projects"];

            // добавление нового поля
            DataRow dr = current_table.NewRow();
            dr["Title"] = project.Title;
            dr["StartDate"] = project.StartDate;
            dr["EndDate"] = project.EndDate;
            dr["Description"] = project.Description;
            current_table.Rows.Add(dr);

            // синхронизация данных с сервером
            UpdateProjects();
      
            //Подтвердить изминения(закрепить)
            current_table.AcceptChanges();

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

                DataTable current_table = dsProjectsEmployees.Tables["Projects"];

                DataRow findRow = current_table.Rows.Find(selectedId.ToString());
                //DataRow findRow = current_table.AsEnumerable().SingleOrDefault(r => r.Field<int>("VendorId") == selectedId);
                //current_table.Rows.Remove(findRow);//delete on view(local)
                findRow.Delete();//delete on server

                // синхронизация данных с сервером
                UpdateProjects();
          
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

            DataTable current_table = dsProjectsEmployees.Tables["Employees"];

            // добавление нового поля
            DataRow dr = current_table.NewRow();
            dr["FirstName"] = employee.FirstName;
            dr["LastName"] = employee.LastName;
            dr["Age"] = employee.Age;
            dr["Address"] = employee.Address;
            dr["FotoPath"] = employee.FotoPath;
            current_table.Rows.Add(dr);

            // синхронизация данных с сервером
            UpdateEmployees();
         
            //Подтвердить изминения(закрепить)
            current_table.AcceptChanges();

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

                DataTable current_table = dsProjectsEmployees.Tables["Employees"];

                DataRow findRow = current_table.Rows.Find(selectedId.ToString());
                //DataRow findRow = current_table.AsEnumerable().SingleOrDefault(r => r.Field<int>("VendorId") == selectedId);
                //current_table.Rows.Remove(findRow);//delete on view(local)
                findRow.Delete();//delete on server

                // синхронизация данных с сервером
                UpdateEmployees();
           
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
                        DataTable current_table = dsManufacturerAirplane.Tables["Manufacturers"];

                        if (changedManufacturer.VendorId == -1)//создание новой записи
                        {
                            DataRow dr = current_table.NewRow();
                            dr["BrandTitle"] = changedManufacturer.BrandTitle;
                            dr["Phone"] = changedManufacturer.Phone;
                            dr["Address"] = changedManufacturer.Address;

                            // добавление нового поля
                            current_table.Rows.Add(dr);
                        }
                        else
                        {
                            //    Manufacturer selectedManufacturerDB = (from m in dsManufacturerAirplane.Tables["Manufacturers"].AsEnumerable()
                            //                                            where (int)(m["VendorId"]) == selectedId
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

                            DataRow findRow = current_table.Rows.Find(selectedId.ToString());
                            //  int indexUpdateRow = current_table.Rows.IndexOf(findRow);
                            //  current_table.Rows[indexUpdateRow].BeginEdit();
                            //  current_table.Rows[indexUpdateRow]["FirstName"] = changedEmployee.FirstName;
                            //  current_table.Rows[indexUpdateRow]["LastName"] = changedEmployee.LastName;
                            //  current_table.Rows[indexUpdateRow]["Age"] = changedEmployee.Age;
                            //  current_table.Rows[indexUpdateRow]["Address"] = changedEmployee.Address;
                            //  current_table.Rows[indexUpdateRow]["FotoPath"] = changedEmployee.FotoPath;
                            //  current_table.Rows[indexUpdateRow].EndEdit();

                            findRow.BeginEdit();
                            findRow["BrandTitle"] = changedManufacturer.BrandTitle;
                            findRow["Phone"] = changedManufacturer.Phone;
                            findRow["Address"] = changedManufacturer.Address;
                            findRow.EndEdit();
                        }

                        // синхронизация данных с сервером
                        UpdateManufacture();
                
                        //Подтвердить изминения(закрепить)
                        current_table.AcceptChanges();

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
                    (from m in dsManufacturerAirplane.Tables["Manufacturers"].AsEnumerable()
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
                        DataTable current_table = dsManufacturerAirplane.Tables["Airplanes"];

                        if (changedAirplane.Id == -1)//создание новой записи
                        {
                            DataRow dr = current_table.NewRow();
                            dr["Model"] = changedAirplane.Model;
                            dr["Price"] = changedAirplane.Price;
                            dr["Speed"] = changedAirplane.Speed;
                            dr["VendorId"] = changedAirplane.VendorId;
                            dr["Vendor"] = dsManufacturerAirplane.Tables["Manufacturers"].AsEnumerable()
                                .Where(a => (int)a["VendorId"] == changedAirplane.VendorId)
                                .Select(a => (string)a["BrandTitle"]).SingleOrDefault();

                            // добавление нового поля
                            current_table.Rows.Add(dr);
                        }
                        else
                        {
                            //    Airplane selectedAirplaneDB = (from a in dsManufacturerAirplane.Tables["Airplanes"].AsEnumerable()
                            //                                    where (int)(a["Id"]) == selectedId
                            //                                    select new Airplane
                            //                                    {
                            //                                        Id = (int)(a["Id"]),
                            //                                        Model = (string)(a["Model"]),
                            //                                        Price = (double)(a["Price"]),
                            //                                        Speed = (int)(a["Speed"]),
                            //                                        VendorId = (int)(a["VendorId"]),
                            //                                        Vendor = (string)(a["Vendor"])
                            //                                    })?.First();
                            //
                            //    selectedAirplaneDB.Id = changedAirplane.Id;
                            //    selectedAirplaneDB.Model = changedAirplane.Model;
                            //    selectedAirplaneDB.Price = changedAirplane.Price;
                            //    selectedAirplaneDB.Speed = changedAirplane.Speed;
                            //    selectedAirplaneDB.VendorId = changedAirplane.VendorId;

                            DataRow findRow = current_table.Rows.Find(selectedId.ToString());
                            //  int indexUpdateRow = current_table.Rows.IndexOf(findRow);
                            //  current_table.Rows[indexUpdateRow].BeginEdit();
                            //  current_table.Rows[indexUpdateRow]["FirstName"] = changedEmployee.FirstName;
                            //  current_table.Rows[indexUpdateRow]["LastName"] = changedEmployee.LastName;
                            //  current_table.Rows[indexUpdateRow]["Age"] = changedEmployee.Age;
                            //  current_table.Rows[indexUpdateRow]["Address"] = changedEmployee.Address;
                            //  current_table.Rows[indexUpdateRow]["FotoPath"] = changedEmployee.FotoPath;
                            //  current_table.Rows[indexUpdateRow].EndEdit();

                            findRow.BeginEdit();
                            findRow["Model"] = changedAirplane.Model;
                            findRow["Price"] = changedAirplane.Price;
                            findRow["Speed"] = changedAirplane.Speed;
                            findRow["VendorId"] = changedAirplane.VendorId;
                            findRow.EndEdit();
                        }

                        // синхронизация данных с сервером
                        UpdateAirplane();
                
                        //Подтвердить изминения(закрепить)
                        current_table.AcceptChanges();

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
                        DataTable current_table = dsProjectsEmployees.Tables["Projects"];
                                                
                        if (changedProject.Id == -1)//создание новой записи
                        {
                            DataRow dr = current_table.NewRow();
                            dr["Title"] = changedProject.Title;
                            dr["StartDate"] = changedProject.StartDate;
                            dr["EndDate"] = changedProject.EndDate;
                            dr["Description"] = changedProject.Description;

                            // добавление нового поля
                            current_table.Rows.Add(dr);
                        }
                        else
                        {
                            //    Project selectedProjectDB = (from p in dsProjectsEmployees.Tables["Projects"].AsEnumerable()
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

                            DataRow findRow = current_table.Rows.Find(selectedId.ToString());
                            //  int indexUpdateRow = current_table.Rows.IndexOf(findRow);
                            //  current_table.Rows[indexUpdateRow].BeginEdit();
                            //  current_table.Rows[indexUpdateRow]["FirstName"] = changedEmployee.FirstName;
                            //  current_table.Rows[indexUpdateRow]["LastName"] = changedEmployee.LastName;
                            //  current_table.Rows[indexUpdateRow]["Age"] = changedEmployee.Age;
                            //  current_table.Rows[indexUpdateRow]["Address"] = changedEmployee.Address;
                            //  current_table.Rows[indexUpdateRow]["FotoPath"] = changedEmployee.FotoPath;
                            //  current_table.Rows[indexUpdateRow].EndEdit();

                            findRow.BeginEdit();
                            findRow["Title"] = changedProject.Title;
                            findRow["StartDate"] = changedProject.StartDate;
                            findRow["EndDate"] = changedProject.EndDate;
                            findRow["Description"] = changedProject.Description;
                            findRow.EndEdit();
                        }

                        // синхронизация данных с сервером
                        UpdateProjects();
                       
                        //Подтвердить изминения(закрепить)
                        current_table.AcceptChanges();

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
                        DataTable current_table = dsProjectsEmployees.Tables["Employees"];

                        if (changedEmployee.Id == -1)//создание новой записи
                        {
                            DataRow dr = current_table.NewRow();
                            dr["FirstName"] = changedEmployee.FirstName;
                            dr["LastName"] = changedEmployee.LastName;
                            dr["Age"] = changedEmployee.Age;
                            dr["Address"] = changedEmployee.Address;
                            dr["FotoPath"] = changedEmployee.FotoPath;

                            // добавление нового поля
                            current_table.Rows.Add(dr);
                        }
                        else
                        {
                        //    Employee selectedEmployeeDB = (from emp in dsProjectsEmployees.Tables["Employees"].AsEnumerable()
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

                            DataRow findRow = current_table.Rows.Find(selectedId.ToString());
                          //  int indexUpdateRow = current_table.Rows.IndexOf(findRow);
                          //  current_table.Rows[indexUpdateRow].BeginEdit();
                          //  current_table.Rows[indexUpdateRow]["FirstName"] = changedEmployee.FirstName;
                          //  current_table.Rows[indexUpdateRow]["LastName"] = changedEmployee.LastName;
                          //  current_table.Rows[indexUpdateRow]["Age"] = changedEmployee.Age;
                          //  current_table.Rows[indexUpdateRow]["Address"] = changedEmployee.Address;
                          //  current_table.Rows[indexUpdateRow]["FotoPath"] = changedEmployee.FotoPath;
                          //  current_table.Rows[indexUpdateRow].EndEdit();

                            findRow.BeginEdit();
                            findRow["FirstName"] = changedEmployee.FirstName;
                            findRow["LastName"] = changedEmployee.LastName;
                            findRow["Age"] = changedEmployee.Age;
                            findRow["Address"] = changedEmployee.Address;
                            findRow["FotoPath"] = changedEmployee.FotoPath;
                            findRow.EndEdit();
                        }

                        // синхронизация данных с сервером
                        UpdateEmployees();
                
                        //Подтвердить изминения(закрепить)
                        current_table.AcceptChanges();

                        // Обновить таблицу
                        RefreshEmployees();
                    }
                }

            }
        }
    }
}
