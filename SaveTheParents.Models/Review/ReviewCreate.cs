using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheParents.Models.Review
{
    public class ReviewCreate
    {
        public Guid UserId { get; set; }
        public int ProductId { get; set; }
        public float ParentRating { get; set; }
        public float ChildRating { get; set; }
        public string ReviewTitle { get; set; }
        public string ReviewText { get; set; }
    }
}
