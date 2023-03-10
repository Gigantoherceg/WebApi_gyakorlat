using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApi_gyakorlat.Models
{
    public class GyakDbContext : IdentityUserContext<ApplicationUser>
    {
        public GyakDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
