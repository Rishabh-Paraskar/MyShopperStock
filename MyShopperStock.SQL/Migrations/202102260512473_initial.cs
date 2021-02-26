namespace MyShopperStock.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        userId = c.String(),
                        firstname = c.String(),
                        lastName = c.String(),
                        email = c.String(),
                        phoneNumber = c.String(),
                        dateOfBirth = c.String(),
                        securityQuestion = c.String(),
                        answer = c.String(),
                        address = c.String(),
                        disable = c.Boolean(nullable: false),
                        createdAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        productName = c.String(),
                        Description = c.String(),
                        Category = c.String(),
                        totalQuantity = c.Int(nullable: false),
                        unit = c.Int(nullable: false),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        createdAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        category = c.String(),
                        createdAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProductCategories");
            DropTable("dbo.Products");
            DropTable("dbo.Customers");
        }
    }
}
