using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheParents.Models.Review
{
    public class ReviewEdit
    {
        [Required]
        public int ReviewId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        [Range(0,10)]
        [DefaultValue(0)]
        public int ParentRating { get; set; }

        [Required]
        [Range(0,10)]
        [DefaultValue(0)]
        public int ChildRating { get; set; }
        
        [Required]
        public string ReviewTitle { get; set; }

        [Required]
        public string ReviewText { get; set; }

        [Required]
        public DateTimeOffset? ModifiedDate { get; set; }
    }
}
