using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

using Endpoints;

using FluentAssertions;

using Microsoft.Extensions.DependencyInjection;

using Models;

using NSubstitute;

using Repositories;

using Xunit;

namespace NewStyle;

public class AttendeeEndpointsTests
{
    private readonly IAttendeeRepository _attendeeRepository = Substitute.For<IAttendeeRepository>();

    [Fact]
    public void GetAttendeeById_ReturnAttendee_WhenAttendeeExists()
    {
        //Arrange
        var id = Guid.NewGuid();
        var attendee = new Attendee(id, "Ramon");
        _attendeeRepository.GetById(Arg.Is(id)).Returns(attendee);

        //Act
        var result = AttendeeEndpoints.GetAttendeeById(_attendeeRepository, id);
        
        // Problem: Microsoft.AspNetCore.Http.Result.OkObjectResult <> Microsoft.AspNetCore.Mvc.OkObjectResult
        //var okResult = (Microsoft.AspNetCore.Http.Result.OkObjectResult)result;

        //Assert
        result.GetOkObjectResultStatusCode().Should().Be(200);
        result.GetOkObjectResult<Attendee>().Should().BeEquivalentTo(attendee);
    }

    [Fact]
    public async Task Integration_GetAttendeeById_ReturnAttendee_WhenAttendeeExists()
    {
        //Arrange
        var id = Guid.NewGuid();
        var attendee = new Attendee(id, "Ramon");
        _attendeeRepository.GetById(Arg.Is(id)).Returns(attendee);

        // using WebApplicationFactory is not a unit test but an integration test because all middleware is called (before and after)
        await using var app = new AttendeeEndpointsTestApp(services => services.AddSingleton(_attendeeRepository));

        var client = app.CreateClient();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        //Act
        var response = await client.GetAsync($"/attendees/{id}");
        var responseText = await response.Content.ReadAsStringAsync();
        var attendeeResult = JsonSerializer.Deserialize<Attendee>(responseText, options);

        //Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        attendeeResult.Should().BeEquivalentTo(attendee);
    }
}