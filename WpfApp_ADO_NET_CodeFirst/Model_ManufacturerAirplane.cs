namespace WpfApp_ADO_NET_CodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;

    public class Model_ManufacturerAirplane : DbContext
    {
        // Контекст настроен для использования строки подключения "Model_ManufacturerAirplane" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "WpfApp_ADO_NET_CodeFirst.Model_ManufacturerAirplane" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "Model_ManufacturerAirplane" 
        // в файле конфигурации приложения.
        public Model_ManufacturerAirplane()
            : base("name=Model_ManufacturerAirplane")
        {
        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<Airplane> Airplanes { get; set; }
    }

    public class Manufacturer
    {
        [Key]
        public int VendorId { get; set; }
        [Required]
        [StringLength(50)]
        public string BrandTitle { get; set; }
        [DefaultValue("")]
        public string Address { get; set; }
        [DefaultValue("")]
        public string Phone { get; set; }

        public virtual ICollection<Airplane> Airplanes { get; set; } 

        public Manufacturer()
        {
            Airplanes = new List<Airplane>();
        }
    }
    public class Airplane
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Model { get; set; }
        [DefaultValue(0.0)]
        public double Price { get; set; }
        [DefaultValue(0)]
        public int Speed { get; set; }

        public int? VendorId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
    }
}