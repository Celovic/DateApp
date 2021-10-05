using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tinder.Data.Context;
using Tinder.Data.Entities;
using Tinder.Repository.Concrete;
using Tinder.Service.Abstract;

namespace Tinder.Service.Concrete
{
    public class UserService : GenericRepository<User,TinderDbContext>, IUserService
    {
        readonly TinderDbContext _context;

        public UserService(TinderDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetTopUser(int count)
        {
            return await _context.TBLUser.Take(count).ToListAsync(); ;
        }

        public async Task<IEnumerable<User>> GetUserWithMatches()
        {
            return await _context.TBLUser.Include("Matches").ToListAsync();
        }
        public async Task<User> SaveUser(User user)
        {
            var prod = _context.TBLUser.Attach(user);
            prod.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
