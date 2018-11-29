using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace WebApiExcercise.Filters_
{
    public class BasicAuthetication1 : GenericIdentity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }
        public BasicAuthetication1(string username, string pass):base(username,"Basic")

        {
            this.Username = username;this.Password = Password;

        }
    }
}