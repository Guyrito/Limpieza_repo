using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Reflection.Metadata;
using System.Diagnostics;
using PersistenciaBD;
using System.Threading;
using System.Windows.Markup;
using System.IO;
using ControlzEx.Standard;
using System.Drawing;
using System.Xml.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using static System.Net.WebRequestMethods;
using static Vistas.Administrador;
using Path = System.IO.Path;
using Controladores;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para ReporteChecklist.xaml
    /// </summary>
    public partial class ReporteChecklist : MetroWindow
    {
        public ReporteChecklist()
        {
            InitializeComponent();
            FormatoCalendario();
            DatePickerFechaReporte.SelectedDate = DateTime.Now;
        }
        public int idChecklist;
        public string DisplayFechaReporte { get; set; }
        public void FormatoCalendario()
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-CL");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("es-CL");
            DatePickerFechaReporte.Language = XmlLanguage.GetLanguage("es-CL");
            DatePickerFechaReporte.DisplayDate = DateTime.Now;
        }
        private bool ValidarCampos()
        {
            if (TxtboxReporte.Text == String.Empty)
            {
                MessageBox.Show("El reporte esta vacío.", "Validación de campos");
                return false;
            }
            else
            {
                return true;
            }
        }
        private System.Drawing.Image ImageWpfToGDI(System.Windows.Media.ImageSource image)
        {
            MemoryStream ms = new MemoryStream();
            var encoder = new System.Windows.Media.Imaging.BmpBitmapEncoder();
            encoder.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(image as System.Windows.Media.Imaging.BitmapSource));
            encoder.Save(ms);
            ms.Flush();
            return System.Drawing.Image.FromStream(ms);
        }
        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }
        private void CrearReporteChecklist()
        {
            System.Drawing.Image imagenReferencia = null;
            imagenReferencia = ImageWpfToGDI(imgReporte.Source);

            if (ValidarCampos() == true)
            {
                using BD_NMAEntities contextCreateReporte = new();
                contextCreateReporte.CREATE_REPORTE
                    (
                    nombre_reporte: TxtBoxNombreReporte.Text,
                    fecha_reporte: DatePickerFechaReporte.SelectedDate,
                    archivoReporte: ImageToByteArray(imagenReferencia),
                    extension: ".jpg"
                    );
                contextCreateReporte.SaveChanges();
            }
        }
        /*
        private void CrearPDF()
        {
            //Crear documento PDF
            PdfDocument document = new PdfDocument();

            //Agregar la página en el documento PDF
            PdfPage page = document.Pages[2];

            // Para dibujar en la página PDF, necesitará el objeto XGraphics
            XGraphics gfx = XGraphics.FromPdfPage(page);

            //Definir la fuente que se utilizará
            XFont font = new(familyName: "Verdana", emSize: 20, style: XFontStyle.Bold);
            //Finalmente usa XGraphics y el objeto de fuente para dibujar texto en la página PDF
            gfx.DrawString("Reporte de Checklist", font, XBrushes.Black,
            new XRect(0, 0, page.Width, page.Height), XStringFormats.Center);
            gfx.DrawImage(xReporte, 0, 0, page.Width, page.Height);
            //Especifique el nombre de archivo del archivo PDF
            string filename = "Reporte.pdf";
            //Guardar archivo PDF
            document.Save(filename);
            //Cargar archivo PDF para verlo
            Process.Start(filename);
            WebBrowser webBrowser = new();
            webBrowser.Document.Equals(document);
        }
        */
        private void ActualizarReporteChecklist(int idChecklist)
        {
            using BD_NMAEntities context = new();
            context.crudUpdate
                (
                    nombreTabla: "Checklist",
                    nombreColumna: "Reporte",
                    nuevoDato: TxtboxReporte.Text,
                    id: idChecklist
                );
            context.SaveChanges();
        }
        private void TileGuardar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("La información a continuación será ingresada. \n¿Esta seguro(a) que la información ingresada es correcta?", "Pregunta de confirmación", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                if (ValidarCampos() == true)
                {
                    CrearReporteChecklist();
                    ActualizarReporteChecklist(idChecklist);
                    MessageBox.Show("Reporte creado correctamente.");
                    this.Close();
                }
                else if (ValidarCampos() == false)
                {
                    MessageBox.Show("No se pudo crear la asesoría.");
                }
            }
            else if (messageBoxResult == MessageBoxResult.No)
            {
            }
            
        }
        private void TileAtras_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            //ServiceReporte svr = new();
            //try
            //{

            //    string path = Path.GetTempPath();
            //    byte[] binaryData;
            //    binaryData = svr.GetEntity(1).ArchivoReporte.ToArray();
            //    string nombreArc = svr.GetEntity(1).Nombre_reporte+".jpg";
            //    System.IO.File.WriteAllBytes(@path + "//" + nombreArc, binaryData);
            //    //imgComprobante.Source = new BitmapImage(new Uri(@path + "//" + nombreArc));
            //    //imgComprobante.Visibility = Visibility.Visible;

            //    MessageBox.Show("Se ha descargado el archivo " + nombreArc + " correctamente");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("DEBES SELECCIONAR UN PAGO \n" + ex.Message, "ERROR: ");
            //}
        }
    }
}
