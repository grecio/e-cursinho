using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class CursoDto
    {
        public long IdCurso { get; set; }
        public string Curso { get; set; }
        public string Descricao { get; set; }
        public int Ano { get; set; }
        public decimal Valor { get; set; }
        public int Horas { get; set; }
        public int Parcelas { get; set; }
        public DateTime? DataInc { get; set; }
        public long IdUsuarioInc { get; set; }
        public DateTime? DataUpd { get; set; }
        public long IdUsuarioUpd { get; set; }

    }
}
