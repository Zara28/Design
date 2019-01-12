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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pic(this);
        }

        public static void pic ( Control c)
        {
            foreach (Control ctr in c.Controls)
            {
                if (ctr.GetType().ToString() == "System.Windows.Forms.Button")
                {
                    ((Button)ctr).BackgroundImage = Class1.IMG;
                    ((Button)ctr).BackgroundImageLayout = ImageLayout.Stretch;
                    ((Button)ctr).ForeColor = Class1.col;
                }
                else
                {
                    pic(ctr);
                }
            }
        }
    

        private void button1_Click(object sender, EventArgs e)
        {
            //Class1.IMG = button1.BackgroundImage;
            //pic (this);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();

            pic(this);
        }
    }
}
