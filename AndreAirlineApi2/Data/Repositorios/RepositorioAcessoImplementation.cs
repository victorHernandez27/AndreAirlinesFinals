using AndreAirlineApi2.Model;
using Canducci.MongoDB.Repository;

namespace AndreAirlineApi2.Data.Repositorios
{
    public abstract class RepositorioAcessoImplementation : Repository<Acesso>
    {
        public RepositorioAcessoImplementation(IConnect connect) : base(connect)
        {

        }
    }
}
