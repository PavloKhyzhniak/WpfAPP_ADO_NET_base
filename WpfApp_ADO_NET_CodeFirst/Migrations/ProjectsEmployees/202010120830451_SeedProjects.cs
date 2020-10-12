namespace WpfApp_ADO_NET_CodeFirst.Migrations.ProjectsEmployees
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedProjects : DbMigration
    {
        public override void Up()
        {
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
        }
        
        public override void Down()
        {
        }
    }
}
