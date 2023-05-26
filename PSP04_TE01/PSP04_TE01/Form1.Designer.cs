namespace PSP04_TE01
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
            this.buttonActivarConsulta = new System.Windows.Forms.Button();
            this.labelProvincia = new System.Windows.Forms.Label();
            this.labelMunicipio = new System.Windows.Forms.Label();
            this.labelEvento = new System.Windows.Forms.Label();
            this.labelDatosEvento = new System.Windows.Forms.Label();
            this.comboBoxProvincia = new System.Windows.Forms.ComboBox();
            this.comboBoxMunicipio = new System.Windows.Forms.ComboBox();
            this.comboBoxEvento = new System.Windows.Forms.ComboBox();
            this.textBoxDatosEvento = new System.Windows.Forms.TextBox();
            this.pictureBoxFotoEvento = new System.Windows.Forms.PictureBox();
            this.buttonActivarEnvioFTP = new System.Windows.Forms.Button();
            this.labelServidor = new System.Windows.Forms.Label();
            this.textBoxServidor = new System.Windows.Forms.TextBox();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.textBoxUsuario = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonGuardarFTP = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFotoEvento)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonActivarConsulta
            // 
            this.buttonActivarConsulta.Location = new System.Drawing.Point(29, 34);
            this.buttonActivarConsulta.Name = "buttonActivarConsulta";
            this.buttonActivarConsulta.Size = new System.Drawing.Size(125, 47);
            this.buttonActivarConsulta.TabIndex = 0;
            this.buttonActivarConsulta.Text = "Activar Consulta";
            this.buttonActivarConsulta.UseVisualStyleBackColor = true;
            this.buttonActivarConsulta.Click += new System.EventHandler(this.buttonActivarConsulta_Click);
            // 
            // labelProvincia
            // 
            this.labelProvincia.AutoSize = true;
            this.labelProvincia.Location = new System.Drawing.Point(220, 50);
            this.labelProvincia.Name = "labelProvincia";
            this.labelProvincia.Size = new System.Drawing.Size(116, 15);
            this.labelProvincia.TabIndex = 1;
            this.labelProvincia.Text = "Provincia / Lurraldea";
            // 
            // labelMunicipio
            // 
            this.labelMunicipio.AutoSize = true;
            this.labelMunicipio.Location = new System.Drawing.Point(220, 97);
            this.labelMunicipio.Name = "labelMunicipio";
            this.labelMunicipio.Size = new System.Drawing.Size(104, 15);
            this.labelMunicipio.TabIndex = 2;
            this.labelMunicipio.Text = "Municipio / Herria";
            // 
            // labelEvento
            // 
            this.labelEvento.AutoSize = true;
            this.labelEvento.Location = new System.Drawing.Point(220, 140);
            this.labelEvento.Name = "labelEvento";
            this.labelEvento.Size = new System.Drawing.Size(43, 15);
            this.labelEvento.TabIndex = 3;
            this.labelEvento.Text = "Evento";
            // 
            // labelDatosEvento
            // 
            this.labelDatosEvento.AutoSize = true;
            this.labelDatosEvento.Location = new System.Drawing.Point(220, 181);
            this.labelDatosEvento.Name = "labelDatosEvento";
            this.labelDatosEvento.Size = new System.Drawing.Size(95, 15);
            this.labelDatosEvento.TabIndex = 4;
            this.labelDatosEvento.Text = "Datos del evento";
            // 
            // comboBoxProvincia
            // 
            this.comboBoxProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProvincia.Enabled = false;
            this.comboBoxProvincia.FormattingEnabled = true;
            this.comboBoxProvincia.Location = new System.Drawing.Point(399, 42);
            this.comboBoxProvincia.Name = "comboBoxProvincia";
            this.comboBoxProvincia.Size = new System.Drawing.Size(255, 23);
            this.comboBoxProvincia.TabIndex = 5;
            this.comboBoxProvincia.SelectedIndexChanged += new System.EventHandler(this.comboBoxProvincia_SelectedIndexChanged);
            // 
            // comboBoxMunicipio
            // 
            this.comboBoxMunicipio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMunicipio.Enabled = false;
            this.comboBoxMunicipio.FormattingEnabled = true;
            this.comboBoxMunicipio.Location = new System.Drawing.Point(399, 89);
            this.comboBoxMunicipio.Name = "comboBoxMunicipio";
            this.comboBoxMunicipio.Size = new System.Drawing.Size(255, 23);
            this.comboBoxMunicipio.TabIndex = 6;
            this.comboBoxMunicipio.SelectedIndexChanged += new System.EventHandler(this.comboBoxMunicipio_SelectedIndexChanged);
            // 
            // comboBoxEvento
            // 
            this.comboBoxEvento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEvento.Enabled = false;
            this.comboBoxEvento.FormattingEnabled = true;
            this.comboBoxEvento.Location = new System.Drawing.Point(399, 137);
            this.comboBoxEvento.Name = "comboBoxEvento";
            this.comboBoxEvento.Size = new System.Drawing.Size(255, 23);
            this.comboBoxEvento.TabIndex = 7;
            this.comboBoxEvento.SelectedIndexChanged += new System.EventHandler(this.comboBoxEvento_SelectedIndexChanged);
            // 
            // textBoxDatosEvento
            // 
            this.textBoxDatosEvento.Location = new System.Drawing.Point(398, 182);
            this.textBoxDatosEvento.Multiline = true;
            this.textBoxDatosEvento.Name = "textBoxDatosEvento";
            this.textBoxDatosEvento.ReadOnly = true;
            this.textBoxDatosEvento.Size = new System.Drawing.Size(256, 155);
            this.textBoxDatosEvento.TabIndex = 8;
            // 
            // pictureBoxFotoEvento
            // 
            this.pictureBoxFotoEvento.Location = new System.Drawing.Point(831, 34);
            this.pictureBoxFotoEvento.Name = "pictureBoxFotoEvento";
            this.pictureBoxFotoEvento.Size = new System.Drawing.Size(341, 233);
            this.pictureBoxFotoEvento.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxFotoEvento.TabIndex = 9;
            this.pictureBoxFotoEvento.TabStop = false;
            // 
            // buttonActivarEnvioFTP
            // 
            this.buttonActivarEnvioFTP.Enabled = false;
            this.buttonActivarEnvioFTP.Location = new System.Drawing.Point(29, 415);
            this.buttonActivarEnvioFTP.Name = "buttonActivarEnvioFTP";
            this.buttonActivarEnvioFTP.Size = new System.Drawing.Size(125, 47);
            this.buttonActivarEnvioFTP.TabIndex = 10;
            this.buttonActivarEnvioFTP.Text = "Activar Envío FTP";
            this.buttonActivarEnvioFTP.UseVisualStyleBackColor = true;
            this.buttonActivarEnvioFTP.Click += new System.EventHandler(this.buttonActivarEnvioFTP_Click);
            // 
            // labelServidor
            // 
            this.labelServidor.AutoSize = true;
            this.labelServidor.Location = new System.Drawing.Point(286, 431);
            this.labelServidor.Name = "labelServidor";
            this.labelServidor.Size = new System.Drawing.Size(50, 15);
            this.labelServidor.TabIndex = 11;
            this.labelServidor.Text = "Servidor";
            // 
            // textBoxServidor
            // 
            this.textBoxServidor.Enabled = false;
            this.textBoxServidor.Location = new System.Drawing.Point(396, 428);
            this.textBoxServidor.Name = "textBoxServidor";
            this.textBoxServidor.Size = new System.Drawing.Size(191, 23);
            this.textBoxServidor.TabIndex = 12;
            this.textBoxServidor.Text = "ftp.dlptest.com";
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Location = new System.Drawing.Point(286, 494);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(47, 15);
            this.labelUsuario.TabIndex = 13;
            this.labelUsuario.Text = "Usuario";
            // 
            // textBoxUsuario
            // 
            this.textBoxUsuario.Enabled = false;
            this.textBoxUsuario.Location = new System.Drawing.Point(396, 491);
            this.textBoxUsuario.Name = "textBoxUsuario";
            this.textBoxUsuario.Size = new System.Drawing.Size(191, 23);
            this.textBoxUsuario.TabIndex = 14;
            this.textBoxUsuario.Text = "dlpuser";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(641, 494);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(57, 15);
            this.labelPassword.TabIndex = 15;
            this.labelPassword.Text = "Password";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Enabled = false;
            this.textBoxPassword.Location = new System.Drawing.Point(748, 491);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(191, 23);
            this.textBoxPassword.TabIndex = 16;
            this.textBoxPassword.Text = "rNrKYTX9g7z3RgJRmxWuGHbeu";
            // 
            // buttonGuardarFTP
            // 
            this.buttonGuardarFTP.Enabled = false;
            this.buttonGuardarFTP.Location = new System.Drawing.Point(396, 553);
            this.buttonGuardarFTP.Name = "buttonGuardarFTP";
            this.buttonGuardarFTP.Size = new System.Drawing.Size(75, 23);
            this.buttonGuardarFTP.TabIndex = 17;
            this.buttonGuardarFTP.Text = "Guardar";
            this.buttonGuardarFTP.UseVisualStyleBackColor = true;
            this.buttonGuardarFTP.Click += new System.EventHandler(this.buttonGuardarFTP_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.buttonGuardarFTP);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.textBoxUsuario);
            this.Controls.Add(this.labelUsuario);
            this.Controls.Add(this.textBoxServidor);
            this.Controls.Add(this.labelServidor);
            this.Controls.Add(this.buttonActivarEnvioFTP);
            this.Controls.Add(this.pictureBoxFotoEvento);
            this.Controls.Add(this.textBoxDatosEvento);
            this.Controls.Add(this.comboBoxEvento);
            this.Controls.Add(this.comboBoxMunicipio);
            this.Controls.Add(this.comboBoxProvincia);
            this.Controls.Add(this.labelDatosEvento);
            this.Controls.Add(this.labelEvento);
            this.Controls.Add(this.labelMunicipio);
            this.Controls.Add(this.labelProvincia);
            this.Controls.Add(this.buttonActivarConsulta);
            this.Name = "Form1";
            this.Text = "Consultar Eventos Euskadi";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFotoEvento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonActivarConsulta;
        private Label labelProvincia;
        private Label labelMunicipio;
        private Label labelEvento;
        private Label labelDatosEvento;
        private ComboBox comboBoxProvincia;
        private ComboBox comboBoxMunicipio;
        private ComboBox comboBoxEvento;
        private TextBox textBoxDatosEvento;
        private PictureBox pictureBoxFotoEvento;
        private Button buttonActivarEnvioFTP;
        private Label labelServidor;
        private TextBox textBoxServidor;
        private Label labelUsuario;
        private TextBox textBoxUsuario;
        private Label labelPassword;
        private TextBox textBoxPassword;
        private Button buttonGuardarFTP;
    }
}