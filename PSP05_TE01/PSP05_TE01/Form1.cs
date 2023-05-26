using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace PSP05_TE01
{
    public partial class Form1 : Form
    {
        //Constantes y variables globales
        private const string bbddPath = "bbdd/";
        private const string privatePath = "private/";
        private const string publicPath = "public/";
        private string txtPath = string.Empty;
        private string rutaClavePublica = string.Empty;
        private string rutaClavePrivada = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }
        #region Registro usuario
        private void buttonRegistrar_Click(object sender, EventArgs e)
        {
            string usuario = textBoxUsuario.Text;
            txtPath = bbddPath + usuario + ".txt";
            bool existe = File.Exists(txtPath);

            //Si el usuario existe
            if (existe)
            {
                //Activar checkboxes
                checkBoxVisualizar.Enabled = true;
                checkBoxRegistrar.Enabled = true;
                checkBoxBorrar.Enabled = true;

                //Desasctivar alta usuario
                radioButtonSi.Enabled = false;
                radioButtonNo.Enabled = false;
                radioButtonSi.Checked = false;
                textBoxEmail.Enabled = false;
                buttonAceptar.Enabled = false;

                //Actualizar rutas
                rutaClavePublica = publicPath + textBoxUsuario.Text + ".xml";
                rutaClavePrivada = privatePath + textBoxUsuario.Text + ".xml";

                //Cargar comboboxes con datos del fichero
                cargaComboBox(ref comboBoxDescripcion);
                cargaComboBox(ref comboBoxBorrar);
                if (comboBoxDescripcion.Items.Count > 0)
                {
                    comboBoxDescripcion.SelectedIndex = 0;
                    comboBoxBorrar.SelectedIndex = 0;
                }

                MessageBox.Show("Existe el usuario " + usuario, "Existe usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //Si el usuario no existe
            else if (!existe)
            {   //verificamos que cumpla formato usuario
                if (verificarUsuario(usuario))
                {
                    //Activar pregunta crear nuevo usuario con email
                    MessageBox.Show("Puedes crear el usuario " + usuario, "Crear usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Activamos zona alta de usuario
                    radioButtonSi.Enabled = true;
                    radioButtonNo.Enabled = true;
                    radioButtonSi.Checked = true;
                    textBoxEmail.Enabled = true;
                    buttonAceptar.Enabled = true;

                    //Desactivamos checkboxes
                    checkBoxVisualizar.Enabled = false;
                    checkBoxRegistrar.Enabled = false;
                    checkBoxBorrar.Enabled = false;
                }
                else
                {
                    MessageBox.Show("El usuario debe cumplir:"
                                       + Environment.NewLine
                                       + " · Tener de 4 a 10 caracteres"
                                       + Environment.NewLine
                                       + " · Todo en minúsuclas y letras exclusivamente", "Error usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            if (radioButtonSi.Checked)
            {
                //Comprobar e-mail (al menos que hay arroba y punto)
                if (textBoxEmail.Text.Contains('@') && textBoxEmail.Text.Contains('.'))
                {
                    try
                    {
                        //Si el texto no es un email saltaría el catch
                        MailAddress emailDestino = new MailAddress(textBoxEmail.Text);

                        MessageBox.Show("Vamos enviar la clave privada a " + textBoxEmail.Text, "Enviar clave privada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Si no existen creamos los directorios publico y privado
                        if (!Directory.Exists(publicPath))
                        {
                            Directory.CreateDirectory(publicPath);
                        }

                        if (!Directory.Exists(privatePath))
                        {
                            Directory.CreateDirectory(privatePath);
                        }

                        //Crear claves publica y privada
                        rutaClavePublica = publicPath + textBoxUsuario.Text + ".xml";
                        rutaClavePrivada = privatePath + textBoxUsuario.Text + ".xml";
                        generarClaves(rutaClavePublica, rutaClavePrivada);

                        //Enviar clave privada por email
                        //Preparamos el subject
                        string subject = "Clave privada de " + textBoxUsuario.Text;
                        //Body del email
                        string body = "Clave de acceso a contraseñas del usuario " + textBoxUsuario.Text;
                        //Fichero de clave privada adjunto
                        Attachment ficheroAdjunto = new Attachment(rutaClavePrivada);
                        //Dirección origen
                        MailAddress emailOrigen = new MailAddress("pruebaedupsp@gmail.com", "From Prueba Edu Birt");

                        enviarEmail(subject,body,emailOrigen,emailDestino,ficheroAdjunto);

                        //Una vez enviado el mail borramos la clave privada en local
                        File.Delete(rutaClavePrivada);

                        //Cuando se ha enviado el email creamos el txt del usuario (directorio también si BBDD si no existe)
                        if (!Directory.Exists(bbddPath))
                        {
                            Directory.CreateDirectory(bbddPath);
                        }
                        using (FileStream fs = new FileStream(txtPath, FileMode.CreateNew)) { }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Revisa el formato del email", "Error email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                    MessageBox.Show("Hay que registrar el usuario para utilizar la aplicación", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Visualizar 
        private void checkBoxVisualizar_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxVisualizar.Checked)
            {                
                //Activar zona visualizar
                foreach (Control control in groupBoxVisualizar.Controls)
                {
                    control.Enabled = true;
                }
            }
            else
            {
                //Desactivar zona visualizar
                foreach (Control control in groupBoxVisualizar.Controls)
                {
                    control.Enabled = false;
                }
            }
        }

        private void buttonFichero_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Seleccionar el fichero";
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Filter = "All files (*.*)|*.*|Xml File(*.xml)|*.xml";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                labelFichero.Text = openFileDialog1.FileName;
                //Vamos a descifrar la password con la clave privada
                RegistroComboBox registroComboBox = (RegistroComboBox)comboBoxDescripcion.SelectedItem;

                try
                {
                    byte[] desencriptado = desencriptar(openFileDialog1.FileName, registroComboBox.Password);
                    textBoxVisualizarPassword.Text = Encoding.UTF8.GetString(desencriptado);
                }catch (Exception ex)
                {
                    MessageBox.Show("Error: "+ex.Message, "¿Has usado la clave correcta?", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                    MessageBox.Show("No has elegido ningún fichero", "Error fichero", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Registrar
        private void checkBoxRegistrar_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRegistrar.Checked)
            {
                //Activar zona registrar
                foreach (Control control in groupBoxRegistrar.Controls)
                {
                    control.Enabled = true;
                }
            }
            else
            {
                //Desactivar zona registrar
                foreach (Control control in groupBoxRegistrar.Controls)
                {
                    control.Enabled = false;
                }
            }
        }

        private void buttonRegistrarGuardar_Click(object sender, EventArgs e)
        {
            // Comprobamos que la contraseña cumple condiciones
            // Si cumple guardamos registro: descripcion + contraseña encriptada
            if (verificarPassword(textBoxRegsitrarPassword.Text))
            {
                MessageBox.Show("Contraseña cumple requisitos", "Password OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Encriptamos contraseña
                byte[] bytePasswordCifrado = encriptar(rutaClavePublica, Encoding.UTF8.GetBytes(this.textBoxRegsitrarPassword.Text));
                string cadenaPasswordCifrado = Encoding.UTF8.GetString(bytePasswordCifrado);
                MessageBox.Show("Contraseña cifrada: " + cadenaPasswordCifrado, "Password cifrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                //Prefiero usar ToBase64String
                //https://stackoverflow.com/questions/19849883/difference-between-convert-tobase64string-convert-frombase64string-and-encoding
                string cadenaParaFichero = Convert.ToBase64String(bytePasswordCifrado);
                MessageBox.Show("Contraseña cifrada Base 64: " + cadenaParaFichero, "Password cifrada 2", MessageBoxButtons.OK, MessageBoxIcon.Information);

                RegistroComboBox item = new RegistroComboBox(textBoxRegistrarDescripcion.Text, bytePasswordCifrado);
                comboBoxDescripcion.Items.Add(item);
                igualaComboBox(ref comboBoxDescripcion, ref comboBoxBorrar);
                comboBoxDescripcion.SelectedIndex = 0;
                comboBoxBorrar.SelectedIndex = 0;
            }
            else   // Si no cumple fomato avisamos
            {
                MessageBox.Show("La contraseña al menos debe de contener"
                    + Environment.NewLine
                    + " · 1 Mayúscula"
                    + Environment.NewLine
                    + " · 1 Minúscula"
                    + Environment.NewLine
                    + " · 1 Número"
                    + Environment.NewLine
                    + " . 8-10 caracteres de longitud"
                    + Environment.NewLine
                    + " . 1 Cararcter: !@#&()–[{}:',?/*~$^+=<>", "Error password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Borrar
        private void checkBoxBorrar_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxBorrar.Checked)
            {
                //Activar zona borrar
                foreach (Control control in groupBoxBorrar.Controls)
                {
                    control.Enabled = true;
                }
            }
            else
            {
                //Desactivar zona borrar
                foreach (Control control in groupBoxBorrar.Controls)
                {
                    control.Enabled = false;
                }
            }
        }

        private void buttonBorrar_Click(object sender, EventArgs e)
        {
            if (comboBoxBorrar.SelectedItem.ToString() != null)
            {
                string? descripcionEliminar = comboBoxBorrar.SelectedItem.ToString();
                comboBoxBorrar.Items.Remove(comboBoxBorrar.SelectedItem);
                igualaComboBox(ref comboBoxBorrar, ref comboBoxDescripcion);

                if (comboBoxDescripcion.Items.Count > 0)
                {
                    comboBoxDescripcion.SelectedIndex = 0;
                    comboBoxBorrar.SelectedIndex = 0; 
                }
                MessageBox.Show("Se ha borrado la contraseña de " + descripcionEliminar, "Password borrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Guardar y cerrar
        //Boton Guardar-Cerrar
        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            //Vaciamos el fichero de texto
            File.WriteAllText(txtPath, string.Empty);
            //Guardamos en fichero de texto las parejas descripcion - password encriptada que tenemos
            using (StreamWriter sw = new StreamWriter(txtPath))
            {
                for (int i = 0; i < comboBoxDescripcion.Items.Count; i++)
                {
                    RegistroComboBox item = (RegistroComboBox)comboBoxDescripcion.Items[i];
                    sw.WriteLine(item.Descripcion + ";" + Convert.ToBase64String(item.Password));
                }
            }
            MessageBox.Show("Se han guardado " + comboBoxDescripcion.Items.Count+" passwords. Adiós", "Guardado realizado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Cerramos el formulario
            this.Close();
        }
        #endregion

        #region Metodos y clases auxiliares

        //Método de los videos explicativos para generar clave privada y publica
        private void generarClaves(string publicKF, string privateKF)
        {
            //Creamos un objeto de tipo RSACryptoServiceProvider para hacer uso de la clave pública y clave privada para su poserior uso.
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                //Obtiene o establece un valor que indica si la clave debe conservarse en el proveedor de servicios criptográficos (CSP).
                //Le indicamos el valor a false porque no queremos que esté en ningún proveedor de servicios.
                rsa.PersistKeyInCsp = false;

                //Borramos cualquier fichero que contenga los mismos nombres
                if (File.Exists(publicKF))
                    File.Delete(publicKF);
                if (File.Exists(privateKF))
                    File.Delete(privateKF);

                //ToXmlString(false): Crea un string con la clave pública. Para que sea pública hay que pasarle como parámetro (false).
                string publicKey = rsa.ToXmlString(false);

                //Crea un fichero y guarda el texto de la clave en el fichero.
                File.WriteAllText(publicKF, publicKey);

                //Mismo proceso anterior para la clave privada
                string privateKey = rsa.ToXmlString(true);
                File.WriteAllText(privateKF, privateKey);
            }
        }
        //Método reutilizado de los vídeos para encriptar
        private byte[] encriptar(string publicKF, byte[] textoPlano)
        {
            byte[] encriptado;

            //Se crea un objeto de tipo RSACryptoServiceProvider para poder hacer uso de sus métodos de encriptación
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                //Le indicamos el valor a false porque no queremos que esté en ningún proveedor de servicios.
                rsa.PersistKeyInCsp = false;

                //Lee el contenido del fichero y lo guarda en un string
                string publicKey = File.ReadAllText(publicKF);

                //FromXmlString(publicKey): Inicializa un objeto RSA de la información de clave de una cadena XML.
                rsa.FromXmlString(publicKey);

                //Cifra los datos con el algoritmo RSA.
                //@textoPlano: datos que se van a cifrar
                //@Booleano: true para realizar el cifrado RSA directo mediante el relleno de OAEP (solo disponible en equipos con Windows XP o versiones posteriores como en nuestro caso); de lo contrario, false para usar el relleno PKCS#1 v1.5.
                encriptado = rsa.Encrypt(textoPlano, true);
            }
            //Valor que se devuelve
            return encriptado;
        }
        //Método de los vídeos para desencriptar
        private byte[] desencriptar(string privateKF, byte[] textoEncriptado)
        {
            byte[] desencriptado;
            //Se crea un objeto de tipo RSACryptoServiceProvider para poder hacer uso de sus métodos.
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                //Le indicamos el valor a false porque no queremos que esté en ningún proveedor de servicios.
                rsa.PersistKeyInCsp = false;

                //Lee el contenido del fichero y lo guarda en un string
                string privateKey = File.ReadAllText(privateKF);

                //FromXmlString(false): Inicializa un objeto RSA de la información de clave de una cadena XML.
                //En este caso clave privada ya que la utilizaremos para descifrar
                rsa.FromXmlString(privateKey);

                //Descifra los datos que se cifraron anteriormente.
                //@textoEncriptado: Datos que se van a descifrar.
                //@Booleano: true para realizar el cifrado RSA directo mediante el relleno de OAEP (solo disponible en equipos con Windows XP o versiones posteriores como en nuestro caso); de lo contrario, false 
                desencriptado = rsa.Decrypt(textoEncriptado, true);
            }
            return (desencriptado);

        }
        //Método para enviar un email teniendo subject,body,origen,destino y adjunto
        private void enviarEmail(string subject,string body,MailAddress emailOrigen,MailAddress emailDestino,Attachment ficheroAdjunto)
        {
            try
            {
                using (MailMessage message = new MailMessage(emailOrigen, emailDestino))
                {
                    message.Subject = subject;
                    message.Body = body;
                    message.Attachments.Add(ficheroAdjunto);

                    using (SmtpClient client = new SmtpClient())
                    {
                        client.Host = "smtp.gmail.com";
                        client.Port = 587;
                        client.EnableSsl = true;
                        client.Credentials = new NetworkCredential("pruebaedupsp@gmail.com", "pmaeijwiqkxxfybd");
                        client.Send(message);
                    }
                }
                //Avisar con MessageBox de Email enviado
                MessageBox.Show("Email con clave privada enviado", "Email enviado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }catch(Exception ex)
            {   //Avisamos si hay error/excepción
                MessageBox.Show("Email error: "+ex.Message, "Error al enviar email", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Las Regex tienen su complejidad de sintaxis hacerlas bien, he pedido ayuda a chatGPT para el password
        private bool verificarPassword(string password)
        {
            // Verificar si la longitud de la contraseña está entre 8 y 10 caracteres
            if (password.Length < 8 || password.Length > 10)
            {
                return false;
            }

            // Verificar si la contraseña contiene al menos una mayúscula, una minúscula y un número
            Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$");
            if (!regex.IsMatch(password))
            {
                return false;
            }

            // Verificar si la contraseña contiene al menos uno de los caracteres especiales
            regex = new Regex(@"^[a-zA-Z0-9!@#&()–[{}\:',?/*~$^+=<>]+$");
            if (!regex.IsMatch(password))
            {
                return false;
            }

            // Si la contraseña cumple con todas las condiciones, es válida
            return true;
        }
        private bool verificarUsuario(string usuario)
        {
            // Verificar si la longitud del usuario está entre 4 y 10 caracteres
            if (usuario.Length < 4 || usuario.Length > 10)
            {
                return false;
            }

            // Verificar si el usuario contiene minúsculas 
            Regex regex = new Regex("^[a-z]*$");
            if (!regex.IsMatch(usuario))
            {
                return false;
            }

            // Si el usuario cumple con todas las condiciones, es válido
            return true;
        }
        //Para cargar los comboBox con los datos del fichero de texto al inicio
        private void cargaComboBox (ref System.Windows.Forms.ComboBox comboBox)
        {
            comboBox.Items.Clear();

            using (StreamReader sr = new StreamReader(txtPath))
            {
                string linea = string.Empty;
                while ((linea = sr.ReadLine()) != null)
                {
                    //Dividimos en partes cada linea
                    string[] parte = linea.Split(';'); // Separamos la descripción de la contraseña encriptada
                    string descripcion = parte[0];
                    byte[] passwordCifrado = Convert.FromBase64String(parte[1]);
                    RegistroComboBox item = new RegistroComboBox(descripcion, passwordCifrado);
                    comboBox.Items.Add(item);
                }
            }
        }

        //Para mantener iguales los comboBox de Borrar y Visualizar
        private void igualaComboBox(ref System.Windows.Forms.ComboBox comboBoxOrigen, ref System.Windows.Forms.ComboBox comboBoxDestino)
        {
            comboBoxDestino.Items.Clear();
            for (int i =0;i<comboBoxOrigen.Items.Count;i++)
            {
                comboBoxDestino.Items.Add(comboBoxOrigen.Items[i]);
            }
        }
    }

    //Clase para registros a guardar en ComboBox
    public class RegistroComboBox
    {
        public string Descripcion { get; set; }
        public byte[] Password { get; set; }
        public RegistroComboBox(string descripcion, byte[] password)
        {
            Descripcion = descripcion;
            Password = password;
        }
        public override string ToString()
        {
            return Descripcion;
        }
    }
    #endregion
}