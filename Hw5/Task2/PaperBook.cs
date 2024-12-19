using System.Text.Json.Serialization;
using System.Xml.Serialization;

public class PaperBook : Book {
    [JsonIgnore]
    [XmlIgnore]
    public List<string> Isbns { get; set; } = new();
    [JsonIgnore]
    [XmlIgnore]
    public string Publisher { get; set; } = "";

    public PaperBook(string title, HashSet<Author> authors, DateTime publicationDate, string publisher, List<string> isbns) : base(title, authors, publicationDate)
    {
        Publisher = publisher;
        Isbns = isbns.ToList();
    }
}