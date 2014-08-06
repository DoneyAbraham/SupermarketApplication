namespace SuperMarketApplication.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShoppingHistoryAndSuperMarket : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShoppingHistory",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ShoppingItems",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Price = c.Single(nullable: false),
                        Type = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SuperMarkets",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShoppingItemShoppingHistories",
                c => new
                    {
                        ShoppingItem_Id = c.Guid(nullable: false),
                        ShoppingHistory_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ShoppingItem_Id, t.ShoppingHistory_Id })
                .ForeignKey("dbo.ShoppingItems", t => t.ShoppingItem_Id, cascadeDelete: true)
                .ForeignKey("dbo.ShoppingHistory", t => t.ShoppingHistory_Id, cascadeDelete: true)
                .Index(t => t.ShoppingItem_Id)
                .Index(t => t.ShoppingHistory_Id);
            
            CreateTable(
                "dbo.SuperMarketShoppingItems",
                c => new
                    {
                        SuperMarket_Id = c.Guid(nullable: false),
                        ShoppingItem_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.SuperMarket_Id, t.ShoppingItem_Id })
                .ForeignKey("dbo.SuperMarkets", t => t.SuperMarket_Id, cascadeDelete: true)
                .ForeignKey("dbo.ShoppingItems", t => t.ShoppingItem_Id, cascadeDelete: true)
                .Index(t => t.SuperMarket_Id)
                .Index(t => t.ShoppingItem_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingHistory", "UserId", "dbo.Users");
            DropForeignKey("dbo.SuperMarketShoppingItems", "ShoppingItem_Id", "dbo.ShoppingItems");
            DropForeignKey("dbo.SuperMarketShoppingItems", "SuperMarket_Id", "dbo.SuperMarkets");
            DropForeignKey("dbo.ShoppingItemShoppingHistories", "ShoppingHistory_Id", "dbo.ShoppingHistory");
            DropForeignKey("dbo.ShoppingItemShoppingHistories", "ShoppingItem_Id", "dbo.ShoppingItems");
            DropIndex("dbo.SuperMarketShoppingItems", new[] { "ShoppingItem_Id" });
            DropIndex("dbo.SuperMarketShoppingItems", new[] { "SuperMarket_Id" });
            DropIndex("dbo.ShoppingItemShoppingHistories", new[] { "ShoppingHistory_Id" });
            DropIndex("dbo.ShoppingItemShoppingHistories", new[] { "ShoppingItem_Id" });
            DropIndex("dbo.ShoppingHistory", new[] { "UserId" });
            DropTable("dbo.SuperMarketShoppingItems");
            DropTable("dbo.ShoppingItemShoppingHistories");
            DropTable("dbo.SuperMarkets");
            DropTable("dbo.ShoppingItems");
            DropTable("dbo.ShoppingHistory");
        }
    }
}
