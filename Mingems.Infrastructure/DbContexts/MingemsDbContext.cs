using Microsoft.EntityFrameworkCore;
using Mingems.Core.Models;
using Mingems.Shared.Core.Enums;

namespace Mingems.Infrastructure.DbContexts
{
    public class MingemsDbContext : DbContext
    {
        public MingemsDbContext(DbContextOptions<MingemsDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Investment> Investments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasQueryFilter(u => u.RecordState == RecordState.Active);
            builder.Entity<Supplier>().HasQueryFilter(s => s.RecordState == RecordState.Active);
            builder.Entity<Investment>().HasQueryFilter(i => i.RecordState == RecordState.Active);
        }
    }
}
