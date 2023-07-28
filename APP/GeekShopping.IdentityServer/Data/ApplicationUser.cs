using Microsoft.AspNetCore.Identity;

namespace GeekShopping.IdentityServer.Data
{
    public class ApplicationUser : IdentityUser
    {
        private string FirstName { get; set; }
        private string LastName { get; set; }
    }
}
