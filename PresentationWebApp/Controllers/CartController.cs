using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingCart.Application.Interfaces;

namespace ShoppingCart.Controllers
{
    public class CartController : Controller
    {
        private ICartProductService _cartProductService;
        private IOrderHistoryService _orderHistoryService;
        private readonly ILogger<CartController> _logger;
        public CartController( ICartProductService cartProductService, IOrderHistoryService orderHistoryService, ILogger<CartController> logger)
        {
            _cartProductService = cartProductService;
            _orderHistoryService = orderHistoryService;
            _logger = logger;
        }

        public IActionResult Index(string email)
        {
            var myProduct = _cartProductService.GetCartProducts(email);
            return View(myProduct);
        }

        public IActionResult DeleteFromCart(Guid id)
        {
            _cartProductService.DeleteFromCart(id);
            TempData["feedback"] = "The product was deleted successfully!";

            _logger.LogInformation("Deleting product from cart. ID: ", id);

            return RedirectToAction("Index");      
        }

        public IActionResult AddToOrderHistory()
        {
            string email = User.Identity.Name;
            _orderHistoryService.AddToOrderHistory(email);

            TempData["feedback"] = "Added to Order";
            _logger.LogInformation("Product added to OrderHistory. User email: ", email);

            return RedirectToAction("Index", "OrderHistory");
            
        }
    }
}
