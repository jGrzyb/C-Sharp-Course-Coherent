using System.Data.SqlTypes;

public interface IRepository
{
    void Save(Catalog data);
    Catalog? Load();
}