using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkLogicAPI.Domain.Entities;

namespace ThinkLogicAPI.Application.Service.Interface
{
    public interface ICalendarEventService
    {
        public CalendarEvent Create(CalendarEvent calEvent);
        public CalendarEvent Update(CalendarEvent calEvent);
    }
}
