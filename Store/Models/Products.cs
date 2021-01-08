using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using LinqToDB.Mapping;
using Mindbox.Data.Linq;
using System.Data.Linq.Mapping;

namespace Store.Models
{
    public class Products
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "product_name")]
        public string Name { get; set; }
        public virtual ICollection<Catalog> Catalogs { get; set; } = new List<Catalog>();
       
    }
}
