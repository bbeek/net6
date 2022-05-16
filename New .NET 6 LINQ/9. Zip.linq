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
// New LINQ API's - Zip
//
// 	A new overload to zip three sequences into a new sequence of tuples with three values

var albums = Albums.AsEnumerable().Take(10).Select(a => a.Title);
var tracks = Albums.AsEnumerable().Take(10).Select(a => a.Tracks.Count);
var artists = Albums.AsEnumerable().Take(10).Select(a => a.Artist.Name);

// old: 
albums
	.Zip(tracks)
	.Zip(artists, (z1,e3) => Tuple.Create(z1.First, z1.Second, e3))
		.Dump("Ten albums, tracks and artists zipped together");

// new: 
albums
	.Zip(tracks,artists)
		.Dump("Ten albums, tracks and artists zipped together");