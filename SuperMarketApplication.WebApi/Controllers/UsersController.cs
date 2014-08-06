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
    public class UsersController : BaseController<UsersRepository>
    {
        public IList<User> Get()
        {
            return this.Repository.GetAllUsers();
        }

        public User Get(Guid id)
        {
            return this.Repository.GetUser(id);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this.Repository.Dispose();
        }
    }
}
