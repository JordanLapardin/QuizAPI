using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using QuizAPI.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace QuizAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : Controller
    {
        private readonly IConfiguration _config;
        private readonly QuizableDbContext _context;
        
        #region config

        public TokenController(IConfiguration config, QuizableDbContext context)
        {
            _config = config;
            _context = context;
        }

        #endregion

        #region public endpoint

        // Generate a Token for an existing user
        [HttpPost]
        [Route("GenerateToken")]
        public IActionResult GenerateToken(UserStuff _userData)
        {
            // All of the null checks
            if (_userData != null && _userData.UserName != null && _userData.UserPassword != null)
            {
                // retrieve the user for these credentials
                var user = GetUser(_userData.UserName, _userData.UserPassword);

                // If we have a user that matches the credentials
                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                    // JWT Subject
                    new Claim(JwtRegisteredClaimNames.Sub, _config["JWT:Subject"]),
                    // JWT ID
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    // JWT Date/Time
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    // JWT User ID
                    new Claim("Id", user.UserStuffID.ToString()),
                    // JWT UserName
                    new Claim("UserName", user.UserName)
                   };

                    // Generate a new key based on the Key we created and stored in appsettings.json
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
                    // use the generated key to generate new Signing Credentials
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    // Generate a new token based on all of the details generated so far
                    var token = new JwtSecurityToken(
                        _config["JWT:Issuer"],
                        _config["JWT:Audience"],
                        claims,
                        // How long the JWT will be valid for
                        expires: DateTime.UtcNow.AddDays(2),
                        signingCredentials: signIn);

                    // Return the Token via JSON
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        #endregion

        #region private Method

        UserStuff GetUser(string userName, string userPassword)
        {
            var user = _context.Users.Where(c => c.UserName.Equals(userName)).FirstOrDefault();

            if(user != null && user.UserPassword.Equals(userPassword))
            {
                return user;
            }
            return null;
        }

        #endregion
    }
}
