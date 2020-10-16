using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace WpfApp_ADO_NET_DatabaseFirst
{
    /// <summary>
    /// Логика взаимодействия для Window_Change_Employee.xaml
    /// </summary>
    public partial class Window_Change : Window
    {
        public event Action<object> ReturnObject;

        public object CurrentObject { get; set; }

        public Manufacturer Manufacturer { get; set; }
        public Airplane Airplane { get; set; }
        public Project Project { get; set; }
        public Employee Employee { get; set; }

        public Dictionary<int,string> DictionaryVendorIdBrandTitle { get; set; }

        enum SelectedClass
        {
            Manufacturer,
            Airplane,
            Projects,
            Employee
        };

        SelectedClass selectedClass;


        public Window_Change()
        {
            InitializeComponent();
        }

        public Window_Change(object change_object)
            : this()
        {

            if (change_object is Manufacturer manufacturer)
            {
                Manufacturer = new Manufacturer
                {
                    VendorId = manufacturer.VendorId,
                    BrandTitle = manufacturer.BrandTitle,
                    Address = manufacturer.Address,
                    Phone = manufacturer.Phone
                };
                this.mainGrid.Style = (Style)FindResource("styleChange_Manufacturer");
                selectedClass = SelectedClass.Manufacturer;
                CurrentObject = Manufacturer;
            }
            else if (change_object is Airplane airplane)
            {
                Airplane = new Airplane
                {
                    Id = airplane.Id,
                    Model = airplane.Model,
                    Price = airplane.Price,
                    Speed = airplane.Speed,
                    VendorId = airplane.VendorId
                };
                this.mainGrid.Style = (Style)FindResource("styleChange_Airplane");
                selectedClass = SelectedClass.Airplane;
                CurrentObject = Airplane;
            }
            else if (change_object is Project project)
            {
                Project = new Project
                {
                    Id = project.Id,
                    Title = project.Title,
                    StartDate = project.StartDate,
                    EndDate = project.EndDate,
                    Description = project.Description
                };
                this.mainGrid.Style = (Style)FindResource("styleChange_Project");
                selectedClass = SelectedClass.Projects;
                CurrentObject = Project;               
            }
            else if (change_object is Employee employee)
            {
                Employee = new Employee
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Age = employee.Age,
                    Address = employee.Address,
                    FotoPath = employee.FotoPath
                };
                this.mainGrid.Style = (Style)FindResource("styleChange_Employee");
                selectedClass = SelectedClass.Employee;
                CurrentObject = Employee;
                //Button buttonOpenFolderDialogWinForms = this.GetTemplateChild("buttonOpenFolderDialogWinForms") as Button;
                //if (buttonOpenFolderDialogWinForms != null)
                //{
                //    buttonOpenFolderDialogWinForms.Click += buttonOpenFolderDialogWinForms_Click;
                //}
            }            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ReturnObject(CurrentObject);
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        public void buttonOpenFolderDialogWinForms_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

            bool? result = dlg.ShowDialog();

            if (result == true)
            {
                Employee.FotoPath = dlg.FileName;
                //                MessageBox.Show(dlg.FileName);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Width = 400;
            switch (selectedClass)
            {
                case SelectedClass.Manufacturer:
                    this.DataContext = Manufacturer;
                    this.Height = 320;
                    break;
                case SelectedClass.Airplane:
                    this.DataContext = Airplane;
                    Resources["VendorIdBrandTitle"] = DictionaryVendorIdBrandTitle;
                    this.Height = 500;
                    break;
                case SelectedClass.Projects:
                    this.DataContext = Project;
                    this.Height = 740;
                    break;
                case SelectedClass.Employee:
                    this.DataContext = Employee;
                    this.Height = 440;
                    break;
            }


            Button buttonOpenFolderDialogWinForms = this.GetTemplateChild("buttonOpenFolderDialogWinForms") as Button;
            if (buttonOpenFolderDialogWinForms != null)
            {
                buttonOpenFolderDialogWinForms.Click += buttonOpenFolderDialogWinForms_Click;
            }
        }

        private void buttonADD_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("Confirm the creation of a new entry or continue editing?", "Add New Record", MessageBoxButton.YesNo, MessageBoxImage.Information);
            switch (res)
            {
                case MessageBoxResult.Yes:
                    this.DialogResult = true;

                    switch (selectedClass)
                    {
                        case SelectedClass.Manufacturer:
                            Manufacturer.VendorId=-1;
                            break;
                        case SelectedClass.Airplane:
                            Airplane.Id=-1;
                            break;
                        case SelectedClass.Projects:
                            Project.Id=-1;
                            break;
                        case SelectedClass.Employee:
                            Employee.Id=-1;
                            break;
                    }
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
    }
}
