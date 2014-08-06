namespace SuperMarketApplication.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPriceToSuperMarketIngredients : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SuperMarketIngredients", "SuperMarket_Id", "dbo.SuperMarkets");
            DropForeignKey("dbo.SuperMarketIngredients", "Ingredient_Id", "dbo.Ingredients");
            DropIndex("dbo.SuperMarketIngredients", new[] { "SuperMarket_Id" });
            DropIndex("dbo.SuperMarketIngredients", new[] { "Ingredient_Id" });
            CreateTable(
                "dbo.SuperMarketsIngredients",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Price = c.Single(nullable: false),
                        IngredientId = c.Guid(nullable: false),
                        SuperMarketId = c.Guid(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ingredients", t => t.IngredientId, cascadeDelete: true)
                .ForeignKey("dbo.SuperMarkets", t => t.SuperMarketId, cascadeDelete: true)
                .Index(t => t.IngredientId)
                .Index(t => t.SuperMarketId);
            
            DropColumn("dbo.Ingredients", "Price");
            DropTable("dbo.SuperMarketIngredients");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SuperMarketIngredients",
                c => new
                    {
                        SuperMarket_Id = c.Guid(nullable: false),
                        Ingredient_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.SuperMarket_Id, t.Ingredient_Id });
            
            AddColumn("dbo.Ingredients", "Price", c => c.Single(nullable: false));
            DropForeignKey("dbo.SuperMarketsIngredients", "SuperMarketId", "dbo.SuperMarkets");
            DropForeignKey("dbo.SuperMarketsIngredients", "IngredientId", "dbo.Ingredients");
            DropIndex("dbo.SuperMarketsIngredients", new[] { "SuperMarketId" });
            DropIndex("dbo.SuperMarketsIngredients", new[] { "IngredientId" });
            DropTable("dbo.SuperMarketsIngredients");
            CreateIndex("dbo.SuperMarketIngredients", "Ingredient_Id");
            CreateIndex("dbo.SuperMarketIngredients", "SuperMarket_Id");
            AddForeignKey("dbo.SuperMarketIngredients", "Ingredient_Id", "dbo.Ingredients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SuperMarketIngredients", "SuperMarket_Id", "dbo.SuperMarkets", "Id", cascadeDelete: true);
        }
    }
}
