using System.ComponentModel.DataAnnotations;

namespace WebApi_gyakorlat.Models.ViewModel
{
    public class AuthenticationRequest
    {
        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
