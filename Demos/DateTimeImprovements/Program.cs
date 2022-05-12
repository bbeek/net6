using DateTimeImprovements;

var now = DateTime.Now;

Console.WriteLine(now);



































DateOnly dateOnly = DateOnly.FromDateTime(DateTime.Now);
TimeOnly timeOnly = TimeOnly.FromDateTime(DateTime.Now);
Console.WriteLine(dateOnly);
Console.WriteLine(timeOnly);














var timeSpan = TimeSpan.FromSeconds(1);
var fromTimeSpan = TimeOnly.FromTimeSpan(timeSpan);
Console.WriteLine(fromTimeSpan.ToLongTimeString());







Console.WriteLine(dateOnly.DayOfWeek);
Console.WriteLine(dateOnly.ToLongDateString());

Console.WriteLine(timeOnly.ToLongTimeString());






















var dateTime = dateOnly.ToDateTime(timeOnly);
Console.WriteLine(dateTime.ToLongTimeString()); 









// IsBetween
var begin = new TimeOnly(9, 0);
var end = new TimeOnly(17, 0);
Console.WriteLine(timeOnly.IsBetween(begin, end));




// Circular time
Console.WriteLine(timeOnly.IsBetween(new TimeOnly(15,0), new TimeOnly(09,0)));






























//Serialize support (plus EF support)
//var hours = new OpeningHours(begin, end);
//var json = System.Text.Json.JsonSerializer.Serialize(hours);
//var newtonSoft = Newtonsoft.Json.JsonConvert.SerializeObject(hours);

//Console.WriteLine(json);
//Console.WriteLine(newtonSoft);

// .Net 7 will introduce support for System.Text.Json.  For now, custom converters


























// Before .Net 6, timezone support was depended on OS version.
// The set of time zones created by Microsoft that ship with Windows. 
// The set of time zones that everyone else uses, which are currently maintained by IANA. 
//Previously, the TimeZoneInfo.FindSystemTimeZoneById method looked up time zones available on the operating system
// Workaround was nuget package https://github.com/mattjohnsonpint/TimeZoneConverter

foreach (var timezone in TimeZoneInfo.GetSystemTimeZones())
{
    Console.WriteLine(timezone.DisplayName + " => " + timezone.Id);
}

var curacao = TimeZoneInfo.FindSystemTimeZoneById("America/Curacao");
Console.WriteLine(curacao.DisplayName + " => " + curacao.Id);

string ianaId1 = "America/Curacao";
if (!TimeZoneInfo.TryConvertIanaIdToWindowsId(ianaId1, out string winId))
    throw new TimeZoneNotFoundException($"No Windows time zone found for { ianaId1 }.");
Console.WriteLine($"{ianaId1} => {winId}");

var winZone = TimeZoneInfo.GetSystemTimeZones().First(zone => zone.Id == winId);
Console.WriteLine(winZone.DisplayName + " => " + winZone.Id);

