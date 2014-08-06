using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SuperMarketApplication.Data.Models
{
    public class Ingredient : BaseEntity
    {
        public string Name { get; set; }

        public IngredientType Type { get; set; }

        [InverseProperty("Ingredient"), IgnoreDataMember]
        public IList<SuperMarketIngredient> SuperMarkets { get; set; }

        public IList<ShoppingHistory> ShoppingHistory { get; set; }

        [InverseProperty("Ingredients"), IgnoreDataMember]
        public IList<Container> Containers { get; set; }
    }

    public enum IngredientType
    {
        Vegetable = 0,
    }
}
