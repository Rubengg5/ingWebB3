using MongoDB.Bson.Serialization.Attributes;

namespace WebAPI.Models
{
    public class Mensaje
    {
        [BsonId]
        public Guid Identificador { get; set; }
        public DateTime Timestamp { get; set; }
        public int Origen { get; set; }
        public int Destino { get; set; }
        public string Texto { get; set; }
    }
}
