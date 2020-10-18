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

namespace WpfApp_ADO_NET_CodeFirst
{
    /// <summary>
    /// Логика взаимодействия для Window_Change_Employee.xaml
    /// </summary>
    public partial class Window_Change : Window
    {
        //событие возврата изминенного объекта
        public event Action<object> ReturnObject;
        //события изминения ID объекта при необходимости
        public event Action<object> ValidateID;
        //объект изменяемый и возвращаемый
        public object CurrentObject { get; set; }

        public Window_Change()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ReturnObject(CurrentObject);
        }

        private void buttonUPDATE_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void buttonCANCEL_Click(object sender, RoutedEventArgs e)
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

        private void buttonINSERT_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("Confirm the creation of a new entry or continue editing?", "Add New Record", MessageBoxButton.YesNo, MessageBoxImage.Information);
            switch (res)
            {
                case MessageBoxResult.Yes:
                    this.DialogResult = true;
                    ValidateID?.Invoke(CurrentObject);
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
    }
}
