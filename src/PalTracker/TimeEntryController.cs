using Microsoft.AspNetCore.Mvc;

namespace PalTracker
{
    [Route("/time-entries")]
    public class TimeEntryController : ControllerBase
    {

        ITimeEntryRepository _timeRepository;

        public TimeEntryController(ITimeEntryRepository timeRepository)
        {
            _timeRepository = timeRepository;
        }

        [HttpGet]
        public IActionResult List()
        {

            return Ok(_timeRepository.List());
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody] TimeEntry timeEntry)
        {
            //if(!repository.Contains(id))
            TimeEntry updatedObject = _timeRepository.Update(id, timeEntry);
            if (updatedObject != null && updatedObject.Id == id)
                return Ok(updatedObject);
            else
                //return new StatusCodeResult(404);
                return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(!_timeRepository.Contains(id)){
                return NotFound();
            }
            _timeRepository.Delete(id);
            return NoContent();

        }


        [HttpGet("{id}", Name = "GetTimeEntry")]
        public IActionResult Read(int id)
        {
            var FoundObject = _timeRepository.Find(id);
            if (FoundObject != null)
                return Ok(FoundObject);
            else
                return NotFound();
        }


        [HttpPost]
        public IActionResult Create([FromBody] TimeEntry timeEntry)
        {
            var createdObject = _timeRepository.Create(timeEntry);
            return CreatedAtRoute("GetTimeEntry", new {id = createdObject.Id}, createdObject);
        }


    }
}