using System;

namespace DataAccess.Model
{
    [Serializable]
    public class Event
    {
        public string Id { get; set; }
        public string Subject { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public bool AllDayEvent { get; set; }
        public bool Reminder { get; set; }
        public DateTime ReminderDateTime { get; set; }
        public string MeetingOrganizer { get; set; }
        public string RequiredAttendees { get; set; }
        public string OptionalAttendees { get; set; }
        public string MeetingResources { get; set; }
        public string BillingInformation { get; set; }
        public string Categories { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Mileage { get; set; }
        public string Priority { get; set; }
        public bool Private { get; set; }
        public string Sensitivity { get; set; }
        public int ShowTimeAs { get; set; }
    }
}
