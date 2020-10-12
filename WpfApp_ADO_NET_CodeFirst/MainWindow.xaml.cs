using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp_ADO_NET_CodeFirst
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Model_ManufacturerAirplane contextManufacturerAirplane = new Model_ManufacturerAirplane();
        Model_ProjectsEmployees contextProjectsEmployees = new Model_ProjectsEmployees();

        public MainWindow()
        {
            InitializeComponent();
        }

        EventHandler<DataGridCellEditEndingEventArgs> eventCellEditEnding;
        EventHandler<DataGridAutoGeneratingColumnEventArgs> eventAutoGeneratingColumn;
        public void RefreshManufacturer()
        {
            var result = from t in contextManufacturerAirplane.Manufacturers
                         select t;

            ObservableCollection<Manufacturer> observableCollection = new ObservableCollection<Manufacturer>(result);

            CollectionViewSource collection = new CollectionViewSource() { Source = observableCollection };
            collection.GroupDescriptions.Add(new PropertyGroupDescription("BrandTitle"));
            //collection.GroupDescriptions.Add(new PropertyGroupDescription("City"));
            //collection.SortDescriptions.Add(new SortDescription("City", ListSortDirection.Ascending));
            //collection.Filter += Collection_Filter;

            dataGrid_Main.Style = (Style)FindResource("dataGridManufacturer");
            dataGrid_Main.CellEditEnding += dataGrid_Manufacturer_CellEditEnding;
            dataGrid_Main.AutoGeneratingColumn += dataGrid_Manufacturer_AutoGeneratingColumn;

            dataGrid_Main.CellEditEnding -= eventCellEditEnding;
            dataGrid_Main.AutoGeneratingColumn -= eventAutoGeneratingColumn;
            eventCellEditEnding = dataGrid_Manufacturer_CellEditEnding;
            eventAutoGeneratingColumn = dataGrid_Manufacturer_AutoGeneratingColumn;

            dataGrid_Main.ItemsSource = collection.View;

            //            var statesList = (from t in context.authors
            //                              select t.state).Distinct();
            //            StateColumn.ItemsSource = statesList.ToList();

            //dataGrid1.Columns[0].Visibility = Visibility.Hidden;
        }

        public void RefreshAirplane()
        {
            var result = from t in contextManufacturerAirplane.Airplanes
                         select t;

            ObservableCollection<Airplane> observableCollection = new ObservableCollection<Airplane>(result);

            CollectionViewSource collection = new CollectionViewSource() { Source = observableCollection };
            collection.GroupDescriptions.Add(new PropertyGroupDescription("Manufacturer.BrandTitle"));
            //collection.GroupDescriptions.Add(new PropertyGroupDescription("City"));
            //collection.SortDescriptions.Add(new SortDescription("City", ListSortDirection.Ascending));
            //collection.Filter += Collection_Filter;

            dataGrid_Main.Style = (Style)FindResource("dataGridAirplane");
            dataGrid_Main.CellEditEnding += dataGrid_Airplane_CellEditEnding;
            dataGrid_Main.AutoGeneratingColumn += dataGrid_Airplane_AutoGeneratingColumn;

            dataGrid_Main.CellEditEnding -= eventCellEditEnding;
            dataGrid_Main.AutoGeneratingColumn -= eventAutoGeneratingColumn;
            eventCellEditEnding = dataGrid_Airplane_CellEditEnding;
            eventAutoGeneratingColumn = dataGrid_Airplane_AutoGeneratingColumn;

            dataGrid_Main.ItemsSource = collection.View;

            //            var statesList = (from t in context.authors
            //                              select t.state).Distinct();
            //            StateColumn.ItemsSource = statesList.ToList();

            //dataGrid1.Columns[0].Visibility = Visibility.Hidden;
        }

        public void dataGrid_Manufacturer_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            int selectedId = 0;
            if (dataGrid_Main.SelectedItem is Manufacturer selectedManufacturerRow)
            {
                selectedId = selectedManufacturerRow.VendorId;

                Manufacturer selectedManufacturerDB = (from t in contextManufacturerAirplane.Manufacturers
                                           where t.VendorId == selectedId
                                           select t)?.First();

                selectedManufacturerDB.VendorId = selectedManufacturerRow.VendorId;
                selectedManufacturerDB.BrandTitle = selectedManufacturerRow.BrandTitle;
                selectedManufacturerDB.Address = selectedManufacturerRow.Address;
                selectedManufacturerDB.Phone = selectedManufacturerRow.Phone;

                contextManufacturerAirplane.SaveChanges();

                RefreshManufacturer();
            }
        }

        public void dataGrid_Airplane_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            int selectedId = 0;
            if (dataGrid_Main.SelectedItem is Airplane selectedAirplaneRow)
            {
                selectedId = selectedAirplaneRow.Id;

                Airplane selectedAirplaneDB = (from t in contextManufacturerAirplane.Airplanes
                                           where t.Id == selectedId
                                           select t)?.First();

                selectedAirplaneDB.Id = selectedAirplaneRow.Id;
                selectedAirplaneDB.Model = selectedAirplaneRow.Model;
                selectedAirplaneDB.Price = selectedAirplaneRow.Price;
                selectedAirplaneDB.Speed = selectedAirplaneRow.Speed;
                selectedAirplaneDB.VendorId = selectedAirplaneRow.VendorId;
                
                contextManufacturerAirplane.SaveChanges();

                RefreshAirplane();
            }
        }

        private void dataGrid_Manufacturer_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "VendorId":
                case "BrandTitle":
                case "Address":
                case "Phone":

                case "Id":
                case "Model":
                case "Price":
                case "Speed":
                    e.Cancel = true;
                    break;
                default:
                    break;
            }
        }

        private void dataGrid_Airplane_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "VendorId":
                case "BrandTitle":
                case "Address":
                case "Phone":

                case "Id":
                case "Model":
                case "Price":
                case "Speed":
                    e.Cancel = true;
                    break;
                default:
                    break;
            }
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

            contextManufacturerAirplane.Manufacturers.Add(manufacturer);

            contextManufacturerAirplane.SaveChanges();

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

                Manufacturer del_manufacturer = (from t in contextManufacturerAirplane.Manufacturers
                                     where t.VendorId == selectedId
                                     select t).First();

                // Удалить из БД автора с данным ID
                contextManufacturerAirplane.Manufacturers.Remove(del_manufacturer);

                // Синхронизировать изменения
                contextManufacturerAirplane.SaveChanges();

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
                Model= "Airbus A220-100",
                Price =345000000,
                Speed = 670,
                VendorId=2
            };

            contextManufacturerAirplane.Airplanes.Add(airplane);

            contextManufacturerAirplane.SaveChanges();

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

                Airplane del_airplane = (from t in contextManufacturerAirplane.Airplanes
                                                 where t.Id == selectedId
                                                 select t).First();

                // Удалить из БД автора с данным ID
                contextManufacturerAirplane.Airplanes.Remove(del_airplane);

                // Синхронизировать изменения
                contextManufacturerAirplane.SaveChanges();

                // Обновить таблицу
                RefreshAirplane();
            }
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {

        }




        public void RefreshProjects()
        {
            var result = from t in contextProjectsEmployees.Projects
                         select t;

            ObservableCollection<Project> observableCollection = new ObservableCollection<Project>(result);

            CollectionViewSource collection = new CollectionViewSource() { Source = observableCollection };
            collection.GroupDescriptions.Add(new PropertyGroupDescription("StartDate"));
            //collection.GroupDescriptions.Add(new PropertyGroupDescription("City"));
            //collection.SortDescriptions.Add(new SortDescription("City", ListSortDirection.Ascending));
            //collection.Filter += Collection_Filter;

            dataGrid_Main.Style = (Style)FindResource("dataGridProjects");
            dataGrid_Main.CellEditEnding += dataGrid_Projects_CellEditEnding;
            dataGrid_Main.AutoGeneratingColumn += dataGrid_Projects_AutoGeneratingColumn;

            dataGrid_Main.CellEditEnding -= eventCellEditEnding;
            dataGrid_Main.AutoGeneratingColumn -= eventAutoGeneratingColumn;
            eventCellEditEnding = dataGrid_Projects_CellEditEnding;
            eventAutoGeneratingColumn = dataGrid_Projects_AutoGeneratingColumn;

            dataGrid_Main.ItemsSource = collection.View;

            //            var statesList = (from t in context.authors
            //                              select t.state).Distinct();
            //            StateColumn.ItemsSource = statesList.ToList();

            //dataGrid1.Columns[0].Visibility = Visibility.Hidden;
        }

        public void dataGrid_Projects_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            int selectedId = 0;
            if (dataGrid_Main.SelectedItem is Project selectedProjectsRow)
            {
                selectedId = selectedProjectsRow.ProjectId;

                Project selectedProjectDB = (from t in contextProjectsEmployees.Projects
                                               where t.ProjectId == selectedId
                                               select t)?.First();

                selectedProjectDB.ProjectId = selectedProjectsRow.ProjectId;
                selectedProjectDB.Title = selectedProjectsRow.Title;
                selectedProjectDB.StartDate = selectedProjectsRow.StartDate;
                selectedProjectDB.EndDate = selectedProjectsRow.EndDate;
                selectedProjectDB.Description = selectedProjectsRow.Description;

                contextProjectsEmployees.SaveChanges();

                RefreshProjects();
            }
        }

        private void dataGrid_Projects_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Id":
                case "FirstName":
                case "LastName":
                case "Age":
                case "Address":
                case "FotoPath":

                case "Title":
                case "StartDate":
                case "EndDate":
                case "Description":
                    e.Cancel = true;
                    break;
                default:
                    break;
            }
        }

        public void RefreshEmployees()
        {
            var result = from t in contextProjectsEmployees.Employees
                         select t;

            ObservableCollection<Employee> observableCollection = new ObservableCollection<Employee>(result);

            CollectionViewSource collection = new CollectionViewSource() { Source = observableCollection };
            collection.GroupDescriptions.Add(new PropertyGroupDescription("Age"));
            //collection.GroupDescriptions.Add(new PropertyGroupDescription("City"));
            //collection.SortDescriptions.Add(new SortDescription("City", ListSortDirection.Ascending));
            //collection.Filter += Collection_Filter;

            dataGrid_Main.Style = (Style)FindResource("dataGridEmployees");
            dataGrid_Main.CellEditEnding += dataGrid_Employees_CellEditEnding;
            dataGrid_Main.AutoGeneratingColumn += dataGrid_Employees_AutoGeneratingColumn;

            dataGrid_Main.CellEditEnding -= eventCellEditEnding;
            dataGrid_Main.AutoGeneratingColumn -= eventAutoGeneratingColumn;
            eventCellEditEnding = dataGrid_Employees_CellEditEnding;
            eventAutoGeneratingColumn = dataGrid_Employees_AutoGeneratingColumn;

            dataGrid_Main.ItemsSource = collection.View;

            //            var statesList = (from t in context.authors
            //                              select t.state).Distinct();
            //            StateColumn.ItemsSource = statesList.ToList();

            //dataGrid1.Columns[0].Visibility = Visibility.Hidden;
        }

        public void dataGrid_Employees_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            int selectedId = 0;
            if (dataGrid_Main.SelectedItem is Employee selectedEmployeeRow)
            {
                selectedId = selectedEmployeeRow.EmployeeId;

                Employee selectedEmployeeDB = (from t in contextProjectsEmployees.Employees
                                               where t.EmployeeId == selectedId
                                               select t)?.First();

                selectedEmployeeDB.EmployeeId = selectedEmployeeRow.EmployeeId;
                selectedEmployeeDB.FirstName = selectedEmployeeRow.FirstName;
                selectedEmployeeDB.LastName = selectedEmployeeRow.LastName;
                selectedEmployeeDB.Age = selectedEmployeeRow.Age;
                selectedEmployeeDB.Address = selectedEmployeeRow.Address;
                selectedEmployeeDB.FotoPath = selectedEmployeeRow.FotoPath;

                contextManufacturerAirplane.SaveChanges();

                RefreshEmployees();
            }
        }

        private void dataGrid_Employees_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Id":
                case "FirstName":
                case "LastName":
                case "Age":
                case "Address":
                case "FotoPath":

                case "Title":
                case "StartDate":
                case "EndDate":
                case "Description":
                    e.Cancel = true;
                    break;
                default:
                    break;
            }
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
                EndDate = DateTime.MinValue,
                Description = "New Funny Project"
            };

            contextProjectsEmployees.Projects.Add(project);

            contextProjectsEmployees.SaveChanges();

            RefreshProjects();
        }

        private void DeleteProjects_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid_Main.SelectedItem != null)
            {
                // Получить выделенного автора
                Project selectedProjectRow = dataGrid_Main.SelectedItem as Project;

                // Получить ID выделенного автора
                int selectedId = selectedProjectRow.ProjectId;

                Project del_project = (from t in contextProjectsEmployees.Projects
                                         where t.ProjectId == selectedId
                                         select t).First();

                // Удалить из БД автора с данным ID
                contextProjectsEmployees.Projects.Remove(del_project);

                // Синхронизировать изменения
                contextProjectsEmployees.SaveChanges();

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

            contextProjectsEmployees.Employees.Add(employee);

            contextProjectsEmployees.SaveChanges();

            RefreshEmployees();
        }

        private void DeleteEmployees_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid_Main.SelectedItem != null)
            {
                // Получить выделенного автора
                Employee selectedEmployeeRow = dataGrid_Main.SelectedItem as Employee;

                // Получить ID выделенного автора
                int selectedId = selectedEmployeeRow.EmployeeId;

                Employee del_employee = (from t in contextProjectsEmployees.Employees
                                         where t.EmployeeId == selectedId
                                         select t).First();

                // Удалить из БД автора с данным ID
                contextProjectsEmployees.Employees.Remove(del_employee);

                // Синхронизировать изменения
                contextProjectsEmployees.SaveChanges();

                // Обновить таблицу
                RefreshEmployees();
            }
        }

        private void MenuItem_Click_13(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_14(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_15(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click2(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_11(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_12(object sender, RoutedEventArgs e)
        {

        }
    }
}
