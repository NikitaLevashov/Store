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
    //public class RepositoryByLinqToSqlEntity : IRepository
    //{
    //    public IEnumerable<Products> GetProducts(string catalog)
    //    {
    //        using (ProductContext db = new ProductContext())
    //        {
    //            var products = db.Products.Where(c => c.Name == "Xiaomi product" || c.Name == "Panasonic product" || c.Name == "Samsung product" || c.Name == "Huawei product" || c.Name == "Apple product" || c.Name == "Nokia product" || c.Name == "Honor product" || c.Name == "LG product" || c.Name == "Sony product").Select(c => c).ToList();
    //            return products;
    //        }

    //    }
    //}
}
