namespace Records;


public class AccountDTO
{
    public string Name { get; set; }
    public string Email { get; set; }
}



#region Records

/*
public record class AccountDTO(string Name, string Email) 
{
    //public string MutableName { get; set; } = default!;       // Always immutable?
    
    
    // PrintMembers

}
*/

#region Value equality
// Show value equality ?


#endregion

#region inheritance
/*
public class GoldAccount : AccountDTO
{
    public GoldAccount(string Name, string Email) : base(Name, Email)
    {
    }
}
*/







/*
public record GoldAccount(string Name, string Email, bool IsGold) : AccountDTO(Name, Email)
{
}
*/

#endregion


#region structs

public struct StructExample
{
    public string Name { get; set; }
    public string Email { get; set; } 
}

/*
public record struct AccountStruct(string Name, string Email)
{
    public string MutableName { get; set; } = default!;

};
*/

// Value types met non reflection value equality 

// Usage => vervanger van Tuple<string, string, string>


/// readonly record struct
// Show example with MutableString








// struct inheritance not allowed
/*
public struct SubStruct: StructExample
{
}
*/

//
//
//, so no record struct inheritance
/*
public record struct SubRecordStruct : AccountStruct
{

}
*/
#endregion


#region Sealed ToString

// Show with inheritance zonder sealed (en daarna met)
/*
public record AccountDTO(string Name, string Email)
{
    public string MutableName { get; set; } = default!;

    
    public sealed override string ToString()
    {
        return "This cannot be changed via inheritance";
    }    
}
*/
#endregion


// Last example:
// Mixed declaration in deconstructor

// (var n, var e)
// string n, string e
// (n, e)

// Allowed
// (var n, e)
#endregion