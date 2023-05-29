using System.Collections.Concurrent;

namespace ejercicio1
{
    public class ej1
    {
        public static void Main(string[] args)
        {

            BlockingCollection<int> aPrimario = new BlockingCollection<int>(100);
            BlockingCollection<int> aSecundario = new BlockingCollection<int>(100);

            Task gros = Task.Run(() =>{
                while (!aPrimario.IsCompleted){
                    int bici = -1;
                    try{
                        //Se coge prestada una bici si hay disponibles
                        bici = aPrimario.Take();
                    }
                    //Se recoge la excepcion
                    catch (InvalidOperationException) { }

                    if (bici != -1)
                        Console.WriteLine("Un usuario en la zona de gros ha" +
                            " recogido la bicicleta {0} ", bici);
                    //Si la bici es multiplo de 3 se devuelve
                    if ((bici % 3) == 0){
                        //Cuando el almacen primario no esta cerrado la bici deveuelve ahi
                        if (!aPrimario.IsAddingCompleted){
                            aPrimario.Add(bici);
                            Console.WriteLine("Un usuario en la zona de gros ha devuelto la bicicleta {0}" +
                                " al almacen PRIMARIO ", bici);
                        }
                        else{
                            aSecundario.Add(bici);
                            Console.WriteLine("Un usuario en la zona de gros ha devuelto la bicicleta {0}" +
                                " al almacen SECUNDARIO ", bici);
                        }
                    }
                }
            });

            Task amara = Task.Run(() =>{
                while (!aPrimario.IsCompleted){
                    int bici = -1;
                    try
                    {
                        bici = aPrimario.Take();
                    }
                    //Recogemos una excepción que no vamos a tratar en este ejercicio. Entraría dentro del catch si hay una operación no válida.
                    catch (InvalidOperationException) { }
                    
                    if (bici != -1)
                        Console.WriteLine("Un usuario en la zona de amara ha recogido la bicicleta {0} ", bici);
                }
            });

            Task proveedor = Task.Run(() =>{
                int bici = 0;
                bool anadirElemento = true;

                while (anadirElemento){

                    aPrimario.Add(bici);
                    Console.WriteLine("Anadir la bicicleta {0}", bici);
                    bici++;
                    if (bici == 200)
                        anadirElemento = false;
                }
                // La colección no va a aceptar más elementos
                aPrimario.CompleteAdding();
                Console.WriteLine("Almacen primario cerrado");
            });
            gros.Wait();
            amara.Wait();
            proveedor.Wait();
            Console.WriteLine(" Hay {0} bicicletas almacenadas en el almacen secundario", aSecundario.Count);
            while (true) { }
        }
    }
}
