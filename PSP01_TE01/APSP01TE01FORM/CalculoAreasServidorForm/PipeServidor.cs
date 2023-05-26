using System;
using System.IO;
using System.IO.Pipes;
using System.Threading.Tasks;

namespace CalculoAreasServidorForm
{
    class PipeServidor
    {
        static void Main(string[] args)
        {
            try
            {
                var server = new NamedPipeServerStream("PSP01_UD01TE01_Pipes");
                server.WaitForConnection();
                Console.WriteLine("Conexión a servidor establecida.");
                Console.WriteLine("Pipe Servidor esperando datos.");
                StreamReader reader = new StreamReader(server);
                StreamWriter writer = new StreamWriter(server);
                while (true)
                {
                    var line = reader.ReadLine();
                    if (line != null)
                    {
                        Console.WriteLine("Pipe Servidor procesando datos: '{0}'", line);
                        float resultado = ProcesaOperdador(line);
                        writer.WriteLine(resultado.ToString());
                        Console.WriteLine("Pipe Servidor datos enviados: '{0}'", resultado);
                        writer.Flush();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}  Apangado servidor por error", e.Message);
            }
        }

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

            //Console.WriteLine("Pipe Servidor procesando datos: '{0} {1} {2}'", op1, datOperador[0], op2);

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
                Console.WriteLine("Pipe Servidor pentágono de perímetro '{0}' y apotema '{1}'", op1, op2);
                resultado = 5 * op1 * op2 / 2;
            }

            //else if ("^".Equals(datOperador[0]))
            //{
            //    resultado = 1;
            //    for (int i = 1; i <= op2; i++)
            //        resultado = resultado * op1;
            //}
            //Console.WriteLine("Ret: {0}", resultado);
            return resultado;
        }
    }
}
