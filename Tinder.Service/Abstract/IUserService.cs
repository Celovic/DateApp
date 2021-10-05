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
        Task<IEnumerable<User>> GetUserWithMatches();
        Task<User> SaveUser(User user);

        // Her modelimizin veri tabanı işlemleri değişikolabilir. Eğer IGenericRepository'de bizim modelimize ait metdo yok ise modelimize ait bir interface oluşturulur.
        // Bu interface de bizim modelimize ait ek metodları tanıtırız.
    }
}
