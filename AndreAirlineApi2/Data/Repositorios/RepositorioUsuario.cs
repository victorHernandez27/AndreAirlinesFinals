using Canducci.MongoDB.Repository;

namespace AndreAirlineApi2.Data.Repositorios
{
    public sealed class RepositorioUsuario : RepositorioUsuarioImplementation
    {
        public RepositorioUsuario(IConnect connect) : base(connect)
        {

        }
    }
}
