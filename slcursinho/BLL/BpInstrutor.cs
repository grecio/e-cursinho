using Dal;
using Domain;
using Dto;
using Framework.Concerns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BpInstrutor
    {
        private readonly DbInstrutor dbinstrutor;

        public BpInstrutor()
        {
            dbinstrutor = new DbInstrutor();
        }

        public IEnumerable<InstrutorDto> Listar()
        {
            return dbinstrutor.Listar();

        }

        public InstrutorDto Selecionar(long id)
        {
            Validador.Validar(id > 0, "Informe um instrutor.");

            return dbinstrutor.Selecionar(id);
        }

        public bool Salvar(Instrutor instrutor)
        {
            Validador.Validar(!string.IsNullOrWhiteSpace(instrutor.Nome), "Informe o nome do instrutor.");
         
            if (instrutor.IdInstrutor == 0)
            {
                if (dbinstrutor.Listar().Any(item =>
                    item.Instrutor.ToLowerInvariant().Equals(instrutor.Nome.ToLowerInvariant())))
                {
                    Validador.Validar(false, "Já existe um instrutor cadastrado com o nome informado.");
                }
            }
            else
            {
                if (dbinstrutor.Listar().Any(item =>
                    item.Instrutor.ToLowerInvariant().Equals(instrutor.Nome.ToLowerInvariant()) &&
                    item.IdInstrutor != instrutor.IdInstrutor))
                {
                    Validador.Validar(false, "Já existe um instrutor cadastrado com o nome informado.");
                }
            }

            return dbinstrutor.Salvar(instrutor);
        }

        public bool Excluir(long id)
        {
            Validador.Validar(id > 0, "Informe um instrutor.");
            return dbinstrutor.Excluir(id);
        }
    }
}
