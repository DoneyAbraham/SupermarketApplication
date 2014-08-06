namespace SuperMarketApplication.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIngredientsToShoppingHistory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShoppingHistoryIngredientIds",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ShoppingHistory_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ShoppingHistory", t => t.ShoppingHistory_Id)
                .Index(t => t.ShoppingHistory_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingHistoryIngredientIds", "ShoppingHistory_Id", "dbo.ShoppingHistory");
            DropIndex("dbo.ShoppingHistoryIngredientIds", new[] { "ShoppingHistory_Id" });
            DropTable("dbo.ShoppingHistoryIngredientIds");
        }
    }
}
