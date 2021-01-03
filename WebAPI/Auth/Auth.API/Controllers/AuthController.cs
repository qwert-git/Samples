using System.Security.Claims;
using System.Threading.Tasks;
using Auth.API.DTO;
using Auth.API.Services.AuthenticationService;
using Auth.API.Services.AuthTokenIssuer;
using Auth.API.Services.RoleManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auth.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authService;
        private readonly IRoleManager _roleManager;
        private readonly IAuthTokenIssuer _tokenIssuer;

        public AuthController(IAuthenticationService authService, IRoleManager roleManager, IAuthTokenIssuer tokenIssuer)
        {
            _authService = authService;
            _roleManager = roleManager;
            _tokenIssuer = tokenIssuer;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserLoginDto model)
        {
            if (await _authService.AuthenticateAsync(model.UserName, model.Password))
            {
                var userRole = await _roleManager.GetUserRoleAsync(model.UserName);

                var claims = new Claim[]
                {
                    new Claim(ClaimTypes.Name, model.UserName),
                    new Claim(ClaimTypes.Role, userRole.Name)
                };

                string accessToken = _tokenIssuer.GetAccessToken(claims);
                return Ok(new
                {
                    UserName = model.UserName,
                    Role = userRole.Name,
                    AccessToken = accessToken
                });
            }

            return Unauthorized();
        }
    }
}