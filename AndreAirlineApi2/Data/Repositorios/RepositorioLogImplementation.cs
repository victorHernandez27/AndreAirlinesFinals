using AndreAirlineApi2.Model;
using Canducci.MongoDB.Repository;

namespace AndreAirlineApi2.Data.Repositorios
{
    public abstract class RepositorioLogImplementation : Repository<Log>
    {
        public RepositorioLogImplementation(IConnect connect) : base(connect)
        {

        }
    }
}
