﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp_ADO_NET_LinqToSQL
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataClasses_ManufacturerAirplaneDataContext contextManufacturerAirplane = new DataClasses_ManufacturerAirplaneDataContext();
        DataClasses_ProjectsEmployeesDataContext contextProjectsEmployees = new DataClasses_ProjectsEmployeesDataContext();

        public MainWindow()
        {
            InitializeComponent();

            //dataGrid_Main.CellEditEnding += dataGrid_CellEditEnding;
        }

       public void RefreshManufacturer()
        {
            var result = from t in contextManufacturerAirplane.Manufacturers
                         select new Manufacturer
                         {
                             VendorId = t.VendorId,
                             BrandTitle = t.BrandTitle,
                             Address = t.Address,
                             Phone = t.Phone
                         };

            ObservableCollection<Manufacturer> observableCollection = new ObservableCollection<Manufacturer>(result);

            CollectionViewSource collection = new CollectionViewSource() { Source = observableCollection };
            collection.GroupDescriptions.Add(new PropertyGroupDescription("Address"));
            //collection.GroupDescriptions.Add(new PropertyGroupDescription("City"));
            //collection.SortDescriptions.Add(new SortDescription("City", ListSortDirection.Ascending));
            //collection.Filter += Collection_Filter;

            dataGrid_Main.Style = (Style)FindResource("dataGridManufacturer");

    
            dataGrid_Main.ItemsSource = collection.View;

            //            var statesList = (from t in context.authors
            //                              select t.state).Distinct();
            //            StateColumn.ItemsSource = statesList.ToList();

            //dataGrid1.Columns[0].Visibility = Visibility.Hidden;
        }

        public void RefreshAirplane()
        {
            var result = from t in contextManufacturerAirplane.Airplanes
                         select new Airplane
                         {
                             Id = t.Id,
                             Model = t.Model,
                             Price = t.Price,
                             Speed = t.Speed,
                             VendorId = t.VendorId,
                             Vendor = (from m in contextManufacturerAirplane.Manufacturers
                                       where m.VendorId == t.VendorId
                                       select m.BrandTitle).SingleOrDefault()
                         };

            ObservableCollection<Airplane> observableCollection = new ObservableCollection<Airplane>(result);

            CollectionViewSource collection = new CollectionViewSource() { Source = observableCollection };
            collection.GroupDescriptions.Add(new PropertyGroupDescription("Vendor"));
            //collection.GroupDescriptions.Add(new PropertyGroupDescription("City"));
            //collection.SortDescriptions.Add(new SortDescription("City", ListSortDirection.Ascending));
            //collection.Filter += Collection_Filter;

            dataGrid_Main.Style = (Style)FindResource("dataGridAirplane");

  
            dataGrid_Main.ItemsSource = collection.View;

            //            var statesList = (from t in context.authors
            //                              select t.state).Distinct();
            //            StateColumn.ItemsSource = statesList.ToList();

            //dataGrid1.Columns[0].Visibility = Visibility.Hidden;
        }


//       public void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
//       {
//           int selectedId = 0;
//
//           if (dataGrid_Main.SelectedItem is Airplane selectedAirplaneRow)
//           {
//               selectedId = selectedAirplaneRow.Id;
//
//               Airplanes selectedAirplaneDB = (from t in contextManufacturerAirplane.Airplanes
//                                               where t.Id == selectedId
//                                               select t)?.First();
//
//               selectedAirplaneDB.Id = selectedAirplaneRow.Id;
//               selectedAirplaneDB.Model = selectedAirplaneRow.Model;
//               selectedAirplaneDB.Price = selectedAirplaneRow.Price;
//               selectedAirplaneDB.Speed = selectedAirplaneRow.Speed;
//               selectedAirplaneDB.VendorId = selectedAirplaneRow.VendorId;
//
//               contextManufacturerAirplane.SubmitChanges();
//
//               RefreshAirplane();
//           }
//
//           if (dataGrid_Main.SelectedItem is Manufacturer selectedManufacturerRow)
//           {
//               selectedId = selectedManufacturerRow.VendorId;
//
//               Manufacturers selectedManufacturerDB = (from t in contextManufacturerAirplane.Manufacturers
//                                                       where t.VendorId == selectedId
//                                                       select t)?.First();
//
//               selectedManufacturerDB.VendorId = selectedManufacturerRow.VendorId;
//               selectedManufacturerDB.BrandTitle = selectedManufacturerRow.BrandTitle;
//               selectedManufacturerDB.Address = selectedManufacturerRow.Address;
//               selectedManufacturerDB.Phone = selectedManufacturerRow.Phone;
//
//               contextManufacturerAirplane.SubmitChanges();
//
//               RefreshManufacturer();
//           }
//
//           if (dataGrid_Main.SelectedItem is Project selectedProjectsRow)
//           {
//               selectedId = selectedProjectsRow.Id;
//
//               Projects selectedProjectDB = (from t in contextProjectsEmployees.Projects
//                                             where t.Id == selectedId
//                                             select t)?.First();
//
//               selectedProjectDB.Id = selectedProjectsRow.Id;
//               selectedProjectDB.Title = selectedProjectsRow.Title;
//               selectedProjectDB.StartDate = selectedProjectsRow.StartDate;
//               selectedProjectDB.EndDate = selectedProjectsRow.EndDate;
//               selectedProjectDB.Description = selectedProjectsRow.Description;
//
//               contextProjectsEmployees.SubmitChanges();
//
//               RefreshProjects();
//           }
//
//           if (dataGrid_Main.SelectedItem is Employee selectedEmployeeRow)
//           {
//               selectedId = selectedEmployeeRow.Id;
//
//               Employees selectedEmployeeDB = (from t in contextProjectsEmployees.Employees
//                                               where t.Id == selectedId
//                                               select t)?.First();
//
//               selectedEmployeeDB.Id = selectedEmployeeRow.Id;
//               selectedEmployeeDB.FirstName = selectedEmployeeRow.FirstName;
//               selectedEmployeeDB.LastName = selectedEmployeeRow.LastName;
//               selectedEmployeeDB.Age = selectedEmployeeRow.Age;
//               selectedEmployeeDB.Address = selectedEmployeeRow.Address;
//               selectedEmployeeDB.FotoPath = selectedEmployeeRow.FotoPath;
//
//               contextManufacturerAirplane.SubmitChanges();
//
//               RefreshEmployees();
//           }
//       }
//       public void dataGrid_Manufacturer_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
//       {
//           int selectedId = 0;
//           if (dataGrid_Main.SelectedItem is Manufacturer selectedManufacturerRow)
//           {
//               selectedId = selectedManufacturerRow.VendorId;
//
//               Manufacturers selectedManufacturerDB = (from t in contextManufacturerAirplane.Manufacturers
//                                                       where t.VendorId == selectedId
//                                                       select t)?.First();
//
//               selectedManufacturerDB.VendorId = selectedManufacturerRow.VendorId;
//               selectedManufacturerDB.BrandTitle = selectedManufacturerRow.BrandTitle;
//               selectedManufacturerDB.Address = selectedManufacturerRow.Address;
//               selectedManufacturerDB.Phone = selectedManufacturerRow.Phone;
//
//               contextManufacturerAirplane.SubmitChanges();
//
//               RefreshManufacturer();
//           }
//       }
//
//       public void dataGrid_Airplane_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
//       {
//           int selectedId = 0;
//           if (dataGrid_Main.SelectedItem is Airplane selectedAirplaneRow)
//           {
//               selectedId = selectedAirplaneRow.Id;
//
//               Airplanes selectedAirplaneDB = (from t in contextManufacturerAirplane.Airplanes
//                                               where t.Id == selectedId
//                                               select t)?.First();
//
//               selectedAirplaneDB.Id = selectedAirplaneRow.Id;
//               selectedAirplaneDB.Model = selectedAirplaneRow.Model;
//               selectedAirplaneDB.Price = selectedAirplaneRow.Price;
//               selectedAirplaneDB.Speed = selectedAirplaneRow.Speed;
//               selectedAirplaneDB.VendorId = selectedAirplaneRow.VendorId;
//
//               contextManufacturerAirplane.SubmitChanges();
//
//               RefreshAirplane();
//           }
//       }
//
//        private void dataGrid_Manufacturer_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
//        {
//            switch (e.PropertyName)
//            {
//                case "VendorId":
//                case "BrandTitle":
//                case "Address":
//                case "Phone":
//
//                case "Id":
//                case "Model":
//                case "Price":
//                case "Speed":
//                    e.Cancel = true;
//                    break;
//                default:
//                    break;
//            }
//        }
//
//        private void dataGrid_Airplane_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
//        {
//            switch (e.PropertyName)
//            {
//                case "VendorId":
//                case "BrandTitle":
//                case "Address":
//                case "Phone":
//
//                case "Id":
//                case "Model":
//                case "Price":
//                case "Speed":
//                    e.Cancel = true;
//                    break;
//                default:
//                    break;
//            }
//        }

        private void ShowManufacturer_Click(object sender, RoutedEventArgs e)
        {
            RefreshManufacturer();
        }

        private void AddManufacturer_Click(object sender, RoutedEventArgs e)
        {
            Manufacturers manufacturer = new Manufacturers
            {
                BrandTitle = "Fokker",
                Phone = "(099) 322-45-33",
                Address = "Голландия"
            };

            contextManufacturerAirplane.Manufacturers.InsertOnSubmit(manufacturer);

            contextManufacturerAirplane.SubmitChanges();

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

                Manufacturers del_manufacturer = (from t in contextManufacturerAirplane.Manufacturers
                                                  where t.VendorId == selectedId
                                                  select t).First();

                // Удалить из БД автора с данным ID
                contextManufacturerAirplane.Manufacturers.DeleteOnSubmit(del_manufacturer);

                // Синхронизировать изменения
                contextManufacturerAirplane.SubmitChanges();

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
            Airplanes airplane = new Airplanes
            {
                Model = "Airbus A220-100",
                Price = 345000000,
                Speed = 670,
                VendorId = 2
            };

            contextManufacturerAirplane.Airplanes.InsertOnSubmit(airplane);

            contextManufacturerAirplane.SubmitChanges();

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

                Airplanes del_airplane = (from t in contextManufacturerAirplane.Airplanes
                                          where t.Id == selectedId
                                          select t).First();

                // Удалить из БД автора с данным ID
                contextManufacturerAirplane.Airplanes.DeleteOnSubmit(del_airplane);

                // Синхронизировать изменения
                contextManufacturerAirplane.SubmitChanges();

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

            //var result =
            //    from a in contextManufacturerAirplane.Airplanes
            //    join m in contextManufacturerAirplane.Manufacturers on a.VendorId equals m.VendorId
            //    where a.Speed<600
            //    select new
            //    {
            //        Id = a.Id,
            //        Model = a.Model,
            //        Price = a.Price,
            //        Speed = a.Speed,
            //        BrandTitle = m.BrandTitle
            //    };

            var result = contextManufacturerAirplane.Airplanes
                .Where(a => a.Speed < 600)
                .Join(contextManufacturerAirplane.Manufacturers
                    , a => a.VendorId, m => m.VendorId,
                    (a, m) => new
                    {
                        Id = a.Id,
                        Model = a.Model,
                        Price = a.Price,
                        Speed = a.Speed,
                        BrandTitle = m.BrandTitle
                    });




            Window DataGridPresent = new Window_DataGrid(result.ToList());

            DataGridPresent.Show();
            //            dataGrid_Main.ItemsSource = result.ToList();
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

            var result =
              from a in contextManufacturerAirplane.Airplanes
              group a by a.VendorId into grp
              where grp.Count() > 3
              join m in contextManufacturerAirplane.Manufacturers on grp.Key equals m.VendorId
              select new
              {
                  BrandTitle = m.BrandTitle
              };


            //var result =
            //    contextManufacturerAirplane.Airplanes.GroupBy(a => a.VendorId).Select(g => new { g.Key, Count = g.Count() }).Where(d=>d.Count>3)
            //    .Join(contextManufacturerAirplane.Manufacturers,
            //    g => g.Key, m => m.VendorId,
            //    (g, m) => new
            //    {
            //        BrandTitle = m.BrandTitle
            //    }).Distinct();


            Window DataGridPresent = new Window_DataGrid(result.ToList());

            DataGridPresent.Show();
            //            dataGrid_Main.ItemsSource = result.ToList();
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

            var result =
                from m in contextManufacturerAirplane.Manufacturers
                where m.BrandTitle.Length < 7
                select new
                {
                    BrandTitle = m.BrandTitle
                };

            //var result = contextManufacturerAirplane.Manufacturers
            //    .Where(a => a.BrandTitle.Length<7)
            //    .Select(a=> new
            //        {
            //            BrandTitle = a.BrandTitle
            //        });


            Window DataGridPresent = new Window_DataGrid(result.ToList());

            DataGridPresent.Show();
            //            dataGrid_Main.ItemsSource = result.ToList();
        }

        class MyData_GetAirplaineWithSpeedLess
        {
            public int Id { get; set; }
            public string Model { get; set; }
            public double Price { get; set; }
            public int Speed { get; set; }
            public string BrandTitle { get; set; }
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

            // Параметризированный запрос, состоящий из LINQ и SQL, вызывающий хранимую функцию
            var result = contextManufacturerAirplane.GetAirplaineWithSpeedLess(600);

            //            // Параметризированный запрос, состоящий из LINQ и SQL, вызывающий хранимую функцию
            //            SqlParameter parameter = new SqlParameter("@state", "CA");
            //            var result = from t in context.Database.SqlQuery<author>("select * from GetAuthorsByState(@state)", parameter)
            //                         select new MyAuthor
            //                         {
            //                             Au_id = t.au_id,
            //                             FirstName = t.au_fname,
            //                             LastName = t.au_lname,
            //                             City = t.city,
            //                             State = t.state,
            //                             Phone = t.phone,
            //                             Address = t.address,
            //                             Zip = t.zip,
            //                             Contract = t.contract
            //                         };

            Window DataGridPresent = new Window_DataGrid(result.ToList());

            DataGridPresent.Show();
            //            dataGrid_Main.ItemsSource = result.ToList();
        }

        class MyData_GetManufacturerWithAirplaneMore
        {
            public string BrandTitle { get; set; }
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
            // Параметризированный запрос, состоящий из LINQ и SQL, вызывающий хранимую функцию
            var result = contextManufacturerAirplane.GetManufacturerWithAirplaneMore(3);


            //            // Параметризированный запрос, состоящий из LINQ и SQL, вызывающий хранимую функцию
            //            SqlParameter parameter = new SqlParameter("@state", "CA");
            //            var result = from t in context.Database.SqlQuery<author>("select * from GetAuthorsByState(@state)", parameter)
            //                         select new MyAuthor
            //                         {
            //                             Au_id = t.au_id,
            //                             FirstName = t.au_fname,
            //                             LastName = t.au_lname,
            //                             City = t.city,
            //                             State = t.state,
            //                             Phone = t.phone,
            //                             Address = t.address,
            //                             Zip = t.zip,
            //                             Contract = t.contract
            //                         };

            Window DataGridPresent = new Window_DataGrid(result.ToList());

            DataGridPresent.Show();
            //            dataGrid_Main.ItemsSource = result.ToList();
        }
        class MyData_GetManufacturerNameWithLengthLess
        {
            public string BrandTitle { get; set; }
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
            // Параметризированный запрос, состоящий из LINQ и SQL, вызывающий хранимую функцию
            var result = contextManufacturerAirplane.GetManufacturerNameWithLengthLess(7);


            //            // Параметризированный запрос, состоящий из LINQ и SQL, вызывающий хранимую функцию
            //            SqlParameter parameter = new SqlParameter("@state", "CA");
            //            var result = from t in context.Database.SqlQuery<author>("select * from GetAuthorsByState(@state)", parameter)
            //                         select new MyAuthor
            //                         {
            //                             Au_id = t.au_id,
            //                             FirstName = t.au_fname,
            //                             LastName = t.au_lname,
            //                             City = t.city,
            //                             State = t.state,
            //                             Phone = t.phone,
            //                             Address = t.address,
            //                             Zip = t.zip,
            //                             Contract = t.contract
            //                         };

            Window DataGridPresent = new Window_DataGrid(result.ToList());

            DataGridPresent.Show();
            //            dataGrid_Main.ItemsSource = result.ToList();
        }




        public void RefreshProjects()
        {
            var result = from t in contextProjectsEmployees.Projects
                         select new Project
                         {
                             Id = t.Id,
                             Title = t.Title,
                             StartDate = t.StartDate,
                             EndDate = t.EndDate,
                             Description = t.Description,
                             Employees = ((ICollection<Employees>)(from e in contextProjectsEmployees.Employees
                                                                   from pe in contextProjectsEmployees.ProjectEmployees
                                                                   where e.Id == pe.EmployeeId
                                                                   where pe.ProjectId == t.Id
                                                                   select e))
                         };

            ObservableCollection<Project> observableCollection = new ObservableCollection<Project>(result);

            CollectionViewSource collection = new CollectionViewSource() { Source = observableCollection };
            collection.GroupDescriptions.Add(new PropertyGroupDescription("StartDate"));
            //collection.GroupDescriptions.Add(new PropertyGroupDescription("City"));
            //collection.SortDescriptions.Add(new SortDescription("City", ListSortDirection.Ascending));
            //collection.Filter += Collection_Filter;
           
            dataGrid_Main.Style = (Style)FindResource("dataGridProjects");

   
            dataGrid_Main.ItemsSource = collection.View;

            //            var statesList = (from t in context.authors
            //                              select t.state).Distinct();
            //            StateColumn.ItemsSource = statesList.ToList();

            //dataGrid1.Columns[0].Visibility = Visibility.Hidden;
        }


//        public void dataGrid_Projects_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
//        {
//            int selectedId = 0;
//            if (dataGrid_Main.SelectedItem is Project selectedProjectsRow)
//            {
//                selectedId = selectedProjectsRow.Id;
//
//                Projects selectedProjectDB = (from t in contextProjectsEmployees.Projects
//                                              where t.Id == selectedId
//                                              select t)?.First();
//
//                selectedProjectDB.Id = selectedProjectsRow.Id;
//                selectedProjectDB.Title = selectedProjectsRow.Title;
//                selectedProjectDB.StartDate = selectedProjectsRow.StartDate;
//                selectedProjectDB.EndDate = selectedProjectsRow.EndDate;
//                selectedProjectDB.Description = selectedProjectsRow.Description;
//
//                contextProjectsEmployees.SubmitChanges();
//
//                RefreshProjects();
//            }
//        }
//
//        private void dataGrid_Projects_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
//        {
//            switch (e.PropertyName)
//            {
//                case "Id":
//                case "FirstName":
//                case "LastName":
//                case "Age":
//                case "Address":
//                case "FotoPath":
//
//                case "Title":
//                case "StartDate":
//                case "EndDate":
//                case "Description":
//                    e.Cancel = true;
//                    break;
//                default:
//                    break;
//            }
//        }

        public void RefreshEmployees()
        {
            var result = from t in contextProjectsEmployees.Employees
                         select new Employee
                         {
                             Id = t.Id,
                             FirstName = t.FirstName,
                             LastName = t.LastName,
                             Age = t.Age,
                             Address = t.Address,
                             FotoPath = t.FotoPath,
                             Projects = ((ICollection<Projects>)(from p in contextProjectsEmployees.Projects
                                         from pe in contextProjectsEmployees.ProjectEmployees
                                         where p.Id==pe.ProjectId
                                         where pe.EmployeeId==t.Id
                                         select p))
                         };

            ObservableCollection<Employee> observableCollection = new ObservableCollection<Employee>(result);

            CollectionViewSource collection = new CollectionViewSource() { Source = observableCollection };
            collection.GroupDescriptions.Add(new PropertyGroupDescription("Age"));
            //collection.GroupDescriptions.Add(new PropertyGroupDescription("City"));
            //collection.SortDescriptions.Add(new SortDescription("City", ListSortDirection.Ascending));
            //collection.Filter += Collection_Filter;

            dataGrid_Main.Style = (Style)FindResource("dataGridEmployees");

  
            dataGrid_Main.ItemsSource = collection.View;

            //            var statesList = (from t in context.authors
            //                              select t.state).Distinct();
            //            StateColumn.ItemsSource = statesList.ToList();

            //dataGrid1.Columns[0].Visibility = Visibility.Hidden;
        }

//        public void dataGrid_Employees_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
//        {
//            int selectedId = 0;
//            if (dataGrid_Main.SelectedItem is Employee selectedEmployeeRow)
//            {
//                selectedId = selectedEmployeeRow.Id;
//
//                Employees selectedEmployeeDB = (from t in contextProjectsEmployees.Employees
//                                                where t.Id == selectedId
//                                                select t)?.First();
//
//                selectedEmployeeDB.Id = selectedEmployeeRow.Id;
//                selectedEmployeeDB.FirstName = selectedEmployeeRow.FirstName;
//                selectedEmployeeDB.LastName = selectedEmployeeRow.LastName;
//                selectedEmployeeDB.Age = selectedEmployeeRow.Age;
//                selectedEmployeeDB.Address = selectedEmployeeRow.Address;
//                selectedEmployeeDB.FotoPath = selectedEmployeeRow.FotoPath;
//
//                contextManufacturerAirplane.SubmitChanges();
//
//                RefreshEmployees();
//            }
//        }
//
//        private void dataGrid_Employees_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
//        {
//            switch (e.PropertyName)
//            {
//                case "Id":
//                case "FirstName":
//                case "LastName":
//                case "Age":
//                case "Address":
//                case "FotoPath":
//
//                case "Title":
//                case "StartDate":
//                case "EndDate":
//                case "Description":
//                    e.Cancel = true;
//                    break;
//                default:
//                    break;
//            }
//        }

        private void ShowProjects_Click(object sender, RoutedEventArgs e)
        {
            RefreshProjects();
        }

        private void AddProjects_Click(object sender, RoutedEventArgs e)
        {
            Projects project = new Projects
            {
                Title = "Creative System for Gratulation!!!",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Description = "New Funny Project"
            };

            contextProjectsEmployees.Projects.InsertOnSubmit(project);

            contextProjectsEmployees.SubmitChanges();

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

                Projects del_project = (from t in contextProjectsEmployees.Projects
                                        where t.Id == selectedId
                                        select t).First();

                // Удалить из БД автора с данным ID
                contextProjectsEmployees.Projects.DeleteOnSubmit(del_project);

                // Синхронизировать изменения
                contextProjectsEmployees.SubmitChanges();

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
            Employees employee = new Employees
            {
                FirstName = "Petr",
                LastName = "Lionesku",
                Age = 32,
                Address = "Большевитская улица, дом 14",
                FotoPath = "\\resources\\catBlue.jpg"
            };

            contextProjectsEmployees.Employees.InsertOnSubmit(employee);

            contextProjectsEmployees.SubmitChanges();

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

                Employees del_employee = (from t in contextProjectsEmployees.Employees
                                          where t.Id == selectedId
                                          select t).First();

                // Удалить из БД автора с данным ID
                contextProjectsEmployees.Employees.DeleteOnSubmit(del_employee);

                // Синхронизировать изменения
                contextProjectsEmployees.SubmitChanges();

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


            var result =
                from p in contextProjectsEmployees.Projects
                where p.Id == (contextProjectsEmployees.ProjectEmployees.GroupBy(g=>g.ProjectId).Select(s=>new {s.Key,Count=s.Count()}).OrderByDescending(a=>a.Count).FirstOrDefault().Key)
                select new
                {
                    p.Id,
                    p.Title
                };

            //var result = contextProjectsEmployees.Projects
            //    .Where(a => a== (contextProjectsEmployees.Projects.OrderByDescending(s=>s.Employees.Count).FirstOrDefault()))
            //    .Select(p=> new
            //        {
            //        p.Id,
            //        p.Title
            //        });


            Window DataGridPresent = new Window_DataGrid(result.ToList());

            DataGridPresent.Show();
            //            dataGrid_Main.ItemsSource = result.ToList();
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

            //var result =
            //    from emp in contextProjectsEmployees.Employees
            //    where emp.Age < 35
            //    select new
            //    {
            //        emp.FirstName,
            //        emp.LastName
            //    };

            var result = contextProjectsEmployees.Employees
                .Where(a => a.Age < 35)
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName
                });


            Window DataGridPresent = new Window_DataGrid(result.ToList());

            DataGridPresent.Show();
            //            dataGrid_Main.ItemsSource = result.ToList();
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

            //var result =
            //    from emp in contextProjectsEmployees.Employees
            //    where emp.LastName.Length >= 5
            //    select new
            //    {
            //        FirstName = emp.FirstName,
            //        LastName = emp.LastName
            //    };

            var result = contextProjectsEmployees.Employees
                .Where(a => a.LastName.Length >= 5)
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName
                });

            Window DataGridPresent = new Window_DataGrid(result.ToList());

            DataGridPresent.Show();
            //            dataGrid_Main.ItemsSource = result.ToList();
        }

        class MyData_GetProjectWithMaxEmployees
        {
            public int? Id { get; set; }
            public string Title { get; set; }
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
            // Параметризированный запрос, состоящий из LINQ и SQL, вызывающий хранимую функцию
            var result = contextProjectsEmployees.GetProjectWithMaxEmployees();


            //            // Параметризированный запрос, состоящий из LINQ и SQL, вызывающий хранимую функцию
            //            SqlParameter parameter = new SqlParameter("@state", "CA");
            //            var result = from t in context.Database.SqlQuery<author>("select * from GetAuthorsByState(@state)", parameter)
            //                         select new MyAuthor
            //                         {
            //                             Au_id = t.au_id,
            //                             FirstName = t.au_fname,
            //                             LastName = t.au_lname,
            //                             City = t.city,
            //                             State = t.state,
            //                             Phone = t.phone,
            //                             Address = t.address,
            //                             Zip = t.zip,
            //                             Contract = t.contract
            //                         };

            Window DataGridPresent = new Window_DataGrid(result.ToList());

            DataGridPresent.Show();
            //            dataGrid_Main.ItemsSource = result.ToList();
        }
        class MyData_GetEmployeerWithAgeLess
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
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
            // Параметризированный запрос, состоящий из LINQ и SQL, вызывающий хранимую функцию
            var result = contextProjectsEmployees.GetEmployeerWithAgeLess(35);


            //            // Параметризированный запрос, состоящий из LINQ и SQL, вызывающий хранимую функцию
            //            SqlParameter parameter = new SqlParameter("@state", "CA");
            //            var result = from t in context.Database.SqlQuery<author>("select * from GetAuthorsByState(@state)", parameter)
            //                         select new MyAuthor
            //                         {
            //                             Au_id = t.au_id,
            //                             FirstName = t.au_fname,
            //                             LastName = t.au_lname,
            //                             City = t.city,
            //                             State = t.state,
            //                             Phone = t.phone,
            //                             Address = t.address,
            //                             Zip = t.zip,
            //                             Contract = t.contract
            //                         };

            Window DataGridPresent = new Window_DataGrid(result.ToList());

            DataGridPresent.Show();
            //            dataGrid_Main.ItemsSource = result.ToList();
        }

        class MyData_GetEmployeerWithLastNameLengthMoreOrEqual
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
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
            // Параметризированный запрос, состоящий из LINQ и SQL, вызывающий хранимую функцию
            var result = contextProjectsEmployees.GetEmployeerWithLastNameLengthMoreOrEqual(5);


            //            // Параметризированный запрос, состоящий из LINQ и SQL, вызывающий хранимую функцию
            //            SqlParameter parameter = new SqlParameter("@state", "CA");
            //            var result = from t in context.Database.SqlQuery<author>("select * from GetAuthorsByState(@state)", parameter)
            //                         select new MyAuthor
            //                         {
            //                             Au_id = t.au_id,
            //                             FirstName = t.au_fname,
            //                             LastName = t.au_lname,
            //                             City = t.city,
            //                             State = t.state,
            //                             Phone = t.phone,
            //                             Address = t.address,
            //                             Zip = t.zip,
            //                             Contract = t.contract
            //                         };

            Window DataGridPresent = new Window_DataGrid(result.ToList());

            DataGridPresent.Show();
            //            dataGrid_Main.ItemsSource = result.ToList();
        }

        private void dataGrid_Main_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dataGrid_Main.SelectedItem != null)
            {
                if (dataGrid_Main.SelectedItem is Manufacturer manufacturer)
                {
                    // Получить ID выделенного автора
                    int selectedId = manufacturer.VendorId;

                    // Получить выделенного автора
                    Manufacturers selectedManufacturerDB = (from t in contextManufacturerAirplane.Manufacturers
                                                            where t.VendorId == selectedId
                                                            select t)?.First();

                    Window_Change window_change = new Window_Change(selectedManufacturerDB);

                    Manufacturers changedManufacturer = null;//ожидаем изминенный обьект
                    window_change.ReturnObject += res => changedManufacturer = res as Manufacturers;//по событию забираем изминенный объект

                    if (window_change.ShowDialog() == true)
                    {
                        if (changedManufacturer.VendorId == -1)//создание новой записи
                        {
                            contextManufacturerAirplane.Manufacturers.InsertOnSubmit(changedManufacturer);
                        }
                        else
                        {
                            selectedManufacturerDB.VendorId = changedManufacturer.VendorId;
                            selectedManufacturerDB.BrandTitle = changedManufacturer.BrandTitle;
                            selectedManufacturerDB.Address = changedManufacturer.Address;
                            selectedManufacturerDB.Phone = changedManufacturer.Phone;
                        }

                        contextManufacturerAirplane.SubmitChanges();

                        // Обновить таблицу
                        RefreshManufacturer();
                    }
                }

                if (dataGrid_Main.SelectedItem is Airplane airplane)
                {
                    // Получить ID выделенного автора
                    int selectedId = airplane.Id;

                    // Получить выделенного автора
                    Airplanes selectedAirplaneDB = (from t in contextManufacturerAirplane.Airplanes
                                                    where t.Id == selectedId
                                                    select t)?.First();

                    Window_Change window_change = new Window_Change(selectedAirplaneDB);

                    var dictVendorIdBrandTitle =
                    contextManufacturerAirplane.Manufacturers.Select(m => new { Key = m.VendorId, Value = m.BrandTitle }).AsEnumerable().ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

                    window_change.DictionaryVendorIdBrandTitle = dictVendorIdBrandTitle;

                    Airplanes changedAirplane = null;//ожидаем изминенный обьект
                    window_change.ReturnObject += res => changedAirplane = res as Airplanes;//по событию забираем изминенный объект

                    if (window_change.ShowDialog() == true)
                    {
                        if (changedAirplane.Id == -1)//создание новой записи
                        {
                            contextManufacturerAirplane.Airplanes.InsertOnSubmit(changedAirplane);
                        }
                        else
                        {                        
                            selectedAirplaneDB.Id = changedAirplane.Id;
                            selectedAirplaneDB.Model = changedAirplane.Model;
                            selectedAirplaneDB.Price = changedAirplane.Price;
                            selectedAirplaneDB.Speed = changedAirplane.Speed;
                            selectedAirplaneDB.VendorId = changedAirplane.VendorId;
                        }

                        contextManufacturerAirplane.SubmitChanges();

                        // Обновить таблицу
                        RefreshAirplane();
                    }
                }

                if (dataGrid_Main.SelectedItem is Project project)
                {
                    // Получить ID выделенного автора
                    int selectedId = project.Id;

                    // Получить выделенного автора
                    Projects selectedProjectDB = (from t in contextProjectsEmployees.Projects
                                                  where t.Id == selectedId
                                                  select t)?.First();

                    Window_Change window_change = new Window_Change(selectedProjectDB);

                    Projects changedProject = null;//ожидаем изминенный обьект
                    window_change.ReturnObject += res => changedProject = res as Projects;//по событию забираем изминенный объект

                    if (window_change.ShowDialog() == true)
                    {
                        if (changedProject.Id == -1)//создание новой записи
                        {
                            contextProjectsEmployees.Projects.InsertOnSubmit(changedProject);
                        }
                        else
                        {
                            selectedProjectDB.Id = changedProject.Id;
                            selectedProjectDB.Title = changedProject.Title;
                            selectedProjectDB.StartDate = changedProject.StartDate;
                            selectedProjectDB.EndDate = changedProject.EndDate;
                            selectedProjectDB.Description = changedProject.Description;
                        }

                        contextProjectsEmployees.SubmitChanges();

                        // Обновить таблицу
                        RefreshProjects();
                    }
                }

                if (dataGrid_Main.SelectedItem is Employee employee)
                {
                    // Получить ID выделенного автора
                    int selectedId = employee.Id;

                    // Получить выделенного автора
                    Employees selectedEmployeeDB = (from t in contextProjectsEmployees.Employees
                                                    where t.Id == selectedId
                                                    select t)?.First();

                    Window_Change window_change = new Window_Change(selectedEmployeeDB);

                    Employees changedEmployee = null;//ожидаем изминенный обьект
                    window_change.ReturnObject += res => changedEmployee = res as Employees;//по событию забираем изминенный объект

                    if (window_change.ShowDialog() == true)
                    {
                        if (changedEmployee.Id == -1)//создание новой записи
                        {
                            contextProjectsEmployees.Employees.InsertOnSubmit(changedEmployee);
                        }
                        else
                        {                           
                            selectedEmployeeDB.Id = changedEmployee.Id;
                            selectedEmployeeDB.FirstName = changedEmployee.FirstName;
                            selectedEmployeeDB.LastName = changedEmployee.LastName;
                            selectedEmployeeDB.Age = changedEmployee.Age;
                            selectedEmployeeDB.Address = changedEmployee.Address;
                            selectedEmployeeDB.FotoPath = changedEmployee.FotoPath;
                        }

                        contextProjectsEmployees.SubmitChanges();

                        // Обновить таблицу
                        RefreshEmployees();
                    }
                }

            }
        }
    }
}
