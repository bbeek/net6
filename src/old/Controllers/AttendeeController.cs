namespace Controllers;

[ApiController]
[Route("attendees")]
public class AttendeeController : ControllerBase
{
    private readonly IAttendeeRepository _repository;

    public AttendeeController(IAttendeeRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetAllAttendees()
    {
        var attendees = _repository.GetAll();
        return Ok(attendees);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetAttendeeById([FromRoute] Guid id)
    {
        var attendee = _repository.GetById(id);
        return attendee is not null ? Ok(attendee) : NotFound();
    }

    [HttpPost]
    public IActionResult CreateAttendee([FromBody] Attendee attendee)
    {
        _repository.Create(attendee);
        return Created($"/attendees/{attendee.Id}", attendee);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateAttendee([FromRoute] Guid id, [FromBody] Attendee updatedAttendee)
    {
        var existingAttendee = _repository.GetById(id);
        if (existingAttendee is null)
        {
            return NotFound();
        }
        
        _repository.Update(updatedAttendee);
        return Ok(updatedAttendee);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteAttendee([FromRoute] Guid id)
    {
        _repository.Delete(id);
        return Ok();
    }
}
