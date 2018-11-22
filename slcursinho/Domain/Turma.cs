using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Turma
    {
        public long IdTurma { get; set; }
        public long IdCurso { get; set; }
        public long IdTurmaStatus { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int Capacidade { get; set; }
        public long IdUSuarioExc { get; set; }
        public DateTime DataExc { get => DateTime.Now; }
    }
}
