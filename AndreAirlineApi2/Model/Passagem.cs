using Canducci.MongoDB.Repository.Attributes;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace AndreAirlineApi2.Model
{
    [BsonCollectionName("passagens")]
    public class Passagem
    {
        [BsonId]
        public string Id { get; set; }
        public virtual Voo Voo { get; set; }
        public virtual Passageiro Passageiro { get; set; }
        public virtual PrecoBase PrecoBase { get; set; }
        public virtual Classe Classe { get; set; }
        public DateTime DataCadastro { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal PromocaoPorcentagem { get; set; }
        public string LoginUser { get; set; }
    }
}
