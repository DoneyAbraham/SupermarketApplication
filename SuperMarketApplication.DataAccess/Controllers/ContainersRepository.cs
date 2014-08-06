using SuperMarketApplication.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SuperMarketApplication.DataAccess.Controllers
{
    public class ContainersRepository : BaseRepository
    {
        public Container CreateContainer(Container container)
        {
            this.Context.Containers.Add(container);
            this.Context.SaveChanges();

            return container;
        }

        public IList<Container> GetContainersForUser(Guid userId)
        {
            return this.Context.Containers.Include(c => c.Ingredients).Where(c => c.UserId == userId).ToList();
        }

        public void DeleteContainer(Guid containerId)
        {
            var container = this.Context.Containers.Include(c => c.Ingredients).Single(c => c.Id == containerId);

            this.Context.Containers.Remove(container);

            this.Context.SaveChanges();
        }
    }
}
