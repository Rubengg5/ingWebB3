using WebAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Linq;

namespace WebAPI.Services;

public class MensajesService
{
    private readonly IMongoCollection<Mensaje> mensajesCollection;

    public MensajesService(
        IOptions<iwebDatabaseSettings> iwebDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            iwebDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            iwebDatabaseSettings.Value.DatabaseName);

        mensajesCollection = mongoDatabase.GetCollection<Mensaje>(
            iwebDatabaseSettings.Value.MensajesCollectionName);
    }

    public async Task<List<Mensaje>> GetMensajes() =>
        await mensajesCollection.Find(_ => true).ToListAsync();

    public async Task<Mensaje?> GetMensajesById(Guid id) =>
        await mensajesCollection.Find(x => x.Identificador == id).FirstOrDefaultAsync();

    public async Task CreateMensaje(Mensaje newMensaje) =>
    await mensajesCollection.InsertOneAsync(newMensaje);

    public async Task UpdateMensaje(Guid id, Mensaje updatedMensaje) =>
        await mensajesCollection.ReplaceOneAsync(x => x.Identificador == id, updatedMensaje);

    public async Task RemoveMensaje(Guid id) =>
        await mensajesCollection.DeleteOneAsync(x => x.Identificador == id);

    //public async Task<List<SigueMe>> GetSigueMeByFecha(string fechaEntrada, string fechaSalida) =>
    //    await sigueMeCollection.Find(x => x.FechaEntrada == fechaEntrada && x.FechaSalida == fechaSalida).ToListAsync();

    //public async Task<List<SigueMe>> GetReservasByVivienda(Guid idVivienda) =>
    //    await sigueMeCollection.Find(x => x.IdVivienda == idVivienda).ToListAsync();

    //public async Task<SigueMe?> GetReservaByInquilinoId(Guid inquilino) =>
    //    await sigueMeCollection.Find(x => x.Inquilino.Equals(inquilino)).FirstOrDefaultAsync();

    //lat > lat-0.1 && lat < lat+0.1 && lon > lon-0.1 && lon < lon+0.1

    //public async Task<List<string>> GetSeguidoresAsync(string email) 
    //{ 
    //    List<SigueMe> sigueMes = await mensajesCollection.Find(x => x.Seguido.Equals(email)).ToListAsync();
    //    List<string> seguidores = sigueMes.Select(x => x.Seguidor).ToList();
    //    return seguidores;
    //}

    //public Task<List<string>> GetSeguidores(string email)
    //{
    //    List<string> seguidores = mensajesCollection.Find(x => x.Seguido.Equals(email)).ToList().Select(x => x.Seguidor).ToList();
    //    return Task.FromResult(seguidores);
    //}

}