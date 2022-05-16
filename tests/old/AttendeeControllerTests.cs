using System;

using Controllers;

using FluentAssertions;

using Microsoft.AspNetCore.Mvc;

using Models;

using NSubstitute;

using Repositories;

using Xunit;

namespace OldStyle;

public class AttendeeControllerTests
{
    private readonly AttendeeController _sut;
    private readonly IAttendeeRepository _attendeeRepository = Substitute.For<IAttendeeRepository>();

    public AttendeeControllerTests()
    {
        _sut = new AttendeeController(_attendeeRepository);
    }

    [Fact]
    public void GetAttendeeById_ReturnsAttendee_WhenAttendeeExists()
    {
        //Arrange
        var id = Guid.NewGuid();
        var attendee = new Attendee(id, "Ramon");
        _attendeeRepository.GetById(Arg.Is(id)).Returns(attendee);

        //Act
        var actionResult = _sut.GetAttendeeById(id);
        var okObjectResult = (OkObjectResult)actionResult;

        //Assert
        okObjectResult.StatusCode.Should().Be(200);
        okObjectResult.Value.Should().BeEquivalentTo(attendee);
    }
}