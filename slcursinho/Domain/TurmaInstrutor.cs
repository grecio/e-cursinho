using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class TurmaInstrutor
    {
        public long IdTurmaInstrutor { get; set; }
        public long IdTurma { get; set; }
        public long IdInstrutor { get; set; }
    }
}
