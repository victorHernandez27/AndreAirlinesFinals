using Canducci.MongoDB.Repository.Attributes;
using MongoDB.Bson.Serialization.Attributes;

namespace AndreAirlineApi2.Model
{
    [BsonCollectionName("aeroportos")]
    public class Aeroporto
    {
        [BsonId]
        public string Sigla { get; set; }
        public string Nome { get; set; }
        public virtual Endereco Endereco { get; set; }
        public string LoginUser { get; set; }
    }
}
