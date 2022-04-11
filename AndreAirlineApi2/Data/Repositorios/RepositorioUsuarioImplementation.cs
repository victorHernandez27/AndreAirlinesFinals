using AndreAirlineApi2.Model;
using Canducci.MongoDB.Repository;

namespace AndreAirlineApi2.Data.Repositorios
{
    public abstract class RepositorioUsuarioImplementation : Repository<Usuario>
    {
        public RepositorioUsuarioImplementation(IConnect connect) : base(connect)
        {

        }
    }
}
