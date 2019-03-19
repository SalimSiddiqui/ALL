using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FirstWebApi.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections;

namespace FirstWebApi.Controllers
{
    public class ProductController : ApiController
    {

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [ActionName("SupplierAndProduct")]
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
