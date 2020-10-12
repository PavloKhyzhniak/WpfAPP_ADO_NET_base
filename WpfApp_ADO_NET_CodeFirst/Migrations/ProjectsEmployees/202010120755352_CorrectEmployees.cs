namespace WpfApp_ADO_NET_CodeFirst.Migrations.ProjectsEmployees
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectEmployees : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectEmployees",
                c => new
                    {
                        Project_ProjectId = c.Int(nullable: false),
                        Employee_EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Project_ProjectId, t.Employee_EmployeeId })
                .ForeignKey("dbo.Projects", t => t.Project_ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId, cascadeDelete: true)
                .Index(t => t.Project_ProjectId)
                .Index(t => t.Employee_EmployeeId);
            
            AddColumn("dbo.Employees", "FirstName", c => c.String());
            AddColumn("dbo.Employees", "LastName", c => c.String());
            AddColumn("dbo.Employees", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "Address", c => c.String());
            AddColumn("dbo.Employees", "FotoPath", c => c.String());
            DropColumn("dbo.Employees", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Name", c => c.String());
            DropForeignKey("dbo.ProjectEmployees", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.ProjectEmployees", "Project_ProjectId", "dbo.Projects");
            DropIndex("dbo.ProjectEmployees", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.ProjectEmployees", new[] { "Project_ProjectId" });
            DropColumn("dbo.Employees", "FotoPath");
            DropColumn("dbo.Employees", "Address");
            DropColumn("dbo.Employees", "Age");
            DropColumn("dbo.Employees", "LastName");
            DropColumn("dbo.Employees", "FirstName");
            DropTable("dbo.ProjectEmployees");
        }
    }
}
