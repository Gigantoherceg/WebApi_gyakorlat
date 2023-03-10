using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebApi_gyakorlat.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string MemberType { get; set; } = "author";
        public int Age { get; set; }
        public bool IsDeleted { get; set; } = false;

        public List<Book> Books { get; set; } = new List<Book>();
    }
}
