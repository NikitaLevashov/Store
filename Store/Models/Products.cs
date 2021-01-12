using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mindbox.Data.Linq;
using System.Data.Linq.Mapping;
using Microsoft.EntityFrameworkCore;



namespace Store.Models
{
    [Table(Name = "Products")]
    public class Products
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "product_name")]
        public string Name { get; set; }
        public ICollection<CatalogProducts> CatalogProduct { get; set; } = new List<CatalogProducts>();

    }
}
