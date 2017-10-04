using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace AnToanGiaoThong.Module
{
    public partial class ucDiemNongGT : UserControl
    {
        public ucDiemNongGT()
        {
            InitializeComponent();
        }

        private void ucDiemNongGT_Load(object sender, EventArgs e)
        {
            if (CheckForInternetConnection())
            {
                pictureBox1.Hide();

                label1.Hide();

                webBrowser1.Navigate("https://www.google.com/maps/d/u/0/viewer?hl=en&mid=1ZvbiZUB7vVtKFeFAi3su4_Vm2aY");

            }
            else
            {
                webBrowser1.Hide();

                pictureBox1.Show();

                label1.Show();
            }
           
        }
        public  bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
