using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Trinos
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Autor { get; set; }
        public string Post { get; set; }
        public string Lat { get; set; }
        public int Lon { get; set; }
        public string Stamp { get; set; }
        public int Reposts { get; set; }

    }
}