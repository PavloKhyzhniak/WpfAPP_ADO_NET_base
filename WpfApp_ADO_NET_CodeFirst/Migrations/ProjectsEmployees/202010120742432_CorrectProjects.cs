namespace WpfApp_ADO_NET_CodeFirst.Migrations.ProjectsEmployees
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectProjects : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Title", c => c.String());
            AddColumn("dbo.Projects", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Projects", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Projects", "Description", c => c.String());
            DropColumn("dbo.Projects", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "Name", c => c.String());
            DropColumn("dbo.Projects", "Description");
            DropColumn("dbo.Projects", "EndDate");
            DropColumn("dbo.Projects", "StartDate");
            DropColumn("dbo.Projects", "Title");
        }
    }
}
