namespace CatFact.Configuration;

public sealed class CatFactApiConfiguration
{
    public const string SectionName = "CatFactApi";
    public string BaseUrl { get; set; } = string.Empty;
    public string FactEndpoint { get; set; } = string.Empty;
}