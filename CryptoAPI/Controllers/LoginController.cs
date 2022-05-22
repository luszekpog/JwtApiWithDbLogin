using CryptoAPI.Modules;
using CryptoAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CryptoAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly UserConstants _userConstants;
        private readonly IUserRepository _userRepository;
        public LoginController(IConfiguration config, UserConstants userConstants, IUserRepository userRepository)
        {
            _config = config;
            _userConstants = userConstants;
            _userRepository = userRepository;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            var user = Authenticate(userLogin);
            if(user != null)
            {
                var token = Generate(user);
                return Ok(token);
            }
            return NotFound("User Not Found");
        }

        private string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256); 
            
            var claims= new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.UserName),
                new Claim(ClaimTypes.Email,user.EmailAdress),
                new Claim(ClaimTypes.GivenName,user.GivenName),
                new Claim(ClaimTypes.Surname,user.Surname),
                new Claim(ClaimTypes.Role, user.Role)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token); 
        }

        private User Authenticate(UserLogin userLogin)
        {
            var currentUser = _userConstants.UsersTable.FirstOrDefault(o => o.UserName.ToLower() ==
            userLogin.UserName.ToLower() && o.Password == userLogin.Password);
            
            if(currentUser != null)
            {
                return currentUser;
            }
            return null;
        }
        [HttpPost]
        public async Task<ActionResult<User>> RegisterUser([FromBody] User user)
        {
            var newUser = await _userRepository.Register(user);
            return CreatedAtAction(nameof(RegisterUser), new { Id = newUser.Id }, newUser);
        }
    }
}
