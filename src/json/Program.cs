using System.Text.Json;

using BenchmarkDotNet.Running;

using Models;

using SourceGenerated;

//var person = new Attendee { FirstName = "Ramon", LastName = "Wehrmann"};
//var serializerOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

//// With options
//var serializedAttendeeOptions = JsonSerializer.Serialize(person, serializerOptions);
//var deserializedAttendeeOptions = JsonSerializer.Deserialize<Attendee>(serializedAttendeeOptions, serializerOptions);
//Console.WriteLine(serializedAttendeeOptions);

//// With source generated code
//var serializedAttendeeTypeInfo = JsonSerializer.Serialize(person, AttendeeJsonContext.Default.Attendee);
//var deserializedAttendeeTypeInfo = JsonSerializer.Deserialize(serializedAttendeeTypeInfo, AttendeesJsonContext.Default.Attendee);
//Console.WriteLine(serializedAttendeeTypeInfo);
//Console.WriteLine();

BenchmarkRunner.Run<SerializationBenchmarks>();
//BenchmarkRunner.Run<DeserializationBenchmarks>();