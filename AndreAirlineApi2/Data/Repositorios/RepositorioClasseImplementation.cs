using AndreAirlineApi2.Model;
using Canducci.MongoDB.Repository;

namespace AndreAirlineApi2.Data.Repositorios
{
    public abstract class RepositorioClasseImplementation : Repository<Classe>
    {
        public RepositorioClasseImplementation(IConnect connect) : base(connect)
        {

        }
    }
}
