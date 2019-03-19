using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace WebApiExc.Filters
{
    public class BasicAuthenticationIdentity: GenericIdentity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Userid{ get; set; }
        public BasicAuthenticationIdentity(string username, string Pass): base(username,"Basic")
        {
            UserName = username;
            Password = Pass;
        }
    }
}