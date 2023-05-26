using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Ejercicio2
{
    public class ClienteFotos
    {
        public static void Main(string[] args)
        {
            // Directorio local en el que se descargan las imágenes
            // En C:/ puede dar problemas de permisos y pongo D:/
            // que es una ruta que casi todos tenemos
            string rutaDescarga = "D:/";

            // Debería crear el TcpClient aquí, pero algo estaba haciendo mal
            // que solo me funcionaba la primera vez que enviaba la imagen
            // porque tengo que cerrar la conexión

            // Muestra el menú al usuario
            while (true)
            {
                MuestraMenuFotos();
                string localizacion = "-1";

                //Leemos la opción elegida
                string opcion = Console.ReadLine();

                if (opcion == "1" || opcion == "2" || opcion == "3" || opcion == "4")
                {
                    //He tenido que introducir aquí la creación del TcpClient que no debería
                    //El servidor para enviar el fichero me tiene que cerrar la conexión...
                    //Puede que sea una tontería, pero me he bloqueado y solo me funciona así.

                    TcpClient client = new TcpClient("127.0.0.1", 12000);
                    NetworkStream stream = client.GetStream();
                    StreamWriter writer = new StreamWriter(stream);

                    if (opcion == "1")
                    {
                        localizacion = "Monte";
                    }
                    else if (opcion == "2")
                    {
                        localizacion = "Playa";
                    }
                    else if (opcion == "3")
                    {
                        localizacion = "Ciudad";
                    }
                    else if (opcion == "4")
                    {
                        localizacion = "Salir";
                    }
                    // Envía la selección del usuario al servidor (mando el número pero guardo el nombre para el fichero)
                    writer.WriteLine(opcion);
                    writer.Flush();

                    // Cerrar la conexión con el servidor si hemos escrito 4 (hemos mandado el "4" al servidor para que lo sepa)
                    if (opcion == "4")
                    {
                        Console.WriteLine("Fin del programa");
                        writer.Close();
                        stream.Close();
                        client.Close();
                        break;
                    }

                    //Reparamos la rutaCompleta
                    string rutaCompleta = Path.Combine(rutaDescarga, "Foto" + localizacion + ".jpg");
                    // Recibe la imagen del servidor y la guarda en un archivo local en la ruta de descarga configurada al inicio
                    try
                    {
                        FileStream fileStream = new FileStream(rutaCompleta, FileMode.Create);
                        stream.CopyTo(fileStream);
                        fileStream.Close();
                        writer.Close();
                        stream.Close();
                        client.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine(e.StackTrace);
                    }

                    //BinaryReader reader = new BinaryReader(stream);

                    //// Lee el tamaño de la imagen
                    //int imagenSize = reader.ReadInt32();

                    //// Lee los datos de la imagen
                    //byte[] imagenBytes = reader.ReadBytes(imagenSize);

                    //Otras pruebas con Binary Reader
                    //int bufferSize = 1024;
                    //byte[] buffer = new byte[bufferSize];
                    //int bytesRead = 0;
                    //MemoryStream memoryStream = new MemoryStream();
                    //do
                    //{
                    //    bytesRead = reader.Read(buffer, 0, bufferSize);
                    //    memoryStream.Write(buffer, 0, bytesRead);
                    //} while (bytesRead > 0);

                    //byte[] imageBytes = memoryStream.ToArray();

                    //Pruebas con Filestream
                    //Console.WriteLine("La imagen ocupa: {0} bytes",imagenBytes.Length);

                    //https://stackoverflow.com/questions/6397235/write-bytes-to-file
                    //try
                    //{
                    //    using (var fs = new FileStream(rutaCompleta, FileMode.Create, FileAccess.Write))
                    //    {
                    //        fs.Write(imagenBytes, 0, imagenBytes.Length);  
                    //    }
                    //}
                    //catch (Exception e)
                    //{
                    //    Console.WriteLine("Error: {0}", e);
                    //}

                    // Muestra la ruta del archivo local al usuario
                    Console.WriteLine("---------------------------------------");
                    Console.WriteLine("Imagen descargada en: {0}", rutaCompleta);
                    Console.WriteLine("---------------------------------------");

                }

                else
                {
                    Console.WriteLine("Opción no válida");
                }
            }
        }
        public static void MuestraMenuFotos()
        {
            Console.WriteLine("------------CLIENTE FOTOS-------------");
            Console.WriteLine("1. FotoMonte");
            Console.WriteLine("2. FotoPlaya");
            Console.WriteLine("3. FotoCiudad");
            Console.WriteLine("4. Salir");
            Console.WriteLine("Seleccione una opción: ");
            Console.WriteLine("---------------------------------------");
        }
    }
}