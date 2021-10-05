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
        private readonly IUnitOfWorkPattern _unitOfWork;
        public UserController(IUnitOfWorkPattern unitOfWork, IMatchesService matchesService, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _matchesService = matchesService;
            _userService = userService;
        }
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _userService.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<User> Get(string id)
        {
            return (await _userService.GetAll()).FirstOrDefault(x => x.Id == id);
        }
        [HttpPost]
        public async Task<User> Post([FromBody] User user)
        {
            await _userService.Add(user);
            _unitOfWork.Complete();
            return user;
        }
        [HttpPut]
        public async Task<User> Put([FromBody] User user,string id)
        {
            var editedUser =(await _userService.GetAll()).FirstOrDefault(x => x.Id == id);
            _userService.Update(user);
            _unitOfWork.Complete();
            return user;
        }
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            var deletedUser = (await _userService.GetAll()).FirstOrDefault(x => x.Id == id);
            _userService.Remove(deletedUser);
            _unitOfWork.Complete();
        }
    }
}
