using System.Diagnostics;
using System.IO.Pipes;

namespace PSP01TE01FORM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Botones
        /// <summary>
        /// Se ejecuta al hacer click en el botón para lanzar el proceso
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLanzaProceso_Click(object sender, EventArgs e)
        {

            //Lanza el proceso usando el método StartServer si el servidor no está corriendo
            if (p == null || p.HasExited)
            {
                StartServer(out p);
                Task.Delay(1000).Wait();
                operacion = "";

                //Preparamos conexión del cliente con el servidor
                var client = new NamedPipeClientStream("PSP01_UD01TE01_Pipes");
                //Console.WriteLine("Conectando al servidor...");
                client.Connect();
                reader = new StreamReader(client);
                writer = new StreamWriter(client);
            }
            


            //Mostramos el ID del proceso en label
            labelProceso.Text= "Proceso cálculo arrancado ID: "+p.Id.ToString();

            //Activamos radio buttons y botón finalizar proceso
            cambiaEnableA(true);

        }
        /// <summary>
        /// Se ejecuta al hacer click en el botón de calcular el área
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCalculaArea_Click(object sender, EventArgs e)
        {


            // Si está elegido un círculo vemos si es posible enviar la operacion
            if (radioButtonCirculo.Checked)
            {
                if (!Single.TryParse(textBoxCirculo.Text, out float op))
                {
                    MessageBox.Show("Revise que el radio sea un número", "ERROR al introducir datos del CÍRCULO ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    operacion = null;
                }
                else //Hay datos válidos y seguimos
                {
                    operacion = "0 " + textBoxCirculo.Text + " 0";
                }
            }
            // Preparación para triángulo
            else if (radioButtonTriangulo.Checked)
            {
                if ((!Single.TryParse(textBoxTrianguloAltura.Text, out float op)) || (!Single.TryParse(textBoxTrianguloBase.Text, out float op2)))
                {
                    MessageBox.Show("Revise que los valores sean numéricos", "ERROR al introducir datos del TRIÁNGULO ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    operacion = null;
                }

                // Comentamos esta manera de revisar los valores más específica y la borramos en el resto

                //if (!Single.TryParse(textBoxTrianguloAltura.Text, out float op))
                //{
                //    MessageBox.Show("El valor para la altura del triángulo NO es un número");
                //    operacion = null;
                //}
                //else if (!Single.TryParse(textBoxTrianguloBase.Text, out float op2))
                //{
                //    MessageBox.Show("El valor para la base del triángulo NO es un número");
                //    operacion = null;
                
                else  //Hay datos válidos y seguimos
                {
                    operacion = "3 " + textBoxTrianguloAltura.Text + " " + textBoxTrianguloBase.Text;
                }

            }
            //Preparación para rectángulo
            else if (radioButtonRectangulo.Checked)
            {
                if ((!Single.TryParse(textBoxRectanguloAltura.Text, out float op)) || (!Single.TryParse(textBoxRectanguloBase.Text, out float op2)))
                {
                    MessageBox.Show("Revise que los valores sean numéricos", "ERROR al introducir datos del RECTÁNGULO ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    operacion = null;
                }
                else //Hay datos válidos y seguimos
                {
                    operacion = "4 " + textBoxRectanguloAltura.Text + " " + textBoxRectanguloBase.Text;
                }
            }
            //Preparación para pentágono
            else if (radioButtonPentagono.Checked)
            {
                if ((!Single.TryParse(textBoxPentagonoApotema.Text, out float op)) || (!Single.TryParse(textBoxPentagonoLado.Text, out float op2)))
                {
                    MessageBox.Show("Revise que los valores sean numéricos", "ERROR al introducir datos del PENTÁGONO ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    operacion = null;
                }
                else
                {
                    operacion = "5 " + textBoxPentagonoLado.Text + " " + textBoxPentagonoApotema.Text;
                }

            }
            //Enviamos la operacion si no es null
            if (operacion != null)
            {
                writer.WriteLine(operacion);
                //Limpiamos el Stream de escritura
                writer.Flush();
                //Leemos el resultado
                labelResultado.Text = "Resultado: " + reader.ReadLine() + " cm^2";
            }
        }

        /// <summary>
        /// Se ejecuta al hacer click al botón de finalizar el proceso
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFin_Click(object sender, EventArgs e)
        {
            if (p!=null && !p.HasExited)
            {
                p.Kill();
                p= null;
                labelProceso.Text = "Proceso cálculo parado";

                //Ponemos Enable a false en varios componentes
                cambiaEnableA(false);
                
                //Reseteamos el texto del label resultado
                labelResultado.Text = "Mostrar resultado";
            }
        }

        #endregion

        #region radioButtons
        //Hacemos que los textBoxes se activen si su radioButton está activo
        //Ponemos a true el botón de Calcular Area
        private void radioButtonCirculo_CheckedChanged(object sender, EventArgs e)
        {
            textBoxCirculo.Enabled = radioButtonCirculo.Checked;
            //Si el boton de calcular area no está activo, lo activamos
            if (!buttonCalculaArea.Enabled)
            {
                buttonCalculaArea.Enabled = true;
            }
        }

        private void radioButtonTriangulo_CheckedChanged(object sender, EventArgs e)
        {
            textBoxTrianguloBase.Enabled = radioButtonTriangulo.Checked;
            textBoxTrianguloAltura.Enabled = radioButtonTriangulo.Checked;
            if (!buttonCalculaArea.Enabled)
            {
                buttonCalculaArea.Enabled = true;
            }
        }

        private void radioButtonRectangulo_CheckedChanged(object sender, EventArgs e)
        {
            textBoxRectanguloBase.Enabled = radioButtonRectangulo.Checked;
            textBoxRectanguloAltura.Enabled= radioButtonRectangulo.Checked;
            if (!buttonCalculaArea.Enabled)
            {
                buttonCalculaArea.Enabled = true;
            }
        }

        private void radioButtonPentagono_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPentagonoLado.Enabled = radioButtonPentagono.Checked;
            textBoxPentagonoApotema.Enabled = radioButtonPentagono.Checked;
            if (!buttonCalculaArea.Enabled)
            {
                buttonCalculaArea.Enabled = true;
            }
        }

        #endregion


        #region Métodos auxiliares

        /// <summary>
        /// Método para arrancar proceso del ejecutable servidor
        /// </summary>
        /// <param name="p1"></param>
        /// <returns></returns>
        static Process StartServer(out Process p1)
        {
            // iniciar un proceso con el programa servidor y devolverlo
            ProcessStartInfo info = new ProcessStartInfo(@"..\..\..\..\CalculoAreasServidor\bin\Release\net6.0\win-x64\CalculoAreasServidor.exe");

            //Se "crea" ventana
            info.CreateNoWindow = false;
            //Estilo de ventana
            info.WindowStyle = ProcessWindowStyle.Normal;
            // Utiliza shell para lanzar el proceso
            info.UseShellExecute = true;
            p1 = Process.Start(info);
            return p1;
        }

        /// <summary>
        /// Pone a true o false varios radioButton y buttons
        /// </summary>
        /// <param name="b"></param>
        private void cambiaEnableA (bool b)
        {
            //Los RadioButton siempre hacemos el cambio de todos al arrancar o al parar.
            foreach (RadioButton rb in this.Controls.OfType<RadioButton>())
            {
                rb.Enabled = b;
            }
            // Nos ahorramos esto con el foreach
            //radioButtonCirculo.Enabled = b;
            //radioButtonTriangulo.Enabled = b;
            //radioButtonRectangulo.Enabled = b;
            //radioButtonPentagono.Enabled = b;
            
            //Activar o desactivar boton fin
            buttonFin.Enabled = b;

            //El botón de lanzar proceso hacemos lo contrario
            buttonLanzaProceso.Enabled = !b;

            //Si queremos dehabilitar radioButtons (enable=false), también lo hacemos con las TextBoxes
            //pero para habilitar no hace falta
            if (!b)
            {
                foreach (TextBox tb in this.Controls.OfType<TextBox>())
                 {
                    tb.Enabled = b;
                 }

                //Y desactivamos el botón de calcular área
                buttonCalculaArea.Enabled = false;
            }
            
        }
        #endregion
    }
}