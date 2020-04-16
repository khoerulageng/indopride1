using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INDOPRIDE
{
    public partial class indopride : Form
    {
        int mouseX, mouseY, mouse;

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouse == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mouseX, MousePosition.Y - mouseY);

            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouse = 1;
            mouseX = e.X;
            mouseY = e.Y;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouse = 0;
        }

        public indopride()
        {
            this.BackColor = Color.DimGray;
            this.TransparencyKey = Color.DimGray;
            InitializeComponent();
        }


    }
}
