using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwtUsersAPI.Entities;
using JwtUsersAPI.Models;
using JwtUsersAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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


        [HttpGet("{id}")]
        public async Task<ActionResult<UserToReturn>> GetUser(int id)
        {
            var user = await _userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users1/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            var res = await _userService.Update(user);
            if (res)
            {
                return NoContent();
            }
            return NotFound();

        }

        // POST: api/Users1
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            await _userService.Add(user);
            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users1/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _userService.Delete(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);

        }

    }
}