using AndreAirlineApi2.Model;
using System.Collections.Generic;
using System.Linq;

namespace AndreAirlineApi2.Data.Repositorios
{
    public class UserRepository
    {
        public static Usuario Get(string login, string senha)
        {
            var users = new List<Usuario>
            {
                new Usuario { Id = 1, Login = "admin", Senha = "admin", Setor = "manager" },
                new Usuario { Id = 2, Login = "user", Senha = "user", Setor = "employee" }
            };

            return users.FirstOrDefault(x => x.Login.ToLower() == login.ToLower() && x.Senha == senha);
        }
    }
}
