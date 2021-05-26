using CoreWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApp.Repository
{
    public interface IProductsRepository
    {
        List<Product> GetProducts();
        Product GetProduct(int id);
    }
}
