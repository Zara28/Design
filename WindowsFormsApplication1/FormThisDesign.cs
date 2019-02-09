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
    public partial class FormThisDesign : Form
    {
        String FormName;
        public FormThisDesign(String name)
        {
            InitializeComponent();
            FormName = name;
        }

        private void FormThisDesign_Load(object sender, EventArgs e)
        {     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fo.ShowColor = true;
            fo.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cl.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SQLClass.Delete("DELETE FROM designDiffirent WHERE FormFrom = '" + FormName + "' and type = 'Form'");
            SQLClass.Insert("INSERT INTO designDiffirent (type, design, FormFrom, Author, Name)" +
                " VALUES ('Form', " + "'Color: " + Convert.ToString(cl.Color) + "'," + "'" + FormName + "', '', '')");
        }
    }
}
