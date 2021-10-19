using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tinder.Data.Context;
using Tinder.Data.Entities;
using Tinder.Service.Abstract;

namespace TinderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMatchesService _matchesService;
        public UserController(IMatchesService matchesService, IUserService userService)
        {
            _matchesService = matchesService;
            _userService = userService;
        }
        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userService.GetAll();
        }
        [HttpGet("GetUsersById/{id}")]
        public async Task<User> GetUsersById(string id)
        {
            return await _userService.GetById(id);
        }
        [HttpPost]
        public async Task<User> UserPost([FromBody] User user)
        {
            await _userService.Add(user);
            return user;
        }
        [HttpPut]
        public async ValueTask<User> UserPut([FromBody] User user, string userId)
        {
            var editedUser = await _userService.GetById(userId);
            await _userService.Update(editedUser);
            return editedUser;
        }
        [HttpDelete("{userId}")]
        public async ValueTask DeleteUser(string userId)
        {
            var deletedUser = await _userService.GetById(userId);
            await _userService.Remove(deletedUser);
        }
    }
}
