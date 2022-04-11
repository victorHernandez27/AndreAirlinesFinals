using AndreAirlineApi2.Model;
using Canducci.MongoDB.Repository;

namespace AndreAirlineApi2.Data.Repositorios
{
    public abstract class RepositorioPrecoBaseImplementation : Repository<PrecoBase>
    {
        public RepositorioPrecoBaseImplementation(IConnect connect) : base(connect)
        {

        }
    }
}
