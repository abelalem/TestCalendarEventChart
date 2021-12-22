using DataAccess.Model;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Configuration;

namespace DataAccess
{
    public class CalendarEventDataAccess
    {
        private string ConnectionString { get; set; }

        public CalendarEventDataAccess() 
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["calendarEventConnString"].ConnectionString;
        }

        public CalendarEventDataAccess(string connectionString) 
        {
            ConnectionString = connectionString;
        }

        public List<Event> GetOutlookCalendarEvent()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                var output = connection.Query<Event>("dbo.GetOutlookCalendarEvent").ToList();
                return output;
            }
        }

        public void InsertOutlookCalendarEvent(List<Event> calendarEvent)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                connection.Execute("dbo.InsertOutlookCalendarEvent @Id, @Subject, @StartDateTime, @EndDateTime, @AllDayEvent, @Reminder, @ReminderDateTime, @MeetingOrganizer, @RequiredAttendees, @OptionalAttendees, @MeetingResources, @BillingInformation, @Categories, @Description, @Location, @Mileage, @Priority, @Private, @Sensitivity, @ShowTimeAs", calendarEvent);
            }
        }
    }
}
