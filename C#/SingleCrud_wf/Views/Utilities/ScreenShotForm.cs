using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SingleCrud
{
    public partial class ScreenShotForm : Form
    {
        public ScreenShotForm()
        {
            InitializeComponent();
            
        }

        private void btCapturarPantalla_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(txtUbicacionCaptura.Text))
            {
                try
                {
                    //Comprobamos si la ventana está maximizada, si lo está
                    //la dejamos en Normal para que funcione el hide
                    if (this.WindowState == FormWindowState.Maximized)
                    {
                        this.WindowState = FormWindowState.Normal;
                    }
                    //ocultamos la ventana de la aplicación para que 
                    //no aparezca en la captura de pantalla
                    this.Hide();

                    //esperamos unos milisegundos para asegurarnos que 
                    //se ha ocultado la ventana
                    System.Threading.Thread.Sleep(250);

                    //obtenemos la resolución de pantalla
                    Rectangle tamanoEscritorio =
                        Screen.GetBounds(this.ClientRectangle);

                    //creamos un Bitmap del tamaño de nuestra pantalla
                    Bitmap objBitmap = new Bitmap(tamanoEscritorio.Width,
                        tamanoEscritorio.Height);
                    //creamos el gráifco en base al Bitmap objBitmap 
                    Graphics objGrafico = Graphics.FromImage(objBitmap);
                    //transferimos la captura al objeto objGrafico en 
                    //base a las medidas del bitmap
                    objGrafico.CopyFromScreen(0, 0, 0, 0, objBitmap.Size);
                    //liberamos el gráfico de memoria                            
                    objGrafico.Flush();
                    //mostramos la captura de memoria a la ventana de la aplicación
                    imgCaptura.SizeMode = PictureBoxSizeMode.StretchImage;
                    imgCaptura.Image = objBitmap;
                    imgCaptura.Visible = true;

                    /* Si queremos crear el PictureBox en tiempo de ejecución
                    var imgPictureBox = new PictureBox();
                    imgPictureBox.Location = new System.Drawing.Point(15, 89);
                    imgPictureBox.Size = new System.Drawing.Size(609, 332);
                    imgPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    imgPictureBox.Image = objBitmap;
                    Controls.Add(imgPictureBox);
                    imgPictureBox.Visible = true;
                     */
                }
                catch (Exception objError)
                {
                    MessageBox.Show(objError.ToString(), "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    this.Show();
                }
            }
            else
            {
                MessageBox.Show("Ya existe un fichero de imagen con ese " +
                    "nombre, seleccione otra ruta o nombre de fichero.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void bSelDestino_Click(object sender, EventArgs e)
        {
            string formatoImagen = "";
            formatoImagen = lsFormatoImagen.Text;

            if (formatoImagen != "")
            {
                dlGuardarImagen.Title = "Selección de carpeta y fichero de " +
                    "imagen donde se guardará la captura";
                dlGuardarImagen.Filter = "Imágenes " + formatoImagen +
                    " (*." + formatoImagen.ToLower() + ")|*." +
                    formatoImagen.ToLower() +
                    "|Todos los ficheros (*.*)|*.*";
                dlGuardarImagen.DefaultExt = formatoImagen.ToLower();
                dlGuardarImagen.FilterIndex = 1;
                if (dlGuardarImagen.ShowDialog() == DialogResult.OK)
                {
                    txtUbicacionCaptura.Text = dlGuardarImagen.FileName;
                }
            }
            else
            {
                MessageBox.Show("Debes de seleccionar el formato para la imagen.",
                    "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lsFormatoImagen.Focus();
            }
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            if (imgCaptura.Image != null)
            {
                string formatoImagen = "";
                formatoImagen = lsFormatoImagen.Text;
                if (formatoImagen != "")
                {
                    if (txtUbicacionCaptura.Text != "")
                    {
                        //guardarmos la imagen en el formato indicado por el usuario
                        if (System.IO.Directory.Exists(
                            System.IO.Path.GetDirectoryName(txtUbicacionCaptura.Text)))
                        {

                            if (formatoImagen == "BMP")
                            {
                                imgCaptura.Image.Save(txtUbicacionCaptura.Text,
                                    ImageFormat.Bmp);
                            }
                            if (formatoImagen == "PNG")
                            {
                                imgCaptura.Image.Save(txtUbicacionCaptura.Text,
                                    ImageFormat.Png);
                            }
                            if (formatoImagen == "JPEG")
                            {
                                imgCaptura.Image.Save(txtUbicacionCaptura.Text,
                                    ImageFormat.Jpeg);
                            }

                            if (formatoImagen == "TIFF")
                            {
                                imgCaptura.Image.Save(txtUbicacionCaptura.Text,
                                    ImageFormat.Tiff);
                            }
                            if (formatoImagen == "WMF")
                            {
                                imgCaptura.Image.Save(txtUbicacionCaptura.Text,
                                    ImageFormat.Wmf);
                            }
                        }
                        else
                        {
                            MessageBox.Show("La carpeta de destino de la imagen " +
                                "capturada debe de existir.", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            bSelDestino.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe de indicar una carpeta y nombre de fichero " +
                            "para guardar la imagen capturada.", "Atención",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        bSelDestino.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Debes de seleccionar el formato para la imagen. ",
                        "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    lsFormatoImagen.Focus();
                }
            }
            else
            {
                MessageBox.Show("Debe de capturar previamente una imagen.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btCapturarPantalla.Focus();
            }
        }

        private void lsFormatoImagen_SelectedValueChanged(object sender,
            EventArgs e)
        {
            //si el usuario cambia el formato de la imagen destino
            //y ya hay algo escrito en txtUbicacionCaptura, 
            //cambiaremos la extensión del fichero por la 
            //seleccionada en el formato
            string ficheroCaptura = "";
            ficheroCaptura = txtUbicacionCaptura.Text;
            if (ficheroCaptura != "")
            {
                ficheroCaptura = System.IO.Path.GetDirectoryName(ficheroCaptura) +
                    System.IO.Path.DirectorySeparatorChar +
                    System.IO.Path.GetFileNameWithoutExtension(ficheroCaptura) +
                    "." + lsFormatoImagen.Text.ToLower();
                txtUbicacionCaptura.Text = ficheroCaptura;
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"Estas seguro que deseas regresara la ventana anterior?", @"Atención",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }

        }

        private void formCapturarPantalla_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
