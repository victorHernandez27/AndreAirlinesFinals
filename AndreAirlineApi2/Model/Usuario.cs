using Canducci.MongoDB.Repository.Attributes;

namespace AndreAirlineApi2.Model
{
    [BsonCollectionName("usuarios")]
    public class Usuario : Pessoa
    {
        public int Id { get; set; }
        public string Senha { get; set; }
        public string Login { get; set; }
        public string Setor { get; set; }
        public Funcao Funcao { get; set; }
    }
}
