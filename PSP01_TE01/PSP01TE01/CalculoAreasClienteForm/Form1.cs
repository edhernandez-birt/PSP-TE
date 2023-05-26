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
        /// Se ejecuta al hacer click en el bot�n para lanzar el proceso
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLanzaProceso_Click(object sender, EventArgs e)
        {

            //Lanza el proceso usando el m�todo StartServer si el servidor no est� corriendo
            if (p == null || p.HasExited)
            {
                StartServer(out p);
                Task.Delay(1000).Wait();
                operacion = "";

                //Preparamos conexi�n del cliente con el servidor
                var client = new NamedPipeClientStream("PSP01_UD01TE01_Pipes");
                //Console.WriteLine("Conectando al servidor...");
                client.Connect();
                reader = new StreamReader(client);
                writer = new StreamWriter(client);
            }
            


            //Mostramos el ID del proceso en label
            labelProceso.Text= "Proceso c�lculo arrancado ID: "+p.Id.ToString();

            //Activamos radio buttons y bot�n finalizar proceso
            cambiaEnableA(true);

        }
        /// <summary>
        /// Se ejecuta al hacer click en el bot�n de calcular el �rea
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCalculaArea_Click(object sender, EventArgs e)
        {


            // Si est� elegido un c�rculo vemos si es posible enviar la operacion
            if (radioButtonCirculo.Checked)
            {
                if (!Single.TryParse(textBoxCirculo.Text, out float op))
                {
                    MessageBox.Show("Revise que el radio sea un n�mero", "ERROR al introducir datos del C�RCULO ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    operacion = null;
                }
                else //Hay datos v�lidos y seguimos
                {
                    operacion = "0 " + textBoxCirculo.Text + " 0";
                }
            }
            // Preparaci�n para tri�ngulo
            else if (radioButtonTriangulo.Checked)
            {
                if ((!Single.TryParse(textBoxTrianguloAltura.Text, out float op)) || (!Single.TryParse(textBoxTrianguloBase.Text, out float op2)))
                {
                    MessageBox.Show("Revise que los valores sean num�ricos", "ERROR al introducir datos del TRI�NGULO ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    operacion = null;
                }

                // Comentamos esta manera de revisar los valores m�s espec�fica y la borramos en el resto

                //if (!Single.TryParse(textBoxTrianguloAltura.Text, out float op))
                //{
                //    MessageBox.Show("El valor para la altura del tri�ngulo NO es un n�mero");
                //    operacion = null;
                //}
                //else if (!Single.TryParse(textBoxTrianguloBase.Text, out float op2))
                //{
                //    MessageBox.Show("El valor para la base del tri�ngulo NO es un n�mero");
                //    operacion = null;
                
                else  //Hay datos v�lidos y seguimos
                {
                    operacion = "3 " + textBoxTrianguloAltura.Text + " " + textBoxTrianguloBase.Text;
                }

            }
            //Preparaci�n para rect�ngulo
            else if (radioButtonRectangulo.Checked)
            {
                if ((!Single.TryParse(textBoxRectanguloAltura.Text, out float op)) || (!Single.TryParse(textBoxRectanguloBase.Text, out float op2)))
                {
                    MessageBox.Show("Revise que los valores sean num�ricos", "ERROR al introducir datos del RECT�NGULO ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    operacion = null;
                }
                else //Hay datos v�lidos y seguimos
                {
                    operacion = "4 " + textBoxRectanguloAltura.Text + " " + textBoxRectanguloBase.Text;
                }
            }
            //Preparaci�n para pent�gono
            else if (radioButtonPentagono.Checked)
            {
                if ((!Single.TryParse(textBoxPentagonoApotema.Text, out float op)) || (!Single.TryParse(textBoxPentagonoLado.Text, out float op2)))
                {
                    MessageBox.Show("Revise que los valores sean num�ricos", "ERROR al introducir datos del PENT�GONO ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        /// Se ejecuta al hacer click al bot�n de finalizar el proceso
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFin_Click(object sender, EventArgs e)
        {
            if (p!=null && !p.HasExited)
            {
                p.Kill();
                p= null;
                labelProceso.Text = "Proceso c�lculo parado";

                //Ponemos Enable a false en varios componentes
                cambiaEnableA(false);
                
                //Reseteamos el texto del label resultado
                labelResultado.Text = "Mostrar resultado";
            }
        }

        #endregion

        #region radioButtons
        //Hacemos que los textBoxes se activen si su radioButton est� activo
        //Ponemos a true el bot�n de Calcular Area
        private void radioButtonCirculo_CheckedChanged(object sender, EventArgs e)
        {
            textBoxCirculo.Enabled = radioButtonCirculo.Checked;
            //Si el boton de calcular area no est� activo, lo activamos
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


        #region M�todos auxiliares

        /// <summary>
        /// M�todo para arrancar proceso del ejecutable servidor
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

            //El bot�n de lanzar proceso hacemos lo contrario
            buttonLanzaProceso.Enabled = !b;

            //Si queremos dehabilitar radioButtons (enable=false), tambi�n lo hacemos con las TextBoxes
            //pero para habilitar no hace falta
            if (!b)
            {
                foreach (TextBox tb in this.Controls.OfType<TextBox>())
                 {
                    tb.Enabled = b;
                 }

                //Y desactivamos el bot�n de calcular �rea
                buttonCalculaArea.Enabled = false;
            }
            
        }
        #endregion
    }
}