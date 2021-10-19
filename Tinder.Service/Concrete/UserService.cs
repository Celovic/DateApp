using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Tinder.Data.Context;
using Tinder.Data.Entities;
using Tinder.Repository.Concrete;
using Tinder.Service.Abstract;
using X.PagedList;

namespace Tinder.Service.Concrete
{
    public class UserService : GenericRepository<User, TinderDbContext>, IUserService
    {
        readonly TinderDbContext _context;
        readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(TinderDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<User>> GetTopUser(int count)
        {
            return await _context.TBLUser.Take(count).ToListAsync(); ;
        }

        public async Task<IEnumerable<User>> GetUsersWithMatches()
        {
            return await _context.TBLUser.Include("Matches").ToListAsync();
        }
        public async ValueTask<IEnumerable<User>> GetRemainingUsers(int page = 1)
        {
            var loginUser = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var join = await _context.TBLUser
                .Join(_context.TBLMatches, user => user.Id, matches => matches.LikedPerson, (user, matches) => new { user, matches })
                .Where(x => x.matches.PersonId == loginUser && x.user.Id != loginUser).Select(user => user.user).ToListAsync();

            return await join.ToPagedListAsync(page, 1);
        }

        public async Task<IEnumerable<User>> GetUserMatches()
        {
            var loginUser = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var createdMatch = await _context.TBLUser
                .Join(_context.TBLMatches, user => user.Id, matches => matches.LikedPerson, (user, matches) => new { user, matches })
                .Where(x => x.matches.LikedPerson == loginUser && x.matches.Status == true)
                .Select(x => x.user)
                .Union(_context.TBLUser.Join(_context.TBLMatches, user => user.Id, matches => matches.PersonId, (user, matches) => new { user, matches })
                .Where(x => x.matches.PersonId == loginUser && x.matches.Status == true)
                .Select(x => x.user))
                .Select(user => user).ToListAsync(); ;

            return createdMatch;
        }

    }
}
