using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Matricula
    {
        public long IdMatricula { get; set; }
        public string NumeroMatricula { get; set; }
        public string NumeroContrato { get; set; }
        public bool Responsavel { get; set; }
        public string NomeRespAluno { get; set; }
        public string CpfRespAluno { get; set; }
    }

    public class AlunoResponsavel
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
    }
}
