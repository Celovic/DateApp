using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tinder.Data.Entities;
using Tinder.Repository.Abstract;

namespace Tinder.Service.Abstract
{
    public interface IUserService : IGenericRepository<User>
    {
        Task<IEnumerable<User>> GetTopUser(int count);
        Task<IEnumerable<User>> GetUsersWithMatches();
        ValueTask<IEnumerable<User>> GetRemainingUsers(int page = 1);
        Task<IEnumerable<User>> GetUserMatches();


    }
}
