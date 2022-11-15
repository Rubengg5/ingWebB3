namespace WebAPI.Models;

public class iwebDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string TrinosCollectionName { get; set; } = null!;

    public string SigueMeCollectionName { get; set; } = null!;
}