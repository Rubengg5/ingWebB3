using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class SigueMe
    {
        public string Seguidor { get; set; }
        public string Seguido { get; set; }
    }

}
