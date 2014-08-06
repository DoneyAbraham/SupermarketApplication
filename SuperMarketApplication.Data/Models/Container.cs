using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketApplication.Data.Models
{
    public class Container : BaseEntity
    {
        public string Name { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }

        [InverseProperty("Containers")]
        public User User { get; set; }
        
        [InverseProperty("Containers")]
        public IList<Ingredient> Ingredients { get; set; }
    }
}
