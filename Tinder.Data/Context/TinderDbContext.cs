using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tinder.Data.Entities;

namespace Tinder.Data.Context
{
    public class TinderDbContext : IdentityDbContext<User>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = DESKTOP-154APPP; Database = TinderLastDb; Integrated Security = true; Trusted_Connection = True;MultipleActiveResultSets=True");
        }
        public DbSet<User> TBLUser { get; set; }
        public DbSet<Matches> TBLMatches { get; set; }
    }
}
