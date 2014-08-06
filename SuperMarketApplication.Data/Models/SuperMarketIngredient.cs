using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketApplication.Data.Models
{
    [Table("SuperMarketsIngredients")]
    public class SuperMarketIngredient : BaseEntity
    {
        public float Price { get; set; }

        [ForeignKey("Ingredient")]
        public Guid IngredientId { get; set; }

        [InverseProperty("SuperMarkets")]
        public Ingredient Ingredient { get; set; }

        [ForeignKey("SuperMarket")]
        public Guid SuperMarketId { get; set; }

        [InverseProperty("Ingredients"), IgnoreDataMember]
        public SuperMarket SuperMarket { get; set; }
    }
}
