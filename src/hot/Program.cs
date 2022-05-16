using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => 
{
    var pid = Process.GetCurrentProcess().Id;
    return $"Hello Iedereen! {pid}";
});

app.Run();
