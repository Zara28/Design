using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class PanelDefaultForm : Form
    {
        public Panel panel;
        public PanelDefaultForm()
        {
            InitializeComponent();
            
        }
        public struct pokaz
        {
            public string nazvanie;
            public string parametr;
        }

        public struct item
        {
            public string nazv;
            public List<pokaz> par;
        }




        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.ShowDialog();

            DesignClass.PANEL_COLOR = MyDialog.Color;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DesignClass.PANEL_TRANSPARENCY = true;

            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                pictureBox1.Load(textBox2.Text);
            }
            catch (Exception)
            {
                pictureBox1.Image = null;
            }

            DesignClass.PANEL_BACKGROUND_IMG = pictureBox1.Image;

        }

        private void PanelForm_Load(object sender, EventArgs e)
        {
            pokaz[] sjh = new pokaz[5];
            item[] qwerty = new item[100];
            int k = 0;
            int q = 0;
            MainForm.pic(this);
            /*String s = File.ReadAllText("zhukoff.json");
            String[] s2 = s.Split(new char[] {'[', ']', '\n', ' ', '{', '}'}, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < s2.Length; i++)
            {
                if(s2[i] == ",")
                {
                    for(int j = 0; j < k; j++)
                    {
                        qwerty[q].par.Add(sjh[j]);
                        q++;
                    }
                    k = 0;
                }
                else
                { 
                    sjh[k].nazvanie = s2[i];
                    sjh[k].parametr = s2[i + 1];
                    i++;
                    k++;
                }
            }*/
                //String[] s3 = s2[0].Split(new string[] { "},{", "{", "}"}, StringSplitOptions.RemoveEmptyEntries);
                foreach (Control ctr in this.Controls)
                {


                }
           // label1.BackColor = ;
            //textBox5.Text = s[0];


            String str = "Type: Label, " +
                "Name: label1, " +
                "BackColor: Transparent" + 
                "ForeColor: ControlText"; 
            
            String[] words = str.Split(new char[] {':', ',' ,' '}, StringSplitOptions.RemoveEmptyEntries);
            

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.GetType().Name == words[1] && ctrl.Name.ToString() == words[3])
                {
                    foreach (String colorName in Enum.GetNames(typeof(KnownColor)))
                    {
                        if (colorName == words[5])
                        {
                            Color knownColor = Color.FromKnownColor((KnownColor)Enum.Parse(typeof(KnownColor), colorName));//
                            ctrl.BackColor = knownColor;
                        }
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DesignClass.PANEL_LENGTH = Math.Abs(Convert.ToInt32(textBox1.Text));
            Size Size1 = new Size(panel1.Size.Width, 0);
            Size Size2 = new Size(panel2.Size.Width, 0);
            Size s1 = new System.Drawing.Size(DesignClass.PANEL_LENGTH, 0);
            panel2.Location = panel1.Location + Size1 + s1;
            panel3.Location = panel2.Location + Size2 + s1;
            this.Size = new System.Drawing.Size(panel3.Location.X + panel3.Size.Width, this.Size.Height);
        }
    }
}
