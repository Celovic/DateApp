using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tinder.Data.Context;
using Tinder.Service.Abstract;

namespace Tinder.Service.Concrete
{
    public class UnitOfWorkPattern : IUnitOfWorkPattern
    {
        readonly TinderDbContext _context;
        public UnitOfWorkPattern(TinderDbContext context)
        {
            _context = context;
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
