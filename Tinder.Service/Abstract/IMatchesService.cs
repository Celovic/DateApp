using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tinder.Data.Entities;
using Tinder.Repository.Abstract;

namespace Tinder.Service.Abstract
{
    public interface IMatchesService : IGenericRepository<Matches>
    {
        Task<IEnumerable<Matches>> GetTopMatches(int count);
        Task<IEnumerable<Matches>> GetMatchesWithUser();
    }
}
