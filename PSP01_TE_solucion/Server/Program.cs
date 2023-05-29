using System;
using System.IO;
using System.IO.Pipes;


namespace Server
{
    class Program
    {
        //Programa main Servidor
        //Realizar los cálculos
        static void Main(string[] args)
        {
            try
            {
                // Conexión con el cliente mediante el pipe nombre PipeAreas. El servidor se queda esperando datos.
                var server = new NamedPipeServerStream("PipeAreas");
                server.WaitForConnection();
                Console.WriteLine("Pipe Servidor esperando datos.");

                // Creación de flujo de entrada y salida de datos.
                StreamReader reader = new StreamReader(server);
                StreamWriter writer = new StreamWriter(server);

                // Bucle que está continuamente activo
                while (true)
                {
                    // Llegan los datos del cliente y se muestran en la consola del servidor
                    var line = reader.ReadLine();
                    Console.WriteLine("Pipe Servidor procesando datos: '" + line + "'");

                    // Creamos un array con los datos que nos envía el cliente y convertimos los números a double. num2 no es necesario en el caso del círculo,
                    // por eso lo he metido en el if para comprobar si es necesario o no.
                    string[] datos = line.Split(' ');

                    double num1 = double.Parse(datos[1]);
                    double num2 = 0;

                    if (!string.IsNullOrEmpty(datos[2]))
                    {
                        num2 = double.Parse(datos[2]);
                    }

                    // Dependiendo de la figura que se seleccione en el cliente se mostrará en la consola del servidor un texto y se calculará el área.

                    double resultado = 0;
                    switch (datos[0])
                    {
                        case "Circulo":
                            Console.WriteLine("Pipe Servidor operación: '" + datos[1] + " radio ´circulo");
                            resultado = Math.PI * Math.Pow(num1,2);
                            break;
                        case "Triangulo":
                            Console.WriteLine("Pipe Servidor operación: '" + datos[1] + " con base triangulo y altura " + datos[2]);
                            resultado = (num1 * num2) / 2;
                            break;
                        case "Rectangulo":
                            Console.WriteLine("Pipe Servidor operación: '" + datos[1] + " con base rectangulo y altura " + datos[2]);
                            resultado = (num1 * num2);
                            break;
                        case "Pentagono":
                            Console.WriteLine("Pipe Servidor operación: '" + datos[1] + " lado pentagono y apotema " + datos[2]);
                            resultado = (num1 * 5 * num2) / 2;
                            break;
                    }

                    // Se muestra en la consola del servidor el resultado y se envía al cliente.
                    Console.WriteLine("Pipe Servidor datos enviados: '" + resultado + "'");
                    writer.WriteLine(resultado.ToString());

                    // Limpieza del buffer
                    writer.Flush();

                }
                //Cierre de las variables del flujo de datos
                writer.Close();
                reader.Close();
            }
            // Gestión de excepciones
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }
        }
    }
}
