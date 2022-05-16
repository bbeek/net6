using Models;

namespace Repositories;

public class AttendeeRepository : IAttendeeRepository
{
    private readonly Dictionary<Guid, Attendee> _attendees = new();

    public void Create(Attendee attendee)
    {
        if (attendee is null)
        {
            return;
        }

        _attendees[attendee.Id] = attendee;
    }

    public List<Attendee> GetAll()
    {
        return _attendees.Values.ToList();
    }
    
    public Attendee? GetById(Guid id)
    {
        _= _attendees.TryGetValue(id, out var foundAttendee);
        return foundAttendee;
    }

    public void Update(Attendee attendee)
    {
        var existingAttendee = GetById(attendee.Id);
        if (existingAttendee is null)
        {
            return;
        }

        _attendees[attendee.Id] = attendee;
    }

    public void Delete(Guid id)
    {
        _attendees.Remove(id);
    }
}
