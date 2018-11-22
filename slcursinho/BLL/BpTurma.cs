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
    public class BpTurma
    {
        private readonly DbTurma db;

        public BpTurma()
        {
            db = new DbTurma();
        }

        public IEnumerable<TurmaDto> Listar()
        {
            return db.Listar();
        }

        public bool Salvar(Turma turma)
        {
            Validador.Validar(!string.IsNullOrWhiteSpace(turma.Descricao), "Informe a turma.");
            Validador.Validar(turma.IdCurso > 0, "Informe o curso");

            Validador.Validar(turma.DataInicio != DateTime.MinValue, "Informe a data de início.");
            Validador.Validar(turma.DataFim != DateTime.MinValue, "Informe a data de término.");
            Validador.Validar(turma.Capacidade > 0, "Informe a quantidade máxima de vagas");

            return db.Salvar(turma);
        }

        public bool Excluir(long id)
        {

            Validador.Validar(id > 0, "Informe a turma.");

            return db.Excluir(id);
        }
    }
}
