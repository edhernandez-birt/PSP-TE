namespace Calculo_de_Areas
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_lanzarProceso = new System.Windows.Forms.Button();
            this.r_circulo = new System.Windows.Forms.RadioButton();
            this.r_triangulo = new System.Windows.Forms.RadioButton();
            this.r_rectangulo = new System.Windows.Forms.RadioButton();
            this.r_pentagono = new System.Windows.Forms.RadioButton();
            this.lb_circulo = new System.Windows.Forms.Label();
            this.lb_triangulo1 = new System.Windows.Forms.Label();
            this.lb_rectangulo1 = new System.Windows.Forms.Label();
            this.lb_pentagono1 = new System.Windows.Forms.Label();
            this.tb_proceso = new System.Windows.Forms.TextBox();
            this.tb_radioCirculo = new System.Windows.Forms.TextBox();
            this.tb_baseTriangulo = new System.Windows.Forms.TextBox();
            this.tb_baseRectangulo = new System.Windows.Forms.TextBox();
            this.tb_ladoPentagono = new System.Windows.Forms.TextBox();
            this.lb_trinagulo2 = new System.Windows.Forms.Label();
            this.lb_rectangulo2 = new System.Windows.Forms.Label();
            this.lb_pentagono2 = new System.Windows.Forms.Label();
            this.tb_alturaTriangulo = new System.Windows.Forms.TextBox();
            this.tb_Apotema = new System.Windows.Forms.TextBox();
            this.tb_alturaRectangulo = new System.Windows.Forms.TextBox();
            this.btn_calculo = new System.Windows.Forms.Button();
            this.btn_finalizar = new System.Windows.Forms.Button();
            this.tb_resultado = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_lanzarProceso
            // 
            this.btn_lanzarProceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btn_lanzarProceso.Location = new System.Drawing.Point(51, 46);
            this.btn_lanzarProceso.Name = "btn_lanzarProceso";
            this.btn_lanzarProceso.Size = new System.Drawing.Size(170, 51);
            this.btn_lanzarProceso.TabIndex = 0;
            this.btn_lanzarProceso.Text = "Lanzar el proceso";
            this.btn_lanzarProceso.UseVisualStyleBackColor = true;
            this.btn_lanzarProceso.Click += new System.EventHandler(this.btn_lanzarProceso_Click);
            // 
            // r_circulo
            // 
            this.r_circulo.AutoSize = true;
            this.r_circulo.Enabled = false;
            this.r_circulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.r_circulo.Location = new System.Drawing.Point(51, 139);
            this.r_circulo.Name = "r_circulo";
            this.r_circulo.Size = new System.Drawing.Size(103, 21);
            this.r_circulo.TabIndex = 1;
            this.r_circulo.TabStop = true;
            this.r_circulo.Text = "Area Circulo";
            this.r_circulo.UseVisualStyleBackColor = true;
            this.r_circulo.CheckedChanged += new System.EventHandler(this.r_circulo_CheckedChanged);
            // 
            // r_triangulo
            // 
            this.r_triangulo.AutoSize = true;
            this.r_triangulo.Enabled = false;
            this.r_triangulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.r_triangulo.Location = new System.Drawing.Point(51, 189);
            this.r_triangulo.Name = "r_triangulo";
            this.r_triangulo.Size = new System.Drawing.Size(120, 21);
            this.r_triangulo.TabIndex = 2;
            this.r_triangulo.TabStop = true;
            this.r_triangulo.Text = "Area Triangulo";
            this.r_triangulo.UseVisualStyleBackColor = true;
            this.r_triangulo.CheckedChanged += new System.EventHandler(this.r_triangulo_CheckedChanged);
            // 
            // r_rectangulo
            // 
            this.r_rectangulo.AutoSize = true;
            this.r_rectangulo.Enabled = false;
            this.r_rectangulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.r_rectangulo.Location = new System.Drawing.Point(51, 238);
            this.r_rectangulo.Name = "r_rectangulo";
            this.r_rectangulo.Size = new System.Drawing.Size(132, 21);
            this.r_rectangulo.TabIndex = 3;
            this.r_rectangulo.TabStop = true;
            this.r_rectangulo.Text = "Area Rectangulo";
            this.r_rectangulo.UseVisualStyleBackColor = true;
            this.r_rectangulo.CheckedChanged += new System.EventHandler(this.r_rectangulo_CheckedChanged);
            // 
            // r_pentagono
            // 
            this.r_pentagono.AutoSize = true;
            this.r_pentagono.Enabled = false;
            this.r_pentagono.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.r_pentagono.Location = new System.Drawing.Point(51, 287);
            this.r_pentagono.Name = "r_pentagono";
            this.r_pentagono.Size = new System.Drawing.Size(129, 21);
            this.r_pentagono.TabIndex = 4;
            this.r_pentagono.TabStop = true;
            this.r_pentagono.Text = "Area Pentagono";
            this.r_pentagono.UseVisualStyleBackColor = true;
            this.r_pentagono.CheckedChanged += new System.EventHandler(this.r_pentagono_CheckedChanged);
            // 
            // lb_circulo
            // 
            this.lb_circulo.AutoSize = true;
            this.lb_circulo.Enabled = false;
            this.lb_circulo.Location = new System.Drawing.Point(214, 143);
            this.lb_circulo.Name = "lb_circulo";
            this.lb_circulo.Size = new System.Drawing.Size(109, 13);
            this.lb_circulo.TabIndex = 5;
            this.lb_circulo.Text = "Radio del circulo (cm)";
            // 
            // lb_triangulo1
            // 
            this.lb_triangulo1.AutoSize = true;
            this.lb_triangulo1.Enabled = false;
            this.lb_triangulo1.Location = new System.Drawing.Point(214, 193);
            this.lb_triangulo1.Name = "lb_triangulo1";
            this.lb_triangulo1.Size = new System.Drawing.Size(114, 13);
            this.lb_triangulo1.TabIndex = 6;
            this.lb_triangulo1.Text = "Base del triangulo (cm)";
            // 
            // lb_rectangulo1
            // 
            this.lb_rectangulo1.AutoSize = true;
            this.lb_rectangulo1.Enabled = false;
            this.lb_rectangulo1.Location = new System.Drawing.Point(214, 242);
            this.lb_rectangulo1.Name = "lb_rectangulo1";
            this.lb_rectangulo1.Size = new System.Drawing.Size(124, 13);
            this.lb_rectangulo1.TabIndex = 7;
            this.lb_rectangulo1.Text = "Base del rectangulo (cm)";
            // 
            // lb_pentagono1
            // 
            this.lb_pentagono1.AutoSize = true;
            this.lb_pentagono1.Enabled = false;
            this.lb_pentagono1.Location = new System.Drawing.Point(214, 291);
            this.lb_pentagono1.Name = "lb_pentagono1";
            this.lb_pentagono1.Size = new System.Drawing.Size(125, 13);
            this.lb_pentagono1.TabIndex = 8;
            this.lb_pentagono1.Text = "Lado del pentagono (cm)";
            // 
            // tb_proceso
            // 
            this.tb_proceso.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_proceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.tb_proceso.Location = new System.Drawing.Point(274, 63);
            this.tb_proceso.Name = "tb_proceso";
            this.tb_proceso.ReadOnly = true;
            this.tb_proceso.Size = new System.Drawing.Size(277, 17);
            this.tb_proceso.TabIndex = 9;
            this.tb_proceso.Text = "Proceso Calculo Parado";
            // 
            // tb_radioCirculo
            // 
            this.tb_radioCirculo.Enabled = false;
            this.tb_radioCirculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tb_radioCirculo.Location = new System.Drawing.Point(366, 137);
            this.tb_radioCirculo.Name = "tb_radioCirculo";
            this.tb_radioCirculo.Size = new System.Drawing.Size(81, 23);
            this.tb_radioCirculo.TabIndex = 10;
            // 
            // tb_baseTriangulo
            // 
            this.tb_baseTriangulo.Enabled = false;
            this.tb_baseTriangulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tb_baseTriangulo.Location = new System.Drawing.Point(366, 188);
            this.tb_baseTriangulo.Name = "tb_baseTriangulo";
            this.tb_baseTriangulo.Size = new System.Drawing.Size(81, 23);
            this.tb_baseTriangulo.TabIndex = 11;
            // 
            // tb_baseRectangulo
            // 
            this.tb_baseRectangulo.Enabled = false;
            this.tb_baseRectangulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tb_baseRectangulo.Location = new System.Drawing.Point(366, 237);
            this.tb_baseRectangulo.Name = "tb_baseRectangulo";
            this.tb_baseRectangulo.Size = new System.Drawing.Size(81, 23);
            this.tb_baseRectangulo.TabIndex = 12;
            // 
            // tb_ladoPentagono
            // 
            this.tb_ladoPentagono.Enabled = false;
            this.tb_ladoPentagono.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tb_ladoPentagono.Location = new System.Drawing.Point(366, 285);
            this.tb_ladoPentagono.Name = "tb_ladoPentagono";
            this.tb_ladoPentagono.Size = new System.Drawing.Size(81, 23);
            this.tb_ladoPentagono.TabIndex = 13;
            // 
            // lb_trinagulo2
            // 
            this.lb_trinagulo2.AutoSize = true;
            this.lb_trinagulo2.Enabled = false;
            this.lb_trinagulo2.Location = new System.Drawing.Point(507, 193);
            this.lb_trinagulo2.Name = "lb_trinagulo2";
            this.lb_trinagulo2.Size = new System.Drawing.Size(117, 13);
            this.lb_trinagulo2.TabIndex = 14;
            this.lb_trinagulo2.Text = "Altura del triangulo (cm)";
            // 
            // lb_rectangulo2
            // 
            this.lb_rectangulo2.AutoSize = true;
            this.lb_rectangulo2.Enabled = false;
            this.lb_rectangulo2.Location = new System.Drawing.Point(507, 242);
            this.lb_rectangulo2.Name = "lb_rectangulo2";
            this.lb_rectangulo2.Size = new System.Drawing.Size(127, 13);
            this.lb_rectangulo2.TabIndex = 15;
            this.lb_rectangulo2.Text = "Altura del rectangulo (cm)";
            // 
            // lb_pentagono2
            // 
            this.lb_pentagono2.AutoSize = true;
            this.lb_pentagono2.Enabled = false;
            this.lb_pentagono2.Location = new System.Drawing.Point(507, 291);
            this.lb_pentagono2.Name = "lb_pentagono2";
            this.lb_pentagono2.Size = new System.Drawing.Size(72, 13);
            this.lb_pentagono2.TabIndex = 16;
            this.lb_pentagono2.Text = "Apotema (cm)";
            // 
            // tb_alturaTriangulo
            // 
            this.tb_alturaTriangulo.Enabled = false;
            this.tb_alturaTriangulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tb_alturaTriangulo.Location = new System.Drawing.Point(661, 187);
            this.tb_alturaTriangulo.Name = "tb_alturaTriangulo";
            this.tb_alturaTriangulo.Size = new System.Drawing.Size(81, 23);
            this.tb_alturaTriangulo.TabIndex = 17;
            // 
            // tb_Apotema
            // 
            this.tb_Apotema.Enabled = false;
            this.tb_Apotema.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tb_Apotema.Location = new System.Drawing.Point(661, 286);
            this.tb_Apotema.Name = "tb_Apotema";
            this.tb_Apotema.Size = new System.Drawing.Size(81, 23);
            this.tb_Apotema.TabIndex = 18;
            // 
            // tb_alturaRectangulo
            // 
            this.tb_alturaRectangulo.Enabled = false;
            this.tb_alturaRectangulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tb_alturaRectangulo.Location = new System.Drawing.Point(661, 238);
            this.tb_alturaRectangulo.Name = "tb_alturaRectangulo";
            this.tb_alturaRectangulo.Size = new System.Drawing.Size(81, 23);
            this.tb_alturaRectangulo.TabIndex = 19;
            // 
            // btn_calculo
            // 
            this.btn_calculo.Enabled = false;
            this.btn_calculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btn_calculo.Location = new System.Drawing.Point(51, 345);
            this.btn_calculo.Name = "btn_calculo";
            this.btn_calculo.Size = new System.Drawing.Size(170, 51);
            this.btn_calculo.TabIndex = 20;
            this.btn_calculo.Text = "Calcular el Area";
            this.btn_calculo.UseVisualStyleBackColor = true;
            this.btn_calculo.Click += new System.EventHandler(this.btn_calculo_Click);
            // 
            // btn_finalizar
            // 
            this.btn_finalizar.Enabled = false;
            this.btn_finalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btn_finalizar.Location = new System.Drawing.Point(597, 406);
            this.btn_finalizar.Name = "btn_finalizar";
            this.btn_finalizar.Size = new System.Drawing.Size(170, 51);
            this.btn_finalizar.TabIndex = 21;
            this.btn_finalizar.Text = "Finalizar el Proceso";
            this.btn_finalizar.UseVisualStyleBackColor = true;
            this.btn_finalizar.Click += new System.EventHandler(this.btn_finalizar_Click);
            // 
            // tb_resultado
            // 
            this.tb_resultado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_resultado.Enabled = false;
            this.tb_resultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.tb_resultado.Location = new System.Drawing.Point(274, 358);
            this.tb_resultado.Name = "tb_resultado";
            this.tb_resultado.ReadOnly = true;
            this.tb_resultado.Size = new System.Drawing.Size(154, 17);
            this.tb_resultado.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.Controls.Add(this.tb_resultado);
            this.Controls.Add(this.btn_finalizar);
            this.Controls.Add(this.btn_calculo);
            this.Controls.Add(this.tb_alturaRectangulo);
            this.Controls.Add(this.tb_Apotema);
            this.Controls.Add(this.tb_alturaTriangulo);
            this.Controls.Add(this.lb_pentagono2);
            this.Controls.Add(this.lb_rectangulo2);
            this.Controls.Add(this.lb_trinagulo2);
            this.Controls.Add(this.tb_ladoPentagono);
            this.Controls.Add(this.tb_baseRectangulo);
            this.Controls.Add(this.tb_baseTriangulo);
            this.Controls.Add(this.tb_radioCirculo);
            this.Controls.Add(this.tb_proceso);
            this.Controls.Add(this.lb_pentagono1);
            this.Controls.Add(this.lb_rectangulo1);
            this.Controls.Add(this.lb_triangulo1);
            this.Controls.Add(this.lb_circulo);
            this.Controls.Add(this.r_pentagono);
            this.Controls.Add(this.r_rectangulo);
            this.Controls.Add(this.r_triangulo);
            this.Controls.Add(this.r_circulo);
            this.Controls.Add(this.btn_lanzarProceso);
            this.Name = "Form1";
            this.Text = "Calculo de areas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_lanzarProceso;
        private System.Windows.Forms.RadioButton r_circulo;
        private System.Windows.Forms.RadioButton r_triangulo;
        private System.Windows.Forms.RadioButton r_rectangulo;
        private System.Windows.Forms.RadioButton r_pentagono;
        private System.Windows.Forms.Label lb_circulo;
        private System.Windows.Forms.Label lb_triangulo1;
        private System.Windows.Forms.Label lb_rectangulo1;
        private System.Windows.Forms.Label lb_pentagono1;
        private System.Windows.Forms.TextBox tb_proceso;
        private System.Windows.Forms.TextBox tb_radioCirculo;
        private System.Windows.Forms.TextBox tb_baseTriangulo;
        private System.Windows.Forms.TextBox tb_baseRectangulo;
        private System.Windows.Forms.TextBox tb_ladoPentagono;
        private System.Windows.Forms.Label lb_trinagulo2;
        private System.Windows.Forms.Label lb_rectangulo2;
        private System.Windows.Forms.Label lb_pentagono2;
        private System.Windows.Forms.TextBox tb_alturaTriangulo;
        private System.Windows.Forms.TextBox tb_Apotema;
        private System.Windows.Forms.TextBox tb_alturaRectangulo;
        private System.Windows.Forms.Button btn_calculo;
        private System.Windows.Forms.Button btn_finalizar;
        private System.Windows.Forms.TextBox tb_resultado;
    }
}

