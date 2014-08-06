using SuperMarketApplication.Data.Migrations;
using SuperMarketApplication.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketApplication.Data.DataAccess
{
    public class DomainDataContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<ShoppingHistory> ShoppingHistory { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<SuperMarket> SuperMarkets { get; set; }

        public DbSet<Container> Containers { get; set; }

        public DbSet<SuperMarketIngredient> SuperMarketIngredients { get; set; }

        public DomainDataContext()
            : base(GetConnectionString())
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DomainDataContext, Configuration>());
        }

        public new void Dispose()
        {
            base.Dispose();
        }

        private static string GetConnectionString()
        {
            return "DomainDataContext";
        }
    }
}
