using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.VisualBasic.ApplicationServices;
using SaveTheParents.Contracts;
using SaveTheParents.Models.Review;
using SaveTheParents.Services;

namespace SaveTheParents.Api.Controllers
{
    public class ReviewController : ApiController
    {
        private IReviewService CreateReviewService(int productId)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var reviewService = new ReviewService(userId, productId);
            return reviewService;
        }

        private IReviewService CreateReviewService()
        {
            return new ReviewService();
        }

        [AllowAnonymous]
        public IHttpActionResult GetAll()
        {
            var reviewService = CreateReviewService();

            var reviews = reviewService.GetReviews();

            return Ok(reviews);
        }

        [AllowAnonymous]
        public IHttpActionResult GetAll(int productId)
        {
            var reviewService = CreateReviewService(productId);

            var reviews = reviewService.GetReviewsByProductId(productId);

            return Ok(reviews);
        }

        [AllowAnonymous]
        public IHttpActionResult Get(int reviewId)
        {
            var reviewService = CreateReviewService();

            var review = reviewService.GetReviewById(reviewId);

            return Ok(review);
        }

        public IHttpActionResult Post(ReviewCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reviewService = CreateReviewService(model.ProductId);

            if (!reviewService.Create(model))
                return InternalServerError();

            return Ok();
        }

        [Authorize]
        public IHttpActionResult Put(ReviewEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reviewService = CreateReviewService();

            if (!reviewService.Update(model))
                return InternalServerError();

            return Ok();
        }

        [Authorize]
        public IHttpActionResult Delete(int reviewId)
        {
            var reviewService = CreateReviewService();

            if (!reviewService.Delete(reviewId))
                return InternalServerError();

            return Ok();
        }
    }
}