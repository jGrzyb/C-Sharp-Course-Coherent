using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

public class ECatalog : Catalog
{
    [JsonIgnore]
    [XmlIgnore]
    private static readonly Regex urlRegex = new Regex(@"^(http|https)://[^\s/$.?#].[^\s]*$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    public ECatalog()
    {
    }

    public override void Add(string source, Book book)
    {
        if(book is not EBook)
        {
            throw new ArgumentException("All books in this library must be of type EBook.");
        }
        base.Add(source, book);
    }

    public override string[] GetPressReleaseItems()
    {
        return dictionary.Values.Cast<EBook>().SelectMany(x => x.Formats).Distinct().ToArray();
    }

    protected override bool isKeyCorrect(string key)
    {
        // if(!urlRegex.Match(key).Success) 
        // {
        //     return false;
        // }
        return true;
    }

    public override void ReadCSV(string path)
    {
        foreach(var line in ReadCsvLines(path))
        {
            DateTime time = new DateTime();
            DateTime.TryParse(line[3], out time);
            Add(
                line[2], 
                new EBook(
                    line[6], 
                    new HashSet<Author>([new Author(line[0])]),
                    time,
                    line[2],
                    line[1].Split(',')
                )
            );
        }
    }
}