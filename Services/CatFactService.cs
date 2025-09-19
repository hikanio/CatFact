using System.Net.Http.Json;
using CatFact.Configuration;
using CatFact.Models;
using Microsoft.Extensions.Options;

namespace CatFact.Services;

public class CatFactService : ICatFactService
{
    private readonly HttpClient _httpClient;
    private readonly CatFactApiConfiguration _configuration;
    
    public CatFactService(HttpClient httpClient, IOptions<CatFactApiConfiguration> options)
    {
        _httpClient = httpClient;
        _configuration = options.Value;
        _httpClient.BaseAddress = new Uri(_configuration.BaseUrl);
    }
    
    public async Task<CatFactDto?> GetCatFactAsync()
    {
        try
        {
            var catFact = await _httpClient.GetFromJsonAsync<CatFactDto>(_configuration.FactEndpoint);
            return catFact;
        }
        catch (Exception ex)
        {
            // Log ex.Message
            return null;
        }
    }
}