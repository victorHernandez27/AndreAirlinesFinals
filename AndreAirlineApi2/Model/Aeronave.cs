using Canducci.MongoDB.Repository.Attributes;
using MongoDB.Bson.Serialization.Attributes;

namespace AndreAirlineApi2.Model
{
    [BsonCollectionName("aeronaves")]
    public class Aeronave
    {
        [BsonId]
        public string Id { get; set; }
        public string Nome { get; set; }
        public int Capacidade { get; set; }
        public string LoginUser { get; set; }
    }
}
