using MongoDB.Bson.Serialization.Attributes;

namespace AndreAirlineApi2.Model
{
    public abstract class Pessoa
    {
        [BsonId]
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string DataNasc { get; set; }
        public string Email { get; set; }
        public Endereco Endereco { get; set; }
        public string LoginUser { get; set; }
    }
}
