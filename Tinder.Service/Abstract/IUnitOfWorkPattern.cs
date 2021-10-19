using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tinder.Service.Abstract
{
    public interface IUnitOfWorkPattern : IDisposable
    {
        //IUserService UserService { get; }
        //IMatchesService MatchesService { get; }
        int Complete();
    }
}
