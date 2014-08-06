namespace SuperMarketApplication.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveIngredientsFromShoppingHistory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ShoppingHistorySuperMarketIngredients", "ShoppingHistory_Id", "dbo.ShoppingHistory");
            DropForeignKey("dbo.ShoppingHistorySuperMarketIngredients", "SuperMarketIngredient_Id", "dbo.SuperMarketsIngredients");
            DropIndex("dbo.ShoppingHistorySuperMarketIngredients", new[] { "ShoppingHistory_Id" });
            DropIndex("dbo.ShoppingHistorySuperMarketIngredients", new[] { "SuperMarketIngredient_Id" });
            DropTable("dbo.ShoppingHistorySuperMarketIngredients");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ShoppingHistorySuperMarketIngredients",
                c => new
                    {
                        ShoppingHistory_Id = c.Guid(nullable: false),
                        SuperMarketIngredient_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ShoppingHistory_Id, t.SuperMarketIngredient_Id });
            
            CreateIndex("dbo.ShoppingHistorySuperMarketIngredients", "SuperMarketIngredient_Id");
            CreateIndex("dbo.ShoppingHistorySuperMarketIngredients", "ShoppingHistory_Id");
            AddForeignKey("dbo.ShoppingHistorySuperMarketIngredients", "SuperMarketIngredient_Id", "dbo.SuperMarketsIngredients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ShoppingHistorySuperMarketIngredients", "ShoppingHistory_Id", "dbo.ShoppingHistory", "Id", cascadeDelete: true);
        }
    }
}
