namespace Endpoints;

public static class AttendeeEndpoints
{
    public static void MapAttendeeEndpoints(this WebApplication app)
    {
        app.MapGet("attendees", GetAllAttendees)
            .Produces(200, typeof(List<Attendee>))
            .RequireAuthorization();

        app.MapGet("attendees/{id:guid}", GetAttendeeById);
        app.MapPost("attendees", CreateAttendee);
        app.MapPut("attendees/{id:guid}", UpdateAttendee);
        app.MapDelete("attendees/{id:guid}", DeleteAttendee);
    }

    private static IResult GetAllAttendees(IAttendeeRepository repository)
    {
        var attendees = repository.GetAll();
        return Results.Ok(attendees);
    }

    internal static IResult GetAttendeeById(IAttendeeRepository repository, Guid id)
    {
        var attendee = repository.GetById(id);
        return attendee is not null ? Results.Ok(attendee) : Results.NotFound();
    }

    private static IResult CreateAttendee(IAttendeeRepository repository, Attendee attendee)
    {
        repository.Create(attendee);
        return Results.Created($"/attendees/{attendee.Id}", attendee);
    }

    private static IResult UpdateAttendee(IAttendeeRepository repository, Guid id, Attendee updatedAttendee)
    {
        var existingAttendee = repository.GetById(id);
        if (existingAttendee is null)
        {
            return Results.NotFound();
        }

        repository.Update(updatedAttendee);
        return Results.Ok(updatedAttendee);
    }

    private static IResult DeleteAttendee(IAttendeeRepository repository, Guid id)
    {
        repository.Delete(id);
        return Results.Ok();
    }
}
