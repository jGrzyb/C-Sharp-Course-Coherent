// using System.Text.Json;

Catalog catalog = new();
catalog.Add("9780515110234", new Book(
    "The Floating Admiral", 
    [
        new Author("The Detection", "Club", new DateTime(2001, 1, 1)), 
        new Author("G.K.", "Chesterton", new DateTime(2000, 2, 5)), 
        new Author("Victor L.", "Whitechurch", new DateTime(1999, 7, 4))
    ], 
    new DateTime(1990, 5, 10)
));

catalog.Add("9780743285452", new Book(
    "The Sword of Shame", 
    [
        new Author("The medival", "Murders", new DateTime(1980, 3, 6)), 
        new Author("Philip", "Gooden", new DateTime(1898, 2, 3)), 
        new Author("Susanna", "Gregory", new DateTime(1998, 9, 9)), 
        new Author("Michael", "Jecks", new DateTime(2003, 5, 4)), 
        new Author("Brenard", "Knight", new DateTime(2002, 2, 1))
    ], 
    new DateTime(2006, 1, 1)
));

catalog.Add("9780060763442", new Book(
    "The Last Templar", 
    [
        new Author("Michael", "Jecks", new DateTime(1997, 7, 6))
    ], 
    new DateTime(1995, 1, 1)
));

catalog.Add("9780060763466", new Book(
    "The Merchant's Partner", 
    [
        new Author("Michael", "Jecks", new DateTime(1993, 2, 4))
    ], 
    new DateTime(1996, 6, 13)
));

catalog.Add("9781569475126", new Book(
    "The Salisbury Manuscript", 
    [
        new Author("Philip", "Gooden", new DateTime(1992, 1, 8))
    ], 
    new DateTime(2008, 1, 1)
));


Console.WriteLine(catalog.ToString());
Console.WriteLine();

JsonRepository repository = new();
repository.Save(catalog);
catalog = repository.Load()!;
Console.WriteLine(catalog.ToString());
Console.WriteLine();

XmlRepository xmlRepository = new();
xmlRepository.Save(catalog);
catalog = xmlRepository.Load()!;
Console.WriteLine(catalog.ToString());
Console.WriteLine();





// Library<ECatalog> eLibrary = new();
// Library<PaperCatalog> paperLibrary = new();

// eLibrary.ReadCSV("books_info.csv");
// paperLibrary.ReadCSV("books_info.csv");

// Console.WriteLine(eLibrary.ToString());
// Console.WriteLine();
// Console.WriteLine(paperLibrary.ToString());
// Console.WriteLine();