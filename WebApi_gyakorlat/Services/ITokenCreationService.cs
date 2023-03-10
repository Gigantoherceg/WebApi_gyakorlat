using Microsoft.AspNetCore.Identity;
using WebApi_gyakorlat.Models.ViewModel;

namespace WebApi_gyakorlat.Services
{
    public interface ITokenCreationService
    {
        AuthenticationResponse CreateToken(IdentityUser user);
    }
}