using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ImageLab1
{
    public static class ImageOperations
    {
        public static Bitmap CopyToSquareCanvas(this Bitmap sourceBitmap, int canvasWidthLenght)
        {
            float ratio = 1.0f;
            int maxSide = sourceBitmap.Width > sourceBitmap.Height ?
                          sourceBitmap.Width : sourceBitmap.Height;

            ratio = (float)maxSide / (float)canvasWidthLenght;

            Bitmap bitmapResult = (sourceBitmap.Width > sourceBitmap.Height ?
                                    new Bitmap(canvasWidthLenght, (int)(sourceBitmap.Height / ratio))
                                    : new Bitmap((int)(sourceBitmap.Width / ratio), canvasWidthLenght));

            using (Graphics graphicsResult = Graphics.FromImage(bitmapResult))
            {
                graphicsResult.CompositingQuality = CompositingQuality.HighQuality;
                graphicsResult.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphicsResult.PixelOffsetMode = PixelOffsetMode.HighQuality;

                graphicsResult.DrawImage(sourceBitmap,
                                        new Rectangle(0, 0,
                                            bitmapResult.Width, bitmapResult.Height),
                                        new Rectangle(0, 0,
                                            sourceBitmap.Width, sourceBitmap.Height),
                                            GraphicsUnit.Pixel);
                graphicsResult.Flush();
            }

            return bitmapResult;
        }

        public static Bitmap Solzarize(this Bitmap sourceBitmap, byte redValue,byte blueValue, byte greenValue)
        {
            BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0,sourceBitmap.Width, sourceBitmap.Height),ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);

            sourceBitmap.UnlockBits(sourceData);

            for (int k = 0; k + 4 < pixelBuffer.Length; k += 4)
            {
                if (pixelBuffer[k + 2] < redValue)
                {
                    pixelBuffer[k + 2] = (byte)(255 - pixelBuffer[k + 2]);
                }

                if (pixelBuffer[k] < blueValue)
                {
                    pixelBuffer[k] = (byte)(255 - pixelBuffer[k]);
                }

                if (pixelBuffer[k + 1] < greenValue)
                {
                    pixelBuffer[k + 1] = (byte)(255 - pixelBuffer[k + 1]);
                }
            }

            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);

            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                                    resultBitmap.Width, resultBitmap.Height),
                                    ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            Marshal.Copy(pixelBuffer, 0, resultData.Scan0, pixelBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }

        public static Bitmap WindowLevel(this Bitmap sourceBitmap)
        {
            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);
            int a = 45, b = 120;
            for (int i = 0; i < sourceBitmap.Height; i++)
                for (int j = 0; j < sourceBitmap.Width; j++)
                {
                    Color c = sourceBitmap.GetPixel(j, i);
                    int g = c.R;
                    if (g < a) g = 0;
                    else
                    if (g > b) g = 0;
                    resultBitmap.SetPixel(j, i, Color.FromArgb(2 * g, 2 * g, 2 * g));
                }
        
            return resultBitmap;
        }


        public static Bitmap MedianFilter(this Bitmap sourceBitmap)
        {
            BitmapData sourceData =
                       sourceBitmap.LockBits(new Rectangle(0, 0,
                       sourceBitmap.Width, sourceBitmap.Height),
                       ImageLockMode.ReadOnly,
                       PixelFormat.Format32bppArgb);


            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] resultBuffer = new byte[sourceData.Stride *sourceData.Height];
            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0,pixelBuffer.Length);
            sourceBitmap.UnlockBits(sourceData);

            //MATRIX SIZE FOR FILTERING, CHANGE THE FIRST NUMBER FOR DIFFERENT RESULTS
            int filterOffset = 1;
            int calcOffset = 0;
            int byteOffset = 0;

            List<int> neighbourPixels = new List<int>();
            byte[] middlePixel;

            for (int offsetY = filterOffset; offsetY <sourceBitmap.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX <sourceBitmap.Width - filterOffset; offsetX++)
                {
                    byteOffset = offsetY *sourceData.Stride +offsetX * 4;
                    neighbourPixels.Clear();

                    for (int filterY = -filterOffset;filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset;filterX <= filterOffset; filterX++)
                        {
                            calcOffset = byteOffset +(filterX * 4) +(filterY * sourceData.Stride);
                            neighbourPixels.Add(BitConverter.ToInt32(pixelBuffer, calcOffset));
                        }
                    }

                    neighbourPixels.Sort();
                    middlePixel = BitConverter.GetBytes(neighbourPixels[filterOffset]);

                    resultBuffer[byteOffset] = middlePixel[0];
                    resultBuffer[byteOffset + 1] = middlePixel[1];
                    resultBuffer[byteOffset + 2] = middlePixel[2];
                    resultBuffer[byteOffset + 3] = middlePixel[3];
                }
            }

            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width,sourceBitmap.Height);

            BitmapData resultData =
                       resultBitmap.LockBits(new Rectangle(0, 0,
                       resultBitmap.Width, resultBitmap.Height),
                       ImageLockMode.WriteOnly,
                       PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0,resultBuffer.Length);

            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }

        public static Bitmap GrayScaleFilter(this Bitmap sourceBitmap)
        {
            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);
            for (int i = 0; i < sourceBitmap.Width; i++)
                for (int j = 0; j < sourceBitmap.Height; j++)
                {
                    Color p = sourceBitmap.GetPixel(i, j);
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;
                    int avg = (r + g + b) / 3;
                    //set new pixel value
                    resultBitmap.SetPixel(i, j, Color.FromArgb(a, avg, avg, avg));
                }

            return resultBitmap;
        }

        public static Bitmap EdgeFilter(this Bitmap sourceBitmap)
        {
            Bitmap grayBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);
            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);
            grayBitmap = grayBitmap.GrayScaleFilter();
      
            Double l = 2;
            for (int i = 1; i < sourceBitmap.Width -1; i++)
                for (int j = 1; j < sourceBitmap.Height -1; j++)
                {
                    //int u = sourceBitmap.GetPixel(i, j).R;
                    //int f = grayBitmap.GetPixel(i, j).R;

                    int u = 0;
                    int f = 0;
                    for (int i2 = -1; i2 <= 1; i2++)
                        for (int j2 = -1; j2 <= 1; j2++)
                        {
                            Color p1 = sourceBitmap.GetPixel(i + i2, j + j2);
                            Color p2 = grayBitmap.GetPixel(i + i2, j + j2);

                            u += p1.R;
                            f += p2.R;
                        }

                    u = u / 9;
                    f = f / 9;
                    int v = u + (int)(l * (u - f));
                    if (v < 0)
                        v = 0;
                    else if (v > 255)
                        v = 255;
                    resultBitmap.SetPixel(i, j, Color.FromArgb(255, v, v, v));
                }
            return resultBitmap;
            
        }



        public static Bitmap EdgeDetection(this Bitmap sourceBitmap,double[,] filterMatrix, double factor = 1, int bias = 0)
        {
            Bitmap grayBitmap = sourceBitmap.GrayScaleFilter();

            BitmapData sourceData = grayBitmap.LockBits(new Rectangle(0, 0, grayBitmap.Width, grayBitmap.Height),ImageLockMode.ReadOnly,PixelFormat.Format32bppArgb);
            byte[] pixelBuffer = new byte[sourceData.Stride *sourceData.Height];
            byte[] resultBuffer = new byte[sourceData.Stride *sourceData.Height];
            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0,pixelBuffer.Length);

            grayBitmap.UnlockBits(sourceData);

            double blue = 0.0;
            double green = 0.0;
            double red = 0.0;


            int filterWidth = filterMatrix.GetLength(1);
            int filterHeight = filterMatrix.GetLength(0);

            int filterOffset = (filterWidth - 1) / 2;
            int calcOffset = 0;

            int byteOffset = 0;

            for (int offsetY = filterOffset; offsetY <
                sourceBitmap.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX <
                    sourceBitmap.Width - filterOffset; offsetX++)
                {
                    blue = 0;
                    green = 0;
                    red = 0;

                    byteOffset = offsetY *sourceData.Stride +offsetX * 4;

                    for (int filterY = -filterOffset;filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset;filterX <= filterOffset; filterX++)
                        {
                            calcOffset = byteOffset +(filterX * 4) +(filterY * sourceData.Stride);

                            blue += (double)(pixelBuffer[calcOffset]) * filterMatrix[filterY + filterOffset,filterX + filterOffset];
                            green += (double)(pixelBuffer[calcOffset + 1]) * filterMatrix[filterY + filterOffset,filterX + filterOffset];
                            red += (double)(pixelBuffer[calcOffset + 2]) *filterMatrix[filterY + filterOffset,filterX + filterOffset];
                        }
                    }
                    blue = factor * blue + bias;
                    green = factor * green + bias;
                    red = factor * red + bias;


                    if (blue > 255)
                    {
                        blue = 255;
                    }
                    else if (blue < 0)
                    {
                        blue = 0;
                    }
                    if (green > 255)
                    {
                        green = 255;
                    }
                    else if (green < 0)
                    {
                        green = 0;
                    }
                    if (red > 255)
                    {
                        red = 255;
                    }
                    else if (red < 0)
                    {
                        red = 0;
                    }
                    resultBuffer[byteOffset] = (byte)(blue);
                    resultBuffer[byteOffset + 1] = (byte)(green);
                    resultBuffer[byteOffset + 2] = (byte)(red);
                    resultBuffer[byteOffset + 3] = 255;
                }
            }


            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width,sourceBitmap.Height);

            BitmapData resultData =resultBitmap.LockBits(new Rectangle(0, 0, resultBitmap.Width, resultBitmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0,resultBuffer.Length);

            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }

        public static Bitmap PseudoColoringFilter(this Bitmap sourceBitmap)
        {
            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);
            Bitmap grayBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);

            grayBitmap = grayBitmap.GrayScaleFilter();

            int r=0, g = 0, b = 0;
            for (int i = 0; i < sourceBitmap.Width; i++)
                for (int j = 0; j < sourceBitmap.Height; j++)
                {
                    
                    Color p = sourceBitmap.GetPixel(i, j);
                    
                    if (p.R >= 0 && p.R <= 63)
                    {
                        r = 0;
                        g = 255 / 63 * p.R;
                        b = 255;
                    }

                    else if (p.R > 63 && p.R <= 127)
                    {
                        r = 0;
                        g = 255;
                        b = 255 - (255 / (127 - 63) * (p.R - 63));
                    }

                    else if (p.R > 127 && p.R <= 191)
                    {
                        r = 255 / (191 - 127) * (p.R - 127);
                        g = 255;
                        b = 0;
                    }

                    else if (p.R > 191 && p.R <= 255)
                    {
                        r = 255;
                        g = 255 / ( 255 / (255 - 191) * (p.R - 191));
                        b = 0;
                    }

                    resultBitmap.SetPixel(i, j, Color.FromArgb(p.A, r, g, b));
                }
            return resultBitmap;
        }


        public static Bitmap SpatialMediumFilter(this Bitmap sourceBitmap)
        {
            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);

            for (int i = 1; i < sourceBitmap.Width - 1; i++)
                for (int j = 1; j < sourceBitmap.Height - 1; j++)
                {
                    int sR = 0, sG = 0, sB = 0;
                    for (int i2 = -1; i2 <= 1; i2++)
                        for (int j2 = -1; j2 <= 1; j2++)
                        {
                            Color p = sourceBitmap.GetPixel(i + i2, j + j2);
                            sR += p.R;
                            sG += p.G;
                            sB += p.B;
                        }
                    sR = sR / 9;
                    sG = sG / 9;
                    sB = sB / 9;

                    resultBitmap.SetPixel(i, j, Color.FromArgb(255, sR, sG, sB));
                }
            
            return resultBitmap;
        }
    }


}
