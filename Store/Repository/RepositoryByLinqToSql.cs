using Store.Models;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Repository
{
    public class RepositoryByLinqToSql : IRepository
    {
        string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Shopdb;Trusted_Connection=True";

        public IEnumerable<Products> GetProducts(string catalog)
        {
            DataContext db = new DataContext(connectionString);

            var products = db.GetTable<Products>();
            var catalogs = db.GetTable<Catalog>();
            var catalogProducts = db.GetTable<CatalogProducts>();

            var query = from catalogProduct in catalogProducts
                        join catalogItem in catalogs on catalogProduct.CatalogId equals catalogItem.Id
                        where catalogItem.Name == catalog
                        join prod in products on catalogProduct.ProductId equals prod.Id
                        select prod;
            
            return query; 
        }
    }
}
