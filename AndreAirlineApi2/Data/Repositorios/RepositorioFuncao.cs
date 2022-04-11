using Canducci.MongoDB.Repository;

namespace AndreAirlineApi2.Data.Repositorios
{
    public sealed class RepositorioFuncao : RepositorioFuncaoImplementation
    {
        public RepositorioFuncao(IConnect connect) : base(connect)
        {

        }
    }
}
