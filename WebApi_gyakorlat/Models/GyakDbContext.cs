using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApi_gyakorlat.Models;

namespace WebApi_gyakorlat.Models
{
    public class GyakDbContext : IdentityUserContext<ApplicationUser>
    {
        public GyakDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<WebApi_gyakorlat.Models.Book> Book { get; set; } = default!;
    }
}
