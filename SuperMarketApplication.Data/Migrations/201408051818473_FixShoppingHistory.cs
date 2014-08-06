namespace SuperMarketApplication.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixShoppingHistory : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ShoppingHistoryIngredients", newName: "ShoppingHistorySuperMarketIngredients");
            RenameColumn(table: "dbo.ShoppingHistorySuperMarketIngredients", name: "Ingredient_Id", newName: "SuperMarketIngredient_Id");
            RenameIndex(table: "dbo.ShoppingHistorySuperMarketIngredients", name: "IX_Ingredient_Id", newName: "IX_SuperMarketIngredient_Id");
            CreateTable(
                "dbo.RecipeHistories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        ShoppingHistoryId = c.Guid(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ShoppingHistory", t => t.ShoppingHistoryId, cascadeDelete: true)
                .Index(t => t.ShoppingHistoryId);
            
            AddColumn("dbo.ShoppingHistory", "TotalPrice", c => c.Single(nullable: false));
            AddColumn("dbo.ShoppingHistory", "FirstName", c => c.String());
            AddColumn("dbo.ShoppingHistory", "LastName", c => c.String());
            AddColumn("dbo.ShoppingHistory", "Address", c => c.String());
            AddColumn("dbo.ShoppingHistory", "PostCode", c => c.Int(nullable: false));
            AddColumn("dbo.ShoppingHistory", "PostAddress", c => c.String());
            AddColumn("dbo.ShoppingHistory", "Ingredient_Id", c => c.Guid());
            CreateIndex("dbo.ShoppingHistory", "Ingredient_Id");
            AddForeignKey("dbo.ShoppingHistory", "Ingredient_Id", "dbo.Ingredients", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingHistory", "Ingredient_Id", "dbo.Ingredients");
            DropForeignKey("dbo.RecipeHistories", "ShoppingHistoryId", "dbo.ShoppingHistory");
            DropIndex("dbo.RecipeHistories", new[] { "ShoppingHistoryId" });
            DropIndex("dbo.ShoppingHistory", new[] { "Ingredient_Id" });
            DropColumn("dbo.ShoppingHistory", "Ingredient_Id");
            DropColumn("dbo.ShoppingHistory", "PostAddress");
            DropColumn("dbo.ShoppingHistory", "PostCode");
            DropColumn("dbo.ShoppingHistory", "Address");
            DropColumn("dbo.ShoppingHistory", "LastName");
            DropColumn("dbo.ShoppingHistory", "FirstName");
            DropColumn("dbo.ShoppingHistory", "TotalPrice");
            DropTable("dbo.RecipeHistories");
            RenameIndex(table: "dbo.ShoppingHistorySuperMarketIngredients", name: "IX_SuperMarketIngredient_Id", newName: "IX_Ingredient_Id");
            RenameColumn(table: "dbo.ShoppingHistorySuperMarketIngredients", name: "SuperMarketIngredient_Id", newName: "Ingredient_Id");
            RenameTable(name: "dbo.ShoppingHistorySuperMarketIngredients", newName: "ShoppingHistoryIngredients");
        }
    }
}
