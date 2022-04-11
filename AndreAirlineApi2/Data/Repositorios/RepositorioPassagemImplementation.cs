using AndreAirlineApi2.Model;
using Canducci.MongoDB.Repository;

namespace AndreAirlineApi2.Data.Repositorios
{
    public abstract class RepositorioPassagemImplementation : Repository<Passagem>
    {
        public RepositorioPassagemImplementation(IConnect connect) : base(connect)
        {

        }
    }
}
