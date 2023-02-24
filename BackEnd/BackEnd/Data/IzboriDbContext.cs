using BackEnd.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Data
{
    public class IzboriDbContext : DbContext
    {
        public IzboriDbContext(DbContextOptions<IzboriDbContext> options) : base(options)
        {

        }

        public DbSet<Member>Members { get; set; }
        public DbSet<SIK>SIKs { get; set; }
        public DbSet<Distribution>Distribution { get; set; }
    }
}
