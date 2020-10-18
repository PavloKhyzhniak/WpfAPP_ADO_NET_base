using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp_ADO_NET_SQLDataAdapter
{ 
    public partial class Window_Change : Window
    {
        public Manufacturer Manufacturer { get; set; }

        public Window_Change(Manufacturer manufacturer)
           : this()
        {
            this.Width = 400;
            this.Height = 320;

            Manufacturer = new Manufacturer
            {
                VendorId = manufacturer.VendorId,
                BrandTitle = manufacturer.BrandTitle,
                Address = manufacturer.Address,
                Phone = manufacturer.Phone
            };
            ValidateID += e => (e as Manufacturer).VendorId = -1;

            this.DataContext = Manufacturer;

            this.mainGrid.Style = (Style)FindResource("styleChange_Manufacturer");
     
            CurrentObject = Manufacturer;
           
        }
    }
}
