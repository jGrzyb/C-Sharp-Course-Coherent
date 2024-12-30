public class Library
{
    public Catalog catalog;
    public string[] PressReleaseItems;

    public Library(Catalog catalog, string[] pressReleaseItems)
    {
        this.catalog = catalog;
        PressReleaseItems = pressReleaseItems;
    }

    public override string ToString()
    {
        return catalog + "\n\n" + string.Join(", ", PressReleaseItems);
    }
}