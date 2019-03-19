using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiExc.Filters;
namespace WebApiExc.Controllers
{
    //[AuthorizationRequired]
    [RoutePrefix("v1/Products/Product")]
    public class ProductController : ApiController
    {
    }
}
