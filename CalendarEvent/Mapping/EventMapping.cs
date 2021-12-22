using CalendarEvent.Dto;
using DataAccess.Model;
using System.Collections.Generic;

namespace CalendarEvent.Mapping
{
    public static class EventMapping
    {
        public static List<EventDto> MapToDto(this Event calendarEvent) 
        {
            List<EventDto> eventDtos = new List<EventDto>();

            if (calendarEvent.StartDateTime.Date.Equals(calendarEvent.EndDateTime.Date))
            {
                eventDtos.Add(new EventDto
                {
                    Subject = calendarEvent.Subject,
                    Date = calendarEvent.StartDateTime.Date,
                    Hours = calendarEvent.EndDateTime.Subtract(calendarEvent.StartDateTime).Hours
                });
            }
            else 
            {
                int dateDiff = calendarEvent.EndDateTime.Subtract(calendarEvent.StartDateTime).Days;

                for (int i = 0; i < dateDiff; i++) 
                {
                    eventDtos.Add(new EventDto
                    {
                        Subject = calendarEvent.Subject,
                        Date = calendarEvent.StartDateTime.AddDays(i),
                        Hours = calendarEvent.EndDateTime.Subtract(calendarEvent.StartDateTime.AddDays(dateDiff)).Hours
                    });
                }
            }

            return eventDtos;
        }
    }
}
