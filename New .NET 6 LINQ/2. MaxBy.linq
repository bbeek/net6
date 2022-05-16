<Query Kind="Statements">
  <Connection>
    <ID>54bf9502-9daf-4093-88e8-7177c12aaaaa</ID>
    <NamingService>2</NamingService>
    <Driver Assembly="(internal)" PublicKeyToken="no-strong-name">LINQPad.Drivers.EFCore.DynamicDriver</Driver>
    <AttachFileName>&lt;ApplicationData&gt;\LINQPad\ChinookDemoDb.sqlite</AttachFileName>
    <DisplayName>Demo database (SQLite)</DisplayName>
    <DriverData>
      <PreserveNumeric1>true</PreserveNumeric1>
      <EFProvider>Microsoft.EntityFrameworkCore.Sqlite</EFProvider>
      <MapSQLiteDateTimes>true</MapSQLiteDateTimes>
      <MapSQLiteBooleans>true</MapSQLiteBooleans>
    </DriverData>
  </Connection>
</Query>

//
// New LINQ API's - MaxBy(Func keySelector) | MinBy
//
// 	Gets the element with a maximum value according to a specified function

// In the old days:
var max = Albums
	.Max(a => a.Tracks.Count);

Albums
	.First(a => a.Tracks.Count == max)
		.Dump("The album with the most tracks");

// .NET 6:
Albums.AsEnumerable()
	.MaxBy(a => a.Tracks.Count)
		.Dump("The album with the most tracks");