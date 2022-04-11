using Canducci.MongoDB.Repository;

namespace AndreAirlineApi2.Data.Repositorios
{
    public sealed class RepositorioVoo : RepositorioVooImplementation
    {
        public RepositorioVoo(IConnect connect) : base(connect)
        {

        }
    }
}
