using CoreWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApp.Repository
{
    public class ProductsRepository : IProductsRepository
    {
        public Product GetProduct(int id)
        {
            return new Product
            {
                Id = 1,
                Name = "Book1",
                Price = 100
            };
        }

        public List<Product> GetProducts()
        {
  
            var prod = new List<Product>()
            {new Product{
                Id = 1,
                Name = "Book1",
                Price = 100
            },
            new Product{
                Id = 2,
                Name = "Book2",
                Price = 200
            },
            new Product{
                Id = 3,
                Name = "Book3",
                Price = 300
            }
            };

            return prod;
        }
    }
}
