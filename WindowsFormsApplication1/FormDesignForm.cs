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
        }

        private void FormDesignForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.ShowDialog();

            DesignClass.LABEL_TEXT_COLOR = MyDialog.Color;
        }
    }
}
