using Canducci.MongoDB.Repository;

namespace AndreAirlineApi2.Data.Repositorios
{
    public sealed class RepositorioAeronave : RepositorioAeronaveImplementation
    {
        public RepositorioAeronave(IConnect connect) : base(connect)
        {

        }
    }
}
