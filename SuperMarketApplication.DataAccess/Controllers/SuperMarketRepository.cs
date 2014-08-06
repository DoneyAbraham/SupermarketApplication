using SuperMarketApplication.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System;
using SuperMarketApplication.DataAccess.Models;

namespace SuperMarketApplication.DataAccess.Controllers
{
    public class SuperMarketRepository : BaseRepository
    {
        public IList<SuperMarket> FindByIngredients(string[] ingredients)
        {
            return this.Context.SuperMarkets.Include(s => s.Ingredients.Select(i => i.Ingredient)).Where(s => s.Ingredients.Any(i => ingredients.Contains(i.Ingredient.Name))).ToList();
        }

        public ShoppingHistory PlaceOrder(ShoppingOrder order)
        {
            var user = this.Context.Users.Single(u => u.Id == order.UserId);

            var history = new ShoppingHistory
            {
                User = user,
                FirstName = order.FirstName,
                LastName = order.LastName,
                Address = order.Address,
                PostCode = order.PostCode,
                PostAddress = order.PostAddress,
                TotalPrice = order.TotalPrice
            };

            foreach (var recipeName in order.Recipes)
            {
                history.Recipes.Add(new RecipeHistory
                {
                    Name = recipeName
                });
            }

            foreach (var ingredientId in order.Ingredients)
            {
                history.Ingredients.Add(new ShoppingHistoryIngredientId
                {
                    IngredientId = ingredientId
                });
            }

            this.Context.ShoppingHistory.Add(history);

            this.Context.SaveChanges();

            return history;
        }
    }
}
