using Canducci.MongoDB.Repository;

namespace AndreAirlineApi2.Data.Repositorios
{
    public sealed class RepositorioPassagem : RepositorioPassagemImplementation
    {
        public RepositorioPassagem(IConnect connect) : base(connect)
        {

        }
    }
}
