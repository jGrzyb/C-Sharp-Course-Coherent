LibraryBuilder builder = new();
JsonRepository repository = new();

if(!Directory.Exists("eLib"))
{
    Directory.CreateDirectory("eLib");
}
if(!Directory.Exists("pLib"))
{
    Directory.CreateDirectory("pLib");
}


Library eLibrary = builder.Build("books_info.csv", "ELibrary");
File.WriteAllText("output.txt", eLibrary.ToString());
Directory.SetCurrentDirectory("eLib");
repository.Save(eLibrary.catalog);


Directory.SetCurrentDirectory("../");

Library paperLibrary = builder.Build("books_info.csv", "PaperLibrary");
File.AppendAllText("output.txt", "\n\n\n" + paperLibrary.ToString());
Directory.SetCurrentDirectory("pLib");
repository.Save(paperLibrary.catalog);

Console.WriteLine($"{eLibrary.catalog.dictionary.Count} books in eLibrary");
Console.WriteLine($"{paperLibrary.catalog.dictionary.Count} books in paperLibrary");