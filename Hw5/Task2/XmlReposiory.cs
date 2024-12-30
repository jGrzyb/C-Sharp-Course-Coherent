using System.Xml.Serialization;

public class XmlRepository : IRepository
{
    private const string filePath = "catalog.xml";
    public void Save(Catalog data)
    {
        var serializer = new XmlSerializer(typeof(DALCatalog));
        using (var writer = new StreamWriter(filePath))
        {
            serializer.Serialize(writer, new DALCatalog(data));
        }
    }

    public Catalog? Load()
    {
        if (!File.Exists(filePath))
        {
            return default;
        }

        var serializer = new XmlSerializer(typeof(DALCatalog));
        using (var reader = new StreamReader(filePath))
        {
            object? res =  serializer.Deserialize(reader);
            if(res is null)
            {
                return default;
            }
            return ((DALCatalog)res)?.ToCatalog();
        }
    }
}