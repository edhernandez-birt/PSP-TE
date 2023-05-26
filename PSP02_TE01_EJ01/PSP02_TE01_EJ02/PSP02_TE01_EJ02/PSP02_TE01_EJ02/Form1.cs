using System.Diagnostics;
using System.Security.Cryptography;

namespace PSP02_TE01_EJ02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Para el fin del programa
            Application.ApplicationExit += new EventHandler(OnApplicationExit);
        }

        //Evento al hacer click en el botón para empezar la carrera
        private void buttonEmpezar_Click(object sender, EventArgs e)
        {
            //Desactivamos botón para que no deje empezar dos veces la carrera
            buttonEmpezar.Enabled = false;

            //Desactivamos botón de reiniciar para que no deje reiniciar durante la carrera
            buttonReiniciar.Enabled = false;

            //No hay ganador al inicio
            ganador = -1;

            //Creamos los hilos para cada caballo

            Thread tCaballo1 = new Thread(Correr);
            Thread tCaballo2 = new Thread(Correr);
            Thread tCaballo3 = new Thread(Correr);
            Thread tCaballo4 = new Thread(Correr);

            //Damos distintas prioridadades a los hilos
            tCaballo1.Priority = ThreadPriority.AboveNormal;
            tCaballo2.Priority = ThreadPriority.Normal;
            tCaballo3.Priority = ThreadPriority.Lowest;
            tCaballo4.Priority = ThreadPriority.BelowNormal;

            //Ponemos nombres a los hilos
            tCaballo1.Name = "hiloCaballo1";
            tCaballo2.Name = "hiloCaballo2";
            tCaballo3.Name = "hiloCaballo3";
            tCaballo4.Name = "hiloCaballo4";

            //Añadimos los hilos a una lista 
            threads.Add(tCaballo1); threads.Add(tCaballo2); threads.Add(tCaballo3); threads.Add(tCaballo4); 

            //Arrancamos los hilos (No usamos join al final)
            tCaballo1.Start(0);
           // tCaballo1.Join(0);

            tCaballo2.Start(1);
           // tCaballo2.Join(1);

            tCaballo3.Start(2);
           // tCaballo3.Join(2);

            tCaballo4.Start(3);
            // tCaballo4.Join(3);


            //Con hilos iguales sin prioridad se podría hacer con un for
            //Thread[] caballo = new Thread[caballos];
            //for (int i = 0; i < caballos; i++)
            //{
            //    caballo[i] = new Thread(Correr);
            //    caballo[i].Start(i);
            //    caballo[i].Join(i);
            //}

        }

        //Evento al pulsar el botón de reiniciar
        private void buttonReiniciar_Click(object sender, EventArgs e)
        {
            //Ponemos a cero las ProgressBar
            foreach (ProgressBar pb in this.Controls.OfType<ProgressBar>())
            {
                pb.Value = 0;
            }

            //Reactivamos botón empezar
            buttonEmpezar.Enabled = true;

            //Limpiamos texto del resultado
            textBoxResultado.Text = "RESULTADO:";

            //Reseteamos el array que guarda los avances de cada caballo
            for (int i = 0; i < arrayAvance.Length; i++)
            {
                arrayAvance[i] = 0;
            }
            //De momento no hay ganador
            ganador = -1;

            //Borramos todos los threads de la lista
            threads.Clear();

        }

        //Método que ejecutan los hilos para simular el avance de los caballos
        private void Correr(object id)
        {
            //Distancia recorrida por cada caballo
            int distanciaRecorrida = 0;

            //Mientras no haya ganador
            while (ganador<0)
            {
                //Bloqueamos la parte del avance
                lock (bloqueo)
                {
                    if (ganador<0)
                    {
                        //Avanzamos un entero random entre 1 y 10 (La barra completa son 100)
                        Random rnd = new Random();
                        int avance = rnd.Next(1, 10);

                        //El total de metros recorridos lo vamos contando
                        distanciaRecorrida += avance;

                        //Para que no se pase del 100% de la barra y decretar el ganador
                        if (distanciaRecorrida >= 100)
                        {
                            distanciaRecorrida = 100;
                            ganador = (int)id;
                        }
                        //Guardamos la distancia en su posición
                        arrayAvance[(int)id] = distanciaRecorrida;

                        //Mostramos su avance en la progressBar correspondiente
                        if ((int)id == 0)
                        {
                            Invoke(new Action(() => progressBarCaballo1.Value = distanciaRecorrida));
                        }
                        else if ((int)id == 1)
                        {
                            Invoke(new Action(() => progressBarCaballo2.Value = distanciaRecorrida));
                        }
                        else if ((int)id == 2)
                        {
                            Invoke(new Action(() => progressBarCaballo3.Value = distanciaRecorrida));
                        }
                        else if ((int)id == 3)
                        {
                            Invoke(new Action(() => progressBarCaballo4.Value = distanciaRecorrida));
                        }


                        //Ya tenemos la barras como tienen que estar y mostramos los resultados si existe ganador
                        if (ganador>=0)
                        {
                            MostrarResultado(ganador);
                            //Tambien activamos boton de reiniciar
                            Invoke(new Action(() =>buttonReiniciar.Enabled= true));
                        }
                    }
                   
                }
                //Vamos a esperar 200 milisegundos para cada avance aleatorio
                    Thread.Sleep(200);
            }
        }

        //Método para mostrar el resultado en el textBox
        private void MostrarResultado(int ganador)
        {
            Invoke(new Action(() => textBoxResultado.Text = "RESULTADO: " + System.Environment.NewLine));
            Invoke(new Action(() => textBoxResultado.Text += "Ganador caballo: " + (ganador +1) + System.Environment.NewLine));
            Invoke(new Action(() => textBoxResultado.Text += "Caballo 1: " + progressBarCaballo1.Value + System.Environment.NewLine));
            Invoke(new Action(() => textBoxResultado.Text += "Caballo 2: " + progressBarCaballo2.Value + System.Environment.NewLine));
            Invoke(new Action(() => textBoxResultado.Text += "Caballo 3: " + progressBarCaballo3.Value + System.Environment.NewLine));
            Invoke(new Action(() => textBoxResultado.Text += "Caballo 4: " + progressBarCaballo4.Value + System.Environment.NewLine));
        }

        //Método para aplicar al pulsar la X de fin de programa
        private void OnApplicationExit(object sender, EventArgs e)
        {
      
            try
            {
                String mensaje = "Cerramos aplicación y comprobamos estado threads:\n";
                foreach (Thread th in threads)
                {
                        mensaje += th.Name +" está vivo: " + th.IsAlive +"\n ";
                       // th.Abort() //Necesitaría try-catch con ThreadAbortException;
                }
                MessageBox.Show(mensaje,"Fin del programa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
    }
}