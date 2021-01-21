using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Application.Interfaces;

namespace PresentationWebApp.Controllers
{
       public class CartController : Controller
        {
        private readonly IProductsService _productsService;

        public CartController(IProductsService productsService)
        {
            _productsService = productsService;
        }
           
        public IActionResult Index()
        {
            var list = _productsService.GetProducts();
            return View(list);
        }

     

    }
}
