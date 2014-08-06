using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketApplication.Data.Models
{
    public class SuperMarket : BaseEntity
    {
        public string Name { get; set; }

        public IList<SuperMarketIngredient> Ingredients { get; set; }

        public string Address { get; set; }

    }
}
