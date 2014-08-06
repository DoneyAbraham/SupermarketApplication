using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketApplication.Data.Models
{
    public class RecipeHistory : BaseEntity
    {
        public string Name { get; set; }

        [ForeignKey("ShoppingHistory")]
        public Guid ShoppingHistoryId { get; set; }

        [InverseProperty("Recipes"), IgnoreDataMember]
        public ShoppingHistory ShoppingHistory { get; set; }
    }
}
