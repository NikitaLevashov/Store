using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;


namespace Store.Models
{
    [Table(Name = "Catalog")]
    public class Catalog
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "catalog_name")]
        public string Name { get; set; }
        public ICollection<Products> Product { get; set; } = new List<Products>();
    }
}
