using System;
using System.Collections.Generic;

namespace PalTracker
{
    public interface ITimeEntryRepository
    {
        TimeEntry Create(TimeEntry timeEntry);
        TimeEntry Find(int id);
        bool Contains(int id);
        List<TimeEntry> List();
        TimeEntry Update(int id, TimeEntry timeEntry);
        bool Delete(int id); 
    } 
   
}