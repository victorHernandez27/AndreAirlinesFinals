using AndreAirlineApi2.Model;
using Canducci.MongoDB.Repository;

namespace AndreAirlineApi2.Data.Repositorios
{
    public abstract class RepositorioEnderecoImplementation : Repository<Endereco>
    {
        public RepositorioEnderecoImplementation(IConnect connect) : base(connect)
        {

        }
    }
}
