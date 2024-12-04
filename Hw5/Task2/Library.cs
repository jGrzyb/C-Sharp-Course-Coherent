public class Library<T> where T : Catalog, new()
{
    public Catalog catalog;
    public string[] PressReleaseItems => catalog.GetPressReleaseItems();
    public void ReadCSV(string path) => catalog.ReadCSV(path);
    
    public Library()
    {
        catalog = new T();
    }

    public override string ToString() => catalog.ToString();
}