using AndreAirlineApi2.Model;
using Canducci.MongoDB.Repository;

namespace AndreAirlineApi2.Data.Repositorios
{
    public abstract class RepositorioFuncaoImplementation : Repository<Funcao>
    {
        public RepositorioFuncaoImplementation(IConnect connect) : base(connect)
        {

        }
    }
}
