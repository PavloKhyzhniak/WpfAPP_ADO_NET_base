namespace WpfApp_ADO_NET_LinqToSQL
{
    public class Airplane
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public int Speed { get; set; }
        public int? VendorId { get; set; }
    }
}