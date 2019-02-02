using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            pic(this);
        }

        #region Измение растстояния между картинками, сами картинки, цвета и тд
        public static void pic ( Control c)
        {
            //Фон формы FIXME!!!
            if (c.GetType().ToString().Contains("WindowsFormsApplication1"))
            {
                c.BackgroundImage = DesignClass.FORM_BACKGROUND_IMG;
                c.Cursor = DesignClass.FORM_CURSOR;
                c.BackColor = DesignClass.FORM_COLOR;
                c.ContextMenuStrip = DesignClass.FORM_MENU;
            }

            //Дизайн кнопок
            foreach (Control ctr in c.Controls)
            {
                if (ctr.GetType().ToString() == "System.Windows.Forms.Button")
                {
                    ((Button)ctr).BackgroundImage = DesignClass.BUTTON_BACKGROUND_IMG;
                    ((Button)ctr).BackgroundImageLayout = ImageLayout.Stretch;
                    ((Button)ctr).ForeColor = DesignClass.BUTTON_TEXT_COLOR;
                    ((Button)ctr).Font = DesignClass.BUTTON_FONT;
                    ((Button)ctr).BackColor = DesignClass.BUTTON_COLOR;
                    ctr.ContextMenuStrip = DesignClass.BUTTON_MENU;
                }
                else if (ctr.GetType().ToString() == "System.Windows.Forms.Label")
                {
                    ((Label)ctr).BackColor = Color.Transparent;
                    ((Label)ctr).ForeColor = DesignClass.LABEL_TEXT_COLOR;
                }
                else if (ctr.GetType().ToString() == "System.Windows.Forms.PictureBox")
                {
                    ctr.ContextMenuStrip = DesignClass.PICTURE_SAVE_MENU;
                }                
                else if (ctr.GetType().ToString() == "System.Windows.Forms.Panel")
                {                    
                    ((Panel)ctr).BackgroundImage = DesignClass.PANEL_BACKGROUND_IMG;
                    ((Panel)ctr).BackColor = DesignClass.PANEL_COLOR;
                    ctr.ContextMenuStrip = DesignClass.PANEL_MENU;
                    if (DesignClass.PANEL_TRANSPARENCY)
                    {
                        ((Panel)ctr).BackColor = Color.Transparent;
                    }          
                }

                String str = "Type: Label, " +
                "Name: label1, " +
                "BackColor: Transparent" +
                "ForeColor: ControlText";
                List<String> what = SQLClass.Select("SELECT design FROM design1 WHERE type = 'Button'");

                

                



                List<String> uniqueDesign = SQLClass.Select("SELECT design, FormFrom, Name, Type FROM designDiffirent");

                for (int index = 0; index < uniqueDesign.Count; index += 4)
                {
                    if (uniqueDesign[index + 1] == ctr.FindForm().Name &&
                        uniqueDesign[index + 2] == ctr.Name &&
                        ctr.GetType().ToString() == "System.Windows.Forms." + uniqueDesign[index + 3])
                    {
                        String[] words = uniqueDesign[index].Split(new string[] { ":", ",", " = ", "=" }, StringSplitOptions.RemoveEmptyEntries);

                        String FontName = "";
                        int FontSize = 0;

                        for (int i = 0; i < words.Length; i++)
                        {
                            if (words[i] == "Color")
                            {
                                foreach (String colorName in Enum.GetNames(typeof(KnownColor)))
                                {
                                    String colorFromDB = words[i + 1];
                                    if (colorFromDB.StartsWith("Color"))
                                    {
                                        colorFromDB = colorFromDB.Replace("Color [", "").Replace("]", "");
                                    }

                                    if (colorName == colorFromDB)
                                    {
                                        
                                        Color knownColor = Color.FromKnownColor((KnownColor)Enum.Parse(typeof(KnownColor), colorName));
                                        ctr.BackColor = knownColor;
                                       
                                        //ctr.BackColor = Color.FromArgb(Convert.ToInt32(words[i + 1]));
                                        
                                    }
                                }
                            }

                            if (words[i] == "Visible")
                            {
                                ctr.Visible = (words[i + 1] == "True");
                            }

                            if (words[i] == "FontName")
                            {
                                FontName = words[i + 1];
                            }

                            if (words[i] == "FontSize")
                            {
                                FontSize = Convert.ToInt32(words[i + 1]);
                            }

                            /*  if (words[i] == "BackgroundImage")
                              {
                                  if (ctr.GetType().ToString() == "System.Windows.Forms.Button")
                                  {
                                      DesignClass.BUTTON_BACKGROUND_IMG = words[i + 1];
                                  }
                                
                              }*/
                        }

                        if (FontName != "" && FontSize > 0)
                        {
                            ctr.Font = new Font(FontName, FontSize);
                        }

                    }

                }


               
                pic(ctr);
            }
        }
        #endregion


        private void button1_Click(object sender, EventArgs e)
        {
        }

      
        private void button5_Click(object sender, EventArgs e)
        {
            ButtonDefaultForm form = new ButtonDefaultForm();
            form.ShowDialog();

            pic(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DesignClass.PICTURE_SAVE_MENU = PictureBoxContextMenuStrip;
            DesignClass.FORM_MENU = FormContextMenuStrip;
            DesignClass.BUTTON_MENU = ButtonContextMenuStrip;
            DesignClass.PANEL_MENU = PanelContextMenuStrip;
            
            pic(this);
            pictureBox1.Load("http://www.forumdaily.com/wp-content/uploads/2017/03/Depositphotos_31031331_m-2015.jpg");
            pictureBox1.BackgroundImage = pictureBox1.Image;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormDesignForm form = new FormDesignForm();
            form.ShowDialog();

            pic(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PanelDefaultForm f = new PanelDefaultForm();
            f.ShowDialog();
            pic(this);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        #region JSON сохранение



        /// <summary>
        /// Превращает картику в байты
        /// </summary>
        /// <param name="imageIn">Обьект Image</param>
        /// <returns>Байты в виде byte[]</returns>
        public byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                if (imageIn == null)
                {
                    return null;
                }
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }

        #region Строки для поиска конкретных картинок
        string panda = "/9j/4AAQSkZJRgABAQEAyADIAAD/2wBDAAQDAwQDAwQEBAQFB"; 
        string svet = "/9j/4AAQSkZJRgABAQEAAAAAAAD/4QCqRXhpZgAATU0AKgAAA";
        string gun = "/9j/4AAQSkZJRgABAQEAAAAAAAD/4QDGRXhpZgAATU0AKgAAAAgABAEOAAIAAAA";
        #endregion

        /// <summary>
        /// Превращает картинку в её название
        /// </summary>
        /// <param name="img">Обьект Image</param>
        /// <returns>Название картинки. Например panda</returns>
        public string imageText(Image img)
        {
            String imgName = "";
            var bytes = ImageToByteArray(img);
            if (bytes != null)
            {
                string base64string = Convert.ToBase64String(bytes);
                if (base64string.StartsWith(panda))
                {
                    imgName = "panda";
                }
                else if (base64string.StartsWith(svet))
                {
                    imgName = "svet";
                }
                else if (base64string.StartsWith(gun))
                {
                    imgName = "gun";
                }
                else
                {
                    throw new Exception("Не знаю такой картинки");
                }
            }

            return imgName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contrl">лист объектов которые надо сохрнить. обычно равно this</param>
        /// <param name="json">json к которому надо добавить ещё больше json-а</param>
        /// <returns></returns>
        public JArray formSerialize(Control contrl, JArray json = null)
        {
            if (json == null)
            {
                json = new JArray();
            }
            foreach (Control ctr in contrl.Controls)
            {
                if (ctr.GetType().ToString() == "System.Windows.Forms.Button")
                {
                    Dictionary<string, string> button = new Dictionary<string, string>();
                    button.Add("BackgroundImage", imageText(ctr.BackgroundImage));
                    button.Add("Name", ctr.Name);
                    button.Add("BackgroundImageLayout", ctr.BackgroundImageLayout.ToString());
                    button.Add("Type", "Button");
                    button.Add("ForeColor", ctr.ForeColor.Name);
                    button.Add("Font", ctr.Font.Name);
                    json.Add(JObject.FromObject(button));
                }
                else if (ctr.GetType().ToString() == "System.Windows.Forms.Label")
                {
                    Dictionary<string, string> label = new Dictionary<string, string>();

                    label.Add("Name", ctr.Name);
                    label.Add("BackColor", ((Label)ctr).BackColor.Name);
                    label.Add("Type", "Label");
                    label.Add("ForeColor", ((Label)ctr).ForeColor.Name);
                    json.Add(JObject.FromObject(label));
                }
                else if (ctr.GetType().ToString() == "System.Windows.Forms.Panel")
                {
                    json.Add(formSerialize(ctr, json));
                    Dictionary<string, string> panel = new Dictionary<string, string>();
                    panel.Add("Name", ctr.Name);
                    panel.Add("Type", "panel");
                    panel.Add("Form", ctr.FindForm().Name);
                    json.Add(JObject.FromObject(panel));
                }
            }
            return json; 
        }

        public Dictionary<string, JObject> typeSerialize()
        {
            Dictionary<string, JObject> AllTypesData = new Dictionary<string, JObject>();

            //Make a function
            Dictionary<string, string> ButtonData = new Dictionary<string, string>();
            if (DesignClass.BUTTON_BACKGROUND_IMG_ADRESS != null)
            {
                ButtonData.Add("BackgroundImage", DesignClass.BUTTON_BACKGROUND_IMG_ADRESS.ToString());
            }
            if (button1.BackgroundImageLayout != null)
            {
                ButtonData.Add("BackgroundImageLayout", button1.BackgroundImageLayout.ToString());
            }
            if (DesignClass.BUTTON_TEXT_COLOR != null)
            {
                ButtonData.Add("ForeColor", DesignClass.BUTTON_TEXT_COLOR.ToString());
            }
            if (DesignClass.BUTTON_FONT != null)
            {
                ButtonData.Add("Font", DesignClass.BUTTON_FONT.ToString());
            }


            AllTypesData.Add("button", JObject.FromObject(ButtonData));
            AllTypesData.Add("label", JObject.FromObject(new Dictionary<string, string>{
                {"BackColor", label1.BackColor.Name},
                {"ForeColor", label1.ForeColor.Name}
            }));
            AllTypesData.Add("panel", JObject.FromObject(new Dictionary<string, string>{
                {"BackColor", panel1.BackColor.Name},
                {"BackgroundImage", panel1.ForeColor.Name}
            })); 
            
            foreach (string type in AllTypesData.Keys)
            {
                SQLClass.Delete("DELETE FROM design1 WHERE type = '" + type + "'");
                SQLClass.Insert(String.Format("INSERT INTO design1(type, design, author) VALUES ('{0}','{1}','{2}')",
                    type, AllTypesData[type].ToString(), "test"));
            }

            return AllTypesData;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            File.WriteAllText("asdf.json", typeSerialize().ToString());
            File.WriteAllText("zhukoff.json", formSerialize(this).ToString());
        }

        #endregion

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;

            pb.BackgroundImage.Save("../../SavedPictures/Scr" + Convert.ToString(DesignClass.PictureSaveIndex) + ".jpg");
            DesignClass.PictureSaveIndex++;
        }

        private void buttonsVisibilityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nevidimost f = new Nevidimost(((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl.FindForm());
            f.ShowDialog();
        }

        /// <summary>
        /// Меняет дизайн всех кнопок на тот который в базе
        /// </summary>
        private void button7_Click(object sender, EventArgs e)
        {
            List<String> Auths = SQLClass.Select("SELECT design FROM design1 WHERE type = 'Button'");
            String designKnopki = Auths[0];
            
            /*  String designKnopki = "BackColor: Control, " +
                  "ForeColor: ControlText, " +
                  "Font: Microsoft Sans Serif";*/
            
            String[] words = designKnopki.Split(new char[] { ':', ',', ' ', '\"' }, StringSplitOptions.RemoveEmptyEntries);
            
            for (int index = 0; index < words.Length; index++)
            {
                if (words[index] == "BackColor")
                {
                    foreach (String colorName in Enum.GetNames(typeof(KnownColor)))
                    {
                        if (colorName == words[index + 1])
                        {
                            Color knownColor = Color.FromKnownColor((KnownColor)Enum.Parse(typeof(KnownColor), colorName));
                            DesignClass.BUTTON_COLOR = knownColor;
                        }
                    }
                }
                
                if (words[index] == "ForeColor")
                {
                    foreach (String colorName in Enum.GetNames(typeof(KnownColor)))
                    {
                        if (colorName == words[index + 1])
                        {
                            Color knownColor = Color.FromKnownColor((KnownColor)Enum.Parse(typeof(KnownColor), colorName));
                            DesignClass.BUTTON_TEXT_COLOR = knownColor;
                        }

                    }

                }

                if (words[index] == "Font")
                {
                    foreach (FontFamily item in FontFamily.Families)
                    {
                        if (item.ToString() == words[index + 1])
                        {
                            DesignClass.BUTTON_FONT = new Font(item, 14);
                        }
                    }
                }
            }

            pic(this);
        }

        private void дизайнФормыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String FormName = ((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl.FindForm().Name;

            FontDialog fo = new FontDialog();
            fo.ShowColor = true;
            ColorDialog cl = new ColorDialog();

            if (fo.ShowDialog() == DialogResult.OK & cl.ShowDialog() == DialogResult.OK)
            {
                ((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl.FindForm().Font = fo.Font;
                ((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl.FindForm().ForeColor = fo.Color;
                ((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl.FindForm().BackColor = cl.Color;
                SQLClass.Delete("DELETE FROM designDiffirent WHERE FormFrom = '" + FormName + "' and type = 'Form'");
                SQLClass.Insert("INSERT INTO designDiffirent (type, design, FormFrom, Author, Name)" +
                    " VALUES ('Form', " + "'" + Convert.ToString(fo.Font) + "'," + "'" + FormName + "', '', '')");
            }
        }

        private void ggToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Panel pb = (Panel)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            PanelUniqueForm form = new PanelUniqueForm(pb);
            form.ShowDialog();
            pb = form.panel;

            SQLClass.Delete("DELETE FROM designDiffirent WHERE type = 'Panel' AND name = '" + pb.Name + "' AND FormFrom = '" + this.Name +"'");
            SQLClass.Insert("INSERT INTO designDiffirent (type, design, author, name, FormFrom) VALUES " +
                "('Panel', " +
                "'Color = " + pb.BackColor + ", Visible = " + pb.Visible + ", BackgroundImage = " + pb.BackgroundImage + "', "  +
                "'admin', '" + pb.Name + "', '" + this.Name + "')");
        }

        private void changeUniqueBtnMenuItem_Click(object sender, EventArgs e)
        {
            Button pb = (Button)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            ButtonUniqueForm f = new ButtonUniqueForm(pb);
            f.ShowDialog();
            pb = f.newButton;

            SQLClass.Delete("DELETE FROM designDiffirent WHERE type = 'Button' AND name = '" + pb.Name + "' AND FormFrom = '" + this.Name + "'");
            SQLClass.Insert("INSERT INTO designDiffirent (type, design, author, name, FormFrom) VALUES " +
                "('Button', " +
                "'Color = " + pb.BackColor + ", Visible = " + pb.Visible + ", BackgroundImage = " + pb.BackgroundImage + ", Text = "+ pb.Text +
                "', 'admin', '" + pb.Name + "', '" + this.Name + "')");
        }
    }
}
