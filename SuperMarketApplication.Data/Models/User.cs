using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketApplication.Data.Models
{
    public class User : BaseEntity
    {
        public string Email { get; set; }

        [MaxLength(4000)]
        public string Password { get; set; }
        public string FirstName { get; set; }

        [InverseProperty("User")]
        public IList<ShoppingHistory> ShoppingHistory { get; set; }

        [InverseProperty("User")]
        public IList<Container> Containers { get; set; }
    }
}
