using Controladores;
using MahApps.Metro.Controls;
using PersistenciaBD;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
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
using System.Xml.Serialization;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Windows.Controls.Image;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para VentanaChecklist.xaml
    /// </summary>
    public partial class VentanaChecklist : MetroWindow
    {
        public VentanaChecklist()
        {
            InitializeComponent();
        }
        public int idChecklist;
        public string DisplayProfesionalAsignado;
        public string DisplayHoraActividad;
        public string DisplayTipoAct;
        public string DisplayFechaVisita;
        public string DisplayContadorChecklist;

        public void AgregarCheckbox(int idChecklistExistente)
        {
            ServiceChecklist serviceChecklist = new();
            char[] delimiterChars = { ',', '.', ':', '\t', ';' };
            try
            {
                string[] Aspectos = serviceChecklist.GetEntity(idChecklistExistente).Aspectos.Split(delimiterChars);
                int contador = 0;
                //List<CheckBox> checklist = new List<CheckBox>();
                foreach (string Aspecto in Aspectos)
                {
                    contador++;
                    CheckBox checkBox = new()
                    {
                        Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0)),
                        Content = Aspecto,
                        FontSize = 15

                    };
                    StackPanelChecklist.Children.Add(checkBox);
                    //checklist.Add(checkBox);
                }
                StackPanelChecklist.Children.RemoveAt(contador - 1);
                //return checklist.ToArray();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR_MODULO:VentanaChecklist/Metodo/AgregarCheckbox: ", "Se ha producido un error en la carga de los aspectos del checklist. " + ex.Message);
            }
        }
        /*
        public void CapturarVentana(UIElement source, Uri destination)
        {
            try
            {
                Image captura = new Image();
                double Height, renderHeight, Width, renderWidth;

                Height = renderHeight = source.RenderSize.Height;
                Width = renderWidth = source.RenderSize.Width;

                //Especificación para el mapa de bits de destino como píxel de ancho/alto, etc.
                RenderTargetBitmap renderTarget = new RenderTargetBitmap((int)renderWidth, (int)renderHeight, 96, 96, PixelFormats.Pbgra32);

                // crea el Visual Brush de UIElement
                VisualBrush visualBrush = new VisualBrush(source);

                DrawingVisual drawingVisual = new DrawingVisual();
                using (DrawingContext drawingContext = drawingVisual.RenderOpen())
                {
                    //captura la imagen del elemento
                    drawingContext.DrawRectangle(visualBrush, null, new Rect(new Point(0, 0), new Point(Width, Height)));
                }
                //imagen renderizada
                renderTarget.Render(drawingVisual);
                captura.Source = renderTarget;

                //Codificador PNG para crear un archivo PNG
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(renderTarget));
                using (FileStream stream = new FileStream(destination.LocalPath, FileMode.Create, FileAccess.Write))
                {
                    encoder.Save(stream);
                }
                MetroWindow metroWindow = new();
                metroWindow.Content = captura;
                metroWindow.Show();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        */
        public void CapturarVentana_Prueba1(UIElement source /*, Uri destination*/)
        {
            try
            {

                Image captura = new Image();
                double Height, renderHeight, Width, renderWidth;

                Height = renderHeight = source.RenderSize.Height;
                Width = renderWidth = source.RenderSize.Width;

                //Especificación para el mapa de bits de destino como píxel de ancho/alto, etc.
                RenderTargetBitmap renderTarget = new RenderTargetBitmap((int)renderWidth, (int)renderHeight, 96, 96, PixelFormats.Pbgra32);

                // crea el Visual Brush de UIElement
                VisualBrush visualBrush = new VisualBrush(source);

                DrawingVisual drawingVisual = new DrawingVisual();
                using (DrawingContext drawingContext = drawingVisual.RenderOpen())
                {
                    //captura la imagen del elemento
                    drawingContext.DrawRectangle(visualBrush, null, new Rect(new Point(0, 0), new Point(Width, Height)));
                }
                //imagen renderizada
                renderTarget.Render(drawingVisual);

                //Este bloque de codigo se utiliza para guardar archivos en la memoria local
                //Codificador PNG para crear un archivo PNG
                //PngBitmapEncoder encoder = new PngBitmapEncoder();
                //encoder.Frames.Add(BitmapFrame.Create(renderTarget));
                //using (FileStream stream = new FileStream(destination.LocalPath, FileMode.Create, FileAccess.Write))
                //{
                //    encoder.Save(stream);
                //}
                captura.Source = renderTarget;
                ReporteChecklist reporteChecklist = new();
                reporteChecklist.imgReporte.Source = captura.Source;
                reporteChecklist.idChecklist = idChecklist;
                //Debug.WriteLine(idChecklist);
                reporteChecklist.Show();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        private void TileGuardar_Click(object sender, RoutedEventArgs e)
        {
            //Establecer la propiedad de contenido de la ventana
            //como elemento de la interfaz de usuario para capturar el contenido completo
            UIElement element = StackPanelChecklist.Parent as UIElement;
            Uri path = new Uri(@"C:\Prueba\screenshot.png");
            CapturarVentana_Prueba1(element /*, path*/);

        }
        private void TileAtras_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}