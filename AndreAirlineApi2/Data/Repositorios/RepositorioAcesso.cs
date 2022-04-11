using Canducci.MongoDB.Repository;

namespace AndreAirlineApi2.Data.Repositorios
{
    public sealed class RepositorioAcesso : RepositorioAcessoImplementation
    {
        public RepositorioAcesso(IConnect connect) : base(connect)
        {

        }
    }
}
