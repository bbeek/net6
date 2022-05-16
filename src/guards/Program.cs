using System.Runtime.InteropServices;
using System.Runtime.Versioning;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () =>
{
    var guardTester = new GuardTester();
    guardTester.DoesNotWorkOnAndroid();
    guardTester.SupportedOnWindowsAndIos14();
    guardTester.LinuxOnlyApi();
    guardTester.Caller();
    return "test complete";
});

app.Run();

