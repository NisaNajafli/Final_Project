using Application.DTOs.AuthDto;
using Application.Services.Abstracts;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _usermanager;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitofwork;
        private readonly RoleManager<Role> _rolemanager;
        public AuthController(UserManager<User> usermanager, IConfiguration configuration, IUnitOfWork unitofwork, RoleManager<Role> rolemanager)
        {
            _usermanager = usermanager;
            _configuration = configuration;
            _unitofwork = unitofwork;
            _rolemanager = rolemanager;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(Register register)
        {
            User user = new User()
            {
                LastName = register.LastName,
                Email = register.Email,
                FirstName = register.FirstName,
                PhoneNumber = register.Phone,
                UserName = register.UserName,
            };
            IdentityResult result= await _usermanager.CreateAsync(user,register.Password);
            if(!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            IdentityResult role = await _usermanager.AddToRoleAsync(user, "User");
            if (!role.Succeeded)
            {
                foreach (IdentityError error in role.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    return Ok(error);
                }
            }
            return Ok(new
            {
                user.UserName,
                user.Email
            });
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(Login login)
        {
            User user= await _usermanager.FindByNameAsync(login.UserName);
            if(user==null)
            {
                return BadRequest(new
                {
                    Message = "Password incorrect"
                });
            }
            bool chechPassword= await _usermanager.CheckPasswordAsync(user,login.Password);
            if(!chechPassword)
            {
                return BadRequest();
            }
            
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
            };

            IList<string> roles = await _usermanager.GetRolesAsync(user);
            claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

            string privateKey = _configuration["SecurityToken:securityKey"];
            SecurityKey securityKey= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(privateKey));
            SigningCredentials signing = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken token = new JwtSecurityToken
                (
                issuer: _configuration["SecurityToken:issuer"],
                audience: _configuration["SecurityToken:audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: signing
                );
            return Ok(new
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
            });
        }
        [HttpPost("create-role")]
        public async Task<IActionResult> CreateRole()
        {
            List<string> roles = new List<string>()
            {
                "Admin","Employee","Client","User"
            };

            foreach (var item in roles)
            {
                await _rolemanager.CreateAsync(new Role()
                {
                    Name = item
                });
            }
            return Ok();
        }
    }
}
