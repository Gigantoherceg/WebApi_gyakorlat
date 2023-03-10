namespace WebApi_gyakorlat.Models.ViewModel
{
    public class AuthenticationResponse
    {
        public string? Token { get; set; }

        public DateTime Expiration { get; set; }
    }
}
