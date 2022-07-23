using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using System.Linq;
using ThinkLogicAPI.Application.Service.Interface;
using ThinkLogicAPI.Domain.Entities;
using ThinkLogicAPI.Domain.Interfaces;
using ThinkLogicAPI.DTOs;

namespace ThinkLogicAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalendarEventController : ControllerBase
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICalendarEventService _calendarEventService;

        public CalendarEventController(
            IAppDbContext context,
            IMapper mapper,
            ICalendarEventService calendarEventService)
        {
            _mapper = mapper;
            _context = context;
            _calendarEventService = calendarEventService;
        }

        [EnableQuery]
        [HttpGet]
        public ActionResult<IQueryable<CalendarEvent>> Get()
        {
            return Ok(_context.Events);
        }

        [HttpPost]
        public ActionResult<CalendarEventDto> Create([FromBody] CalendarEventDto eventDto)
        {
            var calEvent = _mapper.Map<CalendarEvent>(eventDto);

            var result = _calendarEventService.Create(calEvent);

            return _mapper.Map<CalendarEventDto>(result);
        }

        [HttpPut]
        public ActionResult<CalendarEventDto> Update([FromBody] CalendarEventDto eventDto)
        {
            var calEvent = _mapper.Map<CalendarEvent>(eventDto);

            var result = _calendarEventService.Update(calEvent);

            return _mapper.Map<CalendarEventDto>(result);
        }
    }
}