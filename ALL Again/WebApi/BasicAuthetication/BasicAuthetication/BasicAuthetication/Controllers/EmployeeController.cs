using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccess;
using System.Threading;


namespace BasicAuthetication.Controllers
{
    public class EmployeeController : ApiController
    {
        SampleEntities db = new SampleEntities();
        // GET api/<controller>
       [BasicAuthentication]
        public IEnumerable<tblEmployee> Get()
        {
            string userName = Thread.CurrentPrincipal.Identity.Name;
            //string userName1 = Thread.CurrentPrincipal.Identity.AuthenticationType;
            //bool userName2 = Thread.CurrentPrincipal.Identity.IsAuthenticated;

           //string userId = HttpContext.Current.User.Identity.GetUserId();
           switch(userName)
           {
               case "sa" :
                   return db.tblEmployees.ToList().Where(x=>x.Gender=="Male");
                   case "na" :
                   return db.tblEmployees.ToList().Where(x=>x.Gender=="Female");
               default :
                   return db.tblEmployees.ToList();
           }
            
        }

        // GET api/<controller>/5
     [BasicAuthentication]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}