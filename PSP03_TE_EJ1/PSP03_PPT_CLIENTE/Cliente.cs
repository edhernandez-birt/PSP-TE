
using System.Net.Sockets;
using System.Threading.Tasks.Dataflow;

namespace PSP03_PPT
{
    public class Cliente
    {
        TcpClient socket = null;
        NetworkStream network = null;
        StreamWriter writer = null;
        StreamReader reader = null;
        public static void Main(String[] args)
        {
            PartidaCliente partidaCliente = new PartidaCliente();
            Cliente appcliente = new Cliente();
            string servidor = "127.0.0.1";
            Int32 port = 13000;

            appcliente.Connect(servidor, port, partidaCliente);
            Console.WriteLine("Vamos con el control de datos...");
            appcliente.ControlDatos(partidaCliente);

            appcliente.Cerrar();
            Console.WriteLine("\n Fin del juego");
            Console.Read();
        }

        public Cliente()
        {

        }
        private void Connect(String server, Int32 port, PartidaCliente partidaCli)
        {
            try
            {

                this.socket = new TcpClient(server, port);
                Console.WriteLine("Socket Cliente creado.");
                network = socket.GetStream();
                this.writer = new StreamWriter(network);
                this.reader = new StreamReader(network);
                Console.WriteLine("Buffer de escritura y lectura creados.");

                //En este método añado la introducción del nombre jugador. La respuesta se controla en ControlDatos
                string nombreuser = string.Empty;
                Console.WriteLine("Indica el nombre con el que quiere inscribirse en el juego");
                nombreuser = Console.ReadLine();
                partidaCli.setIdentificador(nombreuser);
                Console.WriteLine("Identificador de jugador: {0} ", nombreuser);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        private void ControlDatos(PartidaCliente partidaCli)
        {
            string datouser = string.Empty;
            bool puedesJugar = true;
            try
            {
                Console.WriteLine("Enviamos nombre de jugador al servidor");
                writer.WriteLine(partidaCli.getIdentificador());
                writer.Flush();
                //La respuesta del servidor
                datouser = reader.ReadLine();

                //Si es MAXIMO no puede jugar 
                if (datouser.Equals("MAXIMO"))
                {
                    puedesJugar = false;
                    Console.WriteLine("Limite de usuarios alcanzado. No puedes jugar");
                }
                else
                {
                    //Si no manda máximo, manda el mensaje de que ha podido inscribirse
                    Console.WriteLine(datouser);
                }

                while (true & puedesJugar)
                {
                    //Muestra menú principal al cliente
                    MostrarMenuPrincipal();

                    //Leemos opción elegida
                    datouser = Console.ReadLine();

                    //Controlamos las opciones y la enviamos al servidor

                    // 1 es jugar
                    if (datouser.Equals("1"))
                    {
                        writer.WriteLine(datouser);
                        writer.Flush();
                        //Queremos jugar y hay que mostrar otro menú
                        MostrarMenuJuego();

                        //Pedimos piedra-papel-tijera al jugador
                        datouser = Console.ReadLine();
                        //Controlamos respuesta
                        if (datouser.Equals("1"))
                        {
                            //Mandamos piedra
                            datouser = "PIEDRA";
                        }
                        else if (datouser.Equals("2"))
                        {
                            //Mandamos papel
                            datouser = "PAPEL";

                        }
                        else if (datouser.Equals("3"))
                        {
                            //Mandamos tijera
                            datouser = "TIJERA";
                        }
                        else
                        {
                            Console.WriteLine("Opcíón incorrecta. Elige 1-2-3 para Piedra-Papel-Tijera");
                            datouser = "-1";
                        }
                        writer.WriteLine(datouser);
                        writer.Flush();
                        //Mostramos número de partida
                        Console.WriteLine(reader.ReadLine() + Environment.NewLine);
                    }
                    // 2 es mostrar puntuación
                    else if (datouser.Equals("2"))
                    {
                        //Mandamos el 2 para que el servidor sepa que queremos la puntuación
                        writer.WriteLine(datouser);
                        writer.Flush();
                        //Para recoger la puntuación lo hacemos con un bucle para los usuarios que haya (pueden ser 1 o 2)
                        int numJugadores = 0;
                        // Nos manda el servidor el número de jugadores
                        datouser = reader.ReadLine();
                        numJugadores = int.Parse(datouser);
                        // Nos manda el servidor el resultado de cada jugador
                        for (int i = 0; i < numJugadores; i++)
                        {
                            Console.WriteLine(reader.ReadLine());
                        }
                    }
                    else if (datouser.Equals("3"))
                    {
                        //Mandamos la opción porque es válida
                        writer.WriteLine(datouser);
                        writer.Flush();
                        //QUEREMOS RESULTADO ULTIMA PARTIDA
                        Console.WriteLine(reader.ReadLine());
                    }
                    else if (datouser.Equals("-1"))
                    {
                        //QUEREMOS SALIR DEL PROGRAMA BREAK
                        writer.WriteLine(datouser);
                        writer.Flush();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Has escrito una opción no válida. Elige una opción de 1 al 3 o -1 para salir");
                    }

                }
                Console.WriteLine("*****************");
                Console.WriteLine("Fin de la partida.");
                Console.WriteLine("*****************");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Out.Flush();
            }

        }
        private void Cerrar()
        {
            this.reader.Close();
            this.writer.Close();
            this.network.Close();
            this.socket.Close();
        }
        private void MostrarMenuPrincipal()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Jugar piedra papel o tijera:elige");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1: Jugar");
            Console.WriteLine("2: Puntuación");
            Console.WriteLine("3: Mostrar Resultado");
            Console.WriteLine("-1: Salir");
            Console.WriteLine("---------------------------------");
        }
        private void MostrarMenuJuego()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Escoge piedra papel o tijera");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1: Piedra");
            Console.WriteLine("2: Papel");
            Console.WriteLine("3: Tijera");
            Console.WriteLine("---------------------------------");
        }
    }
}
