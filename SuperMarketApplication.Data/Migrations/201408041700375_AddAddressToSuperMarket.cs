namespace SuperMarketApplication.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddressToSuperMarket : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SuperMarkets", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SuperMarkets", "Address");
        }
    }
}
