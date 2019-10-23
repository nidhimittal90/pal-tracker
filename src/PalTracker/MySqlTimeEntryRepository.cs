using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PalTracker{
    public class MySqlTimeEntryRepository : ITimeEntryRepository
    {
        private readonly TimeEntryContext context;
        public MySqlTimeEntryRepository(TimeEntryContext timeEntryContext)
        {
            context = timeEntryContext;
        }

        public MySqlTimeEntryRepository(){}

        public bool Contains(long id) => context.TimeEntryRecords.AsNoTracking().Any(t=>t.Id == id);

        public TimeEntry Create(TimeEntry timeEntry)
        {
            var recordToCreate = timeEntry.ToRecord();
            context.TimeEntryRecords.Add(recordToCreate);
            context.SaveChanges();
            return(Find(recordToCreate.Id.Value));
        }

        public void Delete(long id)
        {
            context.TimeEntryRecords.Remove(FindRecord(id));
            context.SaveChanges();
        }

        public TimeEntry Find(long id) => FindRecord(id)?.ToEntity();
        

        public IEnumerable<TimeEntry> List() => context.TimeEntryRecords.AsNoTracking().Select(t=> t.ToEntity());

        public TimeEntry Update(long id, TimeEntry timeEntry)
        {
            var recordToUpdate = timeEntry.ToRecord();
            recordToUpdate.Id = id;
            context.Update(recordToUpdate);
            context.SaveChanges();
            return(Find(id));
        }

        private TimeEntryRecord FindRecord(long id) => context.TimeEntryRecords.AsNoTracking().Where(t=> t.Id == id).FirstOrDefault();
    }
}