using System;
using System.Threading;

namespace PSP_02_Tarea2
{
    class Program
    {
        static object _lockObject = new object();
        private static bool finalizo = false;
        static int[] distanciaRecorrida = new int[4];

        static void Main(string[] args)
        {
            menu();

        }

        public static void menu()
        {

            int jugar = 1;
            while (jugar == 1)
            {
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1. Empezar juego");
                Console.WriteLine("2. Reiniciar juego");
                Console.WriteLine("3. Salir del juego");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("¡Que comience el juego!");

                        iniciarJuego();

                        jugar = 2;
                        break;
                    case "2":
                        Console.WriteLine("El juego aún no se ha ejecutado ninguna vez.");

                        break;
                    case "3":
                        Console.WriteLine("¡Hasta luego!");
                        jugar = 3;
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente de nuevo.");
                        break;
                }
            }

            while (jugar == 2)
            {
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("2. Reiniciar juego");
                Console.WriteLine("3. Salir del juego");
                string opcion = Console.ReadLine();

                switch (opcion)
                {

                    case "2":
                        Console.WriteLine("Juego reiniciado.");

                        // Volver a iniciar los hilos
                        iniciarJuego();
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente de nuevo.");
                        break;
                    case "3":
                        Console.WriteLine("¡Hasta luego!");
                        jugar = 3;
                        break;
                }
            }
        }

        public static void iniciarJuego()
        {
            finalizo = false; // Establecer la bandera de finalización en falso
            int[] distancia = new int[4];

            Thread caballo1 = new Thread(carril1);
            caballo1.Priority = ThreadPriority.Normal;
            Thread caballo2 = new Thread(carril2);
            caballo2.Priority = ThreadPriority.Highest;
            Thread caballo3 = new Thread(carril3);
            caballo3.Priority = ThreadPriority.Lowest;
            Thread caballo4 = new Thread(carril4);
            caballo4.Priority = ThreadPriority.AboveNormal;

            caballo1.Start();
            caballo2.Start();
            caballo3.Start();
            caballo4.Start();

            caballo1.Join();
            caballo2.Join();
            caballo3.Join();
            caballo4.Join();
        }
        private static void meta(int distancia, string numero)
        {
            lock (_lockObject)
            {
                Console.WriteLine("El caballo {0} ha llegado a la meta", numero);
                Console.WriteLine("Ha recorrido 100 metros");


                Console.WriteLine("Distancia recorrida por los demás caballos:");
                for (int i = 0; i < distanciaRecorrida.Length; i++)
                {
                    if ((i + 1).ToString() != numero)
                    {
                        Console.WriteLine("Caballo {0}: {1} metros", i + 1, distanciaRecorrida[i]);
                    }
                }
            }
        }
        private static void carril1()
        {
            Random rnd = new Random();

            int distancia = 0;
            int longitud = 100;
            int limite = longitud / 10;

            while (distancia < longitud && finalizo == false)
            {
                // Generar un número aleatorio limitado al 10% de la longitud
                int avance = rnd.Next(1, limite + 1);

                // Avanzar la distancia del caballo
                distancia += avance;

                distanciaRecorrida[0] = distancia;

                if (distancia < 100)
                {
                    Console.WriteLine("Soy el caballo 1 y el valor de avance hasta el momento es de {0} m", distancia);
                }
                else
                {
                    Console.WriteLine("Soy el caballo 1 y el valor de avance hasta el momento es de 100 m");
                }

                // Esperar un tiempo aleatorio
                Thread.Sleep(rnd.Next(50, 1000));
            }


            // Verificar si llegó a la meta            
            if (distancia >= longitud && finalizo == false)
            {
                finalizo = true;
                meta(distancia, "1");
            }

        }

        private static void carril2()
        {
            Random rnd = new Random();

            int distancia = 0;
            int longitud = 100;
            int limite = longitud / 10;

            while (distancia < longitud && finalizo == false)
            {
                // Generar un número aleatorio limitado al 10% de la longitud
                int avance = rnd.Next(1, limite + 1);

                // Avanzar la distancia del caballo
                distancia += avance;

                distanciaRecorrida[1] = distancia;

                if (distancia < 100)
                {
                    Console.WriteLine("Soy el caballo 2 y el valor de avance hasta el momento es de {0} m", distancia);
                }
                else
                {
                    Console.WriteLine("Soy el caballo 2 y el valor de avance hasta el momento es de 100 m");
                }

                // Esperar un tiempo aleatorio
                Thread.Sleep(rnd.Next(50, 1000));
            }

            // Verificar si llegó a la meta
            // Verificar si llegó a la meta            
            if (distancia >= longitud && finalizo == false)
            {
                meta(distancia, "2");
                finalizo = true;
            }

        }

        private static void carril3()
        {
            Random rnd = new Random();

            int distancia = 0;
            int longitud = 100;
            int limite = longitud / 10;

            while (distancia < longitud && finalizo == false)
            {
                // Generar un número aleatorio limitado al 10% de la longitud
                int avance = rnd.Next(1, limite + 1);

                // Avanzar la distancia del caballo
                distancia += avance;

                distanciaRecorrida[2] = distancia;
                //Indicamos lo recorrido
                if (distancia < 100)
                {
                    Console.WriteLine("Soy el caballo 3 y el valor de avance hasta el momento es de {0} m", distancia);
                }
                else
                {
                    Console.WriteLine("Soy el caballo 3 y el valor de avance hasta el momento es de 100 m");
                }

                // Esperar un tiempo aleatorio
                Thread.Sleep(rnd.Next(50, 1000));
            }

            // Verificar si llegó a la meta        
            if (distancia >= longitud && finalizo == false)
            {
                meta(distancia, "3");
                finalizo = true;
            }
        }
        private static void carril4()
        {
            Random rnd = new Random();

            int distancia = 0;
            int longitud = 100;
            int limite = longitud / 10;

            while (distancia < longitud && finalizo == false)
            {
                // Generar un número aleatorio limitado al 10% de la longitud
                int avance = rnd.Next(1, limite + 1);

                // Avanzar la distancia del caballo
                distancia += avance;

                distanciaRecorrida[3] = distancia;
                //Indicamos lo recorrido
                if (distancia < 100)
                {
                    Console.WriteLine("Soy el caballo 4 y el valor de avance hasta el momento es de {0} m", distancia);
                }
                else
                {
                    Console.WriteLine("Soy el caballo 4 y el valor de avance hasta el momento es de 100 m");
                }

                // Esperar un tiempo aleatorio
                Thread.Sleep(rnd.Next(50, 1000));
            }

            // Verificar si llegó a la meta            
            if (distancia >= longitud && finalizo == false)
            {
                meta(distancia, "4");
                finalizo = true;
            }
        }
    }

}