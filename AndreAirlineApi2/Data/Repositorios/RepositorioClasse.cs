using Canducci.MongoDB.Repository;

namespace AndreAirlineApi2.Data.Repositorios
{
    public sealed class RepositorioClasse : RepositorioClasseImplementation
    {
        public RepositorioClasse(IConnect connect) : base(connect)
        {

        }
    }
}
