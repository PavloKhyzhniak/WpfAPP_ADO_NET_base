namespace WpfApp_ADO_NET_CodeFirst.Migrations.ProjectsEmployees
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedEmployees : DbMigration
    {
        public override void Up()
        {
            Sql(@"
SET IDENTITY_INSERT [dbo].[Employees] ON
INSERT INTO [dbo].[Employees] ([Id], [FirstName], [LastName], [Age], [Address], [FotoPath]) VALUES (1, N'Pavlo', N'Gold', 34, N'������� ��������� �����, ��� 20, ������ 1', N'\resources\bambi.jpg')
INSERT INTO [dbo].[Employees] ([Id], [FirstName], [LastName], [Age], [Address], [FotoPath]) VALUES (2, N'Dimitry', N'Rich', 25, N'��. �������� , ��� 13, ���3', N'\resources\bob.jpg')
INSERT INTO [dbo].[Employees] ([Id], [FirstName], [LastName], [Age], [Address], [FotoPath]) VALUES (3, N'Oleg', N'Baum', 42, N'���. ��������������� , �.14', N'\resources\catBlack.jpg')
INSERT INTO [dbo].[Employees] ([Id], [FirstName], [LastName], [Age], [Address], [FotoPath]) VALUES (4, N'Elena', N'Ulm', 27, N'������� �������, �.45,�� 5', N'\resources\jerry.jpg')
INSERT INTO [dbo].[Employees] ([Id], [FirstName], [LastName], [Age], [Address], [FotoPath]) VALUES (5, N'Olga', N'Wild', 24, N'��. �������, �.3', N'\resources\tom.jpg')
INSERT INTO [dbo].[Employees] ([Id], [FirstName], [LastName], [Age], [Address], [FotoPath]) VALUES (6, N'Misha', N'Flash', 45, N'��. ����� , �.13', N'\resources\mikkiMaus.jpg')
INSERT INTO [dbo].[Employees] ([Id], [FirstName], [LastName], [Age], [Address], [FotoPath]) VALUES (7, N'Genry', N'Ford', 22, N'���. ������������ 89. �� 33', N'\resources\scrudjMacDuck.jpg')
INSERT INTO [dbo].[Employees] ([Id], [FirstName], [LastName], [Age], [Address], [FotoPath]) VALUES (8, N'Bob', N'Humor', 36, N'��. ������, �.44, �� 67', N'\resources\pikachu.jpg')
INSERT INTO [dbo].[Employees] ([Id], [FirstName], [LastName], [Age], [Address], [FotoPath]) VALUES (9, N'Alexander', N'Red', 47, N'��. �������, ��� 15', N'\resources\shrek.jpg')
SET IDENTITY_INSERT [dbo].[Employees] OFF
");
        }
        
        public override void Down()
        {
        }
    }
}
