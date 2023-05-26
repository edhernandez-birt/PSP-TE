using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSP03_PPT
{
    public class PartidaCliente
    {
        private string identificador = String.Empty;

        public PartidaCliente()
        {
        }

        public void setIdentificador(string identificador)
        {
            this.identificador = identificador;
        }

        public string getIdentificador() { 
            return this.identificador;
        }

    }
}
