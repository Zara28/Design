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

        /// <summary>
        /// Получаем название и тип компонента
        /// </summary>
        public static void Get_T_N(String[] stroki, ref string nazv, ref string type)
        {
            for (int i = 0; i < stroki.Length; i++)
            {
                if (stroki[i] == "Name")
                {
                    nazv = stroki[i + 1];
                }
                if (stroki[i] == "Type")
                {
                    type = stroki[i + 1];
                }
            }
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
            pokaz[] sjh = new pokaz[26];
            item[] qwerty = new item[100];
            for (int i = 0; i < qwerty.Length; i++)
            {
                qwerty[i].par = new List<pokaz>();
            }
            int k = 0;
            int q = 0;
            MainForm.pic(this);
            /*String s = File.ReadAllText("zhukoff.json");
            List<String> s2 = new List<string>(s.Split(new string[] { "  ", "[", "]", "\n", "{", "}", ": ", "\r", "\",", "\"" }, StringSplitOptions.RemoveEmptyEntries));
            for (int i = 0; i < s2.Count; i++)
            {
                if (s2[i] == " " && s2[i] == "  ")
                {
                    s2.RemoveAt(i);
                }
            }
            textBox5.Text = s2[6];
            for (int i = 0; i < s2.Count; i++)
            {
                if (s2[i] == ",")
                {
                    for (int j = 0; j < k; j++)
                    {
                        qwerty[q].par.Add(sjh[j]);
                    }
                    q++;
                    k = 0;
                }
                else
                {
                    sjh[k].nazvanie = s2[i];
                    sjh[k].parametr = s2[i + 1];
                    i++;
                    k++;
                }
            }
            for (int i = 0; i < qwerty.Length; i++)
            {
                //qwerty[i].Get_T_N();
            }
            */

            //String[] s3 = s2[0].Split(new string[] { "},{", "{", "}"}, StringSplitOptions.RemoveEmptyEntries); 
            /*foreach (Control ctr in this.Controls)
            {
                for (int i = 0; i < qwerty.Length; i++)
                {
                    if (ctr.Name == qwerty[i].nazv && ctr.GetType().Name == qwerty[i].type)
                    {
                        for (int jj = 0; jj < qwerty[i].par.Count; jj++)
                        {
                            if (qwerty[i].par[jj].nazvanie == "ForeColor")
                            {
                                foreach (String colorName in Enum.GetNames(typeof(KnownColor)))
                                {
                                    if (colorName == qwerty[i].par[jj].parametr)
                                    {
                                        Color knownColor = Color.FromKnownColor((KnownColor)Enum.Parse(typeof(KnownColor), colorName));// 
                                        ctr.BackColor = knownColor;
                                    }
                                }
                            }
                            else
                            {
                                if (qwerty[i].par[jj].nazvanie == "BackColor")
                                    foreach (String colorName in Enum.GetNames(typeof(KnownColor)))
                                    {
                                        if (colorName == qwerty[i].par[jj].parametr)
                                        {
                                            Color knownColor = Color.FromKnownColor((KnownColor)Enum.Parse(typeof(KnownColor), colorName));// 
                                            ctr.BackColor = knownColor;
                                        }
                                    }
                            }
                            break;
                        }
                    }
                }
            }*/
            // label1.BackColor = ; 
            //textBox5.Text = s[0]; 


            String str = "Type: Label, " +
            "Name: label1, " +
            "BackColor: Transparent" +
            "ForeColor: ControlText";


            String[] words = str.Split(new char[] { ':', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            String t = "", n = "";
            Get_T_N(words, ref n, ref t);

            MessageBox.Show("type = " + t + " name = " + n);

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



            /////////////////////////////////////////////////////



            /*
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
             */
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
