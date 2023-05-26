using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
namespace Ejercicio2
{
    public class ServidorFotos
    {
        public static void Main(string[] args)
        {
            //Tope Clientes
            int topeClientes = 5;
            int numeroClientes = 0;

            //Preparación de datos para el listener
            string servidor = "127.0.0.1";
            IPAddress ipserver = IPAddress.Parse(servidor);
            int port = 12000;

            // Crea el TcpListener del servidor
            TcpListener listener = new TcpListener(ipserver, port);

            // Inicia la escucha del socket
            listener.Start(5);
            Console.WriteLine("Servidor iniciado en " + servidor + ":" + port);

            // Maneja conexiones entrantes de clientes
            while (true)
            {
                // Aceptar la conexión entrante
                TcpClient client = listener.AcceptTcpClient();

                // Verificar si ya se alcanzó la cantidad máxima de clientes
                if (numeroClientes >= topeClientes)
                {
                    // Rechazar la conexión porque ya no se aceptan más clientes
                    client.Close();
                    Console.WriteLine("Se alcanzó el número máximo de clientes simultáneos (5)");
                }
                else
                {
                    // Iniciar un nuevo hilo para manejar la solicitud del cliente
                    numeroClientes++;
                    Thread t = new Thread(() => ControlCliente(client, ref numeroClientes));
                    t.Start();
                }
            }
        }
        private static void ControlCliente(TcpClient clienteSocket, ref int numeroClientes)
        {
            // Directorio local que contiene las imágenes (he dejado ahí las imágenes proporcionadas)
            //string rutaImagenes = "C:/Imagenes/";
            string rutaImagenes = Path.Combine(Environment.CurrentDirectory, @"..\..\..\Imagenes");

            Console.WriteLine(rutaImagenes);
            Console.WriteLine("Cliente número {0} conectado", numeroClientes);
            //     while (true)
            //    {
            try
            { 
                // Crea un NetworkStream
                NetworkStream stream = clienteSocket.GetStream();
                // Lee la opción solicitada por el cliente con un StreamReader que usa el NetworkStream
                StreamReader reader = new StreamReader(stream);
                string seleccion = reader.ReadLine();
                Console.WriteLine("La selección del cliente es: {0}", seleccion);
                if (seleccion == "1" || seleccion == "2" || seleccion == "3")
                {
                    Console.WriteLine("Imagen solicitada: {0}", seleccion);

                    if (seleccion.Equals("1"))
                    {
                        seleccion = "Monte";
                    }
                    else if (seleccion.Equals("2"))
                    {
                        seleccion = "Playa";
                    }
                    else if (seleccion.Equals("3"))
                    {
                        seleccion = "Ciudad";
                    }
                    // Busca la imagen en el directorio local
                    string rutaImagen = Path.Combine(rutaImagenes, "Foto" + seleccion + ".jpg");
                    Console.WriteLine("Existe imagen: {0}", File.Exists(rutaImagen));
                    if (File.Exists(rutaImagen))
                    {
                        // Si el fichero existe en la ruta, envía la imagen al cliente

                        // Al final la imagen envío con FileStream
                        FileStream filestream = new FileStream(rutaImagen, FileMode.Open, FileAccess.Read);
                        filestream.CopyTo(stream);
                        filestream.Close();

                        // He hecho pruebas con BinaryWriter también pero solo me funciona en la primera conexión...
                        // o cerrando el cliente al final

                        // Usando binaryReader/binaryWriter
                        //using (var fileStream = new FileStream(rutaImagen, FileMode.Open, FileAccess.Read))
                        //using (var binaryReader = new BinaryReader(fileStream))
                        //{
                        //    var bytes = binaryReader.ReadBytes((int)fileStream.Length);
                        //    var binaryWriter = new BinaryWriter(stream);

                        //    Envía el tamaño de la imagen
                        //    int imagenSize = bytes.Length;
                        //    binaryWriter.Write(imagenSize);

                        //    Envía los datos de la imagen
                        //    binaryWriter.Write(bytes);
                        //    binaryWriter.Flush();
                        //}

                        //Para avisar de que ya se han enviado datos parece que tengo que cerrar la conexión o socket
                        //Imagino que habrá otra manera de hacerlo, pero las maneras que he encontrado, necesito cerrar
                        clienteSocket.Close();

                        //clienteSocket.Client.Shutdown(SocketShutdown.Send);
                        //Aunque cierro conexión no resto número de clientes para probar que aumenta el valor
                        //numeroClientes--;
                    }
                }
                else if (seleccion == "4")
                // Cerraría la conexión con el cliente
                {
                    Console.WriteLine("Cliente ha finalizado la conexión");
                    clienteSocket.Close();
                    numeroClientes--;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //    } //Fin del while que no puedo usar al tener que cerrar clienteSocket.
        }
    }
}
