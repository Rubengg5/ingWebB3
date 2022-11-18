using WebAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Linq;

namespace WebAPI.Services;

public class UsuariosService
{
    private readonly IMongoCollection<Usuario> usuariosCollection;

    public UsuariosService(
        IOptions<iwebDatabaseSettings> iwebDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            iwebDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            iwebDatabaseSettings.Value.DatabaseName);

        usuariosCollection = mongoDatabase.GetCollection<Usuario>(
            iwebDatabaseSettings.Value.UsuariosCollectionName);
    }

    public async Task<List<Usuario>> GetUsuarios() =>
        await usuariosCollection.Find(_ => true).ToListAsync();


    public async Task<Usuario?> GetUsuariosByTelefono(int telefono) =>
        await usuariosCollection.Find(x => x.Telefono == telefono).FirstOrDefaultAsync();

    public async Task CreateUsuario(Usuario newUsuario) =>
        await usuariosCollection.InsertOneAsync(newUsuario);

    public async Task UpdateUsuario(int telefono, Usuario updatedUsuario) =>
        await usuariosCollection.ReplaceOneAsync(x => x.Telefono == telefono, updatedUsuario);

    public async Task RemoveUsuario(int telefono) =>
        await usuariosCollection.DeleteOneAsync(x => x.Telefono == telefono);

    public async Task<List<Usuario>> GetUsuarioPorAlias(string alias) =>
        await usuariosCollection.Find(x => x.Alias.Contains(alias)).ToListAsync();

    public async Task<List<Usuario>> GetContactos(int telefono) 
    {
        Usuario usuario = usuariosCollection.Find(x => x.Telefono == telefono).FirstOrDefault();
        return usuario.Contactos;
    }

    public async Task<Usuario?> GetContactoPorTelefono(int telefono, int telefonoContacto)
    {
        Usuario usuario = usuariosCollection.Find(x => x.Telefono == telefono).FirstOrDefault();
        return usuario.Contactos.Find(x => x.Telefono == telefonoContacto);
    }

    public async Task CreateContacto(int telefono, Usuario newContacto)
    {
        Usuario usuario = usuariosCollection.Find(x => x.Telefono == telefono).FirstOrDefault();
        var contactos = usuario.Contactos;
        contactos.Insert(0, new Usuario
        {
            Telefono = newContacto.Telefono,
            Alias = newContacto.Alias
        });
    }

    //public async Task UpdateUsuario(int telefono, Usuario updatedUsuario) =>
    //    await usuariosCollection.ReplaceOneAsync(x => x.Telefono == telefono, updatedUsuario);

    //public async Task RemoveUsuario(int telefono) =>
    //    await usuariosCollection.DeleteOneAsync(x => x.Telefono == telefono);

    //public async Task<Trinos?> GetUsuariosById(Guid id) =>
    //    await usuariosCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    //public async Task<List<Trinos>> GetTrinosPorUsuario(string email) =>
    //    await usuariosCollection.Find(x => x.Autor.Equals(email)).ToListAsync();



    //public async Task<List<Trinos>> GetTrinosSeguidos(string email) =>
    //    await usuariosCollection.Find(x => x.Autor.Equals(email)).SortByDescending(x => x.Stamp).ToListAsync();

    //public async Task<List<Trinos>> GetTrinosCercanos(double lat, double lon) =>
    //    await usuariosCollection.Find(x => x.Lat == lat).SortByDescending(x => x.Stamp).ToListAsync();

    //public async Task<List<Trinos>> GetTrinosPorFecha(DateTime date) =>
    //await usuariosCollection.Find(x => x.Stamp.Equals(date)).ToListAsync();

    ////public async Task<List<Trinos>> GetViviendasByLocalidad(string localidad) =>
    ////    await viviendasCollection.Find(x => x.Localidad == localidad).ToListAsync();

    ////public async Task<Trinos?> GetViviendasByPropietario(Guid id) =>
    ////    await viviendasCollection.Find(x => x.Propietario.Equals(id)).FirstOrDefaultAsync();

}