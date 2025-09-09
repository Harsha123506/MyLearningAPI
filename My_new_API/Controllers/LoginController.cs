using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using My_new_API.Data;
using My_new_API.DTO_s;
using My_new_API.Repositories.Interfaces;

namespace My_new_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public readonly DataContext _dataContext;
        public readonly UserManager<IdentityUser> _userManager;
        public readonly ITokenRepository _tokenRepository;
        public LoginController(UserManager<IdentityUser> userManager ,DataContext dataContext, ITokenRepository tokenRepository) {
            _dataContext = dataContext;
            _userManager = userManager;
            _tokenRepository = tokenRepository;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> ValidateUser([FromBody]LoginDTO userLogin)
        {
            if (userLogin != null)
            {
                var user = await _userManager.FindByNameAsync(userLogin.Username);
                if (user != null)
                {
                    bool isLoggedIn = await _userManager.CheckPasswordAsync(user, userLogin.Password);
                    if (isLoggedIn)
                    {
                        var roles = await _userManager.GetRolesAsync(user);
                        if (roles != null)
                        {
                            var JWTToken = _tokenRepository.CreateJWTToken(user, roles.ToList());
                            Response.Cookies.Append("JwtToken", JWTToken);
                            return Ok(JWTToken);
                        }
                        else
                        {
                            return BadRequest("No Role is provided");
                        }
                    }
                }
                return BadRequest("User login data is null");
            }
            return Ok("Login SuccessFull");   
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody]UserDTO user)
        {
            var identityUser = new IdentityUser
            {
                UserName = user.userName,
                Email = user.Email
            };
            if (user == null)
            {
                return BadRequest("User data is null");
            }
            var identityResult = await _userManager.CreateAsync(identityUser, user.Password);
            if (identityResult.Succeeded)
            {
                identityResult = await _userManager.AddToRolesAsync(identityUser, user.Roles);

                if (identityResult.Succeeded)
                {
                    return Ok("User Registered Successfully");

                }
                else
                {
                    return BadRequest(identityResult.Errors);
                }
            }
            else
            {
                return BadRequest(identityResult.Errors);
            }
        }
    }
}
