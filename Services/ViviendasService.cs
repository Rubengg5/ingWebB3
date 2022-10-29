using WebAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace WebAPI.Services;

public class ViviendasService
{
    private readonly IMongoCollection<Vivienda> viviendasCollection;

    public ViviendasService(
        IOptions<iwebDatabaseSettings> iwebDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            iwebDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            iwebDatabaseSettings.Value.DatabaseName);

        viviendasCollection = mongoDatabase.GetCollection<Vivienda>(
            iwebDatabaseSettings.Value.ViviendasCollectionName);
    }

    public async Task<List<Vivienda>> GetAsync() =>
        await viviendasCollection.Find(_ => true).ToListAsync();

    public async Task<Vivienda?> GetAsync(Guid id) =>
        await viviendasCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Vivienda newVivienda) =>
        await viviendasCollection.InsertOneAsync(newVivienda);

    public async Task UpdateAsync(Guid id, Vivienda updatedVivienda) =>
        await viviendasCollection.ReplaceOneAsync(x => x.Id == id, updatedVivienda);

    public async Task RemoveAsync(Guid id) =>
        await viviendasCollection.DeleteOneAsync(x => x.Id == id);
}