using System.Text.Json;
using CatFact.Configuration;
using CatFact.Models;
using Microsoft.Extensions.Options;

namespace CatFact.Repositories;

public class CatFactRepository : ICatFactRepository
{
    private readonly string _dataFilePath;
    private List<CatFactDto> _facts = [];

    public CatFactRepository(IOptions<StorageConfiguration> options)
    {
        var configuration = options.Value;
        _dataFilePath = Path.Combine(AppContext.BaseDirectory, configuration.DataDirectory, configuration.FileName);
        EnsureDirectoryExists();
        LoadFacts();
    }

    public void Save(CatFactDto fact)
    {
        _facts.Add(fact);
        AppendFactToFile(fact);
    }

    public IEnumerable<CatFactDto> GetAll()
    {
        return _facts;
    }

    public string GetFilePath()
    {
        return _dataFilePath;
    }

    private void LoadFacts()
    {
        if (!File.Exists(_dataFilePath))
        {
            _facts = [];
            return;
        }

        try
        {
            _facts = [];
            foreach (var line in File.ReadLines(_dataFilePath))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var fact = JsonSerializer.Deserialize<CatFactDto>(line);
                if (fact != null)
                {
                    _facts.Add(fact);
                }
            }
        }
        catch (Exception ex)
        {
            _facts = [];
            Console.WriteLine($"Error loading cat facts: {ex.Message}");
        }
    }

    private void AppendFactToFile(CatFactDto fact)
    {
        try
        {
            var json = JsonSerializer.Serialize(fact);
            EnsureDirectoryExists();
            File.AppendAllText(_dataFilePath, json + Environment.NewLine);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving cat fact: {ex.Message}");
        }
    }

    private void EnsureDirectoryExists()
    {
        var directory = Path.GetDirectoryName(_dataFilePath);
        if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
    }
}