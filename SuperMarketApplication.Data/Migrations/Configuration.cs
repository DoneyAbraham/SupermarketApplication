using SuperMarketApplication.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketApplication.Data.Migrations
{
    internal class Configuration : DbMigrationsConfiguration<DomainDataContext>
    {
        
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.MigrationsDirectory = "Migrations";
        }
    }
}
