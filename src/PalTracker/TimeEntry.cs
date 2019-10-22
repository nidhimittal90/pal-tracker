using System;

namespace PalTracker
{
    public class TimeEntry : IComparable<TimeEntry>
    {

        public int Id {get; set;}
        public int ProjectId {get; set;}
        public int UserId {get; set;}
        public DateTime Date {get; set;}
        public int Hours {get; set; }


        public TimeEntry(int id, int projectId, int userId, DateTime date, int hours)
        {
            Id = id;
            ProjectId  = projectId;
            UserId = userId;
            Date = date;
            Hours = hours;
        }

        public TimeEntry(int projectId, int userId, DateTime date, int hours)
        {
            ProjectId = projectId;
            UserId = userId;
            Date = date;
            Hours = hours;
        }
        public TimeEntry(){}
     
        public int CompareTo(TimeEntry other)
        {
            if(other.Id == Id && other.UserId == UserId)
                return 0;

            return 1;
        }
    }
}