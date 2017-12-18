using SaveTheParents.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.ApplicationServices;
using SaveTheParents.Data;
using SaveTheParents.Data.IdentityModels;
using SaveTheParents.Models.Product;

namespace SaveTheParents.Services
{
    public class ProductService : IProductService
    {
        private readonly Guid _userId;

        public ProductService(Guid userId)
        {
            _userId = userId;
        }

        public ProductService()
        {
        }

        public bool Create(ProductCreate model)
        {
            var product = new Product()
            {
                ProductName = model.ProductName,
                ProductDescription = model.ProductDescription,
                Upc = model.Upc
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Products.Add(product);
                return ctx.SaveChanges() == 1;
            }
        }

        public ICollection<ProductListItem> GetProducts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var products =
                    ctx
                        .Products
                        .Select(
                            e => new ProductListItem()
                            {
                                ProductId = e.ProductId,
                                ProductName = e.ProductName,
                                Upc = e.Upc
                            });

                var final = products.ToList();

                var reviewService = new ReviewService();

                foreach (var item in final)
                {
                    item.ReviewCount = reviewService.GetReviewCountByProductId(item.ProductId);
                }

                return final;
            }
        }

        public ProductDetail GetProductById(int productId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var product =
                    ctx
                        .Products
                        .SingleOrDefault(e => e.ProductId == productId);

                var rService = new ReviewService(_userId, productId);

                return
                    new ProductDetail()
                    {
                        ProductId = product.ProductId,
                        ProductName = product.ProductName,
                        ProductDescription = product.ProductDescription,
                        Upc = product.Upc,
                        Reviews = rService.GetReviewsByProductId(productId)
                    };
            }
        }

        public bool Update(ProductEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var product =
                    ctx
                        .Products
                        .SingleOrDefault(e => e.ProductId == model.ProductId);

                product.ProductName = model.ProductName;
                product.ProductDescription = model.ProductDescription;
                product.Upc = model.Upc;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool Delete(int productId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var product =
                    ctx
                        .Products
                        .SingleOrDefault(e => e.ProductId == productId);

                ctx.Products.Remove(product);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
