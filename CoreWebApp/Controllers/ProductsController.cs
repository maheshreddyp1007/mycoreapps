using CoreWebApp.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsController(IProductsRepository productRepository)
        {
            _productsRepository = productRepository;
        }
        public IActionResult Index()
        {
            var products = _productsRepository.GetProducts();
            return View(products);
        }


        public IActionResult Details(int id)
        {
            var products = _productsRepository.GetProduct(id);
            return View(products);
        }
    }
}
