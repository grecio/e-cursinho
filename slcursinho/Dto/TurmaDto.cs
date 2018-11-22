using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class TurmaDto
    {
        public long IdTurma { get; set; }
        public long IdCurso { get; set; }
        public string Curso { get; set; }
        public long IdTurmaStatus { get; set; }
        public string TurmaStatus { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int Capacidade { get; set; }
    }
}
