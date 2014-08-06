using SuperMarketApplication.Data.Models;
using SuperMarketApplication.DataAccess.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SuperMarketApplication.WebApi.Controllers
{
    public class IngredientsController : BaseController<IngredientsRepository>
    {
        public Ingredient Post(Ingredient ingredient)
        {
            return this.Repository.CreateIngredient(ingredient);
        }
    }
}
