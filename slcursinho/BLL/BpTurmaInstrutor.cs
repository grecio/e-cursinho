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
    public class BpTurmaInstrutor
    {
        private readonly DbTurmaInstrutor db;

        public BpTurmaInstrutor()
        {
            db = new DbTurmaInstrutor();
        }

        public IEnumerable<TurmaInstrutorDto> Listar(long idturma)
        {
            return db.Listar(idturma);
        }

        public bool Inserir(TurmaInstrutor model)
        {
            Validador.Validar(model.IdInstrutor > 0, "Informe o instrutor.");

            if (db.Listar(model.IdTurma).Any(item => item.IdInstrutor == model.IdInstrutor))
            {
                Validador.Validar(false, "Instrutor já inserido.");
            }

            return db.Inserir(model);
        }

        public bool Remover(long id)
        {
            Validador.Validar(id > 0, "Informe o instrutor.");

            return db.Remover(id);
        }
    }
}
