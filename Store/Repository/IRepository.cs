using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Repository
{
    public interface IRepository
    {
        IEnumerable<Products> GetProducts(string catalog);
    }
}
