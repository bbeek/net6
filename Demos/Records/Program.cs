using Records;



var account = new AccountDTO { Name = "Test", Email = "demo@example.org" };

Console.WriteLine(account.Name);



var copy = account;

copy.Name = "Changed";
Console.WriteLine(account.Name);





















/*



var account = new AccountDTO ("Test", "demo@example.org");

Console.WriteLine(account.Name);

var copy = account with { Name = "Changed"};

Console.WriteLine(account);
Console.WriteLine(copy);

*/

#region Immutable?
/*
account.MutableName = "niet immutable";

Console.WriteLine(account);
*/
#endregion

/*
// Value equality op reference types
var duplicate = account;

Console.WriteLine(duplicate == account);
*/


/*
var gold = new GoldAccount("Premium", "vip@example.org", true);
Console.WriteLine(gold);
*/

/*
var struct1 = new StructExample() { Name = "1", Email = "cool@demo.com" };
var struct2 = new StructExample() { Name = "2", Email =  "super@demo.nl" };
Console.WriteLine(struct1.Equals(struct2));
*/

#region struct
/*
var valueType = new AccountStruct();
valueType.Name = "Struct";

Console.WriteLine(valueType);
*/
// Show ILSpy value type



















// change to readonly
#endregion


#region With op struct
/*
var struct3 = struct1 with { Name = "3" };
Console.WriteLine($"{struct3.Name} {struct3.Email}");
*/
#endregion