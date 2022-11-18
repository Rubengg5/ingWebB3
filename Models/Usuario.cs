using MongoDB.Bson.Serialization.Attributes;

namespace WebAPI.Models
{
    public class Usuario
    {
        [BsonId]
        public int Telefono { get; set; }
        public string Alias { get; set; }
        public List<Usuario> Contactos { get; set; }
    }
}
