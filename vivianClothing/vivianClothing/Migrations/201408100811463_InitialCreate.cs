namespace vivianClothing.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 60),
                        Description = c.String(nullable: false, maxLength: 250),
                        Price = c.Int(nullable: false),
                        PublishOn = c.DateTime(),
                        ProductCategory_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductCategories", t => t.ProductCategory_Id, cascadeDelete: true)
                .Index(t => t.ProductCategory_Id);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 250),
                        Password = c.String(nullable: false, maxLength: 40),
                        Name = c.String(nullable: false, maxLength: 5),
                        RegisterOn = c.String(),
                        AutoCode = c.String(maxLength: 36),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderHeaders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactName = c.String(nullable: false, maxLength: 40),
                        ContactPhoneNo = c.String(nullable: false, maxLength: 25),
                        ContactAddress = c.String(nullable: false),
                        TotalPrice = c.Int(nullable: false),
                        memo = c.String(),
                        BuyOn = c.DateTime(nullable: false),
                        Member_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.Member_Id, cascadeDelete: true)
                .Index(t => t.Member_Id);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.String(nullable: false),
                        OrderHeader_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderHeaders", t => t.OrderHeader_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.OrderHeader_Id)
                .Index(t => t.Product_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.OrderDetails", new[] { "Product_Id" });
            DropIndex("dbo.OrderDetails", new[] { "OrderHeader_Id" });
            DropIndex("dbo.OrderHeaders", new[] { "Member_Id" });
            DropIndex("dbo.Products", new[] { "ProductCategory_Id" });
            DropForeignKey("dbo.OrderDetails", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "OrderHeader_Id", "dbo.OrderHeaders");
            DropForeignKey("dbo.OrderHeaders", "Member_Id", "dbo.Members");
            DropForeignKey("dbo.Products", "ProductCategory_Id", "dbo.ProductCategories");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.OrderHeaders");
            DropTable("dbo.Members");
            DropTable("dbo.Products");
            DropTable("dbo.ProductCategories");
        }
    }
}
