using SaveTheParents.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheParents.Contracts
{
    public interface IProductService
    {
        bool Create(ProductCreate model);
        ICollection<ProductListItem> GetProducts();
        ProductDetail GetProductById(int productId);
        bool Update(ProductEdit model);
        bool Delete(int productId);
    }
}
