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

    public async Task<Trinos?> GetTrinosById(Guid id) =>
        await trinosCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task<List<Trinos>> GetTrinosPorUsuario(string email) =>
        await trinosCollection.Find(x => x.Autor.Equals(email)).ToListAsync();

    public async Task<List<Trinos>> GetTrinosPorTema(string tema) =>
        await trinosCollection.Find(x => x.Post.Equals(tema)).ToListAsync();

    public async Task<List<Trinos>> GetTrinosSeguidos(string email) =>
        await trinosCollection.Find(x => x.Autor.Equals(email)).SortByDescending(x => x.Stamp).ToListAsync();

    public async Task<List<Trinos>> GetTrinosCercanos(double lat, double lon) =>
        await trinosCollection.Find(x => x.Lat == lat).SortByDescending(x => x.Stamp).ToListAsync();

    //public async Task<List<Trinos>> GetViviendasByLocalidad(string localidad) =>
    //    await viviendasCollection.Find(x => x.Localidad == localidad).ToListAsync();

    //public async Task<Trinos?> GetViviendasByPropietario(Guid id) =>
    //    await viviendasCollection.Find(x => x.Propietario.Equals(id)).FirstOrDefaultAsync();

    public async Task CreateTrinos(Trinos newTrinos) =>
        await trinosCollection.InsertOneAsync(newTrinos);

    public async Task UpdateTrinos(Guid id, Trinos updatedTrinos) =>
        await trinosCollection.ReplaceOneAsync(x => x.Id == id, updatedTrinos);

    public async Task RemoveTrinos(Guid id) =>
        await trinosCollection.DeleteOneAsync(x => x.Id == id);
}