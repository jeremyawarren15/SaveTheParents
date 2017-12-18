using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheParents.Models.Review
{
    public class ReviewListItem
    {
        public int ReviewId { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public int ParentRating { get; set; }
        public int ChildRating { get; set; }
        public string ReviewTitle { get; set; }
        public string ReviewText { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
    }
}
