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
    public class MatchesController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMatchesService _matchesService;
        private readonly IUnitOfWorkPattern _unitOfWork;
        public MatchesController(IUnitOfWorkPattern unitOfWork, IMatchesService matchesService, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _matchesService = matchesService;
            _userService = userService;
        }
        [HttpGet]
        public async Task<IEnumerable<Matches>> Get()
        {
            return await _matchesService.GetAll();
        }
        [HttpGet("Get/{id}")]
        public async Task<Matches> Get(int id)
        {
            return (await _matchesService.GetAll()).FirstOrDefault(x => x.MatchesId == id);
        }
        [HttpGet("Get/{userId}")]
        public async Task<Matches> Get(string userId)
        {
            return (await _matchesService.GetAll()).FirstOrDefault(x => x.PersonId == userId);
        }
        [HttpPost]
        public async Task<Matches> Post([FromBody] Matches matches)
        {
            await _matchesService.Add(matches);
            _unitOfWork.Complete();
            return matches;
        }
        [HttpPut]
        public async Task<Matches> Put([FromBody] Matches matches, int id)
        {
            var editedMatches = (await _matchesService.GetAll()).FirstOrDefault(x => x.MatchesId == id);
            _matchesService.Update(matches);
            _unitOfWork.Complete();
            return matches;
        }
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var deletedMatches = (await _matchesService.GetAll()).FirstOrDefault(x => x.MatchesId == id);
            _matchesService.Remove(deletedMatches);
            _unitOfWork.Complete();
        }
    }
}
