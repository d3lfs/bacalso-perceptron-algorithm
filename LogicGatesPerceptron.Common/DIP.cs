﻿using System.Drawing;
using System.Drawing.Imaging;

namespace LogicGatesPerceptron.Common
{
    public class DIP
    {
        public static Image ResizeImage(Image image, int newWidth, int newHeight)
        {
            int sourceWidth = image.Width;
            int sourceHeight = image.Height;

            if (sourceWidth < sourceHeight)
            {
                int buff = newWidth;

                newWidth = newHeight;
                newHeight = buff;
            }

            int sourceX = 0, sourceY = 0, destX = 0, destY = 0;
            float nPercent = 0, nPercentW = 0, nPercentH = 0;

            nPercentW = ((float)newWidth / (float)sourceWidth);
            nPercentH = ((float)newHeight / (float)sourceHeight);
            if (nPercentH < nPercentW)
            {
                nPercent = nPercentH;
                destX = System.Convert.ToInt16((newWidth -
                          (sourceWidth * nPercent)) / 2);
            }
            else
            {
                nPercent = nPercentW;
                destY = System.Convert.ToInt16((newHeight -
                          (sourceHeight * nPercent)) / 2);
            }

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);
            

            var bmPhoto = new Bitmap(newWidth, newHeight,
                          PixelFormat.Format24bppRgb);

            bmPhoto.SetResolution(image.HorizontalResolution,
                         image.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.Clear(Color.White);
            grPhoto.InterpolationMode =
                System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

            grPhoto.DrawImage(image,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            image.Dispose();

            return bmPhoto;
        }

        public static String GetBitsString(MemoryStream memoryStream)
        {
            var img = Image.FromStream(memoryStream);
            var bmp = new Bitmap(img);

            if (img.Width != 15 || img.Height != 15)
            {
                img = ResizeImage(img, 15, 15);
                bmp = new Bitmap(img);
            }

            string binData = "";
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    int a = int.Parse(bmp.GetPixel(j, i).A.ToString());
                    int r = int.Parse(bmp.GetPixel(j, i).R.ToString());
                    int g = int.Parse(bmp.GetPixel(j, i).G.ToString());
                    int b = int.Parse(bmp.GetPixel(j, i).B.ToString());

                    if ((a > 0) && (r > 0) && (g > 0) && (b > 0))
                    {
                        binData = binData + "0";
                    }
                    else
                    {
                        binData = binData + "1";
                    }
                }

            }

            return binData;
        }
    }
}
