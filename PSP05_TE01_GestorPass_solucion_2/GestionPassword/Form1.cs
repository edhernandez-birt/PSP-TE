using MimeKit;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using MailKit.Net.Smtp;

using MimeKit;
using MailKit.Net.Smtp;
using System.Net.Mail;
using System.Net.Mime;
using System.Linq;
using System.Net;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace GestionPassword
{
    public partial class Form1 : Form
    {

        String path = "..//..//..//..//bbdd//";
        String pathPublic = "..//..//..//..//public//";
        String pathPrivate = "..//..//..//..//private//";

        List<string> descripciones = new List<string>();
        List<string> contrasenas = new List<string>();

        byte[] contrasenaCifrada;

        public Form1()
        {
            InitializeComponent();
            EstadoInicial();
        }

        private void EstadoInicial()
        {
            chB_Visualizar.Enabled = false;
            chB_Registrar.Enabled = false;
            chB_Borrar.Enabled = false;
            grB_Registro.Enabled = false;
            grB_Visualizar.Enabled = false;
            grB_Registrar.Enabled = false;
            grB_Borrar.Enabled = false;
            btn_GuardarCerrar.Enabled = false;
        }

        private void btn_Registrar_Click(object sender, EventArgs e)
        {
            if (txt_Usuario.Text.Equals(""))
            {
                string mensaje = "Debes rellenar el nombre de usuario";
                string caption = "Falta informaci�n";
                MessageBoxButtons botones = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(mensaje, caption, botones);

                txt_Usuario.Focus();
            }
            else
            {
                if (Regex.IsMatch(txt_Usuario.Text, @"^[a-z]{4,10}$"))
                {
                    String nombreFicheroContrasenas = path + txt_Usuario.Text + ".txt";

                    if (File.Exists(nombreFicheroContrasenas))
                    {
                        string[] lineasFichero = File.ReadAllLines(nombreFicheroContrasenas);

                        for (int i = 0; i < lineasFichero.Length; i = i + 2)
                        {
                            descripciones.Add(lineasFichero[i]);
                            contrasenas.Add(lineasFichero[i + 1]);
                        }

                        txt_Usuario.Enabled = false;
                        btn_Registrar.Enabled = false;
                        chB_Borrar.Enabled = true;
                        chB_Registrar.Enabled = true;
                        chB_Visualizar.Enabled = true;
                    }
                    else
                    {
                        string mensaje = "El usuario no existe. Debes registrarlo.";
                        string caption = "Atenci�n";
                        MessageBoxButtons botones = MessageBoxButtons.OK;
                        DialogResult result = MessageBox.Show(mensaje, caption, botones);

                        grB_Registro.Enabled = true;
                    }
                }
                else
                {
                    string mensaje = "El usuario tiene que tener entre 4 y 10 car�cteres en min�scula.";
                    string caption = "Atenci�n";
                    MessageBoxButtons botones = MessageBoxButtons.OK;
                    DialogResult result = MessageBox.Show(mensaje, caption, botones);

                    txt_Usuario.Focus();
                }
            }
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            if (rdB_RegistrarSi.Checked && !txt_Email.Text.Equals(""))
            {
                if (Regex.IsMatch(txt_Email.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    GenerarClaves();
                    EnviarEmail();

                    String nombreFicheroContrasenas = path + txt_Usuario.Text + ".txt";
                    File.CreateText(nombreFicheroContrasenas);

                    string mensaje = "Puedes encontrar tu fichero en la ruta " + pathPrivate + txt_Usuario.Text + "_private.xml";
                    string caption = "Registro realizado.";
                    MessageBoxButtons botones = MessageBoxButtons.OK;
                    DialogResult result = MessageBox.Show(mensaje, caption, botones);

                    grB_Registro.Enabled = false;
                    txt_Usuario.Enabled = false;
                    btn_Registrar.Enabled = false;
                    chB_Borrar.Enabled = true;
                    chB_Visualizar.Enabled = true;
                    chB_Registrar.Enabled = true;
                }
                else
                {
                    string mensaje = "El email introducido no es una direcci�n de correo v�lida";
                    string caption = "Atenci�n";
                    MessageBoxButtons botones = MessageBoxButtons.OK;
                    DialogResult result = MessageBox.Show(mensaje, caption, botones);

                    txt_Email.Focus();
                }
            }
            else
            {
                string mensaje = "Para registrar el usuario debe hacer clic en 'S�' y escribir un email v�lido";
                string caption = "Atenci�n";
                MessageBoxButtons botones = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(mensaje, caption, botones);

                txt_Email.Focus();
            }
        }


        private void GenerarClaves()
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;

                string publicKey = rsa.ToXmlString(false);
                String ficheroClavePublica = pathPublic + txt_Usuario.Text + "_public.xml";
                File.WriteAllText(ficheroClavePublica, publicKey);

                string privateKey = rsa.ToXmlString(true);
                String ficheroClavePrivada = pathPrivate + txt_Usuario.Text + "_private.xml";
                File.WriteAllText(ficheroClavePrivada, privateKey);
            }
        }


        private void EnviarEmail()
        {
            String ficheroClavePrivada = pathPrivate + txt_Usuario.Text + "_private.xml";
            Attachment data = new Attachment(ficheroClavePrivada, MediaTypeNames.Application.Octet);

            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();

            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("alejperezbirt@gmail.com", "nuvlpsjdqbiamgff");

            MailMessage mail = new MailMessage("alejperezbirt@gmail.com", txt_Email.Text, "Clave privada", "Clave de acceso a contrase�as en el gestor de password");
            mail.BodyEncoding = UTF8Encoding.UTF8;
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            mail.Attachments.Add(data);
            client.Send(mail);

        }

        private void chB_Registrar_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_Registrar.Checked)
            {
                grB_Registrar.Enabled = true;
            }
            else
            {
                grB_Registrar.Enabled = false;
            }
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            if (!txt_Descripcion.Text.Equals("") && !txt_Contrasena02.Text.Equals(""))
            {
                if (Regex.IsMatch(txt_Contrasena02.Text, @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,10}$"))
                {
                    descripciones.Add(@txt_Descripcion.Text);

                    String ficheroClavePublica = pathPublic + txt_Usuario.Text + "_public.xml";
                    contrasenaCifrada = encriptar(ficheroClavePublica, Encoding.UTF8.GetBytes(txt_Contrasena02.Text));
                    //contrasenas.Add(Encoding.UTF8.GetString(contrasenaCifrada).ToLower().Replace("-", ""));
                    contrasenas.Add(Convert.ToBase64String(contrasenaCifrada));


                    txt_Descripcion.Text = "";
                    txt_Contrasena02.Text = "";

                    ActualizarCombos();

                    btn_GuardarCerrar.Enabled = true;
                }
                else
                {
                    string mensaje = "La contrase�a debe estar formada por:\n" +
                        " - Al menos una letra min�scula\n" +
                        " - Al menos una letra may�scula\n" +
                        " - Al menos un n�mero\n" +
                        " - Entre 6 y 12 car�cteres";
                    string caption = "Atenci�n";
                    MessageBoxButtons botones = MessageBoxButtons.OK;
                    DialogResult result = MessageBox.Show(mensaje, caption, botones);

                    txt_Contrasena02.Focus();
                }
            }
            else
            {
                string mensaje = "Debes rellenar los campos descripci�n y contrase�a antes de Guardar";
                string caption = "Atenci�n";
                MessageBoxButtons botones = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(mensaje, caption, botones);

                txt_Descripcion.Focus();
            }
        }

        private byte[] encriptar(string ficheroClavePublica, byte[] contrasenaNoCifrada)
        {
            byte[] encriptado;

            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;

                string publicKey = File.ReadAllText(ficheroClavePublica);

                rsa.FromXmlString(publicKey);

                encriptado = rsa.Encrypt(contrasenaNoCifrada, true);
            }

            return encriptado;

        }

        private void chB_Visualizar_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_Visualizar.Checked)
            {
                grB_Visualizar.Enabled = true;
                ActualizarCombos();
            }
            else
            {
                grB_Visualizar.Enabled = false;
            }
        }

        private void ActualizarCombos()
        {
            cmB_Descripcion01.Items.Clear();
            cmB_Descripcion03.Items.Clear();

            for (int i = 0; i < descripciones.Count(); i++)
            {
                cmB_Descripcion01.Items.Add(descripciones[i]);
                cmB_Descripcion03.Items.Add(descripciones[i]);
            }
        }

        private void btn_Fichero_Click(object sender, EventArgs e)
        {
            if (cmB_Descripcion01.SelectedIndex != -1)
            {
                if (oFD_Fichero.ShowDialog() == DialogResult.OK)
                {
                    String nombreFichero = oFD_Fichero.FileName;
                    lbl_Ubicacion.Text = nombreFichero;

                    int seleccionDescripcion = cmB_Descripcion01.SelectedIndex;

                    //contrasenaCifrada = Encoding.UTF8.GetBytes(contrasenas[seleccionDescripcion]);
                    contrasenaCifrada = Convert.FromBase64String(contrasenas[seleccionDescripcion]);

                    String ficheroClavePrivada = pathPrivate + txt_Usuario.Text + "_private.xml";

                    byte[] desencriptado = Desencriptar(ficheroClavePrivada, contrasenaCifrada);
                    txt_contrasena01.Text = Encoding.UTF8.GetString(desencriptado);

                    btn_GuardarCerrar.Enabled = true;
                }
            }
            else
            {
                string mensaje = "Debes seleccionar una descripci�n de contrase�a para desencriptar";
                string caption = "Atenci�n";
                MessageBoxButtons botones = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(mensaje, caption, botones);
            }
        }

        private byte[] Desencriptar(string nombreFichero, byte[] contrasenaCifrada)
        {
            byte[] desencriptado;

            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;

                string privateKey = File.ReadAllText(nombreFichero);

                rsa.FromXmlString(privateKey);

                desencriptado = rsa.Decrypt(contrasenaCifrada, true);

            }
            return (desencriptado);
        }

        private void chB_Borrar_CheckedChanged(object sender, EventArgs e)
        {
            if (chB_Borrar.Checked)
            {
                grB_Borrar.Enabled = true;
                ActualizarCombos();
                cmB_Descripcion03.SelectedIndex = -1;
            }
            else
            {
                grB_Borrar.Enabled = false;
            }
        }

        private void btn_Borrar_Click(object sender, EventArgs e)
        {
            if (cmB_Descripcion03.SelectedIndex != -1)
            {
                descripciones.RemoveAt(cmB_Descripcion03.SelectedIndex);
                contrasenas.RemoveAt(cmB_Descripcion03.SelectedIndex);

                ActualizarCombos();
                cmB_Descripcion03.Text = "";
                btn_GuardarCerrar.Enabled = true;
            }
            else
            {
                string mensaje = "Debes seleccionar una descripci�n de contrase�a para eliminar";
                string caption = "Atenci�n";
                MessageBoxButtons botones = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(mensaje, caption, botones);
            }
        }

        private void btn_GuardarCerrar_Click(object sender, EventArgs e)
        {
            String nombreFicheroContrasenas = path + txt_Usuario.Text + ".txt";

            using (StreamWriter fichero = File.AppendText(nombreFicheroContrasenas))
            {
                for (int i = 0; i < descripciones.Count(); i++)
                {
                    fichero.WriteLine(descripciones[i]);
                    fichero.WriteLine(@contrasenas[i]);
                }
            }
            this.Close();
        }
    }
}