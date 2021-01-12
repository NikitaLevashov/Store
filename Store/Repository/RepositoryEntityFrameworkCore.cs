using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.Models;
using System.Configuration;


namespace Store.Repository
{
    public class RepositoryEntityFrameworkCore : IRepository
    {
        public IEnumerable<Products> GetProducts(string catalog)
        {
            using (ProductContext db = new ProductContext())
            {
                var products = db.Product.ToList();
                var catalogs = db.Catalogs.ToList();
                var catalogProducts = db.CatalogProduct.ToList();
            
                var query = from catalogProduct in catalogProducts
                             join catalogItem in catalogs on catalogProduct.CatalogId equals catalogItem.Id
                             where catalogItem.Name == catalog
                             join prod in products on catalogProduct.ProductId equals prod.Id
                             select prod;


                return query;
            }

        }
    }
}
