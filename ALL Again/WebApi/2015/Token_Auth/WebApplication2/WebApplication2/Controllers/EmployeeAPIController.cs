using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static WebApplication2.Models.EmployeeModel;

namespace WebApplication2.Controllers
{
    [Authorize]
    public class EmployeeAPIController : ApiController
    {
        public List<Employee> Get()
        {
            return new EmployeeDatabase();
        }
    }
}
