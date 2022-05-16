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
// New LINQ API's - Max(IComparer comparer) | Min
//
// 	A new overload for specifying a comparer to determine the max.

// In the old days:
var max = Albums
	.Max(a => a.Tracks.Sum(t => t.UnitPrice));

Albums
	.First(a => a.Tracks.Sum(t => t.UnitPrice) == max)
		.Dump("The most expensive album");

// .NET 6:
Albums.AsEnumerable()
	.Max(new AlbumPriceComparer())
		.Dump("The most expensive album");

Albums.AsEnumerable()
	.Max(new AlbumLengthComparer())
		.Dump("The longest album");


/// <summary>A comparer on the total price of an album.</summary>
class AlbumPriceComparer : IComparer<Album>
{
	public int Compare(Album x, Album y) => x.Tracks.Sum(t => t.UnitPrice).CompareTo(y.Tracks.Sum(t => t.UnitPrice));
}
/// <summary>A comparer on the length, the total duration of an album.</summary>
class AlbumLengthComparer : IComparer<Album>
{
	public int Compare(Album x, Album y) => x.Tracks.Sum(t => t.Milliseconds).CompareTo(y.Tracks.Sum(t => t.Milliseconds));
}