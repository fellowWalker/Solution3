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
        private IOrdersService _orderHistoryService;
        private readonly ILogger<CartController> _logger;
        public CartController(ICartProductService cartProductService, IOrdersService orderHistoryService, ILogger<CartController> logger)
        {
            _cartProductService = cartProductService;
            _orderHistoryService = orderHistoryService;
            _logger = logger;
        }

        public IActionResult Index(string email)
        {
            var myProduct = _cartProductService.GetCartProduct(email);
            return View(myProduct);
        }

        public IActionResult DeleteFromCart(Guid id)
        {
            _cartProductService.DeleteCartProduct(id);
            TempData["feedback"] = "The product was deleted";

            _logger.LogInformation("Product deleted from cart. ID: ", id);

            return RedirectToAction("Index");
        }

        public IActionResult AddToOrderDetails()
        {
            string email = User.Identity.Name;
            _orderHistoryService.Checkout(email);

            TempData["feedback"] = "Added to Order";
            _logger.LogInformation("Product added to OrderDetails. User email: ", email);

            return RedirectToAction("Index", "OrderDetails");

        }
    }
}