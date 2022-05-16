var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IAttendeeRepository, AttendeeRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapAttendeeEndpoints();

app.Run();