using HotelRoomBookingApp.BLL.Interface;
using HotelRoomBookingApp.DAL.Entities;
using HotelRoomBookingApp.Helper;
using HotelRoomBookingApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomBookingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private IConfiguration _config;

        public UserController(IUserService userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;

        }

        [HttpPost]
        [Route("login/post")]
        public Object Post(UserLogin val)
        {
            User user = new UserLogintoUserHelper().UserLogintoUserMapping(val);
            var userdummy = _userService.UserExists(user);
            if (userdummy != null)
            {
                var tokenstring = GenerateToken(userdummy);
                var response = new
                {
                    JwtToken = tokenstring,
                    EmailId = userdummy.EmailId,
                    Role = userdummy.Role,
                    UserId = userdummy.UserId
                };
                return Ok(response);
            }
            else
                return Unauthorized("Invalid user crdentials");

        }

        private string GenerateToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
            new Claim(ClaimTypes.NameIdentifier, userInfo.EmailId),
            new Claim(ClaimTypes.GivenName, userInfo.Name),
            new Claim(ClaimTypes.UserData, userInfo.UserId.ToString()),
            new Claim(ClaimTypes.Role, userInfo.Role.ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(1),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [Authorize]
        [HttpGet]
        [Route("getuserbyid/{id}")]
        public IActionResult GetUserById(int id)
        {
            var u = _userService.GetUserById(id);
            if (u != null)
            {
                return Ok(u);
            }
            else
            {
                return NoContent();
            }
        }
    }
}
