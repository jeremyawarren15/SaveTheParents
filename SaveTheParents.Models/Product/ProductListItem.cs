using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheParents.Models.Product
{
    public class ProductListItem
    {
        public int ProductId { get; set; }
        public string Upc { get; set; }
        public string ProductName { get; set; }
        public int ReviewCount { get; set; }
    }
}
