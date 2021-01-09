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
        static string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Shopdb;Trusted_Connection=True";

        public IEnumerable<Products> GetProducts(string catalog)
        {
            
            DataContext db = new DataContext(connectionString);

            var products1 = db.GetTable<Products>();
            var catalogs = db.GetTable<Catalog>();
            var catalogProducts = db.GetTable<CatalogProducts>();
            
            var query = from product in products1
                        join catalogProduct in catalogProducts on product.Id equals catalogProduct.ProductId
                        from catalog1 in catalogs
                        join catalogProduct1 in catalogProducts on catalog1.Id equals catalogProduct1.CatalogId

                        where catalog1.Name == catalog
                        select product.Name;

            return query as IEnumerable<Products>; 
        }
    }
}
