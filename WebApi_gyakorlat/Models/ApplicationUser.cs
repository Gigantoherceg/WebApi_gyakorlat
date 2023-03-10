using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebApi_gyakorlat.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string UserId { get; set; } = new Guid().ToString();
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; }= string.Empty;
        public string MemberType { get; set; } = "author";
        public int Age { get; set; }
        public bool IsDeleted { get; set; } = false;

        public List<Book> Books { get; set; } = new List<Book>;
    }
}
