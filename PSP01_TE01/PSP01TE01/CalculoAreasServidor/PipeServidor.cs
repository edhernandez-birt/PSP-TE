using System;
using System.IO;
using System.IO.Pipes;
using System.Threading.Tasks;

namespace CalculoAreasServidor
{
    class PipeServidor
    {
        static void Main(string[] args)
        {
            try
            { //Arrancamos el PipeServidor
                var server = new NamedPipeServerStream("PSP01_UD01TE01_Pipes");
                server.WaitForConnection();
                Console.WriteLine("Conexión a servidor establecida.");
                Console.WriteLine("Pipe Servidor esperando datos.");
                //Creamos flujos de lectura y escritura
                StreamReader reader = new StreamReader(server);
                StreamWriter writer = new StreamWriter(server);
                while (true)
                {
                    //Leemos lo que envía el cliente
                    var datosEntrada = reader.ReadLine();
                    //Si no es null procesamos datos para hacer el cálculo
                    if (datosEntrada != null)
                    {
                        Console.WriteLine("Pipe Servidor procesando datos: '{0}'", datosEntrada);
                        float resultado = ProcesaOperdador(datosEntrada);
                        //Enviamos resultado al cliente
                        writer.WriteLine(resultado.ToString());
                        Console.WriteLine("Pipe Servidor datos enviados: '{0}'", resultado);
                        //Limpiamos buffer de escritura
                        writer.Flush();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}  Apangado servidor por error", e.Message);
            }
        }

        /// <summary>
        /// Procesamos el operador. 0 Círculo 3 Triangulo 4 Rectangulo 5 Pentágono
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static float ProcesaOperdador(string operador)
        {
            float resultado = 0;
            float op1;
            float op2;
            string[] datOperador = operador.Split(' ');
            //No debería pasar, los datos llegan controlados desde el cliente
            if (!Single.TryParse(datOperador[1], out op1))
            {
                Console.WriteLine("No se puede parsear a numero el operando 1 '{0}'.", op1);
            }
            if (!Single.TryParse(datOperador[2], out op2))
            {
                Console.WriteLine("No se puede parsear a numero el operando 2 '{0}'.", op2);
            }

            if ("0".Equals(datOperador[0]))
            {
                Console.WriteLine("Pipe Servidor operación circulo de radio: '{0}'", op1);
                resultado = (float)(op1 * op1 * Math.PI);

            }
            else if ("3".Equals(datOperador[0]))
            {
                Console.WriteLine("Pipe Servidor triángulo de base '{0}' y altura '{1}'", op1, op2);
                resultado = op1 * op2 / 2;

            }
            else if ("4".Equals(datOperador[0]))
            {
                Console.WriteLine("Pipe Servidor rectángulo de base '{0}' y altura '{1}'", op1, op2);
                resultado = op1 * op2;
            }
            else if ("5".Equals(datOperador[0]))
            {
                Console.WriteLine("Pipe Servidor pentágono de lado '{0}' y apotema '{1}'", op1, op2);
                resultado = 5 * op1 * op2 / 2;
            }
            return resultado;
        }
    }
}
