using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketApplication.DataAccess.Models
{
    public class ShoppingOrder
    {
        public Guid UserId { get; set; }

        public IList<Guid> Ingredients { get; set; }

        public IList<string> Recipes { get; set; }

        public float TotalPrice { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public int PostCode { get; set; }

        public string PostAddress { get; set; }
    }
}
