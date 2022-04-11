using Canducci.MongoDB.Repository.Attributes;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace AndreAirlineApi2.Model
{
    [BsonCollectionName("funcoes")]
    public class Funcao
    {
        [BsonId]
        public string Id { get; set; }
        public string Descricao { get; set; }
        public List<Acesso> Acessos { get; set; }
    }
}
