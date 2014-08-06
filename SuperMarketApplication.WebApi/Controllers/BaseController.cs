using SuperMarketApplication.DataAccess.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperMarketApplication.Data.Models;
using System.Web.Http;

namespace SuperMarketApplication.WebApi.Controllers
{
    public abstract class BaseController<TRepository> : ApiController
        where TRepository : BaseRepository
    {
        protected TRepository Repository { get; private set; }
        protected BaseController()
        {
            this.Repository = Activator.CreateInstance<TRepository>();
        }

        //protected override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    base.OnActionExecuting(filterContext);

        //    var userId = filterContext.RequestContext.HttpContext.Request.Cookies["userId"];

        //    if (userId == null)
        //    {
        //        // Redirect to login here
        //    }

        //    User user;
        //    using (var userRepository = new UsersRepository())
        //    {
        //        user = userRepository.GetUser(Guid.Parse(userId.Value));
        //    }
        //}

    }
}
