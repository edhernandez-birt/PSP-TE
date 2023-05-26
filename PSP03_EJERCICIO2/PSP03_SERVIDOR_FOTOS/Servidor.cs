using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Ejercicio2
{
    public class Servidor
    {
        public static void Main(string[] args)
        {
            // Creamos el socket del servidor
            var servidorSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // Definimos los parámetros para que el servidor escuche en todas las interfaces de red en el puerto 5000
            var ipServidor = IPAddress.Any;
            var puertoServidor = 13000;
            var endPointServidor = new IPEndPoint(ipServidor, puertoServidor);

            // Asociamos el socket con el endPointServidor y lo ponemos a escuchar
            servidorSocket.Bind(endPointServidor);
            servidorSocket.Listen(5);

            Console.WriteLine("Servidor iniciado y en espera de conexiones...");

            // Creamos un bucle infinito para aceptar conexiones entrantes
            while (true)
            {
                // Aceptamos la conexión entrante
                var clienteSocket = servidorSocket.Accept();

                Console.WriteLine($"Conexión aceptada desde {clienteSocket.LocalEndPoint}");

                // Creamos un hilo para atender al cliente
                var clienteThread = new Thread(() => ControlClientes(clienteSocket));
                clienteThread.Start();
            }
            //try
            //{
            //    // Establecer la dirección IP y el puerto del servidor
            //    IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            //    int port = 13000;

            //    // Crear un socket TCP/IP
            //    TcpListener server = new TcpListener(ipAddress, port);

            //    // Iniciar la escucha de conexiones entrantes
            //    server.Start();
            //    Console.WriteLine("Servidor iniciado en " + ipAddress + ":" + port);

            //    // Declarar la cantidad máxima de clientes simultáneos que aceptará el servidor
            //    int maxClients = 5;
            //    int numClients = 0;

            //    // Escuchar de manera indefinida las solicitudes de los clientes
            //    while (true)
            //    {
            //        // Aceptar la conexión entrante
            //        TcpClient client = server.AcceptTcpClient();

            //        // Verificar si ya se alcanzó la cantidad máxima de clientes
            //        if (numClients >= maxClients)
            //        {
            //            // Rechazar la conexión si ya no se aceptan más clientes
            //            client.Close();
            //            Console.WriteLine("Rechazando cliente porque se alcanzó el número máximo de clientes simultáneos");
            //        }
            //        else
            //        {
            //            // Iniciar un nuevo hilo para manejar la solicitud del cliente
            //            numClients++;
            //            Thread t = new Thread(() => ControlClientes(client, numClients));
            //            t.Start();
            //        }
            //    }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Error: " + e.Message);
            //}
        }

        private static void ControlClientes(Socket clienteSocket)
        {
            try
            {
                while (true)
                {
                    // Recibimos la opción seleccionada por el cliente
                    var buffer = new byte[1024];
                    var bytesRecibidos = clienteSocket.Receive(buffer);
                    var opcion = Encoding.UTF8.GetString(buffer, 0, bytesRecibidos);
                    Console.WriteLine("Recibida la opcion: {0}", opcion);
                    if (opcion == "-1")
                    {
                        Console.WriteLine($"El cliente {clienteSocket.RemoteEndPoint} ha cerrado la conexión.");
                        clienteSocket.Shutdown(SocketShutdown.Both);
                        clienteSocket.Close();
                        break;
                    }

                    // Leemos la imagen correspondiente
                    var nombreArchivo = "";
                    int eleccion = int.Parse(opcion);
                    switch (eleccion)
                    {
                        case 1:
                            nombreArchivo = "FotoMonte.jpg";
                            break;
                        case 2:
                            nombreArchivo = "FotoPlaya.jpg";
                            break;
                        case 3:
                            nombreArchivo = "FotoCiudad.jpg";
                            break;
                    }
                    Console.WriteLine(nombreArchivo);
                    var rutaArchivo = Path.Combine(Environment.CurrentDirectory, nombreArchivo);
                    Console.WriteLine(rutaArchivo);
                    var imagenBytes = File.ReadAllBytes(rutaArchivo);

                    // Enviamos la imagen al cliente
                    clienteSocket.Send(imagenBytes);
                    Console.WriteLine("Enviada imagen {0}",nombreArchivo);
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine($"Error de socket: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
            }
        
        //    try
        //    {
        //        Console.WriteLine("Cliente #" + clientId + " conectado");
        //        while (true)
        //        {
        //            //   String selection = "0";
        //            //   Console.WriteLine("Selection:{0}", selection);
        //            // Obtener la selección del cliente
        //            NetworkStream stream = client.GetStream();
        //            byte[] buffer = new byte[1024];


        //            Console.WriteLine("Estoy delante de selección");
        //            int bytesRead = stream.Read(buffer, 0, buffer.Length);
        //            String seleccion = Encoding.UTF8.GetString(buffer, 0, bytesRead);

        //            Console.WriteLine("Estoy tras selección {0}", seleccion);
        //            if (seleccion == "1" || seleccion == "2" || seleccion == "3")
        //            {

        //                if (seleccion.Equals("1"))
        //                {
        //                    Console.WriteLine("Estoy en monte");

        //                    seleccion = "Monte";
        //                }
        //                else if (seleccion.Equals("2"))
        //                {
        //                    seleccion = "Playa";
        //                }
        //                else if (seleccion.Equals("3"))
        //                {
        //                    seleccion = "Ciudad";
        //                }

        //                Console.WriteLine("Mandar foto {0}", seleccion);

        //                // Enviar la imagen seleccionada al cliente
        //                byte[] imageBytes = File.ReadAllBytes("imagenes/Foto" + seleccion + ".jpg");

        //                byte[] lengthBytes = BitConverter.GetBytes(imageBytes.Length);
        //                //stream.Write(lengthBytes, 0, lengthBytes.Length);

        //                // Enviar la imagen
        //                stream.Write(imageBytes, 0, imageBytes.Length);

        //                buffer = new byte[1024];

        //            }
        //            else if (seleccion == "-1")
        //            {
        //                client.Close();
        //                Console.WriteLine("Cliente #" + clientId + " desconectado");
        //                break;
        //            }

        //        }



        //        //stream.Write(imageBytes, 0, imageBytes.Length);
        //        //   }
        //        // } while (true && !selection.Equals("4"));

        //        // Cerrar la conexión con el cliente

        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Error: " + e.Message);
        //    }
        //}

        //public static void Main(string[] args)
        //{
        //    TcpClient socketcliente = null;
        //    NetworkStream network = null;
        //    StreamWriter writer = null;
        //    StreamReader reader = null;
        //    string servidor = "127.0.0.1";
        //    IPAddress ipserver = IPAddress.Parse(servidor);
        //    Int32 port = 13000;

        //    TcpListener listener = new TcpListener(ipserver, port);
        //    Console.WriteLine("Socket listener creado");
        //    listener.Start(5);
        //    while (true)
        //    {
        //        socketcliente = listener.AcceptTcpClient();
        //        Console.WriteLine("Conexión con cliente establecida");
        //        Thread t = new Thread(() => ManejarCliente(socketcliente));
        //        t.Start();
        //    }


        //}

        //public static void ManejarCliente(TcpClient clientesocket,StreamWriter writer, StreamReader reader)
        //{
        //    int opcion = 0;
        //    try
        //    {   writer.WriteLine("Intentaré mandarte una foto");
        //        writer.Flush();
        //        while (true)
        //        {


        //            string datorecibido = reader.ReadLine();
        //            opcion = int.Parse(datorecibido);

        //            if (opcion == 4)
        //            {
        //                Console.WriteLine("El cliente ha cerrado la conexión.");
        //                break;
        //            }

        //            // leemos la imagen correspondiente
        //            var nombrearchivo = "";
        //            switch (opcion)
        //            {
        //                case 1:
        //                    nombrearchivo = "FotoMonte.jpg";
        //                    break;
        //                case 2:
        //                    nombrearchivo = "FotoPlaya.jpg";
        //                    break;
        //                case 3:
        //                    nombrearchivo = "FotoCiudad.jpg";
        //                    break;
        //            }


        //            // enviamos la imagen al cliente


        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Error inesperado:{0}",e);
        //    }
        //}


        //public static void Main(string[] args)
        //{
        //    // Creamos el socket del servidor
        //    var servidorSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        //    // Definimos los parámetros para que el servidor escuche en todas las interfaces de red en el puerto 5000
        //    var ipServidor = IPAddress.Any;
        //    var puertoServidor = 13000;
        //    var endPointServidor = new IPEndPoint(ipServidor, puertoServidor);

        //    // Asociamos el socket con el endPointServidor y lo ponemos a escuchar
        //    servidorSocket.Bind(endPointServidor);
        //    servidorSocket.Listen(5);

        //    Console.WriteLine("Servidor iniciado y en espera de conexiones...");

        //    // Creamos un bucle infinito para aceptar conexiones entrantes
        //    while (true)
        //    {
        //        // Aceptamos la conexión entrante
        //        var clienteSocket = servidorSocket.Accept();

        //        Console.WriteLine($"Conexión aceptada desde {clienteSocket.RemoteEndPoint}");

        //        // Creamos un hilo para atender al cliente
        //        var clienteThread = new Thread(() => ManejarCliente(clienteSocket));
        //        clienteThread.Start();
        //    }
        //}

        //public static void ManejarCliente(Socket clienteSocket)
        //{
        //    try
        //    {
        //        while (true)
        //        {
        //            // Recibimos la opción seleccionada por el cliente
        //            var buffer = new byte[1024];
        //            var bytesRecibidos = clienteSocket.Receive(buffer);
        //            var opcion = int.Parse(System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRecibidos));

        //            if (opcion == 4)
        //            {
        //                Console.WriteLine($"El cliente {clienteSocket.RemoteEndPoint} ha cerrado la conexión.");
        //                clienteSocket.Shutdown(SocketShutdown.Both);
        //                clienteSocket.Close();
        //                break;
        //            }

        //            // Leemos la imagen correspondiente
        //            var nombreArchivo = "";
        //            switch (opcion)
        //            {
        //                case 1:
        //                    nombreArchivo = "FotoMonte.jpg";
        //                    break;
        //                case 2:
        //                    nombreArchivo = "FotoPlaya.jpg";
        //                    break;
        //                case 3:
        //                    nombreArchivo = "FotoCiudad.jpg";
        //                    break;
        //            }

        //            
        //            var imagenBytes = File.ReadAllBytes(rutaArchivo);

        //            // Enviamos la imagen al cliente
        //            clienteSocket.Send(imagenBytes);
        //        }
        //    }
        //    catch (SocketException ex)
        //    {
        //        Console.WriteLine($"Error de socket: {ex.Message}");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error inesperado: {ex.Message}");
        //    }
        //}



        //public static void Main(string[] args)
        //{
        //    try
        //    {
        //        // Establecer la dirección IP y el puerto del servidor
        //        IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
        //        int port = 5000;

        //        // Crear un socket TCP/IP
        //        TcpListener server = new TcpListener(ipAddress, port);

        //        // Iniciar la escucha de conexiones entrantes
        //        server.Start();
        //        Console.WriteLine("Servidor iniciado en " + ipAddress + ":" + port);

        //        // Declarar la cantidad máxima de clientes simultáneos que aceptará el servidor
        //        int maxClients = 5;
        //        int numClients = 0;

        //        // Escuchar de manera indefinida las solicitudes de los clientes
        //        while (true)
        //        {
        //            // Aceptar la conexión entrante
        //            TcpClient client = server.AcceptTcpClient();

        //            // Verificar si ya se alcanzó la cantidad máxima de clientes
        //            if (numClients >= maxClients)
        //            {
        //                // Rechazar la conexión si ya no se aceptan más clientes
        //                client.Close();
        //                Console.WriteLine("Rechazando cliente porque se alcanzó el número máximo de clientes simultáneos");
        //            }
        //            else
        //            {
        //                // Iniciar un nuevo hilo para manejar la solicitud del cliente
        //                numClients++;
        //                Thread t = new Thread(() => ControlClientes(client, numClients));
        //                t.Start();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error: " + ex.Message);
        //    }
        //}

        //private static void ControlClientes(TcpClient client, int clientId)
        //{
        //    try
        //    {
        //        Console.WriteLine("Cliente #" + clientId + " conectado");
        //     //   String selection = "0";
        //     //   Console.WriteLine("Selection:{0}", selection);
        //        // Obtener la selección del cliente
        //        NetworkStream stream = client.GetStream();
        //        byte[] buffer = new byte[1024];
        //        while (true)
        //        {
        //            Console.WriteLine("Estoy delante selection");
        //            int bytesRead = stream.Read(buffer, 0, buffer.Length);
        //            String selection = Encoding.UTF8.GetString(buffer, 0, bytesRead);
        //            // do
        //            // {
        //            Console.WriteLine("Estoy tras selection {0}",selection);
        //            if (selection.Equals("1"))
        //            {
        //                Console.WriteLine("Estoy en monte");

        //                selection = "Monte";
        //            }
        //            else if (selection.Equals("2"))
        //            {
        //                selection = "Playa";
        //            }
        //            else if (selection.Equals("3"))
        //            {
        //                selection = "Ciudad";
        //            } 
        //            Console.WriteLine("Mandar foto {0}",selection);

        //            // Enviar la imagen seleccionada al cliente
        //            byte[] imageBytes = File.ReadAllBytes("imagenes/Foto" + selection + ".jpg");

        //            byte[] lengthBytes = BitConverter.GetBytes(imageBytes.Length);
        //            stream.Write(lengthBytes, 0, lengthBytes.Length);

        //            // Enviar la imagen
        //            stream.Write(imageBytes, 0, imageBytes.Length);

        //            buffer = new byte[1024];

        //            //stream.Write(imageBytes, 0, imageBytes.Length);
        //        }
        //        // } while (true && !selection.Equals("4"));

        //        // Cerrar la conexión con el cliente
        //        client.Close();
        //        Console.WriteLine("Cliente #" + clientId + " desconectado");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error: " + ex.Message);
        //    }


    }
    }
}