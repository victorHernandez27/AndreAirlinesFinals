using Canducci.MongoDB.Repository.Attributes;
using MongoDB.Bson.Serialization.Attributes;

namespace AndreAirlineApi2.Model
{
    [BsonCollectionName("acessos")]
    public class Acesso
    {
        [BsonId]
        public string Id { get; set; }
        public string Descricao { get; set; }
    }
}
