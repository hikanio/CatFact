namespace CatFact.Configuration;

public sealed class StorageConfiguration
{
    public const string SectionName = "Storage";
    public string DataDirectory { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
}