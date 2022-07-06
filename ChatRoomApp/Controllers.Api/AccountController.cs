using ChatRoomApp.Dtos;
using ChatRoomApp.Helper;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace ChatRoomApp.Controllers.Api
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtHandler _jwtHandler;
        public AccountController(UserManager<IdentityUser> userManager, JwtHandler jwtHandler)
        {
            _userManager = userManager;
            _jwtHandler = jwtHandler;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserForAuthenticationDto userForAuthentication)
        {
            var user = await _userManager.FindByNameAsync(userForAuthentication.Username);
            if (user == null)
                return Unauthorized(new AuthResponseDto { ErrorMessage = "Invalid Authentication" });
            var passHasher2 = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, userForAuthentication.Password);
            if ((int)passHasher2 != 1)
                return Unauthorized(new AuthResponseDto { ErrorMessage = "Invalid Authentication" });

            var signingCredentials = _jwtHandler.GetSigningCredentials();
            var claims = _jwtHandler.GetClaims(user);
            var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return Ok(new AuthResponseDto { IsAuthSuccessful = true, Token = token, UserId = user.Id, UserName = user.UserName });
        }
    }
}