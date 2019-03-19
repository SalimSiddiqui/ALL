using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Text;
using System.Threading;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using System.Security.Principal;

namespace BasicAuthetication.Controllers
{
    public class Class2: AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {

            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string token = actionContext.Request.Headers.Authorization.Parameter;
                string encode= Encoding.UTF8.GetString(Convert.FromBase64String(token));

                string[] cre = encode.Split(':');
                string username = cre[0];
                string password = cre[1];

               if( EmpoyeeSecutiry.CheckLogin(username,password))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username), null);
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