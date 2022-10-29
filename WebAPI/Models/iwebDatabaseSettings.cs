namespace WebAPI.Models;

public class iwebDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string ViviendasCollectionName { get; set; } = null!;

    public string ReservasCollectionName { get; set; } = null!;
}