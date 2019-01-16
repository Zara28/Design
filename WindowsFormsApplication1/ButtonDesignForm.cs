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
    public partial class ButtonDesignForm : Form
    {
        public ButtonDesignForm()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Form1.pic(this);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DesignClass.BUTTON_BACKGROUND_IMG = ((PictureBox)sender).BackgroundImage;
            Form1.pic(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.ShowDialog();

            this.ForeColor = MyDialog.Color;
            DesignClass.BUTTON_TEXT_COLOR = MyDialog.Color;
        }
    }
}
