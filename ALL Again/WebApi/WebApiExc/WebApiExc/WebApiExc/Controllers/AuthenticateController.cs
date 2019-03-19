using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiExc.Filters;
using BusinessServices;
using System.Configuration;
namespace WebApiExc.Controllers
{
    [ApiAuthenticationFilter]
    public class AuthenticateController : ApiController
    {
        [Route("authenticate")]
        public HttpResponseMessage PostAuthenticate()
        {
            if (System.Threading.Thread.CurrentPrincipal != null && System.Threading.Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                var BasicAuthencticationIdentity = System.Threading.Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;
                if (BasicAuthencticationIdentity != null)
                {
                    var UserId = BasicAuthencticationIdentity.Userid;
                    return GenerateToken(UserId);
                }
            }
            return null;
        }

        private ITokenServices _tokenServices;
        private HttpResponseMessage GenerateToken(int UserId)
        {
            _tokenServices = new BusinessServices.TokenServices();
            var Token = _tokenServices.GenerateToken(UserId);
            var response = Request.CreateResponse(HttpStatusCode.OK, "Authorized");
            response.Headers.Add("Token", Token.AuthToken);
            response.Headers.Add("TokenExpiry", ConfigurationManager.AppSettings["AuthTokenExpiry"]);
            return response;

        }


    }

}
