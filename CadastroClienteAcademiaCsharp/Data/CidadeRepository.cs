using CadastroClienteAcademiaCsharp.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CadastroClienteAcademiaCsharp.Data
{
    public class CidadeRepository
    {
        public IEnumerable<Cidade> GetCidades()
        {
            using (EntityContext context = new EntityContext())
            {
                return context.Cidade.OrderBy(cidade => cidade.Nome).ToList();
            }
        }

        public IEnumerable<Cidade> GetCidadesByNome(string nome)
        {
            using (EntityContext context = new EntityContext())
            {
                return context.Cidade
                    .Where(cidade => cidade.Nome.Contains(nome))
                    .OrderBy(cidade => cidade.Nome)
                    .ToList();
            }

        }
    }
}
