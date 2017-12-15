using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaveTheParents.Models.Review;

namespace SaveTheParents.Data
{
    public class Product
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }
        
        [Required]
        public string Upc { get; set; }

        public string ProductDescription { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
