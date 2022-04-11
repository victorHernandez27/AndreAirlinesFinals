using AndreAirlineApi2.Model;
using Canducci.MongoDB.Repository;

namespace AndreAirlineApi2.Data.Repositorios
{
    public abstract class RepositorioAeroportoImplementation : Repository<Aeroporto>
    {
        public RepositorioAeroportoImplementation(IConnect connect) : base(connect)
        {

        }
    }
}
