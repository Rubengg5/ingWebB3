using WebAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace WebAPI.Services;

public class SigueMeService
{
    private readonly IMongoCollection<SigueMe> sigueMeCollection;

    public SigueMeService(
        IOptions<iwebDatabaseSettings> iwebDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            iwebDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            iwebDatabaseSettings.Value.DatabaseName);

        sigueMeCollection = mongoDatabase.GetCollection<SigueMe>(
            iwebDatabaseSettings.Value.SigueMeCollectionName);
    }

    public async Task<List<SigueMe>> GetSigueMe() =>
        await sigueMeCollection.Find(_ => true).ToListAsync();

    public async Task<SigueMe?> GetSigueMeById(Guid id) =>
        await sigueMeCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateSigueMe(SigueMe newSigueMe) =>
    await sigueMeCollection.InsertOneAsync(newSigueMe);

    public async Task UpdateSigueMe(Guid id, SigueMe updatedSigueMe) =>
        await sigueMeCollection.ReplaceOneAsync(x => x.Id == id, updatedSigueMe);

    public async Task RemoveSigueMe(Guid id) =>
        await sigueMeCollection.DeleteOneAsync(x => x.Id == id);

    //public async Task<List<SigueMe>> GetSigueMeByFecha(string fechaEntrada, string fechaSalida) =>
    //    await sigueMeCollection.Find(x => x.FechaEntrada == fechaEntrada && x.FechaSalida == fechaSalida).ToListAsync();

    //public async Task<List<SigueMe>> GetReservasByVivienda(Guid idVivienda) =>
    //    await sigueMeCollection.Find(x => x.IdVivienda == idVivienda).ToListAsync();

    //public async Task<SigueMe?> GetReservaByInquilinoId(Guid inquilino) =>
    //    await sigueMeCollection.Find(x => x.Inquilino.Equals(inquilino)).FirstOrDefaultAsync();

}