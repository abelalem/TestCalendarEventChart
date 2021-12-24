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
            ConnectionString = GetDatabaseConnectionString();
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

        private string GetDatabaseConnectionString()
        {
            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(executable));
            string connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={path}\Database\CalendarEventDb.mdf;Integrated Security=True;Connect Timeout=30";

            return connectionString;
        }
    }
}
