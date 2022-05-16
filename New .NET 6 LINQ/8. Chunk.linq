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
// New LINQ API's - Chunk(int size)
//
// 	Splits the sequence into chunks of a specified size

// Each box can hold at most 10 albums
IEnumerable<Album[]> boxes = Albums.AsEnumerable()
	.Chunk(10);

// So, what's in the third box?
Album[] box3 = boxes.Skip(2).Take(1).SingleOrDefault()
	.Dump("Third Box");

// And what's in the last box?
Album[] lastBox = boxes.Last()
	.Dump("Last Box");