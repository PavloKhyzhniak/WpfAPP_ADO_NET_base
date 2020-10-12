namespace WpfApp_ADO_NET_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedAirplanes : DbMigration
    {
        public override void Up()
        {
            Sql(@"
SET IDENTITY_INSERT [dbo].[Airplanes] ON
INSERT INTO [dbo].[Airplanes] ([Id], [Model], [Price], [Speed], [VendorId]) VALUES (3, N'������� CZAW', 6500000, 640, 10)
INSERT INTO [dbo].[Airplanes] ([Id], [Model], [Price], [Speed], [VendorId]) VALUES (4, N'��� � - 410', 78400000, 450, 25)
INSERT INTO [dbo].[Airplanes] ([Id], [Model], [Price], [Speed], [VendorId]) VALUES (6, N'������� Corporate Jetliner', 652000000, 670, 2)
INSERT INTO [dbo].[Airplanes] ([Id], [Model], [Price], [Speed], [VendorId]) VALUES (8, N'
������� �300 B2/B4/C4', 15000000, 720, 2)
INSERT INTO [dbo].[Airplanes] ([Id], [Model], [Price], [Speed], [VendorId]) VALUES (9, N'������� �300-600', 168000950, 850, 2)
INSERT INTO [dbo].[Airplanes] ([Id], [Model], [Price], [Speed], [VendorId]) VALUES (10, N'������ �319 ��������', 165000500, 470, 2)
INSERT INTO [dbo].[Airplanes] ([Id], [Model], [Price], [Speed], [VendorId]) VALUES (11, N'������ ��������� ��������� 31/32����� 31', 900520000, 420, 6)
INSERT INTO [dbo].[Airplanes] ([Id], [Model], [Price], [Speed], [VendorId]) VALUES (12, N'������ ��������� ���� RJ 85/70/100', 954006000, 530, 6)
INSERT INTO [dbo].[Airplanes] ([Id], [Model], [Price], [Speed], [VendorId]) VALUES (13, N'
������ ��������� BAe-146
', 26000000, 640, 6)
INSERT INTO [dbo].[Airplanes] ([Id], [Model], [Price], [Speed], [VendorId]) VALUES (14, N'������ ��10', 152000000, 260, 29)
INSERT INTO [dbo].[Airplanes] ([Id], [Model], [Price], [Speed], [VendorId]) VALUES (15, N'
��-124 ������', 65000000, 450, 37)
INSERT INTO [dbo].[Airplanes] ([Id], [Model], [Price], [Speed], [VendorId]) VALUES (16, N'��-225 ����', 164000500, 530, 37)
INSERT INTO [dbo].[Airplanes] ([Id], [Model], [Price], [Speed], [VendorId]) VALUES (17, N'��-12', 650000000, 640, 37)
INSERT INTO [dbo].[Airplanes] ([Id], [Model], [Price], [Speed], [VendorId]) VALUES (18, N'��-134', 54000000, 750, 34)
INSERT INTO [dbo].[Airplanes] ([Id], [Model], [Price], [Speed], [VendorId]) VALUES (19, N'��-144', 154000000, 640, 34)
INSERT INTO [dbo].[Airplanes] ([Id], [Model], [Price], [Speed], [VendorId]) VALUES (20, N'��-324', 154000500, 620, 34)
INSERT INTO [dbo].[Airplanes] ([Id], [Model], [Price], [Speed], [VendorId]) VALUES (21, N'
��-114', 165000000, 550, 38)
INSERT INTO [dbo].[Airplanes] ([Id], [Model], [Price], [Speed], [VendorId]) VALUES (22, N'
��-76', 13200000, 320, 38)
INSERT INTO [dbo].[Airplanes] ([Id], [Model], [Price], [Speed], [VendorId]) VALUES (23, N'��-96�', 65005550, 370, 38)
INSERT INTO [dbo].[Airplanes] ([Id], [Model], [Price], [Speed], [VendorId]) VALUES (24, N'����� ������ ����', 250000000, 450, 4)
INSERT INTO [dbo].[Airplanes] ([Id], [Model], [Price], [Speed], [VendorId]) VALUES (25, N'
����� 737-600', 255005000, 420, 4)
INSERT INTO [dbo].[Airplanes] ([Id], [Model], [Price], [Speed], [VendorId]) VALUES (26, N'����� 737-800 ��������', 64300000, 510, 4)
INSERT INTO [dbo].[Airplanes] ([Id], [Model], [Price], [Speed], [VendorId]) VALUES (27, N'����� 787-8 ����������', 165500000, 650, 4)
SET IDENTITY_INSERT [dbo].[Airplanes] OFF
");

        }

        public override void Down()
        {
        }
    }
}
