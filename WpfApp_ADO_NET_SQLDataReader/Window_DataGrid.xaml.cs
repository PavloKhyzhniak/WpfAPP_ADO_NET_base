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

namespace WpfApp_ADO_NET_SQLDataReader
{
    /// <summary>
    /// Логика взаимодействия для Window_DataGrid.xaml
    /// </summary>
    public partial class Window_DataGrid : Window
    {
        public Window_DataGrid()
        {
            InitializeComponent();
        }

        IEnumerable<object> Collection { get; set; }
        public Window_DataGrid(IEnumerable<object> collection)
            : this()
        {
            Collection = collection;
            dataGrid_MainPresenter.ItemsSource = Collection;
        }
    }
}
