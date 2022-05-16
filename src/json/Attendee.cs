namespace Models;

public class Attendee
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    
    //[JsonInclude]
    //private string IncludeInJson { get; set; } = string.Empty;
}