using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Tinder.Data.Context;
using Tinder.Data.Entities;
using Tinder.Repository.Concrete;
using Tinder.Service.Abstract;

namespace Tinder.Service.Concrete
{
    public class MatchesService : GenericRepository<Matches, TinderDbContext>, IMatchesService
    {
        readonly TinderDbContext _context;
        readonly IHttpContextAccessor _httpContextAccessor;

        public MatchesService(TinderDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<Matches>> GetMatchesWithUser()
        {
            return await _context.TBLMatches.Include("User").ToListAsync();
        }

        //IQueryable
        //IEnumerable
        //List
        /*  public IQueryable<Matches> GetAll()
          {
              return _context.TBLMatches;
          }

          public IQueryable<Matches> ServiceMethod()
          {
              return GetAll().Where(x => x.MatchesId == 1);
          }

          public void ControllerAction()
          {
              var queryResult = ServiceMethod().ToList();
          }*/

        public async Task<IEnumerable<Matches>> GetTopMatches(int count)
        {
            return await _context.TBLMatches.Take(count).ToListAsync();
        }
        public async ValueTask<Matches> LikeToUser(User user)
        {
            var loginUser = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var findIdUserLiked = await _context.TBLUser.FindAsync(user.Id);
            Matches matches = new Matches
            {
                PersonId = loginUser,
                LikedPerson = user.Id,
                Status = true,
                //User = findIdUserLiked
            };
            await _context.TBLMatches.AddAsync(matches);
            await _context.SaveChangesAsync();
            return matches;
        }
        public async ValueTask<Matches> DisLikeToUser(User user)
        {
            var loginUser = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var findIdUserLiked = await _context.TBLUser.FindAsync(user.Id);
            Matches matches = new Matches
            {
                PersonId = loginUser,
                LikedPerson = user.Id,
                //User = findIdUserLiked
            };
            await _context.TBLMatches.AddAsync(matches);
            await _context.SaveChangesAsync();
            return matches;
        }
    }
}
