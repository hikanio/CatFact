using CatFact.Models;

namespace CatFact.Services;

public interface ICatFactService
{
    Task<CatFactDto?> GetCatFactAsync();
}