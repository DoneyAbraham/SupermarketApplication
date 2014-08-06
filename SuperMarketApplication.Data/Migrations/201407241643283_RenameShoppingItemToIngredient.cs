namespace SuperMarketApplication.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameShoppingItemToIngredient : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ShoppingItems", newName: "Ingredients");
            RenameTable(name: "dbo.ContainerShoppingItems", newName: "ContainerIngredients");
            RenameTable(name: "dbo.ShoppingHistoryShoppingItems", newName: "ShoppingHistoryIngredients");
            RenameTable(name: "dbo.SuperMarketShoppingItems", newName: "SuperMarketIngredients");
            RenameColumn(table: "dbo.ContainerIngredients", name: "ShoppingItem_Id", newName: "Ingredient_Id");
            RenameColumn(table: "dbo.ShoppingHistoryIngredients", name: "ShoppingItem_Id", newName: "Ingredient_Id");
            RenameColumn(table: "dbo.SuperMarketIngredients", name: "ShoppingItem_Id", newName: "Ingredient_Id");
            RenameIndex(table: "dbo.ShoppingHistoryIngredients", name: "IX_ShoppingItem_Id", newName: "IX_Ingredient_Id");
            RenameIndex(table: "dbo.SuperMarketIngredients", name: "IX_ShoppingItem_Id", newName: "IX_Ingredient_Id");
            RenameIndex(table: "dbo.ContainerIngredients", name: "IX_ShoppingItem_Id", newName: "IX_Ingredient_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ContainerIngredients", name: "IX_Ingredient_Id", newName: "IX_ShoppingItem_Id");
            RenameIndex(table: "dbo.SuperMarketIngredients", name: "IX_Ingredient_Id", newName: "IX_ShoppingItem_Id");
            RenameIndex(table: "dbo.ShoppingHistoryIngredients", name: "IX_Ingredient_Id", newName: "IX_ShoppingItem_Id");
            RenameColumn(table: "dbo.SuperMarketIngredients", name: "Ingredient_Id", newName: "ShoppingItem_Id");
            RenameColumn(table: "dbo.ShoppingHistoryIngredients", name: "Ingredient_Id", newName: "ShoppingItem_Id");
            RenameColumn(table: "dbo.ContainerIngredients", name: "Ingredient_Id", newName: "ShoppingItem_Id");
            RenameTable(name: "dbo.SuperMarketIngredients", newName: "SuperMarketShoppingItems");
            RenameTable(name: "dbo.ShoppingHistoryIngredients", newName: "ShoppingHistoryShoppingItems");
            RenameTable(name: "dbo.ContainerIngredients", newName: "ContainerShoppingItems");
            RenameTable(name: "dbo.Ingredients", newName: "ShoppingItems");
        }
    }
}
