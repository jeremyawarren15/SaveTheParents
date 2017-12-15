﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaveTheParents.Models.Review;

namespace SaveTheParents.Models.Product
{
    public class ProductDetail
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Upc { get; set; }
        public string ProductDescription { get; set; }
        public virtual ICollection<ReviewListItem> Reviews { get; set; } = new List<ReviewListItem>();
    }
}
