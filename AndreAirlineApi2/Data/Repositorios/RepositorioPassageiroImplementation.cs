using AndreAirlineApi2.Model;
using Canducci.MongoDB.Repository;

namespace AndreAirlineApi2.Data.Repositorios
{
    public abstract class RepositorioPassageiroImplementation : Repository<Passageiro>
    {
        public RepositorioPassageiroImplementation(IConnect connect) : base(connect)
        {

        }
    }
}
