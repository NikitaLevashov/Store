using Microsoft.Extensions.Configuration;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Repository
{
    public class AdoRepository : IRepository
    {
        public IConfiguration Configuration { get; }
        public IEnumerable<Products> GetProducts(string catalog)
        {
            List<Products> products = new List<Products>();
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Shopdb;Trusted_Connection=True";
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandText = $"SELECT Catalog.catalog_name, Products.product_name FROM Products JOIN CatalogProducts ON CatalogProducts.product_id = Products.Id   LEFT JOIN Catalog ON CatalogProducts.catalog_id = Catalog.Id Where Catalog.catalog_name = '{catalog}' ";

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        products.Add(new Products
                        {
                            Name = sqlDataReader["product_name"].ToString()
                        });

                    }
                    sqlConnection.Close();
                }
            }
            return products;
        }
    }
}
