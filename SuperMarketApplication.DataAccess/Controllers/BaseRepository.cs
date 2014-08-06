using SuperMarketApplication.Data.DataAccess;
using SuperMarketApplication.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketApplication.DataAccess.Controllers
{
    public class BaseRepository : IDisposable
    {
        protected DomainDataContext Context { get; set; }

        public BaseRepository()
        {
            this.Context = new DomainDataContext();
        }

        public void Dispose()
        {
            this.Context.Dispose();
        }

        protected T FindEntity<T>(IQueryable<T> collection, Guid id)
            where T : BaseEntity
        {
            return collection.Single(e => e.Id == id);
        }
    }
}
