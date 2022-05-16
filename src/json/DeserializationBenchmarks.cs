using System.Text;
using System.Text.Json;
using BenchmarkDotNet.Attributes;

using Bogus;

using Models;

namespace SourceGenerated;

[MemoryDiagnoser]
public class DeserializationBenchmarks
{
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    private string _attendeeAsText = string.Empty;

    [GlobalSetup]
    public void Setup()
    {
        Faker<Attendee> faker = new();
        Randomizer.Seed = new Random(420);
        var people = faker
            .RuleFor(x => x.FirstName, x => x.Name.FirstName())
            .RuleFor(x => x.LastName, x => x.Name.LastName())
            .Generate(1000);

        var memoryStream = new MemoryStream();
        var jsonWriter = new Utf8JsonWriter(memoryStream);
        JsonSerializer.Serialize(jsonWriter, people, typeof(List<Attendee>), AttendeesJsonContext.Default);
        _attendeeAsText = Encoding.UTF8.GetString(memoryStream.ToArray());
    }

    [Benchmark(Baseline = true)]
    public List<Attendee>? DeserializedUsingJsonSerializerOptions()
    {
        return JsonSerializer.Deserialize<List<Attendee>>(_attendeeAsText, _options);
    }

    [Benchmark]
    public List<Attendee>? DeserializedUsingSourceGeneratedJsonContext()
    {
       return JsonSerializer.Deserialize(_attendeeAsText, AttendeesJsonContext.Default.ListAttendee);
    }    
}
