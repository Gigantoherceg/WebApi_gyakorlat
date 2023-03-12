using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi_gyakorlat.Models
{
    [Table("Books")]
    public class Book
    {
        public Guid BookId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Author { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;

        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
