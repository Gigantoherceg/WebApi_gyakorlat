using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApi_gyakorlat.Models;

namespace WebApi_gyakorlat.Models
{
    public class GyakDbContext : IdentityDbContext<ApplicationUser>
    {
        public GyakDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; } = default!;
    }
}
