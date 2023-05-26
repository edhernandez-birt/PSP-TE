using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSP03_PPT
{
    public class PartidaServidor
    {
        private const int MAX_PARTICIPANTES = 2;
        private int numJugadas = 0;
        private string[] participantes;
        private int[] puntuacion;
        private int numParticipantes = 0;
        private string ultimoGanador = string.Empty;
        private string[] partidaActual;


        public PartidaServidor()
        {
            this.participantes = new string[MAX_PARTICIPANTES];
            this.puntuacion = new int[MAX_PARTICIPANTES];
            this.partidaActual = new string[MAX_PARTICIPANTES];
            for (int i = 0; i < this.participantes.Length; i++)
            {
                this.participantes[i] = string.Empty;
                this.puntuacion[i] = 0;
                this.partidaActual[i] = string.Empty;
            }
        }
        public void setParticipante(string identificador)
        {
            this.participantes[this.numParticipantes] = identificador;
            this.numParticipantes++;
        }
        public int getPuntuacion(int id)
        {
            return puntuacion[id];
        }
        public void sumaPunto(int id)
        {
            this.puntuacion[id]++;
        }

        public void setPartidaActual(string jugada, int id)
        {
            this.partidaActual[id] = jugada;
        }

        public string getPartidaActual(int id)
        {
            return partidaActual[id];
        }

        public string getParticipante(int id)
        {
            return participantes[id];
        }
        public int getNumParticipantes()
        {
            return this.numParticipantes;
        }
        //public void sumaParticipante()
        //{
        //    this.numParticipantes++;
        //}
        public int getJugadasTotales()
        {
            return this.numJugadas;
        }
        public void sumaJugada()
        {
            this.numJugadas++;
        }
        public int getIdentificador(string nombre)
        {
            for (int i = 0; i < this.participantes.Length; i++)
            {
                if (nombre.Equals(participantes[i]))
                {
                    return i;
                }
            }
            return -1;

        }
        public string getUltimoGanador()
        {
            return ultimoGanador;
        }

        public void setUltimoGanador(string ganador)
        {
            this.ultimoGanador = ganador;
        }
    }
}
