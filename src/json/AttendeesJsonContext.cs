using System.Text.Json.Serialization;

using Models;

namespace SourceGenerated;

[JsonSerializable(typeof(List<Attendee>))]
[JsonSourceGenerationOptions(
    GenerationMode = JsonSourceGenerationMode.Default,
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
public partial class AttendeesJsonContext : JsonSerializerContext
{   
}