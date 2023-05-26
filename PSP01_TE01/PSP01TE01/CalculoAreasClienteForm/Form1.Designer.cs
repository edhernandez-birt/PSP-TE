using System.Diagnostics;

namespace PSP01TE01FORM
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            //Centramos el formulario
            this.StartPosition = FormStartPosition.CenterScreen;

            this.buttonLanzaProceso = new System.Windows.Forms.Button();
            this.labelProceso = new System.Windows.Forms.Label();
            this.radioButtonCirculo = new System.Windows.Forms.RadioButton();
            this.radioButtonTriangulo = new System.Windows.Forms.RadioButton();
            this.radioButtonRectangulo = new System.Windows.Forms.RadioButton();
            this.radioButtonPentagono = new System.Windows.Forms.RadioButton();
            this.labelCirculo = new System.Windows.Forms.Label();
            this.textBoxCirculo = new System.Windows.Forms.TextBox();
            this.labelTrianguloBase = new System.Windows.Forms.Label();
            this.textBoxTrianguloBase = new System.Windows.Forms.TextBox();
            this.labelTrianguloAltura = new System.Windows.Forms.Label();
            this.textBoxTrianguloAltura = new System.Windows.Forms.TextBox();
            this.textBoxRectanguloAltura = new System.Windows.Forms.TextBox();
            this.labelRectanguloAltura = new System.Windows.Forms.Label();
            this.textBoxRectanguloBase = new System.Windows.Forms.TextBox();
            this.labelRectanguloBase = new System.Windows.Forms.Label();
            this.textBoxPentagonoApotema = new System.Windows.Forms.TextBox();
            this.labelPentagonoApotema = new System.Windows.Forms.Label();
            this.textBoxPentagonoLado = new System.Windows.Forms.TextBox();
            this.labelPentagonoLado = new System.Windows.Forms.Label();
            this.buttonCalculaArea = new System.Windows.Forms.Button();
            this.labelResultado = new System.Windows.Forms.Label();
            this.buttonFin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonLanzaProceso
            // 
            this.buttonLanzaProceso.Location = new System.Drawing.Point(73, 42);
            this.buttonLanzaProceso.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLanzaProceso.Name = "buttonLanzaProceso";
            this.buttonLanzaProceso.Size = new System.Drawing.Size(150, 38);
            this.buttonLanzaProceso.TabIndex = 0;
            this.buttonLanzaProceso.Text = "Lanzar el proceso";
            this.buttonLanzaProceso.UseVisualStyleBackColor = true;
            this.buttonLanzaProceso.Click += new System.EventHandler(this.buttonLanzaProceso_Click);
            // 
            // labelProceso
            // 
            this.labelProceso.AutoSize = true;
            this.labelProceso.Location = new System.Drawing.Point(310, 53);
            this.labelProceso.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelProceso.Name = "labelProceso";
            this.labelProceso.Size = new System.Drawing.Size(130, 15);
            this.labelProceso.TabIndex = 1;
            this.labelProceso.Text = "Proceso cálculo parado";
            // 
            // radioButtonCirculo
            // 
            this.radioButtonCirculo.AutoSize = true;
            this.radioButtonCirculo.Enabled = false;
            this.radioButtonCirculo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.radioButtonCirculo.Location = new System.Drawing.Point(73, 127);
            this.radioButtonCirculo.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonCirculo.Name = "radioButtonCirculo";
            this.radioButtonCirculo.Size = new System.Drawing.Size(92, 19);
            this.radioButtonCirculo.TabIndex = 2;
            this.radioButtonCirculo.TabStop = true;
            this.radioButtonCirculo.Text = "Area Círculo";
            this.radioButtonCirculo.UseVisualStyleBackColor = true;
            this.radioButtonCirculo.CheckedChanged += new System.EventHandler(this.radioButtonCirculo_CheckedChanged);
            // 
            // radioButtonTriangulo
            // 
            this.radioButtonTriangulo.AutoSize = true;
            this.radioButtonTriangulo.Enabled = false;
            this.radioButtonTriangulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.radioButtonTriangulo.Location = new System.Drawing.Point(73, 172);
            this.radioButtonTriangulo.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonTriangulo.Name = "radioButtonTriangulo";
            this.radioButtonTriangulo.Size = new System.Drawing.Size(105, 19);
            this.radioButtonTriangulo.TabIndex = 3;
            this.radioButtonTriangulo.TabStop = true;
            this.radioButtonTriangulo.Text = "Area Triángulo";
            this.radioButtonTriangulo.UseVisualStyleBackColor = true;
            this.radioButtonTriangulo.CheckedChanged += new System.EventHandler(this.radioButtonTriangulo_CheckedChanged);
            // 
            // radioButtonRectangulo
            // 
            this.radioButtonRectangulo.AutoSize = true;
            this.radioButtonRectangulo.Enabled = false;
            this.radioButtonRectangulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.radioButtonRectangulo.Location = new System.Drawing.Point(73, 220);
            this.radioButtonRectangulo.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonRectangulo.Name = "radioButtonRectangulo";
            this.radioButtonRectangulo.Size = new System.Drawing.Size(117, 19);
            this.radioButtonRectangulo.TabIndex = 4;
            this.radioButtonRectangulo.TabStop = true;
            this.radioButtonRectangulo.Text = "Area Rectángulo";
            this.radioButtonRectangulo.UseVisualStyleBackColor = true;
            this.radioButtonRectangulo.CheckedChanged += new System.EventHandler(this.radioButtonRectangulo_CheckedChanged);
            // 
            // radioButtonPentagono
            // 
            this.radioButtonPentagono.AutoSize = true;
            this.radioButtonPentagono.Enabled = false;
            this.radioButtonPentagono.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.radioButtonPentagono.Location = new System.Drawing.Point(73, 272);
            this.radioButtonPentagono.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonPentagono.Name = "radioButtonPentagono";
            this.radioButtonPentagono.Size = new System.Drawing.Size(114, 19);
            this.radioButtonPentagono.TabIndex = 5;
            this.radioButtonPentagono.TabStop = true;
            this.radioButtonPentagono.Text = "Area Pentágono";
            this.radioButtonPentagono.UseVisualStyleBackColor = true;
            this.radioButtonPentagono.CheckedChanged += new System.EventHandler(this.radioButtonPentagono_CheckedChanged);
            // 
            // labelCirculo
            // 
            this.labelCirculo.AutoSize = true;
            this.labelCirculo.Location = new System.Drawing.Point(244, 129);
            this.labelCirculo.Name = "labelCirculo";
            this.labelCirculo.Size = new System.Drawing.Size(167, 15);
            this.labelCirculo.TabIndex = 6;
            this.labelCirculo.Text = "Indica el radio del círculo (cm)";
            // 
            // textBoxCirculo
            // 
            this.textBoxCirculo.Enabled = false;
            this.textBoxCirculo.Location = new System.Drawing.Point(442, 123);
            this.textBoxCirculo.Name = "textBoxCirculo";
            this.textBoxCirculo.Size = new System.Drawing.Size(100, 23);
            this.textBoxCirculo.TabIndex = 7;
            // 
            // labelTrianguloBase
            // 
            this.labelTrianguloBase.AutoSize = true;
            this.labelTrianguloBase.Location = new System.Drawing.Point(244, 174);
            this.labelTrianguloBase.Name = "labelTrianguloBase";
            this.labelTrianguloBase.Size = new System.Drawing.Size(129, 15);
            this.labelTrianguloBase.TabIndex = 8;
            this.labelTrianguloBase.Text = "Base del triángulo (cm)";
            // 
            // textBoxTrianguloBase
            // 
            this.textBoxTrianguloBase.Enabled = false;
            this.textBoxTrianguloBase.Location = new System.Drawing.Point(442, 171);
            this.textBoxTrianguloBase.Name = "textBoxTrianguloBase";
            this.textBoxTrianguloBase.Size = new System.Drawing.Size(100, 23);
            this.textBoxTrianguloBase.TabIndex = 9;
            // 
            // labelTrianguloAltura
            // 
            this.labelTrianguloAltura.AutoSize = true;
            this.labelTrianguloAltura.Location = new System.Drawing.Point(567, 174);
            this.labelTrianguloAltura.Name = "labelTrianguloAltura";
            this.labelTrianguloAltura.Size = new System.Drawing.Size(137, 15);
            this.labelTrianguloAltura.TabIndex = 10;
            this.labelTrianguloAltura.Text = "Altura del triángulo (cm)";
            // 
            // textBoxTrianguloAltura
            // 
            this.textBoxTrianguloAltura.Enabled = false;
            this.textBoxTrianguloAltura.Location = new System.Drawing.Point(734, 172);
            this.textBoxTrianguloAltura.Name = "textBoxTrianguloAltura";
            this.textBoxTrianguloAltura.Size = new System.Drawing.Size(100, 23);
            this.textBoxTrianguloAltura.TabIndex = 11;
            // 
            // textBoxRectanguloAltura
            // 
            this.textBoxRectanguloAltura.Enabled = false;
            this.textBoxRectanguloAltura.Location = new System.Drawing.Point(734, 220);
            this.textBoxRectanguloAltura.Name = "textBoxRectanguloAltura";
            this.textBoxRectanguloAltura.Size = new System.Drawing.Size(100, 23);
            this.textBoxRectanguloAltura.TabIndex = 15;
            // 
            // labelRectanguloAltura
            // 
            this.labelRectanguloAltura.AutoSize = true;
            this.labelRectanguloAltura.Location = new System.Drawing.Point(567, 222);
            this.labelRectanguloAltura.Name = "labelRectanguloAltura";
            this.labelRectanguloAltura.Size = new System.Drawing.Size(146, 15);
            this.labelRectanguloAltura.TabIndex = 14;
            this.labelRectanguloAltura.Text = "Altura del rectángulo (cm)";
            // 
            // textBoxRectanguloBase
            // 
            this.textBoxRectanguloBase.Enabled = false;
            this.textBoxRectanguloBase.Location = new System.Drawing.Point(442, 219);
            this.textBoxRectanguloBase.Name = "textBoxRectanguloBase";
            this.textBoxRectanguloBase.Size = new System.Drawing.Size(100, 23);
            this.textBoxRectanguloBase.TabIndex = 13;
            // 
            // labelRectanguloBase
            // 
            this.labelRectanguloBase.AutoSize = true;
            this.labelRectanguloBase.Location = new System.Drawing.Point(244, 222);
            this.labelRectanguloBase.Name = "labelRectanguloBase";
            this.labelRectanguloBase.Size = new System.Drawing.Size(138, 15);
            this.labelRectanguloBase.TabIndex = 12;
            this.labelRectanguloBase.Text = "Base del rectángulo (cm)";
            // 
            // textBoxPentagonoApotema
            // 
            this.textBoxPentagonoApotema.Enabled = false;
            this.textBoxPentagonoApotema.Location = new System.Drawing.Point(734, 272);
            this.textBoxPentagonoApotema.Name = "textBoxPentagonoApotema";
            this.textBoxPentagonoApotema.Size = new System.Drawing.Size(100, 23);
            this.textBoxPentagonoApotema.TabIndex = 19;
            // 
            // labelPentagonoApotema
            // 
            this.labelPentagonoApotema.AutoSize = true;
            this.labelPentagonoApotema.Location = new System.Drawing.Point(567, 274);
            this.labelPentagonoApotema.Name = "labelPentagonoApotema";
            this.labelPentagonoApotema.Size = new System.Drawing.Size(84, 15);
            this.labelPentagonoApotema.TabIndex = 18;
            this.labelPentagonoApotema.Text = "Apotema (cm)";
            // 
            // textBoxPentagonoLado
            // 
            this.textBoxPentagonoLado.Enabled = false;
            this.textBoxPentagonoLado.Location = new System.Drawing.Point(442, 271);
            this.textBoxPentagonoLado.Name = "textBoxPentagonoLado";
            this.textBoxPentagonoLado.Size = new System.Drawing.Size(100, 23);
            this.textBoxPentagonoLado.TabIndex = 17;
            // 
            // labelPentagonoLado
            // 
            this.labelPentagonoLado.AutoSize = true;
            this.labelPentagonoLado.Location = new System.Drawing.Point(244, 274);
            this.labelPentagonoLado.Name = "labelPentagonoLado";
            this.labelPentagonoLado.Size = new System.Drawing.Size(141, 15);
            this.labelPentagonoLado.TabIndex = 16;
            this.labelPentagonoLado.Text = "Lado del pentágono (cm)";
            // 
            // buttonCalculaArea
            // 
            this.buttonCalculaArea.Enabled = false;
            this.buttonCalculaArea.Location = new System.Drawing.Point(73, 349);
            this.buttonCalculaArea.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCalculaArea.Name = "buttonCalculaArea";
            this.buttonCalculaArea.Size = new System.Drawing.Size(150, 38);
            this.buttonCalculaArea.TabIndex = 20;
            this.buttonCalculaArea.Text = "Calcular el área";
            this.buttonCalculaArea.UseVisualStyleBackColor = true;
            this.buttonCalculaArea.Click += new System.EventHandler(this.buttonCalculaArea_Click);
            // 
            // labelResultado
            // 
            this.labelResultado.AutoSize = true;
            this.labelResultado.Location = new System.Drawing.Point(310, 361);
            this.labelResultado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelResultado.Name = "labelResultado";
            this.labelResultado.Size = new System.Drawing.Size(100, 15);
            this.labelResultado.TabIndex = 21;
            this.labelResultado.Text = "Mostrar resultado";
            // 
            // buttonFin
            // 
            this.buttonFin.Enabled = false;
            this.buttonFin.Location = new System.Drawing.Point(778, 451);
            this.buttonFin.Margin = new System.Windows.Forms.Padding(2);
            this.buttonFin.Name = "buttonFin";
            this.buttonFin.Size = new System.Drawing.Size(150, 38);
            this.buttonFin.TabIndex = 22;
            this.buttonFin.Text = "Finalizar el proceso";
            this.buttonFin.UseVisualStyleBackColor = true;
            this.buttonFin.Click += new System.EventHandler(this.buttonFin_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 500);
            this.Controls.Add(this.buttonFin);
            this.Controls.Add(this.labelResultado);
            this.Controls.Add(this.buttonCalculaArea);
            this.Controls.Add(this.textBoxPentagonoApotema);
            this.Controls.Add(this.labelPentagonoApotema);
            this.Controls.Add(this.textBoxPentagonoLado);
            this.Controls.Add(this.labelPentagonoLado);
            this.Controls.Add(this.textBoxRectanguloAltura);
            this.Controls.Add(this.labelRectanguloAltura);
            this.Controls.Add(this.textBoxRectanguloBase);
            this.Controls.Add(this.labelRectanguloBase);
            this.Controls.Add(this.textBoxTrianguloAltura);
            this.Controls.Add(this.labelTrianguloAltura);
            this.Controls.Add(this.textBoxTrianguloBase);
            this.Controls.Add(this.labelTrianguloBase);
            this.Controls.Add(this.textBoxCirculo);
            this.Controls.Add(this.labelCirculo);
            this.Controls.Add(this.radioButtonPentagono);
            this.Controls.Add(this.radioButtonRectangulo);
            this.Controls.Add(this.radioButtonTriangulo);
            this.Controls.Add(this.radioButtonCirculo);
            this.Controls.Add(this.labelProceso);
            this.Controls.Add(this.buttonLanzaProceso);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Cálculo de áreas (Cliente)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonLanzaProceso;
        private Label labelProceso;
        private RadioButton radioButtonCirculo;
        private RadioButton radioButtonTriangulo;
        private RadioButton radioButtonRectangulo;
        private RadioButton radioButtonPentagono;
        private Label labelCirculo;
        private TextBox textBoxCirculo;
        private Label labelTrianguloBase;
        private TextBox textBoxTrianguloBase;
        private Label labelTrianguloAltura;
        private TextBox textBoxTrianguloAltura;
        private TextBox textBoxRectanguloAltura;
        private Label labelRectanguloAltura;
        private TextBox textBoxRectanguloBase;
        private Label labelRectanguloBase;
        private TextBox textBoxPentagonoApotema;
        private Label labelPentagonoApotema;
        private TextBox textBoxPentagonoLado;
        private Label labelPentagonoLado;
        private Button buttonCalculaArea;
        private Label labelResultado;
        private Button buttonFin;

        //Variables que vamos a necesitar en el formulario

        private Process p;
        private string operacion;
        private StreamReader reader;
        private StreamWriter writer;
    }
}