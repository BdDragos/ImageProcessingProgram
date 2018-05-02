using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageLab1
{
    public partial class Form1 : Form
    {
        private Bitmap originalBitmap = null;
        private Bitmap previewBitmap = null;
        private Bitmap resultBitmap = null;
        public static double[,] Laplacian3x3
        {
            get
            {
                return new double[,]
                { { -1, -1, -1, },
                { -1,  8, -1, },
                { -1, -1, -1, }, };
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select an image file.";
            ofd.Filter = "Png Images(*.png)|*.png|Jpeg Images(*.jpg)|*.jpg";
            ofd.Filter += "|Bitmap Images(*.bmp)|*.bmp";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(ofd.FileName);
                originalBitmap = (Bitmap)Bitmap.FromStream(streamReader.BaseStream);
                streamReader.Close();

                previewBitmap = originalBitmap.CopyToSquareCanvas(loadImage.Width);
                loadImage.Image = previewBitmap;
                resultImage.Image = null;
            }
        }



        private void solarizeButton_Click(object sender, EventArgs e)
        {
            if (previewBitmap == null)
            {
                return;
            }
            resultBitmap = previewBitmap.Solzarize((Byte)redVal.Value, (Byte)blueVal.Value, (Byte)greenVal.Value);
            resultImage.Image = resultBitmap;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (resultBitmap != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Specify a file name and file path";
                sfd.Filter = "Jpeg Images(*.jpg)|*.jpg|Png Images(*.png)|*.png";
                sfd.Filter += "|Bitmap Images(*.bmp)|*.bmp";

                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string fileExtension = Path.GetExtension(sfd.FileName).ToUpper();
                    ImageFormat imgFormat = ImageFormat.Png;

                    if (fileExtension == "BMP")
                    {
                        imgFormat = ImageFormat.Bmp;
                    }
                    else if (fileExtension == "JPG")
                    {
                        imgFormat = ImageFormat.Jpeg;
                    }

                    StreamWriter streamWriter = new StreamWriter(sfd.FileName, false);
                    resultBitmap.Save(streamWriter.BaseStream, imgFormat);
                    streamWriter.Flush();
                    streamWriter.Close();

                    resultBitmap = null;
                    resultImage.Image = null;
                    loadImage.Image = null;
                }
            }
        }

        private void noiseButton_Click(object sender, EventArgs e)
        {
            if (previewBitmap == null)
            {
                return;
            }
            resultBitmap = previewBitmap.MedianFilter();
            resultImage.Image = resultBitmap;
        }

        private void windowButton_Click(object sender, EventArgs e)
        {
            {
                if (previewBitmap == null)
                {
                    return;
                }
                resultBitmap = previewBitmap.WindowLevel();
                resultImage.Image = resultBitmap;
            }
        }

        private void edgeButton_Click(object sender, EventArgs e)
        {
            if (previewBitmap == null)
            {
                return;
            }
            //resultBitmap = previewBitmap.EdgeFilter();
            resultBitmap = previewBitmap.EdgeDetection(Laplacian3x3,1.0, 0);
            resultImage.Image = resultBitmap;
        }

        

        private void pseudoButton_Click(object sender, EventArgs e)
        {
            if (previewBitmap == null)
            {
                return;
            }
            resultBitmap = previewBitmap.PseudoColoringFilter();
            resultImage.Image = resultBitmap;
        }

        private void spatialButton_Click(object sender, EventArgs e)
        {
            if (previewBitmap == null)
            {
                return;
            }
            resultBitmap = previewBitmap.SpatialMediumFilter();
            resultImage.Image = resultBitmap;
        }

        private void grayscaleButton_Click(object sender, EventArgs e)
        {
            if (previewBitmap == null)
            {
                return;
            }
            resultBitmap = previewBitmap.GrayScaleFilter();
            resultImage.Image = resultBitmap;
        }
    }
}
