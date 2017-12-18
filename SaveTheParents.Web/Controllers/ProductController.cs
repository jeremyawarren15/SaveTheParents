using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SaveTheParents.Models.Product;
using SaveTheParents.Services;

namespace SaveTheParents.Web.Controllers
{
    public class ProductController : Controller
    {
        private Guid _userId;

        public ProductController()
        {
            if (User != null)
            {
                _userId = Guid.Parse(User.Identity.GetUserId());
            }
        }

        // GET: Product
        [AllowAnonymous]
        public ActionResult Index()
        {
            var service = new ProductService();
            return View(service.GetProducts());
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(ProductCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProductService(userId);

            if (service.Create(model))
            {
                TempData["SaveResult"] = "Your product was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Product could not be created");
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var service = new ProductService();
            var model = service.GetProductById(id);

            return View(model);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var productService = new ProductService(_userId);
            var detail = productService.GetProductById(id);
            var model =
                new ProductEdit()
                {
                    ProductId = detail.ProductId,
                    Upc = detail.Upc,
                    ProductName = detail.ProductName,
                    ProductDescription = detail.ProductName
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(int id, ProductEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ProductId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var productService = new ProductService(_userId);

            if (productService.Update(model))
            {
                TempData["SaveResult"] = "Your product was updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your product could not be updated.");
            return View(model);
        }

        
    }
}