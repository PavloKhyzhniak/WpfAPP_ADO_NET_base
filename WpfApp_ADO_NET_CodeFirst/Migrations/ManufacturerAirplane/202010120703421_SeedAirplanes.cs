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
INSERT INTO [dbo].[Airplanes] ([Id], [Model], [Price], [Speed], [VendorId]) VALUES (3, N'Мермэйд CZAW', 6500000, 640, 10)
INSERT INTO [dbo].[Airplanes] ([Id], [Model], [Price], [Speed], [VendorId]) VALUES (4, N'Лет Л - 410', 78400000, 450, 25)
INSERT INTO [dbo].[Airplanes] ([Id], [Model], [Price], [Speed], [VendorId]) VALUES (6, N'Аэробус Corporate Jetliner', 652000000, 670, 2)
INSERT INTO [dbo].[Airplanes] ([Id], [Model], [Price], [Speed], [VendorId]) VALUES (8, N'
Аэробус А300 B2/B4/C4', 15000000, 720, 2)
INSERT INTO [dbo].[Airplanes] ([Id], [Model], [Price], [Speed], [VendorId]) VALUES (9, N'Аэробус А300-600', 168000950, 850, 2)
INSERT INTO [dbo].[Airplanes] ([Id], [Model], [Price], [Speed], [VendorId]) VALUES (10, N'Эйрбас А319 Шарклетс', 165000500, 470, 2)
INSERT INTO [dbo].[Airplanes] ([Id], [Model], [Price], [Speed], [VendorId]) VALUES (11, N'Бритиш Аэроспэйс Джетстрим 31/32Супер 31', 900520000, 420, 6)
INSERT INTO [dbo].[Airplanes] ([Id], [Model], [Price], [Speed], [VendorId]) VALUES (12, N'Бритиш Аэроспэйс Авро RJ 85/70/100', 954006000, 530, 6)
INSERT INTO [dbo].[Airplanes] ([Id], [Model], [Price], [Speed], [VendorId]) VALUES (13, N'
Бритиш Аэроспэйс BAe-146
', 26000000, 640, 6)
INSERT INTO [dbo].[Airplanes] ([Id], [Model], [Price], [Speed], [VendorId]) VALUES (14, N'Викерс ВЦ10', 152000000, 260, 29)
INSERT INTO [dbo].[Airplanes] ([Id], [Model], [Price], [Speed], [VendorId]) VALUES (15, N'
Ан-124 Руслан', 65000000, 450, 37)
INSERT INTO [dbo].[Airplanes] ([Id], [Model], [Price], [Speed], [VendorId]) VALUES (16, N'Ан-225 Мрия', 164000500, 530, 37)
INSERT INTO [dbo].[Airplanes] ([Id], [Model], [Price], [Speed], [VendorId]) VALUES (17, N'Ан-12', 650000000, 640, 37)
INSERT INTO [dbo].[Airplanes] ([Id], [Model], [Price], [Speed], [VendorId]) VALUES (18, N'Ту-134', 54000000, 750, 34)
INSERT INTO [dbo].[Airplanes] ([Id], [Model], [Price], [Speed], [VendorId]) VALUES (19, N'Ту-144', 154000000, 640, 34)
INSERT INTO [dbo].[Airplanes] ([Id], [Model], [Price], [Speed], [VendorId]) VALUES (20, N'Ту-324', 154000500, 620, 34)
INSERT INTO [dbo].[Airplanes] ([Id], [Model], [Price], [Speed], [VendorId]) VALUES (21, N'
Ил-114', 165000000, 550, 38)
INSERT INTO [dbo].[Airplanes] ([Id], [Model], [Price], [Speed], [VendorId]) VALUES (22, N'
Ил-76', 13200000, 320, 38)
INSERT INTO [dbo].[Airplanes] ([Id], [Model], [Price], [Speed], [VendorId]) VALUES (23, N'Ил-96М', 65005550, 370, 38)
INSERT INTO [dbo].[Airplanes] ([Id], [Model], [Price], [Speed], [VendorId]) VALUES (24, N'Боинг Бизнес Джет', 250000000, 450, 4)
INSERT INTO [dbo].[Airplanes] ([Id], [Model], [Price], [Speed], [VendorId]) VALUES (25, N'
Боинг 737-600', 255005000, 420, 4)
INSERT INTO [dbo].[Airplanes] ([Id], [Model], [Price], [Speed], [VendorId]) VALUES (26, N'Боинг 737-800 Винглетс', 64300000, 510, 4)
INSERT INTO [dbo].[Airplanes] ([Id], [Model], [Price], [Speed], [VendorId]) VALUES (27, N'Боинг 787-8 Дримлайнер', 165500000, 650, 4)
SET IDENTITY_INSERT [dbo].[Airplanes] OFF
");

        }

        public override void Down()
        {
        }
    }
}
