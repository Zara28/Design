using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class FormDesignForm : Form
    {
        public FormDesignForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Load(textBox1.Text);
            }
            catch (Exception)
            {
                pictureBox1.Load("https://memepedia.ru/wp-content/uploads/2017/04/%D0%B5%D0%B1%D0%B0%D1%82%D1%8C-%D1%82%D1%8B-%D0%BB%D0%BE%D1%85-%D0%BE%D1%80%D0%B8%D0%B3%D0%B8%D0%BD%D0%B0%D0%BB.jpg");
            }

            DesignClass.FORM_BACKGROUND_IMG = pictureBox1.Image;
            this.BackgroundImage = pictureBox1.Image;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(((Button)sender).Name.ToString());


            if (sender.Equals(button2))
            {
                this.BackgroundImageLayout = ImageLayout.Tile;

            }
            else if (sender.Equals(button3))
            {
                this.BackgroundImageLayout = ImageLayout.Zoom;
            }
            else if (sender.Equals(button4))
            {
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else if (sender.Equals(button5))
            {
                this.BackgroundImageLayout = ImageLayout.Center;
            }
            else if (sender.Equals(button6))
            {
                this.BackgroundImageLayout = ImageLayout.None;
            }

            this.BackgroundImage = pictureBox1.Image;
            //DesignClass.nomer_konfig_image
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            colorButton.Visible = !colorButton.Visible;
            DesignClass.PANEL_COLOR = Color.Transparent;
        }

        private void color_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.ShowDialog();
            DesignClass.PANEL_COLOR = MyDialog.Color;
        }

        private void color_form_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.ShowDialog();
            DesignClass.FORM_COLOR = MyDialog.Color;
            this.BackColor = DesignClass.FORM_COLOR;
        }
    }
}
