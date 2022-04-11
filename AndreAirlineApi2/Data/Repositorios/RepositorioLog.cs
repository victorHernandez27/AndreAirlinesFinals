using Canducci.MongoDB.Repository;

namespace AndreAirlineApi2.Data.Repositorios
{
    public sealed class RepositorioLog : RepositorioLogImplementation
    {
        public RepositorioLog(IConnect connect) : base(connect)
        {

        }
    }
}
