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
        public MatchesController(IMatchesService matchesService, IUserService userService)
        {
            _matchesService = matchesService;
            _userService = userService;
        }
        [HttpGet]
        public async Task<IEnumerable<Matches>> GetMatches()
        {
            return await _matchesService.GetAll();
        }
        [HttpGet("GetMatches/{id}")]
        public async Task<Matches> GetMatches(int id)
        {
            return await _matchesService.GetByMatchesId(id);
        }
        [HttpGet("GetMatchesFromUserId/{userId}")]
        public async Task<Matches> GetMathesWithUser(string userId)
        {
            return await _matchesService.GetById(userId);
        }
        [HttpPost(("MatchAdd/"))]
        public async Task<Matches> Post([FromBody] Matches matches)
        {
            await _matchesService.Add(matches);
            return matches;
        }
        [HttpPut("MatchUpdate/")]
        public async ValueTask<Matches> Put([FromBody] int matchesId)
        {
            var editedMatches = await _matchesService.GetByMatchesId(matchesId);
            await _matchesService.Update(editedMatches);
            return editedMatches;
        }
        [HttpDelete("MatchDelete/{matchesId}")]
        public async ValueTask Delete(Matches matchesId)
        {
            var deletedMatch = await _matchesService.GetByMatchesId(matchesId.MatchesId);
            await _matchesService.Remove(deletedMatch);
        }
    }
}
