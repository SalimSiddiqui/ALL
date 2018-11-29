using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AttributeRouting.Web.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using WebApiExcercise.Models;
using System.Collections;
using Newtonsoft.Json.Converters;

namespace WebApiExcercise.Controllers
{
   
    public class JArrayComplexTypeController : ApiController
    {
        [Route("all")]
        public HttpResponseMessage Get()
        {

            return Request.CreateResponse(HttpStatusCode.OK, "found");
            // throw new ApiDataException(1000, "Products not found", HttpStatusCode.NotFound);
        }
        [Route("SupplierAndProduct")]
        [HttpPost]
        public HttpResponseMessage SuppProduct(JArray paramList)
        {
            if (paramList.Count > 0)
            {
              
                Product product = JsonConvert.DeserializeObject<Product>(paramList[0].ToString());
                Supplier supplier = JsonConvert.DeserializeObject<Supplier>(paramList[1].ToString());

                //TO DO: Your implementation code

                HttpResponseMessage response = new HttpResponseMessage { StatusCode = HttpStatusCode.Created };
                return response;
            }
            else
            {
                HttpResponseMessage response = new HttpResponseMessage { StatusCode = HttpStatusCode.InternalServerError };
                return response;
            }
        }

    }
}
