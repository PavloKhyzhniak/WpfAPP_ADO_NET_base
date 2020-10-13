namespace WpfApp_ADO_NET_CodeFirst.Migrations.ProjectsEmployees
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedProjectsEmployees : DbMigration
    {
        public override void Up()
        {
            Sql(@"
SET IDENTITY_INSERT [dbo].[Employees] ON
INSERT INTO [dbo].[Employees] ([Id], [FirstName], [LastName], [Age], [Address], [FotoPath]) VALUES (1, N'Pavlo', N'Gold', 34, N'Большая Косинская улица, дом 20, корпус 1', N'resources\bambi.jpg')
INSERT INTO [dbo].[Employees] ([Id], [FirstName], [LastName], [Age], [Address], [FotoPath]) VALUES (2, N'Dimitry', N'Rich', 25, N'ул. Филатова , дом 13, квю3', N'resources\bob.jpg')
INSERT INTO [dbo].[Employees] ([Id], [FirstName], [LastName], [Age], [Address], [FotoPath]) VALUES (3, N'Oleg', N'Baum', 42, N'пер. Краснознаменный , д.14', N'resources\catBlack.jpg')
INSERT INTO [dbo].[Employees] ([Id], [FirstName], [LastName], [Age], [Address], [FotoPath]) VALUES (4, N'Elena', N'Ulm', 27, N'бульвар Моцарта, д.45,кв 5', N'resources\jerry.jpg')
INSERT INTO [dbo].[Employees] ([Id], [FirstName], [LastName], [Age], [Address], [FotoPath]) VALUES (5, N'Olga', N'Wild', 24, N'ул. Главная, д.3', N'resources\tom.jpg')
INSERT INTO [dbo].[Employees] ([Id], [FirstName], [LastName], [Age], [Address], [FotoPath]) VALUES (6, N'Misha', N'Flash', 45, N'ул. Тихая , д.13', N'resources\mikkiMaus.jpg')
INSERT INTO [dbo].[Employees] ([Id], [FirstName], [LastName], [Age], [Address], [FotoPath]) VALUES (7, N'Genry', N'Ford', 22, N'пер. Пролетарский 89. кв 33', N'resources\scrudjMacDuck.jpg')
INSERT INTO [dbo].[Employees] ([Id], [FirstName], [LastName], [Age], [Address], [FotoPath]) VALUES (8, N'Bob', N'Humor', 36, N'ул. Рошена, д.44, кв 67', N'resources\pikachu.jpg')
INSERT INTO [dbo].[Employees] ([Id], [FirstName], [LastName], [Age], [Address], [FotoPath]) VALUES (9, N'Alexander', N'Red', 47, N'ул. Крысина, дом 15', N'resources\shrek.jpg')
SET IDENTITY_INSERT [dbo].[Employees] OFF
");


            Sql(@"
SET IDENTITY_INSERT [dbo].[Projects] ON
INSERT INTO[dbo].[Projects]([Id], [Title], [StartDate], [EndDate], [Description]) VALUES(1, N'Notepad Ver2.0', '20200116 00:00:00', '20200526 00:00:00', N'In RealTime show Weather and Time')
INSERT INTO[dbo].[Projects] ([Id], [Title], [StartDate], [EndDate], [Description]) VALUES(2, N'RealTimeOS', '20200304 00:00:00', '20200410 00:00:00', N'Prepare OS for Industrie Line Backerei')
INSERT INTO[dbo].[Projects] ([Id], [Title], [StartDate], [EndDate], [Description]) VALUES(3, N'ArchivatorImages', '20200423 00:00:00', '19000101 00:00:00', N'Find better way for archiviren Images in *.jpg for DB')
INSERT INTO[dbo].[Projects] ([Id], [Title], [StartDate], [EndDate], [Description]) VALUES(4, N'FuzzyRegulator', '20200510 00:00:00', '19000101 00:00:00', N'Regulator Temperatur and Airing in Tunnel')
INSERT INTO[dbo].[Projects] ([Id], [Title], [StartDate], [EndDate], [Description]) VALUES(5, N'MultiPatchingSystem', '20200528 00:00:00', '19000101 00:00:00', N'Find patching for System in Auto and send Request for Run')
INSERT INTO[dbo].[Projects] ([Id], [Title], [StartDate], [EndDate], [Description]) VALUES(6, N'SecretProjectXXX', '20200602 00:00:00', '19000101 00:00:00', N'Top Secret! Ask your TeamLeader')
SET IDENTITY_INSERT[dbo].[Projects] OFF
");

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
