using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Instrutor
    {
        public long IdInstrutor { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataExc { get => DateTime.Now; }
        public long IdUsuario { get; set; }
    }
}
