using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class TurmaHorario
    {
        public long IdTurmaHorario { get; set; }
        public long IdTurma { get; set; }
        public string Dia { get; set; }
        public string HoraEntrada { get; set; }
        public string HoraSaida { get; set; }
    }
}
