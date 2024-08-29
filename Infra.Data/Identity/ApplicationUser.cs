using Microsoft.AspNetCore.Identity;

namespace Infra.Data.Identity
{
    public class ApplicationUser : IdentityUser
    {
    }
}
//* represents an identity user 
//** this class was created because if I want to define others properties to the user, I can do it here.