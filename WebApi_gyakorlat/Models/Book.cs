using System.ComponentModel.DataAnnotations;

namespace WebApi_gyakorlat.Models
{
    public class Book
    {
        public string BookId { get; set; } = new Guid().ToString();
        [Required]
        public string Title { get; set; }
        public string Author { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
