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
    public partial class PicForm : Form
    {
        public PicForm()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            MainForm.pic(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DesignClass.LENGTH = Math.Abs( Convert.ToInt32(textBox1.Text));
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
