using System;
using System.Collections.Generic;

namespace PalTracker
{
    public class TimeEntry //: IComparable<TimeEntry>
    {

        public long? Id {get; set;}
        public long ProjectId {get; set;}
        public long UserId {get; set;}
        public DateTime Date {get; set;}
        public int Hours {get; set; }


        public TimeEntry(long id, long projectId, long userId, DateTime date, int hours)
        {
            Id = id;
            ProjectId  = projectId;
            UserId = userId;
            Date = date;
            Hours = hours;
        }

        public TimeEntry(long projectId, long userId, DateTime date, int hours)
        {
            ProjectId = projectId;
            UserId = userId;
            Date = date;
            Hours = hours;
        }
        public TimeEntry(){}
     
        // public int CompareTo(TimeEntry other)
        // {
        //     if(this.Id != null && other.Id!=null)
        //     {
        //         if(other.Id == Id && other.UserId == UserId)
        //         return 0;
        //     }
        //     return 1;
        // }

        public override bool Equals(object obj)
        {
            return obj is TimeEntry entry &&
                   EqualityComparer<long?>.Default.Equals(Id, entry.Id) &&
                   ProjectId == entry.ProjectId &&
                   UserId == entry.UserId &&
                   Date == entry.Date &&
                   Hours == entry.Hours;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, ProjectId, UserId, Date, Hours);
        }
    }
}