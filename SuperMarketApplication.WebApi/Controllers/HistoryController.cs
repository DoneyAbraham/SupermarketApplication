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
    public class HistoryController : BaseController<UsersRepository>
    {
        public IList<ShoppingHistory> Get(Guid id)
        {
            return this.Repository.GetHistory(id);
        }
    }
}
