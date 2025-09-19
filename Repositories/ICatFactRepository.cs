using CatFact.Models;

namespace CatFact.Repositories;

public interface ICatFactRepository
{
    void Save(CatFactDto fact);
    IEnumerable<CatFactDto> GetAll();
    string GetFilePath();
}