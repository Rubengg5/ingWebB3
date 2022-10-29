using WebAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace WebAPI.Services;

public class ReservasService
{
    private readonly IMongoCollection<Reserva> reservasCollection;

    public ReservasService(
        IOptions<iwebDatabaseSettings> iwebDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            iwebDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            iwebDatabaseSettings.Value.DatabaseName);

        reservasCollection = mongoDatabase.GetCollection<Reserva>(
            iwebDatabaseSettings.Value.ReservasCollectionName);
    }

    public async Task<List<Reserva>> GetAsync() =>
        await reservasCollection.Find(_ => true).ToListAsync();

    public async Task<Reserva?> GetAsync(Guid id) =>
        await reservasCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Reserva newReserva) =>
        await reservasCollection.InsertOneAsync(newReserva);

    public async Task UpdateAsync(Guid id, Reserva updatedReserva) =>
        await reservasCollection.ReplaceOneAsync(x => x.Id == id, updatedReserva);

    public async Task RemoveAsync(Guid id) =>
        await reservasCollection.DeleteOneAsync(x => x.Id == id);
}