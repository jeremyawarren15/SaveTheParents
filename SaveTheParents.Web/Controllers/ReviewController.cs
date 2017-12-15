using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SaveTheParents.Models.Review;
using SaveTheParents.Services;

namespace SaveTheParents.Web.Controllers
{
    public class ReviewController : Controller
    {
        // GET: Review
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Create(int id)
        {
            var model = new ReviewCreate();
            model.ProductId = id;
            model.UserId = Guid.Parse(User.Identity.GetUserId());
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(ReviewCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ReviewService(userId, model.ProductId);

            if (service.Create(model))
            {
                TempData["SaveResult"] = "Your Review was created.";
                return RedirectToAction("Details", "Product", new {id=model.ProductId});
            }

            ModelState.AddModelError("", "Review could not be created");
            return View(model);
        }
    }
}