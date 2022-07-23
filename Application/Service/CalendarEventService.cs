using ThinkLogicAPI.Application.Service.Interface;
using ThinkLogicAPI.Domain.Entities;
using ThinkLogicAPI.Domain.Interfaces;

namespace ThinkLogicAPI.Application.Service
{
    public class CalendarEventService : ICalendarEventService
    {
        private readonly IAppDbContext _context;
        public CalendarEventService(IAppDbContext context)
        {
            _context = context;
        }
        public CalendarEvent Create(CalendarEvent calEvent)
        {
            _context.Events.Add(calEvent);
            _context.SaveChanges();
            return calEvent;
        }

        public CalendarEvent Update(CalendarEvent calEvent)
        {
            if (calEvent.Id == null || !calEvent.Id.HasValue)
                throw new ArgumentNullException($"CalendarEvent Id cannot be null.");

            var exists = _context.Events.Any(e => e.Id.Equals(calEvent.Id));

            if (!exists)
                throw new ArgumentException($"CalendarEvent with Id {calEvent.Id} not found.");

            _context.Events.Update(calEvent);
            _context.SaveChanges();
            return calEvent;
        }
    }
}
