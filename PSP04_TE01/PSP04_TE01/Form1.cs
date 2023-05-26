using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Mail;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PSP04_TE01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Activar Consulta
        private async void buttonActivarConsulta_Click(object sender, EventArgs e)
        {
            comboBoxProvincia.Items.Clear();
            comboBoxProvincia.Enabled = false;
            string consultaREST = "https://api.euskadi.eus/culture/events/v1.0/provinces";
            try  //Pongo try-catch para que si falla algo nos muestre la excepción
            {

                using (HttpClient client = new HttpClient())

                using (HttpResponseMessage response = await client.GetAsync(consultaREST))
                {
                    string datosprovincias = await response.Content.ReadAsStringAsync();

                    //Deserializamos con Newtonsoft
                    dynamic resultadoProvincias = JsonConvert.DeserializeObject<ProvinciasResult>(datosprovincias);
                    if (resultadoProvincias != null && resultadoProvincias.TotalItems > 0)
                    {
                        foreach (Provincia provincia in resultadoProvincias.Items)
                        {   // No queremos mostrar online o Iparralde
                            if (provincia.ProvinceId > 0)
                            {
                                ProvinciaComboBoxItem item = new ProvinciaComboBoxItem(provincia.ProvinceId, provincia.NameEs);
                                comboBoxProvincia.Items.Add(item);
                            }
                        }
                        //Una vez lleno de datos el comboBox lo activamos y elegimos el primer ítem
                        comboBoxProvincia.Enabled = true;
                        //Esta selección activará la petición de los municipios (de Araba al ser el primer ítem)
                        comboBoxProvincia.SelectedIndex = 0;
                    }
                    else
                    {
                        textBoxDatosEvento.Text = "ERROR: No se han podido conseguir items de las provincias";
                    }

                }
            }
            catch (Exception ex)
            {
                textBoxDatosEvento.Text = ex.Message;
            }
        }
        #endregion

        #region Cambio ComboBox Provincia
        private async void comboBoxProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxMunicipio.Items.Clear();
            comboBoxMunicipio.Enabled = false;
            //Obtenemos id de la provincia elegida en el combobox
            ProvinciaComboBoxItem objetoProvincia = (ProvinciaComboBoxItem)comboBoxProvincia.SelectedItem;
            string codigoProvincia = objetoProvincia.ProvinceId.ToString();
            string consultaREST = "https://api.euskadi.eus/culture/events/v1.0/municipalities/byProvince/{provinceId}?_elements=100&_page=1&provinceId=" + codigoProvincia;

            using (HttpClient client = new HttpClient())
                try
                {
                    using (HttpResponseMessage response = await client.GetAsync(consultaREST))
                    {
                        string datoslocalidades = await response.Content.ReadAsStringAsync();

                        dynamic resultadoLocalidades = JsonConvert.DeserializeObject<LocalidadesResult>(datoslocalidades);
                        if (resultadoLocalidades != null && resultadoLocalidades.TotalItems > 0)
                        {
                            //Rellenamos el combobox de localidades
                            foreach (Localidad localidad in resultadoLocalidades.Items)
                            {
                                LocalidadComboBoxItem item = new LocalidadComboBoxItem(localidad.MunicipalityId, localidad.NameEs);
                                comboBoxMunicipio.Items.Add(item);
                            }
                            comboBoxMunicipio.Enabled = true;
                            // Esta selección activará la request de eventos del primer municipio del combobox
                            comboBoxMunicipio.SelectedIndex = 0;
                        }
                        else
                        {
                            textBoxDatosEvento.Text = "ERROR: No se han podido conseguir items de los municipios";
                        }
                    }
                }
                catch (Exception ex)
                {
                    textBoxDatosEvento.Text = ex.Message;
                }

        }
        #endregion

        #region Cambio ComboBox Municipio
        private async void comboBoxMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ejemplo  https://api.euskadi.eus/culture/events/v1.0/events/byYear/2023/byMunicipality/48/167?_elements=20&_page=1

            comboBoxEvento.Items.Clear();
            comboBoxEvento.Enabled = false;
            //Obtenemos ids de localidad y provincia desde los comboBoxes
            LocalidadComboBoxItem objetoLocalidad = (LocalidadComboBoxItem)comboBoxMunicipio.SelectedItem;
            string codigoLocalidad = objetoLocalidad.LocalidadId.ToString();

            ProvinciaComboBoxItem objetoProvincia = (ProvinciaComboBoxItem)comboBoxProvincia.SelectedItem;
            string codigoProvincia = objetoProvincia.ProvinceId.ToString();

            string consultaREST = "https://api.euskadi.eus/culture/events/v1.0/events/byYear/2023/byMunicipality/" + codigoProvincia + "/" + codigoLocalidad + "?_elements=20&_page=1";

            using (HttpClient client = new HttpClient())
                try
                {
                    using (HttpResponseMessage response = await client.GetAsync(consultaREST))
                    {
                        string datosEventos = await response.Content.ReadAsStringAsync();

                        dynamic resultadoEventos = JsonConvert.DeserializeObject<EventosResult>(datosEventos);
                        if (resultadoEventos != null && resultadoEventos.TotalItems > 0)
                        {
                            foreach (Evento evento in resultadoEventos.Items)
                            {
                                EventoComboBoxItem item = new EventoComboBoxItem(evento.id, evento.nameEs);
                                item.Tipo = evento.typeEs;
                                item.Hora = evento.startDate;
                                item.Lugar = evento.establishmentEs;
                                item.Precio = evento.priceEs;
                                item.Apertura = evento.openingHoursEs;
                                //Para evitar error si no existe la URL de la imagen
                                if (evento.images.Count > 0)
                                {
                                    item.ImagenURL = evento.images[0].imageUrl;
                                }
                                else
                                {//Imagen por defecto de wikipedia "Not available"
                                    item.ImagenURL = "https://upload.wikimedia.org/wikipedia/commons/d/d1/Image_not_available.png";
                                }
                                comboBoxEvento.Items.Add(item);
                            }
                            comboBoxEvento.Enabled = true;
                            comboBoxEvento.SelectedIndex = 0;
                        }
                        else
                        {
                            textBoxDatosEvento.Text = "ERROR: No se han podido conseguir items de los eventos";
                        }

                    }
                }
                catch (Exception ex)
                {
                    textBoxDatosEvento.Text = ex.Message;
                }
        }
        #endregion

        #region Cambio ComboBox Evento
        private void comboBoxEvento_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxDatosEvento.Clear();
            EventoComboBoxItem itemEvento = (EventoComboBoxItem)comboBoxEvento.SelectedItem;
            textBoxDatosEvento.Text = itemEvento.RellenaTextBox();
            pictureBoxFotoEvento.ImageLocation = itemEvento.ImagenURL;
            buttonActivarEnvioFTP.Enabled = true;
        }
        #endregion

        #region Activar entrada datos FTP

        private void buttonActivarEnvioFTP_Click(object sender, EventArgs e)
        {
            textBoxServidor.Enabled = true;
            textBoxUsuario.Enabled = true;
            textBoxPassword.Enabled = true;

            buttonGuardarFTP.Enabled = true;
        }
        #endregion

        #region Guardar Evento en FTP y enviar por E-mail

        private void buttonGuardarFTP_Click(object sender, EventArgs e)
        {
            // Estos datos los añado en el formulario por defecto para simplificar las pruebas
            // Server: ftp.dlptest.com  User: dlpuser  Passwd: rNrKYTX9g7z3RgJRmxWuGHbeu

            // Recogemos los datos del textbox con el resultado de la consulta y la información de la obra seleccionada de su comboBox
            string infoEvento = textBoxDatosEvento.Text;
            string nombreEvento = comboBoxEvento.Text;

            // Strings para la conexión FTP
            string servidor = textBoxServidor.Text;
            string usuario = textBoxUsuario.Text;
            string password = textBoxPassword.Text;
            string nombreFichero = nombreEvento.Replace(" ", "") + ".txt";
            string respuestaFtp = string.Empty;
            try
            {
                // Creamos la solicitud FTP
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + servidor + "/" + nombreFichero);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(usuario, password);

                // Escribirmos el contenido del archivo de texto directamente en la solicitud de FTP
                using (Stream requestStream = request.GetRequestStream())
                using (StreamWriter writer = new StreamWriter(requestStream))
                {
                    writer.Write(infoEvento);
                }

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                // Enviar el e-mail solo si la carga de FTP ha dado 226
                if (response.StatusCode == FtpStatusCode.ClosingData)
                {
                    if (response != null)
                    {
                        respuestaFtp = "Fichero subido con código: " + response.StatusDescription;
                        textBoxDatosEvento.Text = respuestaFtp;
                        //Para poder ver el resultado del FTP muestro un MessageBox, de lo contrario no da tiempo, se ve el Email Enviado directamente
                        var thread = new Thread(() =>
                        {
                            MessageBox.Show(respuestaFtp, "Resultado FTP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        });
                        thread.Start();
                    }

                    //Quitamos espacios al subject
                    string subject = nombreEvento.Replace(" ", "");
                    // Body del email será la respuesta del FTP
                    string body = textBoxDatosEvento.Text;

                    //Dirección de cuenta desde la cual se quiere enviar un correo electrónico
                    MailAddress origen = new MailAddress("pruebaedupsp@gmail.com", "From Prueba Edu Birt");

                    //Dirección de cuenta a la cual se quiere enviar un correo electrónico
                    //MailAddress destino = new MailAddress("edhernandez@birt.eus", "To Edu");
                    MailAddress destino = new MailAddress("birtpsp@gmail.com", "BirtPSP");

                    using (MailMessage message = new MailMessage(origen, destino))
                    {
                        message.Subject = subject;
                        message.Body = body;

                        using (SmtpClient client = new SmtpClient())
                        {
                            client.Host = "smtp.gmail.com";
                            client.Port = 587;
                            client.EnableSsl = true;
                            client.Credentials = new NetworkCredential("pruebaedupsp@gmail.com", "pmaeijwiqkxxfybd");
                            client.Send(message);
                        }
                    }
                    textBoxDatosEvento.Text = "Email enviado";
                }
                else
                {
                    textBoxDatosEvento.Text = "Algo ha ocurrido en el envío FTP: " + response.StatusDescription;
                }
                if (response != null)
                    response.Close();
            }
            catch (Exception ex)
            {
                textBoxDatosEvento.Text = ex.Message;
            }

            //Desactivamos comboBoxes, textBoxes y botones
            comboBoxEvento.Enabled = false;
            comboBoxMunicipio.Enabled = false;
            comboBoxProvincia.Enabled = false;

            textBoxServidor.Enabled = false;
            textBoxUsuario.Enabled = false;
            textBoxPassword.Enabled = false;

            buttonActivarEnvioFTP.Enabled = false;
            buttonGuardarFTP.Enabled = false;
        }
        #endregion
    }

    // Algunas clases creadas con ayuda de ChatGPT
    #region Clases para Deserializar JSONs y ComboBoxes items
    public class ProvinciasResult
    {
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public List<Provincia> Items { get; set; }
    }

    public class Provincia
    {
        public int ProvinceId { get; set; }
        public string NameEs { get; set; }
        public string NameEu { get; set; }
    }

    public class LocalidadesResult
    {
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public List<Localidad> Items { get; set; }
    }

    public class Localidad
    {
        public int MunicipalityId { get; set; }
        public int ProvinceId { get; set; }
        public string NameEs { get; set; }
        public string NameEu { get; set; }
    }

    public class EventosResult
    {
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public List<Evento> Items { get; set; }
    }

    public class Evento
    {
        public string id { get; set; }
        public int type { get; set; }
        public string typeEs { get; set; }
        public string typeEu { get; set; }
        public string nameEs { get; set; }
        public string nameEu { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public DateTime publicationDate { get; set; }
        public string language { get; set; }
        public string openingHoursEs { get; set; }
        public string openingHoursEu { get; set; }
        public string priceEs { get; set; }
        public string priceEu { get; set; }
        public string purchaseUrlEs { get; set; }
        public string purchaseUrlEu { get; set; }
        public string descriptionEs { get; set; }
        public string descriptionEu { get; set; }
        public string municipalityEs { get; set; }
        public string municipalityEu { get; set; }
        public string municipalityLatitude { get; set; }
        public string municipalityLongitude { get; set; }
        public string municipalityNoraCode { get; set; }
        public string provinceNoraCode { get; set; }
        public string companyEs { get; set; }
        public string companyEu { get; set; }
        public string establishmentEs { get; set; }
        public string establishmentEu { get; set; }
        public string urlEventEs { get; set; }
        public string urlEventEu { get; set; }
        public string urlNameEs { get; set; }
        public string urlNameEu { get; set; }
        public List<Image> images { get; set; }
        public List<object> attachment { get; set; }
    }

    public class Image
    {
        public string imageId { get; set; }
        public string imageFileName { get; set; }
        public string imageUrl { get; set; }
    }

    // Para que el comboBox de provincias guarde el nombre y el valor (ProvinceId) de cada Item
    public class ProvinciaComboBoxItem
    {
        public int ProvinceId { get; set; }
        public string Name { get; set; }
        public ProvinciaComboBoxItem(int provinceId, string name)
        {
            ProvinceId = provinceId;
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }

    //Lo mismo para localidad
    public class LocalidadComboBoxItem
    {
        public int LocalidadId { get; set; }
        public string Name { get; set; }
        public LocalidadComboBoxItem(int localidadId, string name)
        {
            LocalidadId = localidadId;
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }
    // Para evento añado al nombre y id los datos que queremos mostrar
    public class EventoComboBoxItem
    {
        public string EventoId { get; set; }
        public string Name { get; set; }

        public string Tipo { get; set; }
        public DateTime Hora { get; set; }
        public string Lugar { get; set; }
        public string Precio { get; set; }
        public string Apertura { get; set; }
        public string ImagenURL { get; set; }

        //Constructor con dos atributos
        public EventoComboBoxItem(string eventoId, string name)
        {
            EventoId = eventoId;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
        //Método que prepara la descripción del evento
        public string RellenaTextBox()
        {
            string textoEvento = "Tipo de Evento: " + this.Tipo + Environment.NewLine;
            textoEvento += "Nombre de Evento: " + this.Name + Environment.NewLine;
            textoEvento += "Hora de Evento: " + this.Hora.ToString() + Environment.NewLine;
            textoEvento += "Edificio: " + this.Lugar + Environment.NewLine;
            textoEvento += "Precio: " + this.Precio + Environment.NewLine;
            textoEvento += "Apertura de puertas: " + this.Apertura + Environment.NewLine;

            return textoEvento;
        }
        #endregion
    }
}