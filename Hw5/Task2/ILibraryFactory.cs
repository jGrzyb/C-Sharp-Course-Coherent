using System.Text.RegularExpressions;
using Microsoft.VisualBasic.FileIO;

public interface ILibraryFactory 
{
    Catalog CreateCatalog(string filePath);
    string[] CreatePressReleaseItems();

    // public Library CreateLibrary(string filePath)
    // {
    //     Catalog catalog = new();
    //     using(TextFieldParser csvParser = new TextFieldParser(filePath)) 
    //     {
    //         csvParser.CommentTokens = [ "#" ];
    //         csvParser.SetDelimiters([ "," ]);
    //         csvParser.HasFieldsEnclosedInQuotes = true;

    //         csvParser.ReadLine();

    //         while (!csvParser.EndOfData)
    //         {
    //             string[] fields = csvParser.ReadFields() ?? [];
    //             //---------------------------------------------

    //             // if(isTypeCorrect(fields)) 
    //             // {
    //             //     (string isbn, Book book) = ParseFields(fields);
    //             //     catalog.dictionary.Add(isbn, book);
    //             // }

    //             //---------------------------------------------

    //             (string isbn, Book book) = ParseFields(fields);
    //             if(isbn is null || book is null)
    //             {
    //                 continue;
    //             }
    //             if(catalog.dictionary.ContainsKey(isbn)) 
    //             {
    //                 Console.WriteLine($"Duplicate ISBN: `{isbn}`");
    //                 continue;
    //             }
    //             catalog.dictionary.Add(isbn, book);
                
    //             //---------------------------------------------
    //         }
    //     }
    //     string[] pressReleaseItems = catalog.dictionary.Values.SelectMany(x => x.GetPressRelease()).Distinct().ToArray();
    //     return new Library(catalog, pressReleaseItems);
    // }
}