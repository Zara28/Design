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
    public partial class FormLabel : Form
    {
        public FormLabel()
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
    }
}
