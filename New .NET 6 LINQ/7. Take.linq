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
// New LINQ API's - Take
// 	
// 	Gets specified range of elements from the sequence
//  (Includes support for the range operator .. (C#8))

Albums.AsEnumerable()
	.Take(0..4)
		.Dump("The first four albums");
		
Albums.AsEnumerable()
	.Take(^3..^0)
		.Dump("The last three albums");
		
Albums.AsEnumerable()
	.Take(3..7)   // a.k.a. Skip(3).Take(7-3)
		.Dump("Skip the first three albums, take up to the 7th album");