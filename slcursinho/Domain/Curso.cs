using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Curso
    {
        public long IdCurso { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Ano { get; set; }
        public decimal Valor { get; set; }
        public int Horas { get; set; }
        public int Parcelas { get; set; }
        public DateTime DataExc { get => DateTime.Now; }
        public long IdUsuario { get; set; }

    }
}
