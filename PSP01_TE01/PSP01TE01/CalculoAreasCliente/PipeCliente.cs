using System.Diagnostics;
using System.IO.Pipes;


namespace CalculoAreasCliente
{
    class PipeCliente
    {

        static void Main(string[] args)
        {
            Process p;
            StartServer(out p);
            Task.Delay(1000).Wait();
            string? operacion;

            //Preparar conexion del cliente
            var client = new NamedPipeClientStream("PSP01_UD01TE01_Pipes");
            Console.WriteLine("Conectando al servidor...");
            client.Connect();
            StreamReader reader = new StreamReader(client);
            StreamWriter writer = new StreamWriter(client);

            while (true)
            {
                operacion = "";
                PintarMenu(ref operacion);
                //Console.WriteLine(" operaccion: " + operacion);

                if (operacion != null)
                {
                    if ("E".Equals(operacion))
                    {
                        // Salir del while (true)
                        break;
                    }
                    writer.WriteLine(operacion);
                    writer.Flush();
                    Console.WriteLine("Resultado: {0} cm^2", reader.ReadLine());
                }
            }
            //Parar pipes
            if (p != null && !p.HasExited)
            {
                p.Kill();
                //Es redundante  p = null;
            }
        }

        /// <summary>
        /// Metodo para arrancar el servidor y devolver el proceso
        /// </summary>
        /// <param name="p1"></param>
        /// <returns>Proceso servidor con el que trabajaremos</returns>
        static Process StartServer(out Process p1)
        {
            // iniciar un proceso con el servidor y devolver
            ProcessStartInfo info = new ProcessStartInfo(@"..\..\..\..\CalculoAreasServidor\bin\Release\net6.0\win-x64\CalculoAreasServidor.exe");

            // su valor por defecto el false, si se establece a true no se "crea" ventana
            info.CreateNoWindow = false;
            info.WindowStyle = ProcessWindowStyle.Normal;
            // indica si se utiliza el cmd para lanzar el proceso
            info.UseShellExecute = true;
            p1 = Process.Start(info);
            return p1;
        }

        /// <summary>
        /// Pintar el menú de opciones
        /// </summary>
        /// <param name="operacion"></param>
        private static void PintarMenu(ref string? operacion)
        {
            Console.WriteLine("Area que desea calcular:");
            Console.WriteLine(" 1 - Círculo");
            Console.WriteLine(" 2 - Triángulo");
            Console.WriteLine(" 3 - Rectángulo");
            Console.WriteLine(" 4 - Pentágono");
            //Console.WriteLine(" 5 - Potencia");
            Console.WriteLine(" (-1) Salir");
            Console.Write("Introduzca la operación: ");
            var input = Console.ReadLine();
            //int op;
            if (input != null)
            {
                bool ret = ValidaOperacion(input, ref operacion);//, out op);
            }
          
        }

        /// <summary>
        /// Validamos que se introduce un entero y luego que coincida con las opciones
        /// </summary>
        /// <param name="cadenaIn"></param>
        /// <param name="operacion"></param>
        /// <returns></returns>
        private static bool ValidaOperacion(string cadenaIn, ref string? operacion)
        {
            int opcion;
            if (!Int32.TryParse(cadenaIn, out int op))
            {
                Console.WriteLine("Opción {0} no válida.", op);
                //opcion = op;
                operacion = null;
                return false;
            }
            else
            {
                opcion = op;
            }
            switch (opcion)
            {
                case 1: // Circulo
                    operacion = "0 ";
                    IntroducirOperandos(ref operacion);
                    break;

                case 2: // Triangulo
                    operacion = "3 ";
                    IntroducirOperandos(ref operacion);
                    break;

                case 3: // Cuadrado
                    operacion = "4 ";
                    IntroducirOperandos(ref operacion);
                    break;
                case 4: // Pentagono
                    operacion = "5 ";
                    IntroducirOperandos(ref operacion);
                    break;
                case -1: // Salir
                    operacion = "E"; // Para que salga del While
                    Console.WriteLine("Exit");
                    break;

                default: // Error de opcion
                    Console.WriteLine("Opción {0} no válida.", op);
                    operacion = null;
                    break;

            }
            return false;
        }

        private static bool IntroducirOperandos(ref string? operacion)
        {
            if (operacion.Equals("0 "))
            {
                return PideDatosCirculo(ref operacion);
            } else if (operacion.Equals("3 "))
            {
                return PideDatosTriangulo(ref operacion);
            } else if (operacion.Equals("4 "))
            {
                return PideDatosRectangulo(ref operacion);
            } else if (operacion.Equals("5 "))
            {
                return PideDatosPentagono (ref operacion);
            } else
            {
                return false;
            }
        }

        private static bool PideDatosCirculo(ref string? operacion)
        {
            Console.Write("Introduce en cm el radio del círculo :");
            string? input = Console.ReadLine();
            if (!Single.TryParse(input, out float op))
            {
                Console.WriteLine("El valor para el radio NO es un número");
                operacion = null;
                return false;
            }
            operacion = operacion + input +" 0";
            return true;
        }

        private static bool PideDatosTriangulo(ref string? operacion)
        {
            Console.Write("Introduce en cm la base del triángulo  :");
            string? input = Console.ReadLine();
            if (!Single.TryParse(input, out float op))
            {
                Console.WriteLine("El valor para la base NO es un número");
                operacion = null;
                return false;
            }
            Console.Write("Introduce en cm la altura del triángulo  :");
            string? input2 = Console.ReadLine();
            if (!Single.TryParse(input2, out float op2))
            {
                Console.WriteLine("El valor para la altura NO es un número");
                operacion = null;
                return false;
            }
            operacion = operacion + input + " "+input2;

            return true;
        }

        private static bool PideDatosRectangulo(ref string? operacion)
        {
            Console.Write("Introduce en cm la base del rectángulo  :");
            string? input = Console.ReadLine();
            if (!Single.TryParse(input, out float op))
            {
                Console.WriteLine("El valor para la base NO es un número");
                operacion = null;
                return false;
            }
            Console.Write("Introduce en cm la altura del rectángulo  :");
            string? input2 = Console.ReadLine();
            if (!Single.TryParse(input2, out float op2))
            {
                Console.WriteLine("El valor para la altura NO es un número");
                operacion = null;
                return false;
            }
            operacion = operacion + input + " " + input2;

            return true;
        }

        private static bool PideDatosPentagono(ref string? operacion)
        {
            Console.Write("Introduce en cm el lado del pentágono :");
            string? input = Console.ReadLine();
            if (!Single.TryParse(input, out float op))
            {
                Console.WriteLine("El valor para el lado NO es un número");
                operacion = null;
                return false;
            }
            Console.Write("Introduce en cm la apotema del pentágono :");
            string? input2 = Console.ReadLine();
            if (!Single.TryParse(input2, out float op2))
            {
                Console.WriteLine("El valor para la apotema NO es un número");
                operacion = null;
                return false;
            }
            operacion = operacion + input + " " + input2;

            return true;
        }

    }
}
