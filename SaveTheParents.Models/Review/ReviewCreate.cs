using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheParents.Models.Review
{
    public class ReviewCreate
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        [Range(0,10)]
        [DefaultValue(0)]
        public int ParentRating { get; set; }

        [Range(0,10)]
        [DefaultValue(0)]
        public int ChildRating { get; set; }

        public string ReviewTitle { get; set; }
        public string ReviewText { get; set; }
    }
}
