namespace WpfApp_ADO_NET_CodeFirst.Migrations.ManufacturerAirplane
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WpfApp_ADO_NET_CodeFirst.Model_ManufacturerAirplane>
    {
        public Configuration()
        {
            MigrationsDirectory = "Migrations\\ManufacturerAirplane";
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WpfApp_ADO_NET_CodeFirst.Model_ManufacturerAirplane context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }

        //add-migration InitManufacturerAirplane
        //add-migration InitManufacturerAirplane -Force
        //add-migration SeedManufacturer
        //update-database
        //add-migration SeedAirplanes
        //update-database
        //Add-Migration CorrectManufacturerAirplane -ConfigurationTypeName WpfApp_ADO_NET_CodeFirst.Migrations.ManufacturerAirplane.Configuration
        //Update-Database -ConfigurationTypeName WpfApp_ADO_NET_CodeFirst.Migrations.ManufacturerAirplane.Configuration



    }
}
