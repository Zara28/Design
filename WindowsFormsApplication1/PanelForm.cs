using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class PanelForm : Form
    {
        public PanelForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.ShowDialog();

            DesignClass.PANEL_COLOR = MyDialog.Color;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DesignClass.PANEL_TRANSPARENCY = true;

            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                pictureBox1.Load(textBox2.Text);
            }
            catch (Exception)
            {
                pictureBox1.Image = null;
            }

            DesignClass.PANEL_BACKGROUND_IMG = pictureBox1.Image;

        }
        

    }
}
