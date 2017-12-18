using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaveTheParents.Contracts;
using SaveTheParents.Data;
using SaveTheParents.Data.IdentityModels;
using SaveTheParents.Models.Review;

namespace SaveTheParents.Services
{
    public class ReviewService : IReviewService
    {
        private readonly Guid _userId;
        private readonly int _productId;

        public ReviewService(Guid userId, int productId)
        {
            _userId = userId;
            _productId = productId;
        }

        public ReviewService()
        {
            // Only for getting reviews
        }

        public bool Create(ReviewCreate model)
        {
            var review =
                new Review()
                {
                    UserId = _userId,
                    ProductId = _productId,
                    ParentRating = model.ParentRating,
                    ChildRating = model.ChildRating,
                    ReviewText = model.ReviewText,
                    ReviewTitle = model.ReviewTitle,
                    CreatedDate = DateTimeOffset.UtcNow,
                };

            review.UserName = GetNameFromUserId(model.UserId);

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Reviews.Add(review);
                return ctx.SaveChanges() == 1;
            }
        }

        public ICollection<ReviewListItem> GetReviews()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var reviews =
                    ctx
                        .Reviews
                        .Where(r => r.UserId == _userId)
                        .Select(
                            e => new ReviewListItem()
                            {
                                ReviewId = e.ReviewId,
                                UserId = e.UserId,
                                ParentRating = e.ParentRating,
                                ChildRating = e.ChildRating,
                                CreatedDate = e.CreatedDate,
                                ModifiedDate = e.ModifiedDate
                            });

                return reviews.ToList();
            }
        }

        public ICollection<ReviewListItem> GetReviewsByProductId(int productId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var reviews =
                    ctx
                        .Reviews
                        .Where(r => r.ProductId == productId)
                        .Select(
                            e => new ReviewListItem()
                            {
                                ReviewId = e.ReviewId,
                                UserId = e.UserId,
                                ParentRating = e.ParentRating,
                                ChildRating = e.ChildRating,
                                ReviewTitle = e.ReviewTitle,
                                ReviewText = e.ReviewText,
                                CreatedDate = e.CreatedDate,
                                ModifiedDate = e.ModifiedDate
                            });

                var final = reviews.ToList();

                foreach (var item in final)
                {
                    item.UserName = GetNameFromUserId(item.UserId);
                }

                return final;
            }
        }

        public ReviewDetail GetReviewById(int reviewId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var review =
                    ctx
                        .Reviews
                        .SingleOrDefault(r => r.ReviewId == reviewId);

                return
                    new ReviewDetail()
                    {
                        UserId = review.UserId,
                        ProductId = review.ProductId,
                        ParentRating = review.ParentRating,
                        ChildRating = review.ChildRating,
                        ReviewText = review.ReviewText,
                        CreatedDate = review.CreatedDate,
                        ModifiedDate = review.ModifiedDate
                    };
            }
        }

        public bool Update(ReviewEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var review =
                    ctx
                        .Reviews
                        .SingleOrDefault(
                            r =>
                                r.ReviewId == model.ReviewId &&
                                model.UserId == _userId);

                if (review == null) return false;

                review.ParentRating = model.ParentRating;
                review.ChildRating = model.ChildRating;
                review.ReviewText = model.ReviewText;
                review.ModifiedDate = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool Delete(int reviewId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var review =
                    ctx
                        .Reviews
                        .SingleOrDefault(
                            r =>
                                r.ReviewId == reviewId &&
                                r.UserId == _userId);

                if (review == null) return false;

                ctx.Reviews.Remove(review);

                return ctx.SaveChanges() == 1;
            }
        }

        public static string GetNameFromUserId(Guid userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var user =
                    ctx
                        .Users
                        .SingleOrDefault(u => u.Id == userId.ToString());

                return user.UserName;
            }
        }

        public int GetReviewCountByProductId(int productId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var count =
                    ctx
                        .Reviews
                        .Where(r => r.ProductId == productId)
                        .Select(e => e);

                return count.ToList().Count();
            }
        }
    }
}
