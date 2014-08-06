namespace SuperMarketApplication.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContainers : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ShoppingItemShoppingHistories", newName: "ShoppingHistoryShoppingItems");
            DropPrimaryKey("dbo.ShoppingHistoryShoppingItems");
            CreateTable(
                "dbo.Containers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        UserId = c.Guid(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ContainerShoppingItems",
                c => new
                    {
                        Container_Id = c.Guid(nullable: false),
                        ShoppingItem_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Container_Id, t.ShoppingItem_Id })
                .ForeignKey("dbo.Containers", t => t.Container_Id, cascadeDelete: true)
                .ForeignKey("dbo.ShoppingItems", t => t.ShoppingItem_Id, cascadeDelete: true)
                .Index(t => t.Container_Id)
                .Index(t => t.ShoppingItem_Id);
            
            AddPrimaryKey("dbo.ShoppingHistoryShoppingItems", new[] { "ShoppingHistory_Id", "ShoppingItem_Id" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Containers", "UserId", "dbo.Users");
            DropForeignKey("dbo.ContainerShoppingItems", "ShoppingItem_Id", "dbo.ShoppingItems");
            DropForeignKey("dbo.ContainerShoppingItems", "Container_Id", "dbo.Containers");
            DropIndex("dbo.ContainerShoppingItems", new[] { "ShoppingItem_Id" });
            DropIndex("dbo.ContainerShoppingItems", new[] { "Container_Id" });
            DropIndex("dbo.Containers", new[] { "UserId" });
            DropPrimaryKey("dbo.ShoppingHistoryShoppingItems");
            DropTable("dbo.ContainerShoppingItems");
            DropTable("dbo.Containers");
            AddPrimaryKey("dbo.ShoppingHistoryShoppingItems", new[] { "ShoppingItem_Id", "ShoppingHistory_Id" });
            RenameTable(name: "dbo.ShoppingHistoryShoppingItems", newName: "ShoppingItemShoppingHistories");
        }
    }
}
