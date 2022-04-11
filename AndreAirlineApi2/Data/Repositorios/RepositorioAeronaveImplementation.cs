using AndreAirlineApi2.Model;
using Canducci.MongoDB.Repository;

namespace AndreAirlineApi2.Data.Repositorios
{
    public abstract class RepositorioAeronaveImplementation : Repository<Aeronave>
    {
        public RepositorioAeronaveImplementation(IConnect connect) : base(connect)
        {

        }
    }
}
