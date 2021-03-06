﻿using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;

namespace PresentationWebApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService _productsService;
        private readonly ICategoriesService _categoriesService;
        private IWebHostEnvironment _env;
        private readonly ILogger<ProductsController> _logger;
        public ProductsController(IProductsService productsService, ICategoriesService categoriesService,
             IWebHostEnvironment env, ILogger<ProductsController> logger)
        {
            _productsService = productsService;
            _categoriesService = categoriesService;
            _env = env;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var list = _productsService.GetProducts();
            return View(list);
        }

        [HttpPost]
        public IActionResult Search(string keyword)
        {
            var list = _productsService.GetProducts(keyword).ToList();

            return View("Index", list);
        }

        public IActionResult Details(Guid id)
        {
            var p = _productsService.GetProduct(id);
            _logger.LogInformation("Product details are shown of ID: ", id);

            return View( p);
        }

        //the engine will load a page with empty fields
        [HttpGet]
        [Authorize (Roles ="Admin")] //is going to be accessed only by authenticated users
        public IActionResult Create()
        {
            //fetch a list of categories
            var listOfCategeories = _categoriesService.GetCategories();

            //we pass the categories to the page
            ViewBag.Categories = listOfCategeories;

            return View();
        }

        //here details input by the user will be received
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(ProductViewModel data, IFormFile f)
        {
            try
            {
                if(f !=  null)
                {
                    if(f.Length > 0)
                    {
                        string newFilename = Guid.NewGuid() + System.IO.Path.GetExtension(f.FileName);
                        string newFilenameWithAbsolutePath = _env.WebRootPath +  @"\Images\" + newFilename;
                        
                        using (var stream = System.IO.File.Create(newFilenameWithAbsolutePath))
                        {
                            f.CopyTo(stream);
                        }

                        data.ImageUrl = @"\Images\" + newFilename;
                    }
                }

                _productsService.AddProduct(data);

                TempData["feedback"] = "Product was added successfully";
            }
            catch (Exception ex)
            {
                _logger.LogInformation("The product could not be added of: ", data);
                TempData["warning"] = "Product was not added!";
            }

           var listOfCategeories = _categoriesService.GetCategories();
           ViewBag.Categories = listOfCategeories;
            return View(data);
        
        } //fiddler, burp, zap, postman

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _productsService.DeleteProduct(id);
                TempData["feedback"] = "Product was deleted";
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Product is Deleted ID: ", id);
                TempData["warning"] = "Product was not deleted"; //Change from ViewData to TempData
            }

            return RedirectToAction("Index");
        }
    }
}