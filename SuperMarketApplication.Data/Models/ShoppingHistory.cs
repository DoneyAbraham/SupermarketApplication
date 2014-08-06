using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketApplication.Data.Models
{
    [Table("ShoppingHistory")]
    public class ShoppingHistory : BaseEntity
    {
        public ShoppingHistory()
        {
            this.Recipes = new List<RecipeHistory>();
            this.Ingredients = new List<ShoppingHistoryIngredientId>();
        }

        [ForeignKey("User")]
        public Guid UserId { get; set; }

        [InverseProperty("ShoppingHistory"), IgnoreDataMember]
        public User User { get; set; }

        [InverseProperty("ShoppingHistory")]
        public IList<RecipeHistory> Recipes { get; set; }

        public IList<ShoppingHistoryIngredientId> Ingredients { get; set; }

        [NotMapped]
        public IEnumerable<Guid> IngredientIds
        {
            get {
                return this.Ingredients.Select(i => i.IngredientId);
            }
        }

        public float TotalPrice { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public int PostCode { get; set; }

        public string PostAddress { get; set; }

    }
}
