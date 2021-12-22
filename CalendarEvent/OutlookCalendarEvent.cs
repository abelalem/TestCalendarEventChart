using CalendarEvent.Dto;
using CalendarEvent.Mapping;
using DataAccess;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;

namespace CalendarEvent
{
    public class OutlookCalendarEvent
    {
        private string CalendarEventCsvFilePath;
        private string CalendarEventFileName;
        private CalendarEventDataAccess calendarEventDataAccess;
        public OutlookCalendarEvent() 
        {
            CalendarEventCsvFilePath = Path.GetFullPath($"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}/TestCalendarEventChart");
            CalendarEventFileName = "OutlookCalendarEvent.csv";
            calendarEventDataAccess = new CalendarEventDataAccess(GetDatabaseConnectionString());
            ReadCalendarEventFromCsvFile();
        }
        public OutlookCalendarEvent(string csvFilePath)
        {
            CalendarEventCsvFilePath = Path.GetFullPath(csvFilePath);
            CalendarEventFileName = "OutlookCalendarEvent.csv";
            calendarEventDataAccess = new CalendarEventDataAccess(GetDatabaseConnectionString());
            ReadCalendarEventFromCsvFile();
        }

        private string GetDatabaseConnectionString()
        {
            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(executable));
            string connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={path}\Database\CalendarEventDb.mdf;Integrated Security=True;Connect Timeout=30";

            return connectionString;
        }

        private void ReadCalendarEventFromCsvFile() 
        {
            if (!Directory.Exists(CalendarEventCsvFilePath)) 
            {
                Directory.CreateDirectory(CalendarEventCsvFilePath);
                return;
            }

            if (!File.Exists($"{CalendarEventCsvFilePath}/{CalendarEventFileName}")) 
            {
                return;
            }

            using (StreamReader calendarEvent = File.OpenText($"{CalendarEventCsvFilePath}/{CalendarEventFileName}")) 
            {
                string []eventHeader = calendarEvent.ReadLine().Split(',');
                List<Event> calendarEvents = new List<Event>();
                Event tmpEvent = null;
                string[] eventDetail = null;
                string col = string.Empty;
                int count = 0;

                if (eventHeader == null || eventHeader.Length == 0) 
                {
                    return;
                }
                while ((col = calendarEvent.ReadLine()) != null)
                {
                    eventDetail = col.Split(',');
                    
                    tmpEvent = new Event();
                    tmpEvent.Subject = RemoveQuoteMarks(eventDetail[count++]);
                    tmpEvent.StartDateTime = DateTime.Parse($"{RemoveQuoteMarks(eventDetail[count++])} {RemoveQuoteMarks(eventDetail[count++])}");
                    tmpEvent.EndDateTime = DateTime.Parse($"{RemoveQuoteMarks(eventDetail[count++])} {RemoveQuoteMarks(eventDetail[count++])}");
                    tmpEvent.AllDayEvent = Boolean.Parse(RemoveQuoteMarks(eventDetail[count++]));
                    tmpEvent.Reminder = Boolean.Parse(RemoveQuoteMarks(eventDetail[count++]));
                    tmpEvent.ReminderDateTime = DateTime.Parse($"{RemoveQuoteMarks(eventDetail[count++])} {RemoveQuoteMarks(eventDetail[count++])}");
                    tmpEvent.MeetingOrganizer = RemoveQuoteMarks(eventDetail[count++]);
                    tmpEvent.RequiredAttendees = RemoveQuoteMarks(eventDetail[count++]);
                    tmpEvent.OptionalAttendees = RemoveQuoteMarks(eventDetail[count++]);
                    tmpEvent.MeetingResources = RemoveQuoteMarks(eventDetail[count++]);
                    tmpEvent.BillingInformation = RemoveQuoteMarks(eventDetail[count++]);
                    tmpEvent.Categories = RemoveQuoteMarks(eventDetail[count++]);
                    tmpEvent.Description = RemoveQuoteMarks(eventDetail[count++]);
                    tmpEvent.Location = RemoveQuoteMarks(eventDetail[count++]);
                    tmpEvent.Mileage = RemoveQuoteMarks(eventDetail[count++]);
                    tmpEvent.Priority = RemoveQuoteMarks(eventDetail[count++]);
                    tmpEvent.Private = Boolean.Parse(RemoveQuoteMarks(eventDetail[count++]));
                    tmpEvent.Sensitivity = RemoveQuoteMarks(eventDetail[count++]);
                    tmpEvent.ShowTimeAs = int.Parse(RemoveQuoteMarks(eventDetail[count++]));

                    tmpEvent.Id = GetCalendarEventHashString(tmpEvent);

                    calendarEvents.Add(tmpEvent);

                    count = 0;
                }

                if (calendarEvents.Count == 0)
                {
                    return;
                }

                calendarEventDataAccess.InsertOutlookCalendarEvent(calendarEvents);
            }
        }

        private string RemoveQuoteMarks(string stringWithQuoteMark) 
        {
            if (String.IsNullOrEmpty(stringWithQuoteMark)) 
            {
                return stringWithQuoteMark;
            }

            return stringWithQuoteMark.Remove(stringWithQuoteMark.Length - 1, 1).Remove(0, 1);
        }

        private string GetCalendarEventHashString(Event calendarEvent)
        {
            calendarEvent.Id = string.Empty;

            byte []calendarEventBytes = ObjectToByteArray(calendarEvent);

            byte[] calendarEventHashBytes = (new SHA1Cng()).ComputeHash(calendarEventBytes);

            return string.Concat(calendarEventHashBytes.Select(b => b.ToString("x2")));
        }

        private static byte[] ObjectToByteArray(Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        public List<EventDto> GetCalendarEvents() 
        {

            List<Event> calendarEvents = calendarEventDataAccess.GetOutlookCalendarEvent();

            List<EventDto> calendarEventDtos = new List<EventDto>();

            foreach (var calendarEvent in calendarEvents) 
            {
                calendarEventDtos.AddRange(calendarEvent.MapToDto());
            }                

            return calendarEventDtos;
        }
    }
}
