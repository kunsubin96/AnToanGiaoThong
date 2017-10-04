using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ucHeaderButton
{
    public partial class mHeaderButton: UserControl
    {
        public mHeaderButton()
        {
            InitializeComponent();
        }
        private bool _exitClicked;

        public bool ExitClicked
        {
            get
            {
                return _exitClicked;
            }

            set
            {
                _exitClicked=value;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
           (((Panel) this.Parent).Parent as Form).WindowState=FormWindowState.Minimized;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            _exitClicked=true;
            (((Panel)this.Parent).Parent as Form).Close();
        }
    }
}
