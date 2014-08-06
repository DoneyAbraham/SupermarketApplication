using SuperMarketApplication.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System;

namespace SuperMarketApplication.DataAccess.Controllers
{
    public class IngredientsRepository : BaseRepository
    {
        public Ingredient CreateIngredient(string name, IngredientType type)
        {
            var ingredient = new Ingredient
            {
                Name = name,
                Type = type
            };

            this.Context.Ingredients.Add(ingredient);

            this.Context.SaveChanges();

            return ingredient;
        }

        public Ingredient CreateIngredient(Ingredient ingredient)
        {
            this.Context.Ingredients.Add(ingredient);

            this.Context.SaveChanges();

            return ingredient;
        }
    }
}
