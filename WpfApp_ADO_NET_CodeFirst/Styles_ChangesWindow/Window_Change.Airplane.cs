using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp_ADO_NET_CodeFirst
{ 
    public partial class Window_Change : Window
    {
        public Airplane Airplane { get; set; }
        public Dictionary<int, string> DictionaryVendorIdBrandTitle { get; set; }

        public Window_Change(Airplane airplane)
           : this()
        {
            this.Width = 400;
            this.Height = 500;

            Airplane = new Airplane
            {
                Id = airplane.Id,
                Model = airplane.Model,
                Price = airplane.Price,
                Speed = airplane.Speed,
                VendorId = airplane.VendorId
            };
            ValidateID += e =>(e as Airplane).Id=-1;

            this.DataContext = Airplane;
            Resources["VendorIdBrandTitle"] = DictionaryVendorIdBrandTitle;

            this.mainGrid.Style = (Style)FindResource("styleChange_Airplane");

            CurrentObject = Airplane;
        }
    }
}
