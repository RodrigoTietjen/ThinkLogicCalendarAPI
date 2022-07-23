using Microsoft.EntityFrameworkCore;
using ThinkLogicAPI.Domain.Entities;

namespace ThinkLogicAPI.Domain.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<CalendarEvent> Events { get; set; }

        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
