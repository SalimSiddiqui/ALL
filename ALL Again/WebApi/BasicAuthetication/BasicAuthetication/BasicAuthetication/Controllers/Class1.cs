using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;


namespace BasicAuthetication.Controllers
{
    public class Class1: AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string Authitoken = actionContext.Request.Headers.Authorization.Parameter;
                string EncodedToken=  Encoding.UTF8.GetString(Convert.FromBase64String(Authitoken));
                string[] Cread = EncodedToken.Split(':');
                string username = Cread[0];
                string password = Cread[1];

               if(EmpoyeeSecutiry.CheckLogin(username,password))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username),null);
                }
               else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
            base.OnAuthorization(actionContext);
        }
    }
}