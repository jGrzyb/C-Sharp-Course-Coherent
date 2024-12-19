using System.Data.SqlTypes;

public interface IRepository
{
    void Save(string filePath, Catalog data);
    Catalog? Load(string filePath);
}

// sda, scl
// BMP 280