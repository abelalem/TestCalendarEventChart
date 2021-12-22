using CalendarEvent;
using CalendarEvent.Dto;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsCalendarEventChart
{
    public partial class CalendarEventChart : Form
    {
        private OutlookCalendarEvent outlookCalendarEvent;
        private List<EventDto> calendarEventDtos;
        public CalendarEventChart()
        {
            InitializeComponent();
            outlookCalendarEvent = new OutlookCalendarEvent();
            calendarEventDtos = outlookCalendarEvent.GetCalendarEvents();
            BindConstrols();
        }

        public void BindConstrols()
        {
            chartCalendarEvent.DataSource = calendarEventDtos;

            foreach (var calendarEvent in calendarEventDtos)
            {
                if (chartCalendarEvent.Series.IndexOf(calendarEvent.Subject) < 0) 
                {
                    chartCalendarEvent.Series.Add(calendarEvent.Subject);

                }
                chartCalendarEvent.Series[calendarEvent.Subject].YValueMembers = "Hours";
                chartCalendarEvent.Series[calendarEvent.Subject].XValueMember = "Date";
            }
        }
    }
}
