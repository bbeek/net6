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
// New LINQ API's - FirstOrDefault(Index index) | LastOrDefault | SingleOrDefault
//
// 	A new overload for the default value to return

var albumNotFound = new Album 
{ 
	AlbumId = -1, 
	Title = "Why don't you produce one yourself?" 
};

Albums.AsEnumerable()
	.FirstOrDefault(a => a.Title.StartsWith("X"), albumNotFound)
		.Dump("The first album starting with an X");