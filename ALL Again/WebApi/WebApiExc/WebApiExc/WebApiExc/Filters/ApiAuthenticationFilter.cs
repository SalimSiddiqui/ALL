using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using BusinessServices;
using System.Threading;
namespace WebApiExc.Filters
{
    public class ApiAuthenticationFilter: GenericAuthenticationFilter
    {
        protected override bool OnAuthorizeUser(string username, string Pass, HttpActionContext filterContext)
        {
            IUserServices user = new UserServices();
            if(user!=null)
            {
                var UserId = user.Authenticate(username, Pass);
                if(UserId>0)
                {
                    var BasicAutheticationIdentity = Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;
                    if(BasicAutheticationIdentity!=null)
                    {
                        BasicAutheticationIdentity.Userid = UserId;
                        return true;
                    }
                }
            }
            return false;
         
        }
    }
}