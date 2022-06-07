using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaixaEletronico.APP.Models
{
    public class Final
    {
        public Final() {}

        public Final(int cedula, int quantidade)
        {
            this.cedula = cedula;
            this.quantidade = quantidade;
        }

        public int quantidade { get; set; }
        public int cedula { get; set; }
    }
}
