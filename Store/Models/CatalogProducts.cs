using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;


namespace Store.Models
{
    [Table(Name = "CatalogProducts")]
    public class CatalogProducts
    {
        [Column(Name = "product_id")]
        public int ProductId { get; set; }

        [Column(Name = "catalog_id")]
        public int CatalogId { get; set; }
        public Products Product { get; set; }
        public Catalog Catalog { get; set; }
    }
}
