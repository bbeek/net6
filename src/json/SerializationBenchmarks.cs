using System.Text;
using System.Text.Json;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

using Bogus;

using Models;

namespace SourceGenerated;

[MemoryDiagnoser]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
public class SerializationBenchmarks
{
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    private List<Attendee> _attendees = new();

    [GlobalSetup]
    public void Setup()
    {
        Faker<Attendee> faker = new();
        Randomizer.Seed = new Random(420);
        _attendees = faker
            .RuleFor(x => x.FirstName, x => x.Name.FirstName())
            .RuleFor(x => x.LastName, x => x.Name.LastName())
            .Generate(1000);
    }

    [BenchmarkCategory("Stream"), Benchmark(Baseline = true)]
    public MemoryStream SerializedUsingJsonSerializerOptions()
    {
        var memoryStream = new MemoryStream();
        var jsonWriter = new Utf8JsonWriter(memoryStream);
       
        JsonSerializer.Serialize(jsonWriter, _attendees, _options);
       
        return memoryStream;
    }

    [BenchmarkCategory("Stream"), Benchmark]
    public MemoryStream SerializedUsingSourceGeneratedJsonContext()
    {
        var memoryStream = new MemoryStream();
        var jsonWriter = new Utf8JsonWriter(memoryStream);
        
        JsonSerializer.Serialize(jsonWriter, _attendees, typeof(List<Attendee>), AttendeesJsonContext.Default);
        
        return memoryStream;
    }
    

    [BenchmarkCategory("String"), Benchmark(Baseline = true)]
    public string SerializedUsingJsonSerializerOptions_AsString()
    {
        var memoryStream = SerializedUsingJsonSerializerOptions();
        return Encoding.UTF8.GetString(memoryStream.ToArray());
    }

    [BenchmarkCategory("String"), Benchmark]
    public string SerializedUsingSourceGeneratedJsonContext_AsString()
    {
        var memoryStream = SerializedUsingSourceGeneratedJsonContext();
        return Encoding.UTF8.GetString(memoryStream.ToArray());
    }
}
