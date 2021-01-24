using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingCart.Application.Interfaces;

namespace ShoppingCart.Controllers
{
    public class CartController : Controller
    {
        private ICartProductService _cartProductService;
        private IOrdersService _orderService;
        private readonly ILogger<CartController> _logger;
        public CartController(ICartProductService cartProductService, IOrdersService ordersService,
            ILogger<CartController> logger)
        {
            _cartProductService = cartProductService;
            _orderService = ordersService;
            _logger = logger;
        }

        public IActionResult Index(string email)
        {
            var myProduct = _cartProductService.GetCartProducts(email);
            return View(myProduct);
        }

        public IActionResult DeleteFromCart(Guid id)
        {
            _cartProductService.DeleteCartProduct(id);
            TempData["feedback"] = "Product was deleted";

            _logger.LogInformation("Product deleted from cart of ID: ", id);

            return RedirectToAction("Index");
        }

        public IActionResult AddOrderDetails()
        {
            string email = User.Identity.Name;
            string id = User.Identity.Name;

            _orderService.Checkout(id, email);

            _logger.LogInformation("Product added to OrderDetails. User email: ", email);
            TempData["feedback"] = "Added to Order";            

            return RedirectToAction("Index", "OrderDetails");
        }
    }
}