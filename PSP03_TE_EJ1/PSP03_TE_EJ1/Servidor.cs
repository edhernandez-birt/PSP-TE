using System.Net;
using System.Net.Sockets;

namespace PSP03_PPT
{
    public class Servidor
    {
        //        public int jugadas = 0;
        //        private Object o = new object();
        private string datotratar = string.Empty;


        public static void Main(String[] args)
        {
            Servidor appserver = new Servidor();
            PartidaServidor p = new PartidaServidor();

            TcpClient socketcliente = null;

            //Preparación de datos para el listener
            string servidor = "127.0.0.1";
            IPAddress ipserver = IPAddress.Parse(servidor);
            Int32 port = 13000;

            Console.WriteLine("Vamos a arrancar sockets y listener");

            TcpListener listener = new TcpListener(ipserver, port);
            Console.WriteLine("Socket Listener creado");
            listener.Start(2);
            try
            {
                while (true)
                {
                    socketcliente = listener.AcceptTcpClient(); //linea bloqueante
                    Console.WriteLine("Conexión con cliente establecida.");

                    Thread t = new Thread(() => appserver.ControlDatos(socketcliente, p));
                    t.Start();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                if (socketcliente != null)
                {
                    listener.Stop();
                    socketcliente.Close();
                    Console.WriteLine("\n Servidor cerrado");
                }

            }

        }
        public Servidor()
        {
        }

        private void ControlDatos(TcpClient socket, PartidaServidor partida)
        {

            NetworkStream network = socket.GetStream();
            StreamWriter writer = new StreamWriter(network);
            StreamReader reader = new StreamReader(network);
            Console.WriteLine("Buffer de entrada y salida creados.");
            //Cogemos el nombre del jugador
            datotratar = reader.ReadLine();
            //Lo mostramos por consola
            Console.WriteLine("Identificador de jugador: {0} ", datotratar);
            string identificador = datotratar;

            if (partida.getNumParticipantes() < 2)
            {
                //Podemos inscribir al jugador
                Console.WriteLine("Nombre del jugador cliente: {0}.", datotratar);
                partida.setParticipante(datotratar);
                Console.WriteLine("Hay participantes: {0}", partida.getNumParticipantes());
                //datotratar = socket.Client.Handle.ToString();
                writer.WriteLine("La inscripción de {0} fue correcta", datotratar);
                writer.Flush();
                //     int jugadas = partida.getJugadasTotales();


                try
                {
                    // writer.WriteLine("Intenta adivinar mi número:");
                    // writer.Flush();

                    while (true)
                    {
                        try
                        {

                            datotratar = reader.ReadLine(); //linea bloqueante
                            Console.WriteLine(datotratar);

                            if (datotratar.Equals("1"))
                            {
                                //VAMOS A JUGAR PIEDRA PAPEL TIJERA. PEDIR LA OPCION
                                datotratar = reader.ReadLine(); //bloqueante, esperamos la opción del jugador
                                //Buscamos el "id" del participante
                                int id = -1;
                                for (int i = 0; i < partida.getNumParticipantes(); i++)
                                {
                                    if (identificador.Equals(partida.getParticipante(i)))
                                    {
                                        id = i;
                                    }
                                }
                                Console.WriteLine("Identificador " + id);

                                //Guardamos la opción elegida si es válida
                                if (datotratar == "PIEDRA" || datotratar == "PAPEL" || datotratar == "TIJERA")
                                {
                                    Console.WriteLine("Vamos a escribir la jugada número {0} que es de {1} y elige: {2}", (partida.getJugadasTotales() + 1), identificador, datotratar);
                                    partida.setPartidaActual(datotratar, id);
                                    //Si los dos jugadores han dado su elección resolvemos la partida
                                    if ((partida.getPartidaActual(0) != string.Empty) && (partida.getPartidaActual(1) != string.Empty))
                                    {
                                        Console.WriteLine("Entramos en el juego");
                                        //Vamos a ver quien ha ganado y a dar puntos
                                        string eleccion1 = partida.getPartidaActual(0);
                                        string eleccion2 = partida.getPartidaActual(1);
                                        //Gana primer jugador si PIEDRA-TIJERA, PAPEL-PIEDRA O TIJERA-PAPEL
                                        if ((eleccion1 == "PIEDRA" && eleccion2 == "TIJERA") || (eleccion1 == "PAPEL" && eleccion2 == "PIEDRA") || (eleccion1 == "TIJERA" && eleccion2 == "PAPEL"))
                                        {
                                            partida.setUltimoGanador(partida.getParticipante(0));
                                            partida.sumaPunto(0);

                                        }
                                        else if ((eleccion1 == "TIJERA" && eleccion2 == "PIEDRA") || (eleccion1 == "PIEDRA" && eleccion2 == "PAPEL") || (eleccion1 == "PAPEL" && eleccion2 == "TIJERA"))
                                        {//Gana el segundo jugador
                                            partida.setUltimoGanador(partida.getParticipante(1));
                                            partida.sumaPunto(1);
                                        }
                                        else
                                        {
                                            //empate
                                            partida.setUltimoGanador("Empate");
                                        }
                                        //Una vez visto quien ha ganado vaciamos la partida actual y añadimos 1 al contador de partidas
                                        partida.sumaJugada();
                                        partida.setPartidaActual(string.Empty, 0);
                                        partida.setPartidaActual(string.Empty, 1);
                                        writer.WriteLine("Se ha jugado la partida: " + partida.getJugadasTotales());
                                        writer.Flush();
                                    }
                                    else
                                    {
                                        writer.WriteLine("Pendiente de jugar la partida:" + (partida.getJugadasTotales() + 1));
                                        writer.Flush();
                                    }
                                }


                            }
                            else if (datotratar.Equals("2"))
                            {
                                //VAMOS A MOSTRAR PUNTUACION

                                //Mandamos número de jugadores:
                                writer.WriteLine(partida.getNumParticipantes());
                                writer.Flush();

                                for (int i = 0; i < partida.getNumParticipantes(); i++)
                                {
                                    writer.WriteLine("Puntuacion idjugador: " + partida.getParticipante(i) + ", número puntos: " + partida.getPuntuacion(i));
                                    writer.Flush();
                                }

                            }
                            else if (datotratar.Equals("3"))
                            {
                                string respuestaPartidas = string.Empty;
                                //VAMOS A MOSTRAR ULTIMO RESULTADO
                                if (partida.getJugadasTotales() > 0)
                                {
                                    respuestaPartidas = "El ganador de la última jugada ha sido: " + partida.getUltimoGanador();
                                }
                                else
                                {
                                    respuestaPartidas = "Todavía no se ha completado la primera jugada";
                                }
                                writer.WriteLine(respuestaPartidas);
                                writer.Flush();
                            }
                            else
                            {
                                //SALIR
                                break;
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.Out.Flush();
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    writer.Close();
                    network.Close();
                    reader.Close();
                }
            }
            else
            {
                try
                {
                    Console.WriteLine("Se ha llegado al máximo de usuarios");
                    writer.WriteLine("MAXIMO");
                    writer.Flush();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.Out.Flush();
                }
                finally
                {
                    writer.Close();
                    network.Close();
                    reader.Close();
                }
            }
        }
    }
}
