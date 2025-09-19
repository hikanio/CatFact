using System.Text.Json.Serialization;

namespace CatFact.Models;

public record CatFactDto
{
    [JsonPropertyName("fact")]
    public string? Fact { get; init; }
    
    [JsonPropertyName("length")]
    public int Length { get; init; }
}
