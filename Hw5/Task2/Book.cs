using System.Reflection;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

[Serializable]
public class Book
{
    public string Title { get; set; } = "";
    public DateTime? ReleaseDate { get; set; }
    public HashSet<Author> Authors { get; set; } = new();


    public Book()
    {
    }

    public Book(string title, DateTime? releaseDate = null) : this(title, new HashSet<Author>(), releaseDate)
    {
    }

    [JsonConstructor]
    public Book(string title, HashSet<Author> authors, DateTime? releaseDate = null) 
    {
        if(title is null) 
        {
            throw new ArgumentNullException(nameof(title));
        }
        if(authors is null) 
        {
            throw new ArgumentNullException(nameof(authors));
        }
        Title = title;
        ReleaseDate = releaseDate;
        Authors = new HashSet<Author>(authors);
    }

    public override string ToString()
    {
        return $"\"{Title}\"   -   {string.Join(", ", Authors)}";
    }
}