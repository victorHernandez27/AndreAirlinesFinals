using Canducci.MongoDB.Repository;

namespace AndreAirlineApi2.Data.Repositorios
{
    public sealed class RepositorioPassageiro : RepositorioPassageiroImplementation
    {
        public RepositorioPassageiro(IConnect connect) : base(connect)
        {

        }
    }
}
