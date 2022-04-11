using Canducci.MongoDB.Repository.Attributes;

namespace AndreAirlineApi2.Model
{
    [BsonCollectionName("passageiros")]
    public class Passageiro : Pessoa
    {
        public string CodPassaporte { get; set; }
    }
}
