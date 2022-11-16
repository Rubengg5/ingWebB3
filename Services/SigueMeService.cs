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

    //    public async Task<SigueMe?> GetReservaById(Guid id) =>
    //        await reservasCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    //    public async Task<List<SigueMe>> GetReservasByFecha(string fechaEntrada, string fechaSalida) =>
    //        await reservasCollection.Find(x => x.FechaEntrada == fechaEntrada && x.FechaSalida == fechaSalida).ToListAsync();

    //    public async Task<List<SigueMe>> GetReservasByVivienda(Guid idVivienda) =>
    //        await reservasCollection.Find(x => x.IdVivienda == idVivienda).ToListAsync();

    //    public async Task<SigueMe?> GetReservaByInquilinoId(Guid inquilino) =>
    //        await reservasCollection.Find(x => x.Inquilino.Equals(inquilino)).FirstOrDefaultAsync();

    //    public async Task CreateReserva(SigueMe newReserva) =>
    //        await reservasCollection.InsertOneAsync(newReserva);

    //    public async Task UpdateReserva(Guid id, SigueMe updatedReserva) =>
    //        await reservasCollection.ReplaceOneAsync(x => x.Id == id, updatedReserva);

    //    public async Task RemoveReserva(Guid id) =>
    //        await reservasCollection.DeleteOneAsync(x => x.Id == id);
}