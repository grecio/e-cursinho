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
    public class BpTurmaHorario
    {
        private readonly DbTurmaHorario db;

        public BpTurmaHorario()
        {
            db = new DbTurmaHorario();
        }

        public IEnumerable<TurmaHorarioDto> Listar(long idturma)
        {
            return db.Listar(idturma);
        }

        public bool Inserir(TurmaHorario model)
        {

            Validador.Validar(!string.IsNullOrWhiteSpace(model.Dia), "Informe o dia da semana.");
            Validador.Validar(!string.IsNullOrWhiteSpace(model.HoraEntrada), "Informe a hora de entrada.");
            Validador.Validar(!string.IsNullOrWhiteSpace(model.HoraSaida), "Informe a hora de saída.");

         
            if (db.Listar(model.IdTurma).Any(item => item.Dia == model.Dia))
            {
                Validador.Validar(false, "Já existe um dia registrado.");
            }

            return db.Inserir(model);
        }

        public bool Remover(long id)
        {
            Validador.Validar(id > 0, "Informe o identificador do horário.");

            return db.Remover(id);
        }
    }
}
