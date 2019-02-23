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
            public string type;
            public List<pokaz> par;
            public void Get_T_N(/*String[] stroki, ref string nazv, ref string type*/)
            {
                for (int i = 0; i < par.Count; i++)
                {
                    if (par[i].nazvanie == "Name")
                    {
                        nazv = par[i].parametr;
                    }
                    if (par[i].nazvanie == "Type")
                    {
                        type = par[i].parametr;
                    }
                }
            }
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



        /// <summary>
        /// Выбор цвета панелей
        /// </summary>
        private void colorButton_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            if (DesignClass.PANEL_COLOR != null)
            {
                MyDialog.Color = DesignClass.PANEL_COLOR;
            }
                
            MyDialog.ShowDialog();
            DesignClass.PANEL_COLOR = MyDialog.Color;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DesignClass.PANEL_TRANSPARENCY = true;

            //this.Close();
        }

        private void imageButton_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Load(imageTextBox.Text);
            }
            catch (Exception)
            {
                pictureBox1.Image = null;
            }

            DesignClass.PANEL_BACKGROUND_IMG = pictureBox1.Image;
            DesignClass.PANEL_BACKGROUND_ADDRESS = imageTextBox.Text;
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
            //MainForm.pic(this);
            String s = File.ReadAllText("zhukoff.json");
            List<String> s2 = new List<string>(s.Split(new string[] { "  ", "[", "]", "\n", "{", "}", ": ", "\r", "\",", "\"" }, StringSplitOptions.RemoveEmptyEntries));
            for (int i = 0; i < s2.Count; i++)
            {
                if (s2[i] == " " && s2[i] == "  ")
                {
                    s2.RemoveAt(i);
                }
            }
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
                qwerty[i].Get_T_N();
            }


            //String[] s3 = s2[0].Split(new string[] { "},{", "{", "}"}, StringSplitOptions.RemoveEmptyEntries); 
            
            #region Загрузка цвета в форму (куча странного кода)
            foreach (Control ctr in this.Controls)
            {
                for (int i = 0; i < qwerty.Length; i++)
                {
                    if (ctr.Name == qwerty[i].nazv && ctr.GetType().ToString() == "System.Windows.Forms." + qwerty[i].type)
                    {
                        for (int j = 0; j < qwerty[i].par.Count; j++)
                        {
                            if (qwerty[i].par[j].nazvanie == "ForeColor")
                            {
                                foreach (String colorName in Enum.GetNames(typeof(KnownColor)))
                                {
                                    if (colorName == qwerty[i].par[j].parametr)
                                    {
                                        Color knownColor = Color.FromKnownColor((KnownColor)Enum.Parse(typeof(KnownColor), colorName));
                                        ctr.ForeColor = knownColor;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                if (qwerty[i].par[j].nazvanie == "BackColor")
                                    foreach (String colorName in Enum.GetNames(typeof(KnownColor)))
                                    {
                                        if (colorName == qwerty[i].par[j].parametr)
                                        {
                                            Color knownColor = Color.FromKnownColor((KnownColor)Enum.Parse(typeof(KnownColor), colorName));
                                            ctr.BackColor = knownColor;
                                            break;
                                        }
                                    }
                                else
                                {
                                    if(qwerty[i].par[j].nazvanie == "Font")
                                    {
                                        ctr.Font = new Font(qwerty[i].par[j].parametr, ctr.Font.Size);
                                    }
                                    else
                                    {
                                        if (qwerty[i].par[j].nazvanie == "BackgroundImageLayout")
                                        {
                                            switch (qwerty[i].par[j].nazvanie)
                                            {
                                                case "Stretch":
                                                    ctr.BackgroundImageLayout = ImageLayout.Stretch;
                                                    break;
                                                case "Zoom":
                                                    ctr.BackgroundImageLayout = ImageLayout.Zoom;
                                                    break;
                                                case "Center":
                                                    ctr.BackgroundImageLayout = ImageLayout.Center;
                                                    break;
                                                case "Tile":
                                                    ctr.BackgroundImageLayout = ImageLayout.Tile;
                                                    break;
                                            }
                                        }
                                        else
                                        {
                                            if(qwerty[i].par[j].nazvanie == "Enabled")
                                            {
                                                ctr.Enabled = Convert.ToBoolean(qwerty[i].par[j].parametr);
                                            }
                                            else
                                            {
                                                if (qwerty[i].par[j].nazvanie == "Visible")
                                                {
                                                    ctr.Visible = Convert.ToBoolean(qwerty[i].par[j].parametr);
                                                }
                                                else
                                                {
                                                    if (qwerty[i].par[j].nazvanie == "FontSize")
                                                    {
                                                        //ctr.Font = new Font(ctr.Font.Name, Convert.ToDouble(qwerty[i].par[j].parametr));
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;  
                    }
                }
            }
            #endregion

            // label1.BackColor = ; 
            //textBox5.Text = s[0]; 


            String str = "Type: Label, " +
            "Name: label1, " +
            "BackColor: Transparent" +
            "ForeColor: ControlText";


            String[] words = str.Split(new char[] { ':', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            String t = "", n = "";
            //.Get_T_N(words, ref n, ref t);

            //MessageBox.Show("type = " + t + " name = " + n);

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

        private void PanelDefaultForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            MainForm.typeSerialize();
        }
    }
}