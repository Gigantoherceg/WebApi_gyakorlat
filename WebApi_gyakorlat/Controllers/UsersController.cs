using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_gyakorlat.Models;
using WebApi_gyakorlat.Models.ViewModel;
using WebApi_gyakorlat.Services;

namespace WebApi_gyakorlat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenCreationService _jwtService;

        public UsersController(UserManager<ApplicationUser> userManager, ITokenCreationService jwtService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }

        // POST: api/Users
        [HttpPost("Register")]
        public async Task<ActionResult<CreateUserForm>> RegisterUser(CreateUserForm user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newUser = new ApplicationUser() { UserName = user.UserName};

            var result = await _userManager.CreateAsync(
                newUser,
                user.Password
            );

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            user.Password = null!;
            return CreatedAtAction(nameof(GetUser), new { userName = user.UserName }, user);
        }

        // GET: api/Users
        [HttpGet(nameof(GetAllUser))]
        public async Task<ActionResult<List<UserDetails>>> GetAllUser()
        {
            var users = await _userManager.Users.ToListAsync();

            List<UserDetails> userDetails = new();
            foreach (var user in users)
            {
                userDetails.Add(new UserDetails
                {
                    UserName = user.UserName ?? string.Empty,
                    Email = user.Email ?? string.Empty
                });
            }

            return Ok(userDetails);
        }

        // GET: api/Users/username
        [HttpGet(nameof(GetUser)+"/{username}")]
        public async Task<ActionResult<UserDetails>> GetUser(string username)
        {
            ApplicationUser? user = await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                return NotFound();
            }

            return new UserDetails
            {
                UserName = user.UserName ?? string.Empty,
                Email = user.Email ?? string.Empty
            };
        }


        // POST: api/Users/BearerToken
        [HttpPost("Login")]
        public async Task<ActionResult<AuthenticationResponse>> CreateBearerToken(AuthenticationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Bad credentials");
            }

            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user == null)
            {
                return BadRequest("Bad credentials");
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!isPasswordValid)
            {
                return BadRequest("Bad credentials");
            }

            var token = _jwtService.CreateToken(user);

            return Ok(token);
        }
    }
}
