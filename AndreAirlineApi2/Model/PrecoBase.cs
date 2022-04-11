using Canducci.MongoDB.Repository.Attributes;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace AndreAirlineApi2.Model
{
    [BsonCollectionName("precosbase")]
    public class PrecoBase
    {
        [BsonId]
        public string Id { get; set; }
        public virtual Aeroporto Origem { get; set; }
        public virtual Aeroporto Destino { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataInclusao { get; set; }
        public string LoginUser { get; set; }
    }
}
