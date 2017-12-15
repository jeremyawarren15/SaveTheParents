using SaveTheParents.Models.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheParents.Contracts
{
    public interface IReviewService
    {
        bool Create(ReviewCreate model);
        ICollection<ReviewListItem> GetReviews();
        ICollection<ReviewListItem> GetReviewsByProductId(int productId);
        ReviewDetail GetReviewById(int reviewId);
        bool Update(ReviewEdit model);
        bool Delete(int reviewId);
    }
}
