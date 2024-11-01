Catalog catalog = new();
Book[] books = [
    new("at", ["aa", "ca", "ba"], new DateTime(2000, 1, 1)),
    new("bt", ["aa", "da", "ba"], new DateTime(2000, 2, 1)),
    new("ft", ["aa", "ca", "da"], new DateTime(2000, 1, 2)),
    new("dt", ["aa", "ca"], new DateTime(2000, 4, 3)),
    new("et", ["aa"], new DateTime(2000, 5, 4)),
    new("ct", ["da", "ca", "ba"], new DateTime(2000, 1, 7))
];

for(int i=0; i<books.Length; i++)
{
    catalog.Add((i % 2 == 0 ? "123456789012" : "123-4-56-789012-")+i, books[i]);
}
catalog.GetTitlesAlphabetical().ToList().ForEach(Console.WriteLine);
Console.WriteLine();
catalog.GetBooksByAuthor("aa").ToList().ForEach(x => Console.WriteLine(x.Title));
Console.WriteLine();
catalog.GetAuthorsWithBookCount().ToList().ForEach(x => Console.WriteLine(x.Item1 + " " + x.Item2));