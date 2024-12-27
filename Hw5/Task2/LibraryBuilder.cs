public class LibraryBuilder
{
    public Library Build(string filePath, string type)
    {
        LibraryAbstractFactory factory;
        switch(type)
        {
            case "ELibrary":
                factory = new ELibraryFactory();
                break;
            default:
                throw new ArgumentException("Invalid type");
        }
        return factory.CreateLibrary(filePath);
    }
}