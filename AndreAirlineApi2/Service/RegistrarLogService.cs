using AndreAirlineApi2.Data.Repositorios;
using AndreAirlineApi2.Model;
using System;

namespace AndreAirlineApi2.Service
{
    public class RegistrarLogService
    {
        private readonly RepositorioLogImplementation _respositoyLog;

        public RegistrarLogService(RepositorioLogImplementation respositoyLog)
        {
            _respositoyLog = respositoyLog;
        }

        public void RegistrarLog(object entidadeAntes, object entidadeDepois, string operacao)
        {
            var log = new Log
            {
                Id = Guid.NewGuid().ToString(),
                Usuario = null,
                Data = DateTime.Now,
                EntidadeAntes = entidadeAntes,
                EntidadeDepois = entidadeDepois,
                Operacao = operacao
            };

            _respositoyLog.Add(log);
        }
    }
}
