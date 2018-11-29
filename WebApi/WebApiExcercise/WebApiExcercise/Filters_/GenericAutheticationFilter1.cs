using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebApiExcercise.Filters_
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class GenericAutheticationFilter1 : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {

            var identity = FetchAuthHeader(actionContext);
            if (identity == null)
                return ;
            var principal = new GenericPrincipal(identity, null);
            System.Threading.Thread.CurrentPrincipal = principal;

            base.OnAuthorization(actionContext);
        }

        protected virtual BasicAuthetication1 FetchAuthHeader(HttpActionContext actionContext)
        {
            string authHeaderValue=null;
            var AuthHeader = actionContext.Request.Headers.Authorization;
            if (AuthHeader != null && AuthHeader.Scheme == "Basic" && !String.IsNullOrEmpty(AuthHeader.Scheme))
            {
                authHeaderValue = AuthHeader.Parameter;
            }
            if (string.IsNullOrEmpty(authHeaderValue))
            {
                return null;
            }
            authHeaderValue = Encoding.ASCII.GetString(Convert.FromBase64String(authHeaderValue));

            var UsernamePass = authHeaderValue.Split(':');
            return new BasicAuthetication1(UsernamePass[0], UsernamePass[1]);
        }
        
    }
}