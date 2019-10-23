namespace PalTracker
{
    public static class MappingExtensions
    {
        public static TimeEntry ToEntity(this TimeEntryRecord record)
        {

            var mappped = new TimeEntry
            {

                Id = record.Id,
                ProjectId = record.ProjectId,
                UserId = record.UserId,
                Date = record.Date,
                Hours = record.Hours
            };
            return mappped;
        }

        public static TimeEntryRecord ToRecord(this TimeEntry entity)
        {
            var mapped = new TimeEntryRecord
            {
                Id = entity.Id,
                ProjectId = entity.ProjectId,
                UserId = entity.UserId,
                Date = entity.Date,
                Hours = entity.Hours
            };
            return mapped;
        }
    }
}