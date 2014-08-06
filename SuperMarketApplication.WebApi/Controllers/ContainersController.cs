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
    public class ContainersController : BaseController<ContainersRepository>
    {
        public Container Post(Container container)
        {
            return this.Repository.CreateContainer(container);
        }

        public IList<Container> Get(Guid userId)
        {
            return this.Repository.GetContainersForUser(userId);
        }

        public HttpResponseMessage Delete(Guid id)
        {
            this.Repository.DeleteContainer(id);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
