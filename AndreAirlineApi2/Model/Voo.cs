using Canducci.MongoDB.Repository.Attributes;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace AndreAirlineApi2.Model
{
    [BsonCollectionName("voos")]
    public class Voo
    {
        [BsonId]
        public string Id { get; set; }
        public virtual Aeroporto Destino { get; set; }
        public virtual Aeroporto Origem { get; set; }
        public virtual Aeronave Aeronave { get; set; }
        public DateTime HorarioEmbarque { get; set; }
        public DateTime HorarioDesembarque { get; set; }
        public string LoginUser { get; set; }
    }
}
