using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Text;
using System.Threading;
using System.Security.Principal;
namespace BasicAuthetication.Controllers
{
    public class BasicAuthentication : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                //if (actionContext.Request.Headers.Authorization.Parameter == null)
                //{
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                //}
            }
            else
            {
                string AuthorizationToken = actionContext.Request.Headers.Authorization.Parameter;
                string EncodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(AuthorizationToken));
                string[] Cred = EncodedToken.Split(':');
                string username = Cred[0];
                string pass = Cred[1];
                if (EmpoyeeSecutiry.CheckLogin(username, pass))
                {
                    //  Thread.CurrentPrincipal = new GenericIdentity(new GenericPrincipal(username), null);
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