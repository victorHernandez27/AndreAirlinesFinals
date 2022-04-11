using Canducci.MongoDB.Repository;

namespace AndreAirlineApi2.Data.Repositorios
{
    public sealed class RepositorioPrecoBase : RepositorioPrecoBaseImplementation
    {
        public RepositorioPrecoBase(IConnect connect) : base(connect)
        {

        }
    }
}
