namespace WpfApp_ADO_NET_CodeFirst.Migrations.ProjectsEmployees
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedProjectsEmployees : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[ProjectEmployees] ([ProjectId], [EmployeeId]) VALUES (1, 1)
INSERT INTO [dbo].[ProjectEmployees] ([ProjectId], [EmployeeId]) VALUES (5, 1)
INSERT INTO [dbo].[ProjectEmployees] ([ProjectId], [EmployeeId]) VALUES (6, 1)
INSERT INTO [dbo].[ProjectEmployees] ([ProjectId], [EmployeeId]) VALUES (1, 2)
INSERT INTO [dbo].[ProjectEmployees] ([ProjectId], [EmployeeId]) VALUES (3, 2)
INSERT INTO [dbo].[ProjectEmployees] ([ProjectId], [EmployeeId]) VALUES (2, 3)
INSERT INTO [dbo].[ProjectEmployees] ([ProjectId], [EmployeeId]) VALUES (2, 4)
INSERT INTO [dbo].[ProjectEmployees] ([ProjectId], [EmployeeId]) VALUES (3, 4)
INSERT INTO [dbo].[ProjectEmployees] ([ProjectId], [EmployeeId]) VALUES (2, 5)
INSERT INTO [dbo].[ProjectEmployees] ([ProjectId], [EmployeeId]) VALUES (1, 6)
INSERT INTO [dbo].[ProjectEmployees] ([ProjectId], [EmployeeId]) VALUES (4, 6)
INSERT INTO [dbo].[ProjectEmployees] ([ProjectId], [EmployeeId]) VALUES (2, 7)
INSERT INTO [dbo].[ProjectEmployees] ([ProjectId], [EmployeeId]) VALUES (5, 7)
INSERT INTO [dbo].[ProjectEmployees] ([ProjectId], [EmployeeId]) VALUES (4, 8)
INSERT INTO [dbo].[ProjectEmployees] ([ProjectId], [EmployeeId]) VALUES (5, 9)
");
        }
        
        public override void Down()
        {
        }
    }
}
