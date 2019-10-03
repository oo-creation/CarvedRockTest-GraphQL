using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarvedRock.Webapp.Models;

namespace CarvedRock.Webapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductGraphClient _productGraphClient;

        public HomeController(ProductGraphClient productGraphClient)
        {
            _productGraphClient = productGraphClient;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productGraphClient.GetAllProducts();
            Debug.WriteLine("Got it");
            return View(products);
        }

        public async Task<IActionResult> ProductDetail(int productId)
        {
            var product = await _productGraphClient.GetProduct(productId);
            return View(product);
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}