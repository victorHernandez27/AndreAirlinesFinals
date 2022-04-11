using Canducci.MongoDB.Repository.Attributes;
using MongoDB.Bson.Serialization.Attributes;

namespace AndreAirlineApi2.Model
{
    [BsonCollectionName("classes")]
    public class Classe
    {
        [BsonId]
        public string Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
    }
}
