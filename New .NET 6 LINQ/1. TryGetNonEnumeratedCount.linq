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
// New LINQ API's - TryGetNonEnumeratedCount()
//
// 	Try to get the number of items in a sequence, without enumerating over the sequence
//  requested by users to be used when determining the default value for a new collection's capacity

IEnumerable<string> albumsFromTable = Albums.Where(x => x.Title.Length < 14).Select(a => a.Title); // <-- Albums is a DbSet from the database
IEnumerable<string> albumsFromArray = new[] { "Big Ones","Facelift","Audioslave","Out Of Exile","Black Sabbath","Body Count","Prenda Minha","Na Pista","Bongo Fury","Carnaval 2001","Greatest Kiss","Meus Momentos","Supernatural","Up An' Atom","Vozes do MPB","Fireball","Machine Head","Purpendicular","Stormbringer","Outbreak","Unplugged","Angel Dust","Deixa Entrar","One By One","Roda De Funk","Faceless","Blue Moods","Iron Maiden","Killers","Piece Of Mind","Powerslave","The X Factor","Virtual XI","Sex Machine","Synkronized","Get Born","Cafezinho","Coda","IV","Presence","Mais Do Mesmo","Greatest Hits","Black Album","Kill 'Em All","Load","ReLoad","St. Anger","Miles Ahead","Minas","Ace Of Spades","Demorou...","Nevermind","Compositores","Olodum","Acústico MTV","Arquivo II","Tribute","Pearl Jam","Riot Act","Ten","Vs.","Out Of Time","Green","Cesta Básica","Raul Seixas","By The Way","Santana Live","Maquinarama","A-Sides","Morning Dance","In Step","Core","Mezmerize","Live [Disc 1]","Live [Disc 2]","The Singles","The Doors","No Security","Voodoo Lounge","Tangents","Transmission","Acústico","Volume Dois","Achtung Baby","Pop","War","Zooropa","Diver Down","Van Halen","Van Halen III","Contraband","Un-Led-Ed","Aquaman","House of Pain","Quiet Songs","Muso Ko","Realize","Duos II","Worlds","Carry On","Revelations","Scheherazade","Back to Black","Frank" };

// determine which sequence to use:
var albums = albumsFromTable;

if (albums.TryGetNonEnumeratedCount(out int numberOfAlbums))
{
	Console.WriteLine($"{numberOfAlbums} albums found. And I can work fast with these!");

	string[] fixedBuffer = new string[numberOfAlbums];
	SortUsingFixedBuffer(albums, fixedBuffer);
	fixedBuffer.Dump("Albums, sorted using Array Sort");
}
else
{
	Console.WriteLine($"{(albums.Any() ? "Albums found." : "No albums found.")} Unfortunately, I have to use the expensive way to work with these.");
	
	List<string> resizingBuffer = new List<string>();
	SortUsingResizingBuffer(albums, resizingBuffer);
	resizingBuffer.Dump("Albums, sorted using OrderBy on Enumerable");
}

/// <summary>Sort each album title, then sort the resulting string.</summary>
void SortUsingFixedBuffer(IEnumerable<string> albums, string[] fixedBuffer)
{
	var index = 0;

	foreach (var album in albums)
	{
		char[] characters = album.ToArray();
		Array.Sort(characters);
		fixedBuffer[index++] = new string(characters);
	}
	Array.Sort(fixedBuffer);
}
/// <summary>Sort each album title, then sort the resulting string.</summary>
void SortUsingResizingBuffer(IEnumerable<string> albums, List<string> resizingBuffer)
{
	foreach (var album in albums)
	{
		resizingBuffer.Add(new string(album.OrderBy(c => c.ToString()).ToArray()));
	}
	resizingBuffer = resizingBuffer.OrderBy(s => s).ToList();
}
