using Models;

namespace Repositories;

public interface IAttendeeRepository
{
    void Create(Attendee attendee);
    Attendee? GetById(Guid id);
    void Update(Attendee attendee);
    void Delete(Guid id);
    List<Attendee> GetAll();
}