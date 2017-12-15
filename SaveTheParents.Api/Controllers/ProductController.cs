using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using SaveTheParents.Contracts;
using SaveTheParents.Models.Product;
using SaveTheParents.Services;

namespace SaveTheParents.Api.Controllers
{
    public class ProductController : ApiController
    {
        private IProductService CreateProductService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var productService = new ProductService(userId);
            return productService;
        }

        [AllowAnonymous]
        public IHttpActionResult GetAll()
        {
            var productService = CreateProductService();

            var products = productService.GetProducts();

            return Ok(products);
        }

        [AllowAnonymous]
        public IHttpActionResult Get(int productId)
        {
            var productService = CreateProductService();

            var product = productService.GetProductById(productId);

            return Ok(product);
        }

        [Authorize]
        public IHttpActionResult Post(ProductCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var productService = CreateProductService();

            if (!productService.Create(model))
                return InternalServerError();

            return Ok();
        }

        [Authorize]
        public IHttpActionResult Put(ProductEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var productService = CreateProductService();

            if (!productService.Update(model))
                return InternalServerError();

            return Ok();
        }

        [Authorize]
        public IHttpActionResult Delete(int productId)
        {
            var productService = CreateProductService();

            if (!productService.Delete(productId))
                return InternalServerError();

            return Ok();
        }
    }
}
