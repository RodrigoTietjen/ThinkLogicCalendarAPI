﻿namespace ThinkLogicAPI.DTOs
{
    public class CalendarEventDto
    {
        public Guid? Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }

    }
}
