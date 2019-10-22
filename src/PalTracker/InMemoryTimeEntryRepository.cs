using System;
using System.Collections.Generic;
using System.Linq;

namespace PalTracker
{
    public class InMemoryTimeEntryRepository : ITimeEntryRepository
    {
        List<TimeEntry> timeEntries = new List<TimeEntry>();

        public InMemoryTimeEntryRepository()
        {
           
        }

        public TimeEntry Create(TimeEntry timeEntry){
            if(timeEntries.Count == 0) timeEntry.Id = 1;
            else
            timeEntry.Id = timeEntries.Last().Id + 1;
            
             timeEntries.Add(timeEntry);
             return timeEntry;
        }

        public TimeEntry Find(int id){
            return timeEntries.SingleOrDefault(p=>p.Id == id);
        }

        public bool Contains(int id){
            
            return (Find(id) != null);
                
        }

        public List<TimeEntry> List(){
            return timeEntries;
        }

        public TimeEntry Update(int id, TimeEntry timeEntry){
            TimeEntry e = Find(id);
            e.ProjectId = timeEntry.ProjectId;
            e.Hours = timeEntry.Hours;
            e.Date = timeEntry.Date;
            e.UserId = timeEntry.UserId;
            return e;
        }

        public bool Delete(int id){
            if(Find(id) != null)
            {
                timeEntries.Remove(Find(id));
                return true;
            }
            return false;

        }
    }
}