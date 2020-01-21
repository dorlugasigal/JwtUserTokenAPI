using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwtUsersAPI.Models;
using JwtUsersAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtUsersAPI.Controllers
{
    /// <summary>
    /// Version 2 of the UsersController
    /// </summary>
    [Authorize]
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/Users")]
    public class UsersV2Controller : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersV2Controller(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticateModel model)
        {
            var user = _userService.Authenticate(model.Username, model.Password);

            if (user == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            return Ok(user);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
    }
}