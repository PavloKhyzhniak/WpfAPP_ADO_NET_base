namespace WpfApp_ADO_NET_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitManufacturerAirplane : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Airplanes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Model = c.String(nullable: false, maxLength: 50),
                        Price = c.Double(nullable: false),
                        Speed = c.Int(nullable: false),
                        VendorId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Manufacturers", t => t.VendorId)
                .Index(t => t.VendorId);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        VendorId = c.Int(nullable: false, identity: true),
                        BrandTitle = c.String(nullable: false, maxLength: 50),
                        Address = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.VendorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Airplanes", "VendorId", "dbo.Manufacturers");
            DropIndex("dbo.Airplanes", new[] { "VendorId" });
            DropTable("dbo.Manufacturers");
            DropTable("dbo.Airplanes");
        }
    }
}
