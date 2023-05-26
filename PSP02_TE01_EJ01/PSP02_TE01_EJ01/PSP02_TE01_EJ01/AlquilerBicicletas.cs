using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;


namespace alquilerBicicletas
{
    class AlquilerBicicletas
    {
        static void Main(string[] args)
        {
            // Creamos los almacenes como Blocking Collections de 100 enteros.
            // Almacén principal
            BlockingCollection<int> dataItemsAlmacenPrincipal = new BlockingCollection<int>(100);

            // Almacén secundario
            BlockingCollection<int> dataItemsAlmacenSecundario = new BlockingCollection<int>(100);

            // Int stock secundario
            int stockSecundario = 0;

            // Tarea que realiza función de PRODUCTOR. Produce las 200 bicis que se irán añadiendo a la BlockingCollection del almacén principal.

            // Función lambda que compra bicicletas para el almacén principal.
            Task tareaProductor = Task.Run(() =>
            {
                int numeroBici = 0;
                // bool permitidoCargarBicis = true;

                //Mientras no se marque como CompleteAdding...
                while (!dataItemsAlmacenPrincipal.IsAddingCompleted)
                {
                    try
                    {
                        // Añadimos la bici identificada por el entero cantidadBicis al almacén principal.
                        dataItemsAlmacenPrincipal.Add(numeroBici);
                        Console.WriteLine("La empresa de bicis ha comprado la bicicleta {0} y la manda al almacen principal", numeroBici);

                        //Aumentamos el número la bicicleta
                        numeroBici++;
                    }
                    catch (InvalidOperationException) { }


                    //Mostramos las bicis que hay en el almacén principal en este momento. Para ir viendo como de lleno está
                    Console.WriteLine("En el almacén principal hay {0} bicis", dataItemsAlmacenPrincipal.Count);


                    //Si el número de bici ha llegado al máximo de 200 bicis terminamos el while. (Hay bici desde la 0 hasta la 199, la 200 ya no la compramos)
                    if (numeroBici == 200)
                    {
                        //Cuando se llegue a la cantidad de 200 bicicletas ya no se comprarán más bicis.
                        //permitidoCargarBicis = false;
                        dataItemsAlmacenPrincipal.CompleteAdding();
                        Console.WriteLine("\nCIERRE DE ALMACÉN. Nadie podrá depositar más bicicletas en el Almacén principal\n");

                    }
                }
            });

            // Tarea que realiza función de CONSUMIDOR de GROS. Consume y devueve elementos a los almacenes (BlockingCollection)
            Task tareaConsumidorGros = Task.Run(() =>
            {
                //Mientras no está AddingCompleted el almacén principal se va a intentar consumir del principal y devolverle a él también
                while (!dataItemsAlmacenPrincipal.IsAddingCompleted)
                {

                    int numeroBici = -1;
                    // Se bloquea sí dataItems.Count == 0. Es decir si no hay elemento para consumir se queda a la espera

                    try
                    {
                        //Thread.Sleep(20); //Consumidor duerme hilo 2 segundos.
                        //Cogemos un elemento de la colección de dataItems.
                        //Si no hay nada para coger, se queda la tarea esperando hasta que haya algún elemento para coger.
                        numeroBici = dataItemsAlmacenPrincipal.Take();


                    }
                    //Recogemos una excepción que no tratamos
                    catch (InvalidOperationException) { }

                    if (numeroBici != -1)
                    {
                        Console.WriteLine("Un usuario de GROS ha usado la bicicleta {0}", numeroBici);
                        //Si la bici es múltiplo de 3 devolvemos la bici 
                        if (numeroBici % 3 == 0)
                        {
                            Console.WriteLine("En el almacén principal hay {0}", dataItemsAlmacenPrincipal.Count);

                            try
                            {
                                dataItemsAlmacenPrincipal.Add(numeroBici);
                                Console.WriteLine("Un usuario de GROS ha devuelto la bicicleta {0} al almacén PRINCIPAL", numeroBici);
                            }
                            catch (InvalidOperationException) { }
                        }

                    }

                }

                //Cuando lo marcamos como Adding Completed, pero hay stock en el almacén principal hay que devolver al almacén secundario
                while (dataItemsAlmacenPrincipal.Count > 0)
                {
                    int numeroBici = -1;
                    try
                    {
                        //Thread.Sleep(2); //Consumidor duerme hilo 2 segundos.
                        //Cogemos un elemento de la colección de dataItems.
                        //Si no hay nada para coger, se queda la tarea esperando hasta que haya algún elemento para coger.
                        numeroBici = dataItemsAlmacenPrincipal.Take();


                    }
                    //Recogemos una excepción que no tratamos
                    catch (InvalidOperationException) { }

                    if (numeroBici != -1)
                    {
                        //Si la bici es múltiplo de 3 devolvemos la bici al secundario
                        Console.WriteLine("Un usuario de GROS ha usado la bicicleta {0}", numeroBici);
                        if (numeroBici % 3 == 0)
                        {
                            //Para saber cuántas bicis hay ya en el almacén principal cuando se devuelve alguna
                            Console.WriteLine("En el almacén principal hay {0} bicis", dataItemsAlmacenPrincipal.Count);
                            try
                            {
                                Console.WriteLine("El almacén principal está BLOQUEADO, se depositarán las bicis en el almacén SECUNDARIO", numeroBici);
                                dataItemsAlmacenSecundario.Add(numeroBici);
                                Console.WriteLine("Un usuario de GROS ha devuelto la bicicleta {0} al almacén SECUNDARIO", numeroBici);
                            }
                            catch (InvalidOperationException) { }
                        }

                    }
                }
                //Si no hay nada por consumir, muestra este mensaje por pantalla.
                Console.WriteLine("\nEn la zona de GROS NO HAY más bicis disponibles\n");
                stockSecundario = dataItemsAlmacenSecundario.Count;
            });

            // Tarea que realiza función de CONSUMIDOR de AMARA. Consume y devueve elementos a los almacenes (BlockingCollection)
            Task tareaConsumidorAmara = Task.Run(() =>
            {
                //Mientras no está completo el almacén principal se va a intentar consumir de ahí y se van a cargar bicis nuevas
                while (!dataItemsAlmacenPrincipal.IsAddingCompleted)
                {

                    int numeroBici = -1;
                    // Se bloquea sí dataItems.Count == 0. Es decir si no hay elemento para consumir se queda a la espera

                    try
                    {
                        //Si no hay nada para coger, se queda la tarea esperando hasta que haya algún elemento para coger.
                        numeroBici = dataItemsAlmacenPrincipal.Take();


                    }
                    //Recogemos una excepción que no vamos a tratar en este ejercicio. Entraría dentro del catch si hay una operación no válida.
                    catch (InvalidOperationException) { }

                    if (numeroBici != -1)
                    {
                        Console.WriteLine("Un usuario de AMARA ha usado la bicicleta {0}", numeroBici);
                        //Si la bici es múltiplo de 5 devolvemos la bici 

                        //ESTA PARTE SE DEBERÍA COMENTAR para evitar que ocurra la casualidad de que se llene el almacén principal
                        //y todas las tareas sean productoras. No la comento porque al final me funciona bien casi siempre

                        if (numeroBici % 5 == 0)
                        {
                            //Para saber cuántas bicis hay ya en el almacén principal cuando se devuelve alguna.
                            //Si marca 100 puede haber bloqueo si son todas las tareas productoras (están haciendo Add al Almacén principal)
                            Console.WriteLine("En el almacén principal hay {0} bicis", dataItemsAlmacenPrincipal.Count);
                            try
                            {
                                dataItemsAlmacenPrincipal.Add(numeroBici);
                                Console.WriteLine("Un usuario de AMARA ha devuelto la bicicleta {0} al almacén PRINCIPAL", numeroBici);
                            }
                            catch (InvalidOperationException) { }
                        }
                    }

                }

                //Cuando lo marcamos como Adding Completed hay que devolver al almacén secundario mientras haya stock en el almacén principal
                while (dataItemsAlmacenPrincipal.Count > 0)
                {
                    int numeroBici = -1;

                    try
                    {
                        //Thread.Sleep(2); //Consumidor duerme hilo 2 segundos.
                        //Cogemos un elemento de la colección de dataItems.
                        //Si no hay nada para coger, se queda la tarea esperando hasta que haya algún elemento para coger.
                        numeroBici = dataItemsAlmacenPrincipal.Take();


                    }
                    //Recogemos una excepción que no vamos a tratar en este ejercicio. Entraría dentro del catch si hay una operación no válida.
                    catch (InvalidOperationException) { }

                    if (numeroBici != -1)
                    {
                        Console.WriteLine("Un usuario de AMARA ha usado la bicicleta {0}", numeroBici);

                        //Si la bici es múltiplo de 5 devolvemos la bici al secundario

                        if (numeroBici % 5 == 0)
                        {
                            //Para saber cuántas bicis hay ya en el almacén principal cuando se devuelve alguna
                            Console.WriteLine("En el almacén principal hay {0} bicis", dataItemsAlmacenPrincipal.Count);
                            try
                            {
                                Console.WriteLine("El almacén principal está BLOQUEADO, se depositarán las bicis en el almacén SECUNDARIO", numeroBici);
                                dataItemsAlmacenSecundario.Add(numeroBici);
                                Console.WriteLine("Un usuario de AMARA ha devuelto la bicicleta {0} al almacén SECUNDARIO", numeroBici);
                            }
                            catch (InvalidOperationException) { }
                        }

                    }
                }
                //Si no hay nada por consumir se acaban los while y muestra este mensaje por pantalla.
                Console.WriteLine("\nEn la zona de AMARA NO HAY más bicis disponibles\n");
                stockSecundario = dataItemsAlmacenSecundario.Count;

            });

            //Ejecutamos las tareas de forma síncrona con wait.
            tareaConsumidorAmara.Wait();
            tareaConsumidorGros.Wait();
            tareaProductor.Wait();

            //Cuando finalizan las tareas que muestre las bicis que han quedado en el almacén secundario
            Console.WriteLine("\nRESULTADO FINAL: En el almacén SECUNDARIO HAN QUEDADO {0} bicis\n", stockSecundario);
        }
    }
}