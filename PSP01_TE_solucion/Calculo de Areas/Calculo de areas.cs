using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Pipes;
using System.Runtime.CompilerServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Calculo_de_Areas
{
    public partial class Form1 : Form
    {

        /*+++++++++++++++++++++++++++++++++++++++ Atributos ++++++++++++++++++++++++++++++++++++++++*/
        private Process p1 = null;
        private StreamReader reader;
        private StreamWriter writer;

        /***************************************Constructor****************************************/

        public Form1()
        {
            InitializeComponent();
        }




        /*+++++++++++++++++++++++++++++++++++++++ Acciones Radio Buttons ++++++++++++++++++++++++++++++++++++++++*/
        /*Cambio del check círculo*/
        private void r_circulo_CheckedChanged(object sender, EventArgs e)
        {
            // Deshabilitamos los elementos que estén habilitados si ha habido un cálculo anterior
            DeshabilitarElementos();

            // Habilitamos elementos de circulo
            lb_circulo.Enabled = true;
            tb_radioCirculo.Enabled = true;

            // Habilitamos botón de cálculo, cuadro de resultado y botón de finalizar proceso.
            HabilitarElementos();
        }
        /*Cambio del check triangulo*/
        private void r_triangulo_CheckedChanged(object sender, EventArgs e)
        {
            // Deshabilitamos los elementos que estén habilitados si ha habido un cálculo anterior
            DeshabilitarElementos();

            // Habilitamos elementos de triangulo
            lb_triangulo1.Enabled = true;
            tb_baseTriangulo.Enabled = true;
            lb_trinagulo2.Enabled = true;
            tb_alturaTriangulo.Enabled = true;

            // Habilitamos botón de cálculo, cuadro de resultado y botón de finalizar proceso.
            HabilitarElementos();
        }
        /*Cambio del check rectangulo*/
        private void r_rectangulo_CheckedChanged(object sender, EventArgs e)
        {
            // Deshabilitamos los elementos que estén habilitados si ha habido un cálculo anterior
            DeshabilitarElementos();

            // Habilitamos elementos de rectangulo
            lb_rectangulo1.Enabled = true;
            tb_baseRectangulo.Enabled = true;
            lb_rectangulo2.Enabled = true;
            tb_alturaRectangulo.Enabled = true;

            // Habilitamos botón de cálculo, cuadro de resultado y botón de finalizar proceso.
            HabilitarElementos();
        }
        /*Cambio del check pentagono*/
        private void r_pentagono_CheckedChanged(object sender, EventArgs e)
        {
            // Deshabilitamos los elementos que estén habilitados
            DeshabilitarElementos();

            // Habilitamos elementos de pentagono
            lb_pentagono1.Enabled = true;
            tb_ladoPentagono.Enabled = true;
            lb_pentagono2.Enabled = true;
            tb_Apotema.Enabled = true;

            // Habilitamos botón de cálculo, cuadro de resultado y botón de finalizar proceso.
            HabilitarElementos();

        }

        /*+++++++++++++++++++++++++++++++++++++++ Acciones Botones ++++++++++++++++++++++++++++++++++++++++*/
        /*Clickar lanzamiendo de proceso*/
        private void btn_lanzarProceso_Click(object sender, EventArgs e)
        {
            // Crear proceso 
            ArrancarServidor();
            Task.Delay(1000).Wait();

            // Inicializar pipe con el mismo nombre que en el servidor y nos conectamos.
            var cliente = new NamedPipeClientStream("PipeAreas");
            cliente.Connect();

            // Creamos el reader y el writer para la comunicación con el servidor
            reader = new StreamReader(cliente);
            writer = new StreamWriter(cliente);

            // Escribimos en el cuadro de texto que el proceso está arrancado y su ID
            tb_proceso.Text = "Proceso Calculo Arrancado ID: " + p1.Id;

            // Habilitamos RadioButtons y deshabilitamos resto de elementos
            HabilitarRadioButtons();
            DeshabilitarElementos();

            // Deshabilitar botón para lanzar el proceso. Si se pulsa el botón estando el proceso iniciado da error.
            btn_lanzarProceso.Enabled = false;

            // Habilitar el botón para finalizar proceso
            btn_finalizar.Enabled = true;

        }
        /*Clickar botón cálculos*/
        private void btn_calculo_Click(object sender, EventArgs e)
        {
            // Obtenemos los datos en función de la figura seleccionada.
            string figura = "";
            string num1String = "";
            string num2String = "";

            if (r_circulo.Checked)
            {
                figura = "Circulo";
                num1String = tb_radioCirculo.Text;
                num2String = "1";
            }
            else if (r_triangulo.Checked)
            {
                figura = "Triangulo";
                num1String = tb_baseTriangulo.Text;
                num2String = tb_alturaTriangulo.Text;
            }
            else if (r_rectangulo.Checked)
            {
                figura = "Rectangulo";
                num1String = tb_baseRectangulo.Text;
                num2String = tb_alturaRectangulo.Text;
            }
            else
            {
                figura = "Pentagono";
                num1String = tb_ladoPentagono.Text;
                num2String = tb_Apotema.Text;
            }

            

            // Comprobar si son double y mayores que 0 los datos intoducidos
            bool numerosValidos = NumValidos(num1String, num2String);

            if (numerosValidos)
            { 
                // Envío de información al servidor y recepción del resultado del cálculo.
                writer.WriteLine(figura + " " + num1String + " " + num2String);
                writer.Flush();
                tb_resultado.Text = "Resultado " + reader.ReadLine() + " cm^2";
            }
            else
            {
                // Si los datos no cumplen las condiciones para el calculo se muestra en el cuadro del resultado.
                tb_resultado.Text = "Valor incorrecto.";
            }
        }
        /*Clickar botón finalizar procesos*/
        private void btn_finalizar_Click(object sender, EventArgs e)
        {

            // Estado de los elementos: borrar datos y habilitar/deshabilitar los distintos elementos.
            DeshabilitarRadioButtons();
            DeshabilitarElementos();
            tb_resultado.Text = "";
            btn_finalizar.Enabled = false;
            btn_lanzarProceso.Enabled = true;

            // Si el proceso ha sido iniciado y se está ejecutando matamos el proceso y lo mostramos por pantalla
            if (p1!=null && !p1.HasExited)
            {
                tb_proceso.Text = "Proceso Calculo Finalizado ID: " + p1.Id;
                //cierre de las variables de flujo
                
                p1.Kill();

                p1 = null;
            }

            
        }

        /*+++++++++++++++++++++++++++++++++++++++ Métodos ++++++++++++++++++++++++++++++++++++++++*/
        /*Lanzamiento proceso servidor*/
        private void ArrancarServidor()
        {
            if(p1==null)
            {
                // Creamos el proceso y le pasamos la ruta del ejecutable
             
                ProcessStartInfo info = new ProcessStartInfo(@"..\..\..\Server\bin\Debug\net6.0\Server.exe");

                // Ponemos a true para que no cree una ventana nueva
                info.CreateNoWindow = true;

                // info.WindowStyle = ProcessWindowStyle.Normal

                // info.UseShellExecute = true;

                p1 = Process.Start(info);
            }

        }
        /*Comprueba datos*/
        private bool NumValidos(string str1, string str2)
        {
            // Comprobar que los datos introducidos son números mayores que 0
            if (Double.TryParse(str1, out double n1) && Double.TryParse(str2, out double n2))
            {
                if (n1 > 0 && n2 > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }
        /*Habilita estado de elementos*/
        private void HabilitarElementos()
        {
            // Habilitamos elementos de la parte final del formulario
            btn_calculo.Enabled = true;
            tb_resultado.Enabled = true;
            btn_finalizar.Enabled = true;
        }
        /*Habilita estado de radio buttons*/
        private void HabilitarRadioButtons()
        {
            // Quitar selección
            r_circulo.Checked = false;
            r_triangulo.Checked = false;
            r_rectangulo.Checked = false;
            r_pentagono.Checked = false;

            // Habilitar radio buttons
            r_circulo.Enabled = true;
            r_triangulo.Enabled = true;
            r_rectangulo.Enabled = true;
            r_pentagono.Enabled = true;
        }
        /*Deshabilita estado de radio buttons*/
        private void DeshabilitarRadioButtons()
        {
            // Deshabilitar radio buttons
            r_circulo.Enabled = false;
            r_triangulo.Enabled = false;
            r_rectangulo.Enabled = false;
            r_pentagono.Enabled = false;
        }
        /*Deshabilita estado de elementos*/
        private void DeshabilitarElementos()
        {
            // Borrar valores
            tb_radioCirculo.Text = "";
            tb_baseTriangulo.Text = "";
            tb_alturaTriangulo.Text = "";
            tb_baseRectangulo.Text = "";
            tb_alturaRectangulo.Text = "";
            tb_ladoPentagono.Text = "";
            tb_Apotema.Text = "";


            // Deshabilitar elementos
            lb_circulo.Enabled = false;
            tb_radioCirculo.Enabled = false;
            lb_triangulo1.Enabled = false;
            tb_baseTriangulo.Enabled = false;
            lb_trinagulo2.Enabled = false;
            tb_alturaTriangulo.Enabled = false;
            lb_rectangulo1.Enabled = false;
            tb_baseRectangulo.Enabled = false;
            lb_rectangulo2.Enabled = false;
            tb_alturaRectangulo.Enabled = false;
            lb_pentagono1.Enabled = false;
            tb_ladoPentagono.Enabled = false;
            lb_pentagono2.Enabled = false;
            tb_Apotema.Enabled = false;

            btn_calculo.Enabled = false;
            tb_resultado.Enabled = false;


        }

    }
}
