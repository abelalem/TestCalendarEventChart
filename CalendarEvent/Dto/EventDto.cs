using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarEvent.Dto
{
    public class EventDto
    {
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        public int Hours { get; set; }
    }
}
