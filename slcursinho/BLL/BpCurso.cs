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
    public class BpCurso
    {
        private readonly DbCurso dbcurso;

        public BpCurso()
        {
            dbcurso = new DbCurso();
        }

        public IEnumerable<CursoDto> Listar()
        {
            return dbcurso.Listar();
               
        }

        public CursoDto Selecionar(long id)
        {
            Validador.Validar(id > 0, "Informe um curso.");

            return dbcurso.Selecionar(id);
        }

        public bool Salvar(Curso curso)
        {
            Validador.Validar(!string.IsNullOrWhiteSpace(curso.Nome), "Informe o nome do curso.");
            Validador.Validar(!string.IsNullOrWhiteSpace(curso.Descricao), "Informe a descrição do curso.");
            Validador.Validar(curso.Ano > 0, "Informe o ano do curso.");
            Validador.Validar(curso.Valor > 0, "Informe o valor do curso.");

            if (curso.IdCurso == 0)
            {
                if (dbcurso.Listar().Any(item =>
                    item.Curso.ToLowerInvariant().Equals(curso.Nome.ToLowerInvariant()) && item.Ano == curso.Ano))
                {
                    Validador.Validar(false, "Já existe um curso cadastrado com o nome e ano informados.");
                }
            }
            else
            {
                if (dbcurso.Listar().Any(item =>
                    item.Curso.ToLowerInvariant().Equals(curso.Nome.ToLowerInvariant()) &&
                    item.IdCurso != curso.IdCurso))
                {
                    Validador.Validar(false, "Já existe um curso cadastrado com o nome e ano informados.");
                }
            }

            return dbcurso.Salvar(curso);
        }

        public bool Excluir(long id)
        {
            Validador.Validar(id > 0, "Informe um curso.");
            return dbcurso.Excluir(id);
        }
    }
}
