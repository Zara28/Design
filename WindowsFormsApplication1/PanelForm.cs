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

        private void PanelForm_Load(object sender, EventArgs e)
        {
            MainForm.pic(this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DesignClass.PANEL_LENGTH = Math.Abs(Convert.ToInt32(textBox1.Text));
            Size Size1 = new Size(panel1.Size.Width, 0);
            Size Size2 = new Size(panel2.Size.Width, 0);
            Size s1 = new System.Drawing.Size(DesignClass.PANEL_LENGTH, 0);
            panel2.Location = panel1.Location + Size1 + s1;
            panel3.Location = panel2.Location + Size2 + s1;
            this.Size = new System.Drawing.Size(panel3.Location.X + panel3.Size.Width, this.Size.Height);
        }
        

    }
}
