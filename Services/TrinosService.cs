using WebAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace WebAPI.Services;

public class TrinosService
{
    private readonly IMongoCollection<Trinos> trinosCollection;

    public TrinosService(
        IOptions<iwebDatabaseSettings> iwebDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            iwebDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            iwebDatabaseSettings.Value.DatabaseName);

        trinosCollection = mongoDatabase.GetCollection<Trinos>(
            iwebDatabaseSettings.Value.TrinosCollectionName);
    }

    public async Task<List<Trinos>> GetTrinos() =>
        await trinosCollection.Find(_ => true).ToListAsync();

    //public async Task<Trinos?> GetViviendaById(Guid id) =>
    //    await viviendasCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    //public async Task<List<Trinos>> GetViviendasByLocalidad(string localidad) =>
    //    await viviendasCollection.Find(x => x.Localidad == localidad).ToListAsync();

    //public async Task<Trinos?> GetViviendasByPropietario(Guid id) =>
    //    await viviendasCollection.Find(x => x.Propietario.Equals(id)).FirstOrDefaultAsync();

    //public async Task CreateVivienda(Trinos newVivienda) =>
    //    await viviendasCollection.InsertOneAsync(newVivienda);

    //public async Task UpdateVivienda(Guid id, Trinos updatedVivienda) =>
    //    await viviendasCollection.ReplaceOneAsync(x => x.Id == id, updatedVivienda);

    //public async Task RemoveVivienda(Guid id) =>
    //    await viviendasCollection.DeleteOneAsync(x => x.Id == id);
}