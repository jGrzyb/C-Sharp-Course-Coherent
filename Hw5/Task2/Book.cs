public class Book
{
    public string Title { get; set; } = "";
    public DateTime? ReleaseDate { get; set; }
    public HashSet<Author> Authors { get; set; } = new();

    public Book(string title, DateTime? releaseDate = null) : this(title, new HashSet<Author>(), releaseDate)
    {
    }

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

    public virtual string[] GetPressRelease() => [];

    public override string ToString()
    {
        return Title.PadLeft(40) + " - " + string.Join(", ", Authors);
        // return $"\"{Title}\"   -   {string.Join(", ", Authors)}";
    }
}