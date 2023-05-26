namespace PSP05_TE01
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
            this.labelUsuario = new System.Windows.Forms.Label();
            this.textBoxUsuario = new System.Windows.Forms.TextBox();
            this.buttonRegistrar = new System.Windows.Forms.Button();
            this.groupBoxRegistroUsuario = new System.Windows.Forms.GroupBox();
            this.buttonAceptar = new System.Windows.Forms.Button();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.radioButtonNo = new System.Windows.Forms.RadioButton();
            this.radioButtonSi = new System.Windows.Forms.RadioButton();
            this.labelRegistro = new System.Windows.Forms.Label();
            this.checkBoxVisualizar = new System.Windows.Forms.CheckBox();
            this.checkBoxRegistrar = new System.Windows.Forms.CheckBox();
            this.checkBoxBorrar = new System.Windows.Forms.CheckBox();
            this.groupBoxVisualizar = new System.Windows.Forms.GroupBox();
            this.labelFichero = new System.Windows.Forms.Label();
            this.buttonFichero = new System.Windows.Forms.Button();
            this.comboBoxDescripcion = new System.Windows.Forms.ComboBox();
            this.textBoxVisualizarPassword = new System.Windows.Forms.TextBox();
            this.labelVisualizarPassword = new System.Windows.Forms.Label();
            this.labelVisualizarRegis = new System.Windows.Forms.Label();
            this.labelVisualizarDesc = new System.Windows.Forms.Label();
            this.groupBoxRegistrar = new System.Windows.Forms.GroupBox();
            this.textBoxRegistrarDescripcion = new System.Windows.Forms.TextBox();
            this.textBoxRegsitrarPassword = new System.Windows.Forms.TextBox();
            this.buttonRegistrarGuardar = new System.Windows.Forms.Button();
            this.labelRegistrarPassword = new System.Windows.Forms.Label();
            this.labelRegistrarDescripción = new System.Windows.Forms.Label();
            this.groupBoxBorrar = new System.Windows.Forms.GroupBox();
            this.buttonBorrar = new System.Windows.Forms.Button();
            this.comboBoxBorrar = new System.Windows.Forms.ComboBox();
            this.labelBorrar = new System.Windows.Forms.Label();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBoxRegistroUsuario.SuspendLayout();
            this.groupBoxVisualizar.SuspendLayout();
            this.groupBoxRegistrar.SuspendLayout();
            this.groupBoxBorrar.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelUsuario.Location = new System.Drawing.Point(34, 28);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(49, 15);
            this.labelUsuario.TabIndex = 0;
            this.labelUsuario.Text = "Usuario";
            // 
            // textBoxUsuario
            // 
            this.textBoxUsuario.Location = new System.Drawing.Point(106, 25);
            this.textBoxUsuario.Name = "textBoxUsuario";
            this.textBoxUsuario.Size = new System.Drawing.Size(212, 23);
            this.textBoxUsuario.TabIndex = 1;
            // 
            // buttonRegistrar
            // 
            this.buttonRegistrar.Location = new System.Drawing.Point(324, 25);
            this.buttonRegistrar.Name = "buttonRegistrar";
            this.buttonRegistrar.Size = new System.Drawing.Size(101, 23);
            this.buttonRegistrar.TabIndex = 2;
            this.buttonRegistrar.Text = "Registrar";
            this.buttonRegistrar.UseVisualStyleBackColor = true;
            this.buttonRegistrar.Click += new System.EventHandler(this.buttonRegistrar_Click);
            // 
            // groupBoxRegistroUsuario
            // 
            this.groupBoxRegistroUsuario.Controls.Add(this.buttonAceptar);
            this.groupBoxRegistroUsuario.Controls.Add(this.textBoxEmail);
            this.groupBoxRegistroUsuario.Controls.Add(this.labelEmail);
            this.groupBoxRegistroUsuario.Controls.Add(this.radioButtonNo);
            this.groupBoxRegistroUsuario.Controls.Add(this.radioButtonSi);
            this.groupBoxRegistroUsuario.Controls.Add(this.labelRegistro);
            this.groupBoxRegistroUsuario.Location = new System.Drawing.Point(455, 12);
            this.groupBoxRegistroUsuario.Name = "groupBoxRegistroUsuario";
            this.groupBoxRegistroUsuario.Size = new System.Drawing.Size(251, 150);
            this.groupBoxRegistroUsuario.TabIndex = 3;
            this.groupBoxRegistroUsuario.TabStop = false;
            this.groupBoxRegistroUsuario.Text = "Registro usuario";
            // 
            // buttonAceptar
            // 
            this.buttonAceptar.Enabled = false;
            this.buttonAceptar.Location = new System.Drawing.Point(53, 120);
            this.buttonAceptar.Name = "buttonAceptar";
            this.buttonAceptar.Size = new System.Drawing.Size(85, 23);
            this.buttonAceptar.TabIndex = 5;
            this.buttonAceptar.Text = "Aceptar";
            this.buttonAceptar.UseVisualStyleBackColor = true;
            this.buttonAceptar.Click += new System.EventHandler(this.buttonAceptar_Click);
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Enabled = false;
            this.textBoxEmail.Location = new System.Drawing.Point(53, 91);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(192, 23);
            this.textBoxEmail.TabIndex = 4;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(10, 94);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(47, 15);
            this.labelEmail.TabIndex = 3;
            this.labelEmail.Text = "E-mail: ";
            // 
            // radioButtonNo
            // 
            this.radioButtonNo.AutoSize = true;
            this.radioButtonNo.Enabled = false;
            this.radioButtonNo.Location = new System.Drawing.Point(108, 62);
            this.radioButtonNo.Name = "radioButtonNo";
            this.radioButtonNo.Size = new System.Drawing.Size(41, 19);
            this.radioButtonNo.TabIndex = 2;
            this.radioButtonNo.TabStop = true;
            this.radioButtonNo.Text = "No";
            this.radioButtonNo.UseVisualStyleBackColor = true;
            // 
            // radioButtonSi
            // 
            this.radioButtonSi.AutoSize = true;
            this.radioButtonSi.Enabled = false;
            this.radioButtonSi.Location = new System.Drawing.Point(63, 62);
            this.radioButtonSi.Name = "radioButtonSi";
            this.radioButtonSi.Size = new System.Drawing.Size(34, 19);
            this.radioButtonSi.TabIndex = 1;
            this.radioButtonSi.TabStop = true;
            this.radioButtonSi.Text = "Sí";
            this.radioButtonSi.UseVisualStyleBackColor = true;
            // 
            // labelRegistro
            // 
            this.labelRegistro.AutoSize = true;
            this.labelRegistro.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelRegistro.Location = new System.Drawing.Point(26, 19);
            this.labelRegistro.MaximumSize = new System.Drawing.Size(200, 0);
            this.labelRegistro.Name = "labelRegistro";
            this.labelRegistro.Size = new System.Drawing.Size(179, 30);
            this.labelRegistro.TabIndex = 0;
            this.labelRegistro.Text = "El usuario registrado no existe: ¿Desea registrarlo?";
            // 
            // checkBoxVisualizar
            // 
            this.checkBoxVisualizar.AutoSize = true;
            this.checkBoxVisualizar.Enabled = false;
            this.checkBoxVisualizar.Location = new System.Drawing.Point(34, 63);
            this.checkBoxVisualizar.Name = "checkBoxVisualizar";
            this.checkBoxVisualizar.Size = new System.Drawing.Size(138, 19);
            this.checkBoxVisualizar.TabIndex = 4;
            this.checkBoxVisualizar.Text = "Visualizar Contraseña";
            this.checkBoxVisualizar.UseVisualStyleBackColor = true;
            this.checkBoxVisualizar.CheckedChanged += new System.EventHandler(this.checkBoxVisualizar_CheckedChanged);
            // 
            // checkBoxRegistrar
            // 
            this.checkBoxRegistrar.AutoSize = true;
            this.checkBoxRegistrar.Enabled = false;
            this.checkBoxRegistrar.Location = new System.Drawing.Point(34, 92);
            this.checkBoxRegistrar.Name = "checkBoxRegistrar";
            this.checkBoxRegistrar.Size = new System.Drawing.Size(135, 19);
            this.checkBoxRegistrar.TabIndex = 5;
            this.checkBoxRegistrar.Text = "Registrar Contraseña";
            this.checkBoxRegistrar.UseVisualStyleBackColor = true;
            this.checkBoxRegistrar.CheckedChanged += new System.EventHandler(this.checkBoxRegistrar_CheckedChanged);
            // 
            // checkBoxBorrar
            // 
            this.checkBoxBorrar.AutoSize = true;
            this.checkBoxBorrar.Enabled = false;
            this.checkBoxBorrar.Location = new System.Drawing.Point(34, 121);
            this.checkBoxBorrar.Name = "checkBoxBorrar";
            this.checkBoxBorrar.Size = new System.Drawing.Size(121, 19);
            this.checkBoxBorrar.TabIndex = 6;
            this.checkBoxBorrar.Text = "Borrar Contraseña";
            this.checkBoxBorrar.UseVisualStyleBackColor = true;
            this.checkBoxBorrar.CheckedChanged += new System.EventHandler(this.checkBoxBorrar_CheckedChanged);
            // 
            // groupBoxVisualizar
            // 
            this.groupBoxVisualizar.Controls.Add(this.labelFichero);
            this.groupBoxVisualizar.Controls.Add(this.buttonFichero);
            this.groupBoxVisualizar.Controls.Add(this.comboBoxDescripcion);
            this.groupBoxVisualizar.Controls.Add(this.textBoxVisualizarPassword);
            this.groupBoxVisualizar.Controls.Add(this.labelVisualizarPassword);
            this.groupBoxVisualizar.Controls.Add(this.labelVisualizarRegis);
            this.groupBoxVisualizar.Controls.Add(this.labelVisualizarDesc);
            this.groupBoxVisualizar.Location = new System.Drawing.Point(34, 202);
            this.groupBoxVisualizar.Name = "groupBoxVisualizar";
            this.groupBoxVisualizar.Size = new System.Drawing.Size(672, 150);
            this.groupBoxVisualizar.TabIndex = 7;
            this.groupBoxVisualizar.TabStop = false;
            this.groupBoxVisualizar.Text = "Visualizar";
            // 
            // labelFichero
            // 
            this.labelFichero.AutoSize = true;
            this.labelFichero.Location = new System.Drawing.Point(321, 73);
            this.labelFichero.Name = "labelFichero";
            this.labelFichero.Size = new System.Drawing.Size(119, 15);
            this.labelFichero.TabIndex = 6;
            this.labelFichero.Text = "Ubicación del fichero";
            // 
            // buttonFichero
            // 
            this.buttonFichero.Enabled = false;
            this.buttonFichero.Location = new System.Drawing.Point(188, 69);
            this.buttonFichero.Name = "buttonFichero";
            this.buttonFichero.Size = new System.Drawing.Size(116, 23);
            this.buttonFichero.TabIndex = 5;
            this.buttonFichero.Text = "Fichero";
            this.buttonFichero.UseVisualStyleBackColor = true;
            this.buttonFichero.Click += new System.EventHandler(this.buttonFichero_Click);
            // 
            // comboBoxDescripcion
            // 
            this.comboBoxDescripcion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDescripcion.Enabled = false;
            this.comboBoxDescripcion.FormattingEnabled = true;
            this.comboBoxDescripcion.Location = new System.Drawing.Point(188, 33);
            this.comboBoxDescripcion.Name = "comboBoxDescripcion";
            this.comboBoxDescripcion.Size = new System.Drawing.Size(462, 23);
            this.comboBoxDescripcion.TabIndex = 4;
            // 
            // textBoxVisualizarPassword
            // 
            this.textBoxVisualizarPassword.Enabled = false;
            this.textBoxVisualizarPassword.Location = new System.Drawing.Point(188, 103);
            this.textBoxVisualizarPassword.Name = "textBoxVisualizarPassword";
            this.textBoxVisualizarPassword.ReadOnly = true;
            this.textBoxVisualizarPassword.Size = new System.Drawing.Size(462, 23);
            this.textBoxVisualizarPassword.TabIndex = 3;
            // 
            // labelVisualizarPassword
            // 
            this.labelVisualizarPassword.AutoSize = true;
            this.labelVisualizarPassword.Location = new System.Drawing.Point(63, 106);
            this.labelVisualizarPassword.Name = "labelVisualizarPassword";
            this.labelVisualizarPassword.Size = new System.Drawing.Size(121, 15);
            this.labelVisualizarPassword.TabIndex = 2;
            this.labelVisualizarPassword.Text = "Esta es su contraseña:";
            this.labelVisualizarPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelVisualizarRegis
            // 
            this.labelVisualizarRegis.AutoSize = true;
            this.labelVisualizarRegis.Location = new System.Drawing.Point(34, 73);
            this.labelVisualizarRegis.Name = "labelVisualizarRegis";
            this.labelVisualizarRegis.Size = new System.Drawing.Size(150, 15);
            this.labelVisualizarRegis.TabIndex = 1;
            this.labelVisualizarRegis.Text = "Registre el fichero de clave:";
            this.labelVisualizarRegis.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelVisualizarDesc
            // 
            this.labelVisualizarDesc.AutoSize = true;
            this.labelVisualizarDesc.Location = new System.Drawing.Point(74, 34);
            this.labelVisualizarDesc.Name = "labelVisualizarDesc";
            this.labelVisualizarDesc.Size = new System.Drawing.Size(110, 15);
            this.labelVisualizarDesc.TabIndex = 0;
            this.labelVisualizarDesc.Text = "Elija la descripción: ";
            this.labelVisualizarDesc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBoxRegistrar
            // 
            this.groupBoxRegistrar.Controls.Add(this.textBoxRegistrarDescripcion);
            this.groupBoxRegistrar.Controls.Add(this.textBoxRegsitrarPassword);
            this.groupBoxRegistrar.Controls.Add(this.buttonRegistrarGuardar);
            this.groupBoxRegistrar.Controls.Add(this.labelRegistrarPassword);
            this.groupBoxRegistrar.Controls.Add(this.labelRegistrarDescripción);
            this.groupBoxRegistrar.Location = new System.Drawing.Point(34, 367);
            this.groupBoxRegistrar.Name = "groupBoxRegistrar";
            this.groupBoxRegistrar.Size = new System.Drawing.Size(672, 150);
            this.groupBoxRegistrar.TabIndex = 8;
            this.groupBoxRegistrar.TabStop = false;
            this.groupBoxRegistrar.Text = "Registrar";
            // 
            // textBoxRegistrarDescripcion
            // 
            this.textBoxRegistrarDescripcion.Enabled = false;
            this.textBoxRegistrarDescripcion.Location = new System.Drawing.Point(188, 32);
            this.textBoxRegistrarDescripcion.Name = "textBoxRegistrarDescripcion";
            this.textBoxRegistrarDescripcion.Size = new System.Drawing.Size(462, 23);
            this.textBoxRegistrarDescripcion.TabIndex = 9;
            // 
            // textBoxRegsitrarPassword
            // 
            this.textBoxRegsitrarPassword.Enabled = false;
            this.textBoxRegsitrarPassword.Location = new System.Drawing.Point(188, 69);
            this.textBoxRegsitrarPassword.Name = "textBoxRegsitrarPassword";
            this.textBoxRegsitrarPassword.Size = new System.Drawing.Size(462, 23);
            this.textBoxRegsitrarPassword.TabIndex = 8;
            this.textBoxRegsitrarPassword.UseSystemPasswordChar = true;
            // 
            // buttonRegistrarGuardar
            // 
            this.buttonRegistrarGuardar.Enabled = false;
            this.buttonRegistrarGuardar.Location = new System.Drawing.Point(188, 104);
            this.buttonRegistrarGuardar.Name = "buttonRegistrarGuardar";
            this.buttonRegistrarGuardar.Size = new System.Drawing.Size(116, 23);
            this.buttonRegistrarGuardar.TabIndex = 7;
            this.buttonRegistrarGuardar.Text = "Guardar";
            this.buttonRegistrarGuardar.UseVisualStyleBackColor = true;
            this.buttonRegistrarGuardar.Click += new System.EventHandler(this.buttonRegistrarGuardar_Click);
            // 
            // labelRegistrarPassword
            // 
            this.labelRegistrarPassword.AutoSize = true;
            this.labelRegistrarPassword.Location = new System.Drawing.Point(109, 72);
            this.labelRegistrarPassword.Name = "labelRegistrarPassword";
            this.labelRegistrarPassword.Size = new System.Drawing.Size(70, 15);
            this.labelRegistrarPassword.TabIndex = 7;
            this.labelRegistrarPassword.Text = "Contraseña:";
            this.labelRegistrarPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelRegistrarDescripción
            // 
            this.labelRegistrarDescripción.AutoSize = true;
            this.labelRegistrarDescripción.Location = new System.Drawing.Point(109, 35);
            this.labelRegistrarDescripción.Name = "labelRegistrarDescripción";
            this.labelRegistrarDescripción.Size = new System.Drawing.Size(75, 15);
            this.labelRegistrarDescripción.TabIndex = 7;
            this.labelRegistrarDescripción.Text = "Descripción: ";
            this.labelRegistrarDescripción.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBoxBorrar
            // 
            this.groupBoxBorrar.Controls.Add(this.buttonBorrar);
            this.groupBoxBorrar.Controls.Add(this.comboBoxBorrar);
            this.groupBoxBorrar.Controls.Add(this.labelBorrar);
            this.groupBoxBorrar.Location = new System.Drawing.Point(34, 548);
            this.groupBoxBorrar.Name = "groupBoxBorrar";
            this.groupBoxBorrar.Size = new System.Drawing.Size(672, 120);
            this.groupBoxBorrar.TabIndex = 9;
            this.groupBoxBorrar.TabStop = false;
            this.groupBoxBorrar.Text = "Borrar";
            // 
            // buttonBorrar
            // 
            this.buttonBorrar.Enabled = false;
            this.buttonBorrar.Location = new System.Drawing.Point(188, 78);
            this.buttonBorrar.Name = "buttonBorrar";
            this.buttonBorrar.Size = new System.Drawing.Size(116, 23);
            this.buttonBorrar.TabIndex = 10;
            this.buttonBorrar.Text = "Borrar";
            this.buttonBorrar.UseVisualStyleBackColor = true;
            this.buttonBorrar.Click += new System.EventHandler(this.buttonBorrar_Click);
            // 
            // comboBoxBorrar
            // 
            this.comboBoxBorrar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBorrar.Enabled = false;
            this.comboBoxBorrar.FormattingEnabled = true;
            this.comboBoxBorrar.Location = new System.Drawing.Point(188, 33);
            this.comboBoxBorrar.Name = "comboBoxBorrar";
            this.comboBoxBorrar.Size = new System.Drawing.Size(462, 23);
            this.comboBoxBorrar.TabIndex = 11;
            // 
            // labelBorrar
            // 
            this.labelBorrar.AutoSize = true;
            this.labelBorrar.Location = new System.Drawing.Point(74, 36);
            this.labelBorrar.Name = "labelBorrar";
            this.labelBorrar.Size = new System.Drawing.Size(110, 15);
            this.labelBorrar.TabIndex = 10;
            this.labelBorrar.Text = "Elija la descripción: ";
            this.labelBorrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Location = new System.Drawing.Point(590, 690);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(116, 23);
            this.buttonGuardar.TabIndex = 10;
            this.buttonGuardar.Text = "Guardar y Cerrar";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(724, 735);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.groupBoxBorrar);
            this.Controls.Add(this.groupBoxRegistrar);
            this.Controls.Add(this.groupBoxVisualizar);
            this.Controls.Add(this.checkBoxBorrar);
            this.Controls.Add(this.checkBoxRegistrar);
            this.Controls.Add(this.checkBoxVisualizar);
            this.Controls.Add(this.groupBoxRegistroUsuario);
            this.Controls.Add(this.buttonRegistrar);
            this.Controls.Add(this.textBoxUsuario);
            this.Controls.Add(this.labelUsuario);
            this.Name = "Form1";
            this.Text = "UD05 Gestor Password Birt EHG";
            this.groupBoxRegistroUsuario.ResumeLayout(false);
            this.groupBoxRegistroUsuario.PerformLayout();
            this.groupBoxVisualizar.ResumeLayout(false);
            this.groupBoxVisualizar.PerformLayout();
            this.groupBoxRegistrar.ResumeLayout(false);
            this.groupBoxRegistrar.PerformLayout();
            this.groupBoxBorrar.ResumeLayout(false);
            this.groupBoxBorrar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelUsuario;
        private TextBox textBoxUsuario;
        private Button buttonRegistrar;
        private GroupBox groupBoxRegistroUsuario;
        private Button buttonAceptar;
        private TextBox textBoxEmail;
        private Label labelEmail;
        private RadioButton radioButtonNo;
        private RadioButton radioButtonSi;
        private Label labelRegistro;
        private CheckBox checkBoxVisualizar;
        private CheckBox checkBoxRegistrar;
        private CheckBox checkBoxBorrar;
        private GroupBox groupBoxVisualizar;
        private GroupBox groupBoxRegistrar;
        private GroupBox groupBoxBorrar;
        private TextBox textBoxVisualizarPassword;
        private Label labelVisualizarPassword;
        private Label labelVisualizarRegis;
        private Label labelVisualizarDesc;
        private Button buttonGuardar;
        private Label labelFichero;
        private Button buttonFichero;
        private ComboBox comboBoxDescripcion;
        private Label labelRegistrarDescripción;
        private TextBox textBoxRegistrarDescripcion;
        private TextBox textBoxRegsitrarPassword;
        private Button buttonRegistrarGuardar;
        private Label labelRegistrarPassword;
        private Button buttonBorrar;
        private ComboBox comboBoxBorrar;
        private Label labelBorrar;
        private OpenFileDialog openFileDialog1;
    }
}