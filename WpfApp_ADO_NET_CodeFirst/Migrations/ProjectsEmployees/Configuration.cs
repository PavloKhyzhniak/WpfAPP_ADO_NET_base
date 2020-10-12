namespace WpfApp_ADO_NET_CodeFirst.Migrations.ProjectsEmployees
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WpfApp_ADO_NET_CodeFirst.Model_ProjectsEmployees>
    {
        public Configuration()
        {
            MigrationsDirectory = "Migrations\\ProjectsEmployees";
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WpfApp_ADO_NET_CodeFirst.Model_ProjectsEmployees context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }

        //Add-Migration InitProjectsEmployees -ConfigurationTypeName WpfApp_ADO_NET_CodeFirst.Migrations.ProjectsEmployees.Configuration
        //Add-Migration CorrectProjects -ConfigurationTypeName WpfApp_ADO_NET_CodeFirst.Migrations.ProjectsEmployees.Configuration -Force
        //update-database -ConfigurationTypeName WpfApp_ADO_NET_CodeFirst.Migrations.ProjectsEmployees.Configuration 
        //Add-Migration SeedProjectsEmployees -ConfigurationTypeName WpfApp_ADO_NET_CodeFirst.Migrations.ProjectsEmployees.Configuration 
        //update-database -ConfigurationTypeName WpfApp_ADO_NET_CodeFirst.Migrations.ProjectsEmployees.Configuration 
    }
}
