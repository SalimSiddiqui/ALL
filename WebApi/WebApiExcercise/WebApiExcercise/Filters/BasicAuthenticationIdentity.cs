using System.Security.Principal;

namespace WebApiExcercise.Filters
{
    public class BasicAuthenticationIdentity : GenericIdentity
    {
        public string Password { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public BasicAuthenticationIdentity(string userName, string password) : base(userName, "Basic")
        {
            UserName = userName;
            Password = password;
        }
    }
}