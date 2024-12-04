using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

public class PaperCatalog : Catalog
{
    [JsonIgnore]
    [XmlIgnore]
    private readonly Regex r0 = new(@"\d{3}-\d{1}-\d{2}-\d{6}-\d{1}");
    private readonly Regex r1 = new Regex(@"\d{13}");

    public PaperCatalog()
    {
    }

    public override void Add(string source, Book book)
    {
        if(book is not PaperBook)
        {
            throw new ArgumentException("All books in this library must be of type PaperBook.");
        }
        base.Add(source, book);
    }
    
    public override string[] GetPressReleaseItems()
    {
        return dictionary.Values.Cast<PaperBook>().Select(x => x.Publisher).Distinct().ToArray();
    }

    protected override bool isKeyCorrect(string key)
    {
        // if(!r0.Match(key).Success && !r1.Match(key).Success) 
        // {
        //     return false;
        // }
        return true;
    }

    public override void ReadCSV(string path)
    {
        foreach (var line in ReadCsvLines(path))
        {
            DateTime time = new DateTime();
            DateTime.TryParse(line[3], out time);
            Add(
                line[2], 
                new PaperBook(
                    line[6], 
                    new HashSet<Author>([new Author(line[0])]), 
                    time,
                    line[4],
                    line[5].Split(',').ToList()
                )
            );
        }
    }
}