using Microsoft.EntityFrameworkCore;
using ThinkLogicAPI.Domain.Entities;
using ThinkLogicAPI.Domain.Interfaces;

namespace ThinkLogicAPI.Data.Context
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public AppDbContext() { }
        public DbSet<CalendarEvent> Events { get; set; }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
