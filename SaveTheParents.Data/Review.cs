using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheParents.Data
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public float ParentRating { get; set; }


        public float ChildRating { get; set; }

        public string ReviewText { get; set; }

        [Required]
        public DateTimeOffset CreatedDate { get; set; }


        public DateTimeOffset? ModifiedDate { get; set; }

        public virtual Product Product { get; set; }
    }
}
