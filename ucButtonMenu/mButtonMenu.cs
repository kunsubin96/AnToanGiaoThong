using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace ucButtonMenu
{

    public delegate void ClickHandler(mButtonMenu sender, EventArgs e);
    public partial class mButtonMenu : UserControl
    {
        public event ClickHandler click;
        public mButtonMenu()
        {
            InitializeComponent();
            this.pictureBox1.SendToBack();
            this.label1.SendToBack();
        }
        public static Bitmap ResizeImage(Image image, int width, int height)
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
        public void SetImage(Image img)
        {
            img=ResizeImage(img, pictureBox1.Size.Width, pictureBox1.Size.Height);
            this.pictureBox1.Image=img;
            pictureBox1.SizeMode=PictureBoxSizeMode.StretchImage;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (click!=null)
            {
                click(this, e);
            }
        }
       public void SetText(string name)
        {
            this.label1.Text=name;
        }
        public string getText()
        {
            return this.label1.Text;
        }
        public void setBackColor(int a, int b, int c)
        {
            this.BackColor = Color.FromArgb(a,b,c);
        }
    }
}
