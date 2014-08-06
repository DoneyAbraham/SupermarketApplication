using SuperMarketApplication.Data.Models;
using SuperMarketApplication.DataAccess.Controllers;
using SuperMarketApplication.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SuperMarketApplication.WebApi.Controllers
{
    public class SuperMarketsController : BaseController<SuperMarketRepository>
    {
        public IList<SuperMarket> Get([FromUri]string[] ingredients)
        {
            return this.Repository.FindByIngredients(ingredients);
        }

        public ShoppingHistory Post([FromBody]ShoppingOrder order)
        {
            return this.Repository.PlaceOrder(order);
        }
    }
}
