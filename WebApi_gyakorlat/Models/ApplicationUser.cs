using Microsoft.AspNetCore.Identity;

namespace WebApi_gyakorlat.Models
{
    public class ApplicationUser : IdentityUser
    {
        public String Id { get; set; } = new Guid().ToString();
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

    }
}