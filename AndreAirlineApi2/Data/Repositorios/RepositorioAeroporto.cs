using Canducci.MongoDB.Repository;

namespace AndreAirlineApi2.Data.Repositorios
{
    public sealed class RepositorioAeroporto : RepositorioAeroportoImplementation
    {
        public RepositorioAeroporto(IConnect connect) : base(connect)
        {

        }
    }
}
