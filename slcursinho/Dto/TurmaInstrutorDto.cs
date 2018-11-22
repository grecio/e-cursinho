using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class TurmaInstrutorDto
    {
        public long IdTurmaInstrutor { get; set; }
        public long IdTurma { get; set; }
        public long IdInstrutor { get; set; }
        public string NomeInstrutor { get; set; }
    }
}
