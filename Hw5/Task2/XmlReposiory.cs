using System.Xml.Serialization;

public class XmlRepository : IRepository
{
    public void Save(string filePath, Catalog data)
    {
        var serializer = new XmlSerializer(typeof(BookEntry[]));
        using (var writer = new StreamWriter(filePath))
        {
            var bookEntries = toBookEntries(data);
            serializer.Serialize(writer, bookEntries);
        }
    }

    public Catalog? Load(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return default;
        }

        var serializer = new XmlSerializer(typeof(BookEntry[]));
        using (var reader = new StreamReader(filePath))
        {
            object? res =  serializer.Deserialize(reader);
            if(res is null)
            {
                return default;
            }
            return new Catalog(toDictionary((BookEntry[])res));
        }
    }

    private BookEntry[] toBookEntries(Catalog catalog)
    {
        return catalog.dictionary.Select(x => new BookEntry(x.Key.ISBN, x.Value)).ToArray();
    }

    private Dictionary<Isbn, Book> toDictionary(BookEntry[] bookEntries)
    {
        return bookEntries.ToDictionary(x => new Isbn(x.Isbn), x => x.Book);
    }


    [Serializable]
    public class BookEntry 
    {
        public string Isbn { get; set; }
        public Book Book { get; set; }

        public BookEntry()
        {
        }

        public BookEntry(string isbn, Book book)
        {
            Isbn = isbn;
            Book = book;
        }
    }
}