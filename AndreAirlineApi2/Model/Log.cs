using Canducci.MongoDB.Repository.Attributes;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace AndreAirlineApi2.Model
{
    [BsonCollectionName("logs")]
    public class Log
    {
        [BsonId]
        public string Id { get; set; }
        public Usuario Usuario { get; set; }
        public object EntidadeAntes { get; set; }
        public object EntidadeDepois { get; set; }
        public string Operacao { get; set; }
        public DateTime Data { get; set; }
    }
}
