using System.Text.Json.Serialization;

using Models;

namespace SourceGenerated;

[JsonSerializable(typeof(Attendee))]
[JsonSourceGenerationOptions(
    GenerationMode = JsonSourceGenerationMode.Default,
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
public partial class AttendeeJsonContext : JsonSerializerContext
{   
}