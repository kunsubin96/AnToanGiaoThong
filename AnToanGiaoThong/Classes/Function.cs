using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnToanGiaoThong.Classes
{
    public class Function
    {

        //Resize Image
        public Function()
        {

        }
        public Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode=CompositingMode.SourceCopy;
                graphics.CompositingQuality=CompositingQuality.HighQuality;
                graphics.InterpolationMode=InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode=SmoothingMode.HighQuality;
                graphics.PixelOffsetMode=PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
        public Bitmap Byte2Image(byte[] img)
        {
            Bitmap bit = null;
            try
            {
                MemoryStream str = new MemoryStream();
                str.Write(img, 0, img.Length);
                bit= new Bitmap(str);
               
            }
            catch { }
            return bit;
        }
        public byte[] Image2Byte(Image img)
        {
            MemoryStream ms = new MemoryStream();
            byte[] arrImg;
            img.Save(ms, img.RawFormat);
            arrImg=ms.GetBuffer();
            ms.Close();

            return arrImg;
        }


    }//end class
}
