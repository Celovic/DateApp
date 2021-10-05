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
        public MatchesService(TinderDbContext context)
        {
            _context = context;
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
    }
}
