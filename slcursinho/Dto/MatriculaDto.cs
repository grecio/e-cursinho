using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class MatriculaDto
    {
        public long IdMatricula { get; set; }
        public string NumeroMatricula { get; set; }
        public long IdTurma { get; set; }
        public string Turma { get; set; }
        public long IdAluno { get; set; }
        public string NomeAluno { get; set; }
    }
}
