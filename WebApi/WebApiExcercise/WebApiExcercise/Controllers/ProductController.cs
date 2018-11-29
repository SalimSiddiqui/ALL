using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiExcercise.Filters;
using AttributeRouting.Web.Http;
using BusinessServices;
using WebApiExcercise.ActionFilters;

namespace WebApiExcercise.Controllers
{
   [AuthorizationRequired]
    [RoutePrefix("v1/Products/Product")]
    public class ProductController : ApiController
    {
        [Route("allproducts")]
        //[GET("all")]
        public HttpResponseMessage Get()
        {
            IProductServices _productServices = new ProductServices ();
            var products = _productServices.GetAllProducts();
            //var productEntities = products as List<ProductEntity> ?? products.ToList();
            //if (productEntities.Any())
            return Request.CreateResponse(HttpStatusCode.OK, products);
           // throw new ApiDataException(1000, "Products not found", HttpStatusCode.NotFound);
        }
    }
}
