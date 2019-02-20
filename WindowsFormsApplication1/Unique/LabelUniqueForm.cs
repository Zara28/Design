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
    public partial class LabelUniqueForm : Form
    {
        public Label newLabel;
        String FormName;
        String LabelName;
        public LabelUniqueForm(Label label)
        {
            LabelName = label.Name;
            FormName = label.FindForm().Name;
            newLabel = label;
            InitializeComponent();

            textBox1.Text = label.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public static void UpdateLabelDesignInDb(Control pb)
        {
            SQLClass.Delete("DELETE FROM " + Tables.Unique +
                " WHERE type = 'Label'" +
                " AND name = '" + pb.Name +
                "' AND FormFrom = '" + pb.FindForm().Name + "'");
            SQLClass.Insert("INSERT INTO " + Tables.Unique +
                " (type, design, author, name, FormFrom) VALUES " +
                "('Label', " +
                "'ForeColor = " + pb.ForeColor +
                    ", FontName = " + pb.Font.Name +
                    ", FontSize = " + pb.Font.Size + 
                    ", Text = " + pb.Text +
                "', 'admin', '" + pb.Name + "', '" + pb.FindForm().Name + "')");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            newLabel.ForeColor = colorDialog1.Color;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                if (fontDialog1.Font.Size > 5 && fontDialog1.Font.Size < 38)
                {
                    newLabel.Font = fontDialog1.Font;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
