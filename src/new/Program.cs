var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IAttendeeRepository, AttendeeRepository>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapAttendeeEndpoints();

app.Run();