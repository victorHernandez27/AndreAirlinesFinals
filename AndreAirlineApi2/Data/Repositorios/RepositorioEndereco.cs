using Canducci.MongoDB.Repository;

namespace AndreAirlineApi2.Data.Repositorios
{
    public sealed class RepositorioEndereco : RepositorioEnderecoImplementation
    {
        public RepositorioEndereco(IConnect connect) : base(connect)
        {

        }
    }
}
