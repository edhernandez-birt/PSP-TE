using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Net.Mime;
using System.Text.RegularExpressions;

namespace PSP05_TE_GestorPass
{

    public partial class Form1 : Form
    {
        string path1 = @"../../bbdd";
        string path2 = @"../../publickeys";
        string path3 = @"../../privatekeys";
        string nombreFichero;
        private byte[] byteTextoCifrado;
        private string publicKeyFile;
        private string privateKeyFile;      
        List<string> combo = new List<string>();


        public Form1()
        {
            InitializeComponent(); 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

  

        //Botón para introducir el nombre de usuario, comprobará primero que cumpla con las condiciones ortográficas y después verá si existe ya en la carpeta
        //BBDD o no. En función de ello habilitará el resto de la interfaz u obligará a registrarse para continuar

        private void button4_Click(object sender, EventArgs e)
        {
            if( (textBox1.Text.Length > 4 && textBox1.Text.Length <= 10) && textBox1.Text == textBox1.Text.ToLower() && textBox1.Text.All(Char.IsLetter)) {
                nombreFichero = textBox1.Text + ".txt";

                string[] fileEntries = Directory.GetFiles(Path.GetFullPath(path1));
                bool nombreValido = true;
                foreach (string fileName in fileEntries)
                {
                    if(Path.GetFileName(fileName) == nombreFichero)
                    {
                        
                        nombreValido = false;
                        habilitarBoxes();
                        
                    }
                }
                if(nombreValido)
                {
                    groupBox4.Enabled = true;

                }
            }
            else
            {
                MessageBox.Show("El nombre de usuario debe : " + Environment.NewLine + "1. Tendrá un máximo de 10 caracteres y un mínimo de 4." + Environment.NewLine +
                    "2. Todo en minúsculas y letras exclusivamente.");
            }



        }
      
        //Habilita los boxes necesarios
        private void habilitarBoxes()
        {      
            checkBox1.Enabled = true;
            checkBox2.Enabled = true;
            checkBox3.Enabled = true;
        }

        //Botón para formalizar el registro. Se deberá poner la opción si y enviara el email correspondiente. Crea las keys.
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (EsCorreoValido(textBox5.Text))
            {
                nombreFichero = textBox1.Text + ".txt";
                if (radioButton1.Checked)
                {
                    string pathNuevoUsuario = Path.GetFullPath(path1) + "\\" + nombreFichero;
                    FileStream crear = File.Create(pathNuevoUsuario);
                    actualizarKey();
                    generarClaves(publicKeyFile, privateKeyFile);
                    enviarEmail(privateKeyFile);
                    crear.Close();
                }
                
            }
            else
            {
                MessageBox.Show("Correo no cumple con formato", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        //Actualización del path de las key
        private void actualizarKey()
        {
            publicKeyFile = Path.GetFullPath(path2) + "\\" + textBox1.Text + "_public.xml";
            privateKeyFile = Path.GetFullPath(path3) + "\\" + textBox1.Text + "_private.xml";
        }

        //Actualización del path de las key conforme al desbloqueo de contraseñas. La private irá en función de el archivo que se escoja.
        private void actualizarKeyPass()
        {
            publicKeyFile = Path.GetFullPath(path2) + "\\" + textBox1.Text + "_public.xml";
            privateKeyFile = label6.Text;
        }


        //Genera public y private keys y las guarda en su fichero
        private static void generarClaves(string publicKF, string privateKF)
        {
            using(var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                if (File.Exists(publicKF))
                {
                    File.Delete(publicKF);
                }
                if (File.Exists(privateKF))
                {
                    File.Delete(privateKF);
                }

                string publicKey = rsa.ToXmlString(false);
                File.WriteAllText(publicKF, publicKey);
                string privateKey = rsa.ToXmlString(true);
                File.WriteAllText(privateKF, privateKey);
            }
        }    
   
        //Encripta y devuelve la contraseña que introducimos
        private static byte[] encriptar(string publicKF, byte[] textoPlano)
        {
            byte[] encriptado;
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;

                string publicKey = File.ReadAllText(publicKF);

                rsa.FromXmlString(publicKey);
                encriptado = rsa.Encrypt(textoPlano, true);
            }
            return encriptado;
        }

        //Desencripta y devuelve la contraseña que habiamos guardado
        private static byte[] desencriptar(string privateKF, byte[] textoEncriptado)
        {
            byte[] encriptado = null;
            try
            {
                
                using (var rsa = new RSACryptoServiceProvider(2048))
                {
                    rsa.PersistKeyInCsp = false;

                    string privateKey = File.ReadAllText(privateKF);

                    rsa.FromXmlString(privateKey);

                    encriptado = rsa.Decrypt(textoEncriptado, true);
                    
                    return encriptado;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Privatekey no válida");
            }
            return encriptado;
        } 

        //Envía el email con el archivo de la private key adjuntado
        private void enviarEmail(string privateKeyFile)
        {
            MailAddress origen = new MailAddress("birtpsp@gmail.com", "From BirtPSP");

            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                Credentials = new NetworkCredential(origen.Address, "jkelovzgghdoowgx"),
                EnableSsl = true
            };
            Attachment data = new Attachment(privateKeyFile, MediaTypeNames.Application.Octet);
            //comprobar el email
            MailAddress destino = new MailAddress(textBox5.Text, "To Interesado");
            using (MailMessage mezua = new MailMessage(origen, destino)
            {

                Subject = "Clave privada",
                Body = "Clave de acceso a contraseñas en el gestor de password",

            } ) 
            
            try
                {
                    mezua.Attachments.Add(data);
                    smtp.Send(mezua);
                    MessageBox.Show("Email enviado con clave", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
        }

        //Comprueba que la contraseña introducida cumple con el criterio ortográfico si no no deja continuar
        //Si es correcta encripta la contraseña creada y la guarda en el fichero del usuario en la carpta BBDD junto a su descripcion
        private void button5_Click(object sender, EventArgs e)
        {
            var regex1 = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[!@#&()–[{}:',?/*~$^+=<>]).+$"); //lower cases
            
            if ((textBox4.Text.Length >= 8 && textBox4.Text.Length <= 10) && regex1.IsMatch(textBox4.Text))
            {
                actualizarKey();

                byteTextoCifrado = encriptar(publicKeyFile, Encoding.UTF8.GetBytes(this.textBox4.Text));               
                string pass = Convert.ToBase64String(byteTextoCifrado);
                string fichero = Path.GetFullPath(path1) + "\\" + nombreFichero;

                File.AppendAllText(fichero, textBox3.Text + "\n");
                File.AppendAllText(fichero, pass + "\n");
                MessageBox.Show("Clave Registrada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("La contraseña debe contener : " + Environment.NewLine + "1. 8-10 digitos." + Environment.NewLine +
                    "2. Al menos 1 mayusc, 1 minusc, 1 número." + Environment.NewLine +
                    "1 carácter entre estos: !@#&()–[{}:',?/*~$^+=<>");
            }


        }
        
        //Limpia y actualiza los comboBox
        private void actualizarCombo()
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox1.ResetText();
            comboBox2.ResetText();
            string fichero = Path.GetFullPath(path1) + "\\" + nombreFichero;
            using (StreamReader reader = new StreamReader(fichero))
            {
                string line;
                int contador = 0; ;
                while ((line = reader.ReadLine()) != null)
                {
                    if (contador % 2 == 0)
                    {
                        comboBox1.Items.Add(line);
                        comboBox2.Items.Add(line);
                    }
                    contador++;
                }
                reader.Close();
            }
            
        }

        //Actualiza combo al pulsarlo
        private void comboBox1_DroppedDown(object sender, EventArgs e)
        {

            actualizarCombo();
        }
        //Actualiza combo al pulsarlo
        private void comboBox2_DroppedDown(object sender, EventArgs e)
        {
            actualizarCombo();
            
        }
        //Permite elegir el fichero con la clave privada para desencriptar la contraseña guardada. Lee el combobox y guarda la contraseña del que se haya seleccionado
        //Si la private key no es válida no se desncriptará
        private void button3_Click(object sender, EventArgs e)
        {
            FileStream stream = null;
            StreamReader reader = null;
            try {
                string nombreFichero = String.Empty;

                openFileDialog1.InitialDirectory = Path.GetFullPath(path3);
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    
                    nombreFichero = openFileDialog1.FileName;
                    //ficheroPrivate = nombreFichero;
                    label6.Text = Path.GetFullPath(nombreFichero);
                    //ficheroPrivate = ficheroPrivate.Replace("_private.xml", "");


                    nombreFichero = textBox1.Text + ".txt";
                    string pathPasswords = Path.GetFullPath(path1) + "\\" + nombreFichero;


                    stream = File.OpenRead(pathPasswords);
                    reader = new StreamReader(stream);
                    while (!reader.EndOfStream)
                    {

                        if (comboBox1.SelectedItem.ToString() == reader.ReadLine())
                        {

                            string pass = reader.ReadLine();
                            actualizarKeyPass();
                            byte[] bytePass = Convert.FromBase64String(pass);
                            byte[] desencriptado = desencriptar(privateKeyFile, bytePass);
                            textBox2.Text = Encoding.UTF8.GetString(desencriptado);
                        }
                    }
                    reader.Close();
                    stream.Close();
                    
                }
            }
            catch (Exception ex)
            {
                reader.Close();
                stream.Close();
            }
            


        }

        //Botón para borrar la contraseña y descripción que eligamos del combobox
        private void button6_Click(object sender, EventArgs e)
        {
            nombreFichero = textBox1.Text + ".txt";
            string pathPasswords = Path.GetFullPath(path1) + "\\" + nombreFichero;
            string[] lineasFichero = File.ReadAllLines(pathPasswords);
            string nuevasLineas = "";
            bool borrar = false;
            foreach(string linea in lineasFichero)
            {
                if(linea == comboBox2.SelectedItem.ToString())
                {
                    borrar = true;
                    continue;
                }
                else
                {
                    if (borrar)
                    {
                        borrar = false;
                        continue;
                    }
                    else
                    {
                        nuevasLineas += linea + "\n";
                    }
                }

            }
            File.WriteAllText(pathPasswords, nuevasLineas);
            MessageBox.Show("Contraseña borrada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);






        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Cierra la aplicación
        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
            
        }

        //Controla la situación del checkbox
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            
            if (checkBox3.Checked)
            {
                groupBox3.Enabled = true;
            }
            else
            {
                groupBox3.Enabled = false;
            }
        }
        //Controla la situación del checkbox
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox2.Checked)
            {
                groupBox2.Enabled = true;
            }
            else
            {
                groupBox2.Enabled = false;
            }

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
        //Controla la situación del checkbox
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        
            if (checkBox1.Checked)
            {
                groupBox1.Enabled = true;
            }
            else
            {
                groupBox1.Enabled = false;
            }
        }



        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public static bool EsCorreoValido(string correo)
        {
            // Patrón de expresión regular para verificar la validez del correo electrónico
            string patron = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]{2,}$";
            // Verificar si el correo cumple con el patrón
            bool esValido = Regex.IsMatch(correo, patron);

            return esValido;
        }
    }
}

     