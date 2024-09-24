using Microsoft.AspNetCore.Identity;

namespace EcommerceAuthToken.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
