namespace SuperMarketApplication.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIngredientIdToShoppingHistoryIngredientId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShoppingHistoryIngredientIds", "IngredientId", c => c.Guid(nullable: false));
            AddColumn("dbo.ShoppingHistoryIngredientIds", "Created", c => c.DateTime(nullable: false));
            AddColumn("dbo.ShoppingHistoryIngredientIds", "Updated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShoppingHistoryIngredientIds", "Updated");
            DropColumn("dbo.ShoppingHistoryIngredientIds", "Created");
            DropColumn("dbo.ShoppingHistoryIngredientIds", "IngredientId");
        }
    }
}
