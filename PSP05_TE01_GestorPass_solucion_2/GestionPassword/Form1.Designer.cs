namespace GestionPassword
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
            lbl_Usuario = new Label();
            txt_Usuario = new TextBox();
            btn_Registrar = new Button();
            grB_Registro = new GroupBox();
            txt_Email = new TextBox();
            lbl_Email = new Label();
            btn_Aceptar = new Button();
            rdB_RegistrarNo = new RadioButton();
            rdB_RegistrarSi = new RadioButton();
            lbl_MensajeRegistro = new Label();
            grB_Visualizar = new GroupBox();
            lbl_Ubicacion = new Label();
            btn_Fichero = new Button();
            cmB_Descripcion01 = new ComboBox();
            lbl_Fichero = new Label();
            lbl_Descripcion01 = new Label();
            txt_contrasena01 = new TextBox();
            lbl_Contrasena01 = new Label();
            grB_Registrar = new GroupBox();
            txt_Descripcion = new TextBox();
            btn_Guardar = new Button();
            lbl_Contrasena = new Label();
            lbl_Descripcion02 = new Label();
            txt_Contrasena02 = new TextBox();
            grB_Borrar = new GroupBox();
            cmB_Descripcion03 = new ComboBox();
            lbl_Descripcion03 = new Label();
            btn_Borrar = new Button();
            btn_GuardarCerrar = new Button();
            chB_Visualizar = new CheckBox();
            chB_Registrar = new CheckBox();
            chB_Borrar = new CheckBox();
            oFD_Fichero = new OpenFileDialog();
            grB_Registro.SuspendLayout();
            grB_Visualizar.SuspendLayout();
            grB_Registrar.SuspendLayout();
            grB_Borrar.SuspendLayout();
            SuspendLayout();
            // 
            // lbl_Usuario
            // 
            lbl_Usuario.AutoSize = true;
            lbl_Usuario.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_Usuario.Location = new Point(25, 25);
            lbl_Usuario.Name = "lbl_Usuario";
            lbl_Usuario.Size = new Size(49, 15);
            lbl_Usuario.TabIndex = 0;
            lbl_Usuario.Text = "Usuario";
            // 
            // txt_Usuario
            // 
            txt_Usuario.Location = new Point(90, 22);
            txt_Usuario.Name = "txt_Usuario";
            txt_Usuario.Size = new Size(182, 23);
            txt_Usuario.TabIndex = 1;
            // 
            // btn_Registrar
            // 
            btn_Registrar.Location = new Point(300, 21);
            btn_Registrar.Name = "btn_Registrar";
            btn_Registrar.Size = new Size(107, 23);
            btn_Registrar.TabIndex = 2;
            btn_Registrar.Text = "Registrar";
            btn_Registrar.UseVisualStyleBackColor = true;
            btn_Registrar.Click += btn_Registrar_Click;
            // 
            // grB_Registro
            // 
            grB_Registro.Controls.Add(txt_Email);
            grB_Registro.Controls.Add(lbl_Email);
            grB_Registro.Controls.Add(btn_Aceptar);
            grB_Registro.Controls.Add(rdB_RegistrarNo);
            grB_Registro.Controls.Add(rdB_RegistrarSi);
            grB_Registro.Controls.Add(lbl_MensajeRegistro);
            grB_Registro.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            grB_Registro.Location = new Point(442, 25);
            grB_Registro.Name = "grB_Registro";
            grB_Registro.Size = new Size(306, 114);
            grB_Registro.TabIndex = 6;
            grB_Registro.TabStop = false;
            grB_Registro.Text = "Registro Usuario";
            // 
            // txt_Email
            // 
            txt_Email.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txt_Email.Location = new Point(41, 81);
            txt_Email.Name = "txt_Email";
            txt_Email.Size = new Size(181, 23);
            txt_Email.TabIndex = 8;
            txt_Email.Text = "alex.perez.j@gmail.com";
            // 
            // lbl_Email
            // 
            lbl_Email.AutoSize = true;
            lbl_Email.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Email.Location = new Point(6, 85);
            lbl_Email.Name = "lbl_Email";
            lbl_Email.Size = new Size(36, 15);
            lbl_Email.TabIndex = 7;
            lbl_Email.Text = "Email";
            // 
            // btn_Aceptar
            // 
            btn_Aceptar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Aceptar.Location = new Point(228, 81);
            btn_Aceptar.Name = "btn_Aceptar";
            btn_Aceptar.Size = new Size(70, 23);
            btn_Aceptar.TabIndex = 7;
            btn_Aceptar.Text = "Aceptar";
            btn_Aceptar.UseVisualStyleBackColor = true;
            btn_Aceptar.Click += btn_Aceptar_Click;
            // 
            // rdB_RegistrarNo
            // 
            rdB_RegistrarNo.AutoSize = true;
            rdB_RegistrarNo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            rdB_RegistrarNo.Location = new Point(162, 56);
            rdB_RegistrarNo.Name = "rdB_RegistrarNo";
            rdB_RegistrarNo.Size = new Size(41, 19);
            rdB_RegistrarNo.TabIndex = 8;
            rdB_RegistrarNo.TabStop = true;
            rdB_RegistrarNo.Text = "No";
            rdB_RegistrarNo.UseVisualStyleBackColor = true;
            // 
            // rdB_RegistrarSi
            // 
            rdB_RegistrarSi.AutoSize = true;
            rdB_RegistrarSi.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            rdB_RegistrarSi.Location = new Point(111, 56);
            rdB_RegistrarSi.Name = "rdB_RegistrarSi";
            rdB_RegistrarSi.Size = new Size(34, 19);
            rdB_RegistrarSi.TabIndex = 7;
            rdB_RegistrarSi.TabStop = true;
            rdB_RegistrarSi.Text = "Sí";
            rdB_RegistrarSi.UseVisualStyleBackColor = true;
            // 
            // lbl_MensajeRegistro
            // 
            lbl_MensajeRegistro.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_MensajeRegistro.Location = new Point(6, 31);
            lbl_MensajeRegistro.Name = "lbl_MensajeRegistro";
            lbl_MensajeRegistro.Size = new Size(294, 19);
            lbl_MensajeRegistro.TabIndex = 7;
            lbl_MensajeRegistro.Text = "El usuario indicado no existe. ¿Desea registrarlo?";
            lbl_MensajeRegistro.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // grB_Visualizar
            // 
            grB_Visualizar.Controls.Add(lbl_Ubicacion);
            grB_Visualizar.Controls.Add(btn_Fichero);
            grB_Visualizar.Controls.Add(cmB_Descripcion01);
            grB_Visualizar.Controls.Add(lbl_Fichero);
            grB_Visualizar.Controls.Add(lbl_Descripcion01);
            grB_Visualizar.Controls.Add(txt_contrasena01);
            grB_Visualizar.Controls.Add(lbl_Contrasena01);
            grB_Visualizar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            grB_Visualizar.Location = new Point(25, 156);
            grB_Visualizar.Name = "grB_Visualizar";
            grB_Visualizar.Size = new Size(723, 137);
            grB_Visualizar.TabIndex = 7;
            grB_Visualizar.TabStop = false;
            grB_Visualizar.Text = "Visualizar";
            // 
            // lbl_Ubicacion
            // 
            lbl_Ubicacion.AutoSize = true;
            lbl_Ubicacion.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Ubicacion.Location = new Point(374, 65);
            lbl_Ubicacion.Name = "lbl_Ubicacion";
            lbl_Ubicacion.Size = new Size(119, 15);
            lbl_Ubicacion.TabIndex = 8;
            lbl_Ubicacion.Text = "Ubicación del fichero";
            // 
            // btn_Fichero
            // 
            btn_Fichero.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Fichero.Location = new Point(222, 61);
            btn_Fichero.Name = "btn_Fichero";
            btn_Fichero.Size = new Size(136, 23);
            btn_Fichero.TabIndex = 8;
            btn_Fichero.Text = "Fichero";
            btn_Fichero.UseVisualStyleBackColor = true;
            btn_Fichero.Click += btn_Fichero_Click;
            // 
            // cmB_Descripcion01
            // 
            cmB_Descripcion01.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            cmB_Descripcion01.FormattingEnabled = true;
            cmB_Descripcion01.Location = new Point(223, 27);
            cmB_Descripcion01.Name = "cmB_Descripcion01";
            cmB_Descripcion01.Size = new Size(492, 23);
            cmB_Descripcion01.TabIndex = 13;
            // 
            // lbl_Fichero
            // 
            lbl_Fichero.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Fichero.Location = new Point(7, 65);
            lbl_Fichero.Name = "lbl_Fichero";
            lbl_Fichero.Size = new Size(195, 15);
            lbl_Fichero.TabIndex = 12;
            lbl_Fichero.Text = "Registra el fichero de clave";
            lbl_Fichero.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lbl_Descripcion01
            // 
            lbl_Descripcion01.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Descripcion01.Location = new Point(7, 30);
            lbl_Descripcion01.Name = "lbl_Descripcion01";
            lbl_Descripcion01.Size = new Size(195, 15);
            lbl_Descripcion01.TabIndex = 11;
            lbl_Descripcion01.Text = "Elige la descripción";
            lbl_Descripcion01.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txt_contrasena01
            // 
            txt_contrasena01.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            txt_contrasena01.Location = new Point(223, 97);
            txt_contrasena01.Name = "txt_contrasena01";
            txt_contrasena01.Size = new Size(492, 23);
            txt_contrasena01.TabIndex = 10;
            // 
            // lbl_Contrasena01
            // 
            lbl_Contrasena01.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Contrasena01.Location = new Point(7, 100);
            lbl_Contrasena01.Name = "lbl_Contrasena01";
            lbl_Contrasena01.Size = new Size(195, 15);
            lbl_Contrasena01.TabIndex = 9;
            lbl_Contrasena01.Text = "Ésta es tu contraseña";
            lbl_Contrasena01.TextAlign = ContentAlignment.MiddleRight;
            // 
            // grB_Registrar
            // 
            grB_Registrar.Controls.Add(txt_Descripcion);
            grB_Registrar.Controls.Add(btn_Guardar);
            grB_Registrar.Controls.Add(lbl_Contrasena);
            grB_Registrar.Controls.Add(lbl_Descripcion02);
            grB_Registrar.Controls.Add(txt_Contrasena02);
            grB_Registrar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            grB_Registrar.Location = new Point(25, 316);
            grB_Registrar.Name = "grB_Registrar";
            grB_Registrar.Size = new Size(723, 137);
            grB_Registrar.TabIndex = 14;
            grB_Registrar.TabStop = false;
            grB_Registrar.Text = "Registrar";
            // 
            // txt_Descripcion
            // 
            txt_Descripcion.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txt_Descripcion.Location = new Point(223, 27);
            txt_Descripcion.Name = "txt_Descripcion";
            txt_Descripcion.Size = new Size(492, 23);
            txt_Descripcion.TabIndex = 13;
            // 
            // btn_Guardar
            // 
            btn_Guardar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Guardar.Location = new Point(222, 98);
            btn_Guardar.Name = "btn_Guardar";
            btn_Guardar.Size = new Size(136, 23);
            btn_Guardar.TabIndex = 8;
            btn_Guardar.Text = "Guardar";
            btn_Guardar.UseVisualStyleBackColor = true;
            btn_Guardar.Click += btn_Guardar_Click;
            // 
            // lbl_Contrasena
            // 
            lbl_Contrasena.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Contrasena.Location = new Point(7, 65);
            lbl_Contrasena.Name = "lbl_Contrasena";
            lbl_Contrasena.Size = new Size(195, 15);
            lbl_Contrasena.TabIndex = 12;
            lbl_Contrasena.Text = "Contraseña";
            lbl_Contrasena.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lbl_Descripcion02
            // 
            lbl_Descripcion02.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Descripcion02.Location = new Point(7, 30);
            lbl_Descripcion02.Name = "lbl_Descripcion02";
            lbl_Descripcion02.Size = new Size(195, 15);
            lbl_Descripcion02.TabIndex = 11;
            lbl_Descripcion02.Text = "Descripción";
            lbl_Descripcion02.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txt_Contrasena02
            // 
            txt_Contrasena02.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txt_Contrasena02.Location = new Point(223, 62);
            txt_Contrasena02.Name = "txt_Contrasena02";
            txt_Contrasena02.PasswordChar = '*';
            txt_Contrasena02.Size = new Size(492, 23);
            txt_Contrasena02.TabIndex = 10;
            // 
            // grB_Borrar
            // 
            grB_Borrar.Controls.Add(cmB_Descripcion03);
            grB_Borrar.Controls.Add(lbl_Descripcion03);
            grB_Borrar.Controls.Add(btn_Borrar);
            grB_Borrar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            grB_Borrar.Location = new Point(25, 474);
            grB_Borrar.Name = "grB_Borrar";
            grB_Borrar.Size = new Size(723, 104);
            grB_Borrar.TabIndex = 15;
            grB_Borrar.TabStop = false;
            grB_Borrar.Text = "Borrar";
            // 
            // cmB_Descripcion03
            // 
            cmB_Descripcion03.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            cmB_Descripcion03.FormattingEnabled = true;
            cmB_Descripcion03.Location = new Point(222, 27);
            cmB_Descripcion03.Name = "cmB_Descripcion03";
            cmB_Descripcion03.Size = new Size(492, 23);
            cmB_Descripcion03.TabIndex = 15;
            // 
            // lbl_Descripcion03
            // 
            lbl_Descripcion03.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Descripcion03.Location = new Point(6, 30);
            lbl_Descripcion03.Name = "lbl_Descripcion03";
            lbl_Descripcion03.Size = new Size(195, 15);
            lbl_Descripcion03.TabIndex = 14;
            lbl_Descripcion03.Text = "Elige la descripción";
            lbl_Descripcion03.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btn_Borrar
            // 
            btn_Borrar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_Borrar.Location = new Point(222, 62);
            btn_Borrar.Name = "btn_Borrar";
            btn_Borrar.Size = new Size(136, 23);
            btn_Borrar.TabIndex = 8;
            btn_Borrar.Text = "Borrar";
            btn_Borrar.UseVisualStyleBackColor = true;
            btn_Borrar.Click += btn_Borrar_Click;
            // 
            // btn_GuardarCerrar
            // 
            btn_GuardarCerrar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_GuardarCerrar.Location = new Point(611, 591);
            btn_GuardarCerrar.Name = "btn_GuardarCerrar";
            btn_GuardarCerrar.Size = new Size(136, 23);
            btn_GuardarCerrar.TabIndex = 16;
            btn_GuardarCerrar.Text = "Guardar y Cerrar";
            btn_GuardarCerrar.UseVisualStyleBackColor = true;
            btn_GuardarCerrar.Click += btn_GuardarCerrar_Click;
            // 
            // chB_Visualizar
            // 
            chB_Visualizar.AutoSize = true;
            chB_Visualizar.Location = new Point(90, 57);
            chB_Visualizar.Name = "chB_Visualizar";
            chB_Visualizar.Size = new Size(136, 19);
            chB_Visualizar.TabIndex = 17;
            chB_Visualizar.Text = "Visualizar contraseña";
            chB_Visualizar.UseVisualStyleBackColor = true;
            chB_Visualizar.CheckedChanged += chB_Visualizar_CheckedChanged;
            // 
            // chB_Registrar
            // 
            chB_Registrar.AutoSize = true;
            chB_Registrar.Location = new Point(90, 82);
            chB_Registrar.Name = "chB_Registrar";
            chB_Registrar.Size = new Size(133, 19);
            chB_Registrar.TabIndex = 18;
            chB_Registrar.Text = "Registrar contraseña";
            chB_Registrar.UseVisualStyleBackColor = true;
            chB_Registrar.CheckedChanged += chB_Registrar_CheckedChanged;
            // 
            // chB_Borrar
            // 
            chB_Borrar.AutoSize = true;
            chB_Borrar.Location = new Point(90, 107);
            chB_Borrar.Name = "chB_Borrar";
            chB_Borrar.Size = new Size(119, 19);
            chB_Borrar.TabIndex = 19;
            chB_Borrar.Text = "Borrar contraseña";
            chB_Borrar.UseVisualStyleBackColor = true;
            chB_Borrar.CheckedChanged += chB_Borrar_CheckedChanged;
            // 
            // oFD_Fichero
            // 
            oFD_Fichero.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(771, 634);
            Controls.Add(chB_Borrar);
            Controls.Add(chB_Registrar);
            Controls.Add(chB_Visualizar);
            Controls.Add(btn_GuardarCerrar);
            Controls.Add(grB_Borrar);
            Controls.Add(grB_Registrar);
            Controls.Add(grB_Visualizar);
            Controls.Add(grB_Registro);
            Controls.Add(btn_Registrar);
            Controls.Add(txt_Usuario);
            Controls.Add(lbl_Usuario);
            Name = "Form1";
            Text = "PSP05 Gestión Password";
            grB_Registro.ResumeLayout(false);
            grB_Registro.PerformLayout();
            grB_Visualizar.ResumeLayout(false);
            grB_Visualizar.PerformLayout();
            grB_Registrar.ResumeLayout(false);
            grB_Registrar.PerformLayout();
            grB_Borrar.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_Usuario;
        private TextBox txt_Usuario;
        private Button btn_Registrar;
        private GroupBox grB_Registro;
        private Label lbl_MensajeRegistro;
        private TextBox txt_Email;
        private Label lbl_Email;
        private Button btn_Aceptar;
        private RadioButton rdB_RegistrarNo;
        private RadioButton rdB_RegistrarSi;
        private GroupBox grB_Visualizar;
        private Label lbl_Ubicacion;
        private Button btn_Fichero;
        private ComboBox cmB_Descripcion01;
        private Label lbl_Fichero;
        private Label lbl_Descripcion01;
        private TextBox txt_contrasena01;
        private Label lbl_Contrasena01;
        private GroupBox grB_Registrar;
        private TextBox txt_Descripcion;
        private Button btn_Guardar;
        private Label lbl_Contrasena;
        private Label lbl_Descripcion02;
        private TextBox txt_Contrasena02;
        private GroupBox grB_Borrar;
        private ComboBox cmB_Descripcion03;
        private Label lbl_Descripcion03;
        private Button btn_Borrar;
        private Button btn_GuardarCerrar;
        private CheckBox chB_Visualizar;
        private CheckBox chB_Registrar;
        private CheckBox chB_Borrar;
        private OpenFileDialog oFD_Fichero;
    }
}