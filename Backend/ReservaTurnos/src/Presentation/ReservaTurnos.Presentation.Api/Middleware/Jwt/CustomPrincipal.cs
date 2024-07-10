using System.Linq;
using System.Security.Principal;

namespace ReservaTurnos.Presentation.Api.Middleware.Jwt
{
    public class CustomPrincipal : IPrincipal
    {

        public string[] roles { get; set; }
        public string email { get; set; }

        public IIdentity? Identity { get; set; }

        public bool IsInRole(string role)
        {
            if(roles.Any(r=> role.Contains(r)))
                return true;
            else 
                return false;          
        }

        public CustomPrincipal(string email)
        {
            this.Identity = new GenericIdentity(email);
        }

    }
}
