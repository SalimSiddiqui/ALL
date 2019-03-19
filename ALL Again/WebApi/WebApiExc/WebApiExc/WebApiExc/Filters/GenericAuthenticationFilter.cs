using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Text;
using System.Security.Principal;
using System.Threading;
namespace WebApiExc.Filters
{
    [AttributeUsage(AttributeTargets.Class |AttributeTargets.Method, AllowMultiple =true)]
    public class GenericAuthenticationFilter : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext filterContext)
        {
            var Identity = FetchHeader(filterContext);
            if(Identity==null)
            {
                return;
            }
            var genericPrincipal =new GenericPrincipal(Identity, null);
            Thread.CurrentPrincipal = genericPrincipal; 
            if(!OnAuthorizeUser(Identity.UserName,Identity.Password,filterContext))
            {
                return;
            }
            base.OnAuthorization(filterContext);

        }

        public BasicAuthenticationIdentity FetchHeader(HttpActionContext filterContext)
        {
            string[] Creadential = null;
            if (filterContext.Request.Headers != null && filterContext.Request.Headers.Authorization.Parameter != null)
            {
                string authHeaderValue = filterContext.Request.Headers.Authorization.Parameter;
                authHeaderValue = Encoding.Default.GetString(Convert.FromBase64String(authHeaderValue));
                Creadential = authHeaderValue.Split(':');
            }
            return new BasicAuthenticationIdentity(Creadential[0], Creadential[1]);

        }
        protected virtual bool OnAuthorizeUser(string username, string Pass, HttpActionContext filterContext)
        {
            if(string.IsNullOrEmpty(username)|| string.IsNullOrEmpty(Pass))
                            return false;
            return true;          
             
        }

    }
}