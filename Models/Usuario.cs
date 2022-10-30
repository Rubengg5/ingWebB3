using MongoDB.Bson.Serialization.Attributes;

namespace WebAPI.Models
{
    public class Usuario
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
    }
}
