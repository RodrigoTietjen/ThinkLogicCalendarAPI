using AutoMapper;
using ThinkLogicAPI.Domain.Entities;
using ThinkLogicAPI.DTOs;

namespace ThinkLogicAPI.Mapper
{
    public class CalendarEventProfile : Profile
    {
        public CalendarEventProfile()
        {
            CreateMap<CalendarEvent, CalendarEventDto>();
            CreateMap<CalendarEventDto, CalendarEvent>();
        }
    }
}
