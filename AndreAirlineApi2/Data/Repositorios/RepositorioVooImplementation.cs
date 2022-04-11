using AndreAirlineApi2.Model;
using Canducci.MongoDB.Repository;

namespace AndreAirlineApi2.Data.Repositorios
{
    public abstract class RepositorioVooImplementation : Repository<Voo>
    {
        public RepositorioVooImplementation(IConnect connect) : base(connect)
        {

        }
    }
}
