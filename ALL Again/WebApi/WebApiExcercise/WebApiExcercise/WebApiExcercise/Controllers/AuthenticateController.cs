using System.Net;
using AttributeRouting.Web.Http;
using System.Net.Http;
using System.Web.Http;
using WebApiExcercise.Filters;
using System.Collections.Generic;
using BusinessServices;
using System.Configuration;
namespace WebApiExcercise.Controllers
{
    [ApiAuthenticationFilter]
    public class AuthenticateController : ApiController
    {
        private readonly ITokenServices _tokenServices;
        public  AuthenticateController()
        {
            this._tokenServices = new TokenServices();
        }
        public AuthenticateController(ITokenServices token)
        {
            
        }

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        [POST("login")]
        [POST("authenticate")]
        [POST("get/token")]
        [HttpRoute("authenticate")]
        public HttpResponseMessage PostAuthenticate()
        {
            if (System.Threading.Thread.CurrentPrincipal != null && System.Threading.Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                var basicAuthenticationIdentity = System.Threading.Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;
                if (basicAuthenticationIdentity != null)
                {
                    var userId = basicAuthenticationIdentity.UserId;
                    return GetAuthToken(userId);
                }
            }
            return null;
        }
        private HttpResponseMessage GetAuthToken(int userId)
        {
               var token = _tokenServices.GenerateToken(userId);
               var response = Request.CreateResponse(HttpStatusCode.OK, "Authorized");
                response.Headers.Add("Token", token.AuthToken);
                response.Headers.Add("TokenExpiry", ConfigurationManager.AppSettings["AuthTokenExpiry"]);
                response.Headers.Add("Access-Control-Expose-Headers", "Token,TokenExpiry");
            return response;
        }

    }
}
