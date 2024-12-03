using System.Reflection;

public class Book
{
    public string Title { get; }
    public DateTime? ReleaseDate { get; }
    public HashSet<string> Authors { get; } = new();

    public Book(string title, DateTime? releaseDate = null) : this(title, [], releaseDate)
    {
    }
    public Book(string title, string[] authors, DateTime? releaseDate = null) 
    {
        if(title is null) {
            throw new ArgumentNullException(nameof(title));
        }
        if(authors is null) {
            throw new ArgumentNullException(nameof(authors));
        }
        Title = title;
        ReleaseDate = releaseDate;
        Authors = new HashSet<string>(authors);
    }
}