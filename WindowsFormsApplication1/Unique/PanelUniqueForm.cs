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
    public partial class PanelUniqueForm : Form
    {
        public Panel panel;
        public PanelUniqueForm(Panel p)
        {
            InitializeComponent();
            panel = p;
        }

        /// <summary>
        /// Обновление дизайна конкретной панели в БД
        /// </summary>
        public static void UpdatePanelDesignInDb(Panel p)
        {
            SQLClass.Delete("DELETE FROM " + Tables.Unique + 
                " WHERE type = 'Panel'" +
                " AND name = '" + p.Name + 
                "' AND FormFrom = '" + p.FindForm().Name + "'");

            SQLClass.Insert("INSERT INTO " + Tables.Unique + 
                " (type, design, author, name, FormFrom) VALUES " +
                "('Panel', " +
                "'Color = " + p.BackColor + 
                    ", Visible = " + p.Visible + 
                    ", BackgroundImage = " + p.BackgroundImage + "', " +
                "'admin', '" + 
                p.Name + "', '" + 
                p.FindForm().Name + "')");
        }

        /// <summary>
        /// Загрузка дизайна конкретной панели из БД
        /// </summary>
        public static void GetPanelDesignFromDb(ref Panel p)
        {
        }

      
        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.ShowDialog();

            panel.BackColor = MyDialog.Color;
            //this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel.Visible = false;

            //this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Load(textBox1.Text);
            }
            catch (Exception)
            {
                pictureBox1.Image = null;
            }

            panel.BackgroundImage = pictureBox1.Image;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PanelUniqueForm_Load(object sender, EventArgs e)
        {

        }
    }
}
