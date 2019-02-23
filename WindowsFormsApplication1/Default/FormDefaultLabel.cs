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
    public partial class FormDefaultLabel : Form
    {
        public FormDefaultLabel()
        {
            InitializeComponent();
            MainForm.pic(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.ShowDialog();

            DesignClass.LABEL_TEXT_COLOR = MyDialog.Color;
            MainForm.pic(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                if (fontDialog1.Font.Size > 5 && fontDialog1.Font.Size < 38)
                {
                    DesignClass.FONT_OF_LABEL = fontDialog1.Font;
                    MainForm.pic(this);
                }
            }
        }

        private void FormLabel_Load(object sender, EventArgs e)
        {
            MainForm.pic(this);
            checkBox1.Checked = DesignClass.LABEL_AUTO_SIZE;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            label1.AutoSize = checkBox1.Checked;
            button3.Visible = !checkBox1.Checked;
            button4.Visible = !checkBox1.Checked;
            button5.Visible = !checkBox1.Checked;
            button6.Visible = !checkBox1.Checked;
            button7.Visible = !checkBox1.Checked;
            button8.Visible = !checkBox1.Checked;
            button9.Visible = !checkBox1.Checked;
            button10.Visible = !checkBox1.Checked;
            button11.Visible = !checkBox1.Checked;
            DesignClass.LABEL_AUTO_SIZE = checkBox1.Checked;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DesignClass.LABEL_TEXT_ALIGN = ContentAlignment.TopLeft;
            label1.TextAlign = DesignClass.LABEL_TEXT_ALIGN;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DesignClass.LABEL_TEXT_ALIGN = ContentAlignment.MiddleLeft;
            label1.TextAlign = DesignClass.LABEL_TEXT_ALIGN;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DesignClass.LABEL_TEXT_ALIGN = ContentAlignment.BottomLeft;
            label1.TextAlign = DesignClass.LABEL_TEXT_ALIGN;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DesignClass.LABEL_TEXT_ALIGN = ContentAlignment.TopCenter;
            label1.TextAlign = DesignClass.LABEL_TEXT_ALIGN;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DesignClass.LABEL_TEXT_ALIGN = ContentAlignment.MiddleCenter;
            label1.TextAlign = DesignClass.LABEL_TEXT_ALIGN;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DesignClass.LABEL_TEXT_ALIGN = ContentAlignment.BottomCenter;
            label1.TextAlign = DesignClass.LABEL_TEXT_ALIGN;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DesignClass.LABEL_TEXT_ALIGN = ContentAlignment.TopRight;
            label1.TextAlign = DesignClass.LABEL_TEXT_ALIGN;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DesignClass.LABEL_TEXT_ALIGN = ContentAlignment.MiddleRight;
            label1.TextAlign = DesignClass.LABEL_TEXT_ALIGN;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DesignClass.LABEL_TEXT_ALIGN = ContentAlignment.BottomRight;
            label1.TextAlign = DesignClass.LABEL_TEXT_ALIGN;
        }

        private void FormDefaultLabel_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.typeSerialize();
        }

    }
}
