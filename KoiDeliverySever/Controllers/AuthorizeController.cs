using Business.Base;
using KoiDeliv.DataAccess.Models;
using KoiDeliv.Service.DTO.Auth;
using KoiDeliv.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KoiDeliverySever.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthorizeController(IUserService userService)
        {
            _userService = userService;
        }

        #region GenerateToken
        /// <summary>
        /// Which will generating token accessible for user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [NonAction]
        public TokenResponse GenerateToken(User user, String? RT)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim("UserId", user.UserId.ToString()),
                new Claim("UserName", user.FullName),
                new Claim("Email", user.Email),
                new Claim("Role", user.Role.ToString()),
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("c2VydmVwZXJmZWN0bHljaGVlc2VxdWlja2NvYWNoY29sbGVjdHNsb3Bld2lzZWNhbWU="));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "YourIssuer",
                audience: "YourAudience",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            var accessToken = new JwtSecurityTokenHandler().WriteToken(token);
            if (RT != null)
            {
                return new TokenResponse()
                {
                    AccessTokenToken = accessToken
                };
            }
            return new TokenResponse()
            {
                AccessTokenToken = accessToken
            };
        }
        #endregion

        #region Login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _userService.GetByEmail(email);
            if (user != null)
            {
                // Hash the input password with MD5
                var hashedInputPasswordString = _userService.HashAndTruncatePassword(password);

                // Compare the hashed input password with the stored hashed password
                if (hashedInputPasswordString == user.PasswordHash)
                {
                    var token = GenerateToken(user, null);
                    return Ok(new BusinessResult
                    {
                        Status = 200,
                        Message = " Login Successfully",
                        Data = token
                    });
                }
            }
            return BadRequest(new BusinessResult
            {
                Status = 401,
                Message = " Unauthorized | Invalid email or password",
                Data = null
            });
        }
        #endregion
    }
}
