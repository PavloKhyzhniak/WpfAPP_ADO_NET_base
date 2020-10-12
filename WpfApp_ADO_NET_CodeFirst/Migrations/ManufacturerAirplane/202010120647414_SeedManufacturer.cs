namespace WpfApp_ADO_NET_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedManufacturer : DbMigration
    {
        public override void Up()
        {
            Sql(@"
SET IDENTITY_INSERT [dbo].[Manufacturers] ON
INSERT INTO [dbo].[Manufacturers] ([VendorId], [BrandTitle], [Address], [Phone]) VALUES (1, N'Aerospatiale/Alenia', N'������', N'(097) 123-45-11')
INSERT INTO [dbo].[Manufacturers] ([VendorId], [BrandTitle], [Address], [Phone]) VALUES (2, N'Airbus S.A.S.', N'����������� ����', N'(097) 123-45-22')
INSERT INTO [dbo].[Manufacturers] ([VendorId], [BrandTitle], [Address], [Phone]) VALUES (3, N'Bell/Agusta Aerospace Company', N'���', N'(097) 123-45-33')
INSERT INTO [dbo].[Manufacturers] ([VendorId], [BrandTitle], [Address], [Phone]) VALUES (4, N'Boeing', N'���', N'(097) 123-45-44')
INSERT INTO [dbo].[Manufacturers] ([VendorId], [BrandTitle], [Address], [Phone]) VALUES (5, N'Bombardier Aerospace', N'������', N'(097) 123-45-55')
INSERT INTO [dbo].[Manufacturers] ([VendorId], [BrandTitle], [Address], [Phone]) VALUES (6, N'British Aerospace', N'��������������', N'(097) 123-45-66')
INSERT INTO [dbo].[Manufacturers] ([VendorId], [BrandTitle], [Address], [Phone]) VALUES (7, N'British Aircraft Corporation
', N'��������������', N'(097) 123-45-77')
INSERT INTO [dbo].[Manufacturers] ([VendorId], [BrandTitle], [Address], [Phone]) VALUES (8, N'Britten-Norman', N'��������������', N'(097) 123-45-88')
INSERT INTO [dbo].[Manufacturers] ([VendorId], [BrandTitle], [Address], [Phone]) VALUES (9, N'Cessna Aircraft', N'���', N'(097) 123-45-99')
INSERT INTO [dbo].[Manufacturers] ([VendorId], [BrandTitle], [Address], [Phone]) VALUES (10, N'Czech Aircraft Works', N'�����', N'(097) 123-45-00')
INSERT INTO [dbo].[Manufacturers] ([VendorId], [BrandTitle], [Address], [Phone]) VALUES (11, N'Dassault Aviation', N'�������', N'(097) 123-45-01')
INSERT INTO [dbo].[Manufacturers] ([VendorId], [BrandTitle], [Address], [Phone]) VALUES (12, N'De Havilland', N'��������������', N'(097) 123-45-02')
INSERT INTO [dbo].[Manufacturers] ([VendorId], [BrandTitle], [Address], [Phone]) VALUES (13, N'De Havilland Canada', N'������', N'(097) 123-45-03')
INSERT INTO [dbo].[Manufacturers] ([VendorId], [BrandTitle], [Address], [Phone]) VALUES (14, N'EADS Socata', N'�������', N'(097) 123-45-04')
INSERT INTO [dbo].[Manufacturers] ([VendorId], [BrandTitle], [Address], [Phone]) VALUES (15, N'Embraer (Empresa Brasileira de Aeronautica) S.A.', N'��������', N'(097) 123-45-05')
INSERT INTO [dbo].[Manufacturers] ([VendorId], [BrandTitle], [Address], [Phone]) VALUES (16, N'Fairchild-Dornier', N'���', N'(097) 123-45-06')
INSERT INTO [dbo].[Manufacturers] ([VendorId], [BrandTitle], [Address], [Phone]) VALUES (17, N'Fokker', N'����������', N'(097) 123-45-07')
INSERT INTO [dbo].[Manufacturers] ([VendorId], [BrandTitle], [Address], [Phone]) VALUES (18, N'GROB Aerospace', N'��������', N'(097) 123-45-08')
INSERT INTO [dbo].[Manufacturers] ([VendorId], [BrandTitle], [Address], [Phone]) VALUES (19, N'Gulf Aircraft Partnership (GAP)', N'���', N'(097) 123-45-09')
INSERT INTO [dbo].[Manufacturers] ([VendorId], [BrandTitle], [Address], [Phone]) VALUES (20, N'Gulfstream Aerospace Corporation', N'���', N'(097) 123-45-20')
INSERT INTO [dbo].[Manufacturers] ([VendorId], [BrandTitle], [Address], [Phone]) VALUES (21, N'Harbin Aircraft Manufacturing Corporation', N'�����', N'(097) 123-45-21')
INSERT INTO [dbo].[Manufacturers] ([VendorId], [BrandTitle], [Address], [Phone]) VALUES (22, N'Israel Aircraft', N'�������', N'(097) 123-45-22')
INSERT INTO [dbo].[Manufacturers] ([VendorId], [BrandTitle], [Address], [Phone]) VALUES (23, N'Kestrel Aircraft', N'���', N'(097) 123-45-23')
INSERT INTO [dbo].[Manufacturers] ([VendorId], [BrandTitle], [Address], [Phone]) VALUES (24, N'Lancair', N'���', N'(097) 123-45-24')
INSERT INTO [dbo].[Manufacturers] ([VendorId], [BrandTitle], [Address], [Phone]) VALUES (25, N'Let Aircraft Industries', N'�����', N'(097) 123-45-25')
INSERT INTO [dbo].[Manufacturers] ([VendorId], [BrandTitle], [Address], [Phone]) VALUES (26, N'Lockheed Corporation
', N'���', N'(097) 123-45-26')
INSERT INTO [dbo].[Manufacturers] ([VendorId], [BrandTitle], [Address], [Phone]) VALUES (27, N'McDonnell Douglas', N'���', N'(097) 123-45-27')
INSERT INTO [dbo].[Manufacturers] ([VendorId], [BrandTitle], [Address], [Phone]) VALUES (28, N'Saab', N'������', N'(097) 123-45-28')
INSERT INTO [dbo].[Manufacturers] ([VendorId], [BrandTitle], [Address], [Phone]) VALUES (29, N'Vickers', N'��������������', N'(097) 123-45-29')
INSERT INTO [dbo].[Manufacturers] ([VendorId], [BrandTitle], [Address], [Phone]) VALUES (30, N'Xi''an Aircraft Industrial Corporation', N'�����', N'(097) 123-45-30')
INSERT INTO [dbo].[Manufacturers] ([VendorId], [BrandTitle], [Address], [Phone]) VALUES (31, N'�����-����������� ���������� BAC-SNIAS
', N'�������', N'(097) 123-45-31')
INSERT INTO [dbo].[Manufacturers] ([VendorId], [BrandTitle], [Address], [Phone]) VALUES (32, N'����������� �������� ������', N'������', N'(097) 123-45-32')
INSERT INTO [dbo].[Manufacturers] ([VendorId], [BrandTitle], [Address], [Phone]) VALUES (33, N'������������� ����������� �����', N'������', N'(097) 123-45-33')
INSERT INTO [dbo].[Manufacturers] ([VendorId], [BrandTitle], [Address], [Phone]) VALUES (34, N'��� �.�.��������', N'������', N'(097) 123-45-34')
INSERT INTO [dbo].[Manufacturers] ([VendorId], [BrandTitle], [Address], [Phone]) VALUES (35, N'��� �.�. ��������
', N'������', N'(097) 123-45-35')
INSERT INTO [dbo].[Manufacturers] ([VendorId], [BrandTitle], [Address], [Phone]) VALUES (36, N'��� �.�. �������', N'������', N'(097) 123-45-36')
INSERT INTO [dbo].[Manufacturers] ([VendorId], [BrandTitle], [Address], [Phone]) VALUES (37, N'��� �.�.��������', N'�������', N'(097) 123-45-37')
INSERT INTO [dbo].[Manufacturers] ([VendorId], [BrandTitle], [Address], [Phone]) VALUES (38, N'��� �.�. ��������', N'������', N'(097) 123-45-38')
SET IDENTITY_INSERT [dbo].[Manufacturers] OFF
");
        }
        
        public override void Down()
        {
        }
    }
}
