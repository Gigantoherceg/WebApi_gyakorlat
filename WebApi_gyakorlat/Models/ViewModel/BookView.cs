using System.ComponentModel.DataAnnotations;

namespace WebApi_gyakorlat.Models.ViewModel
{
    public class BookView
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
    }
}
