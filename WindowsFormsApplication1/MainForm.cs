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

            ButtonDefaultForm.ReadButtonDefault();
            ReadLabelDefault();
            ReadPanelDefault();
            pic(this);
        }
        #region Измение расстояния между картинками, сами картинки, цвета и тд
        public static void pic(Control c)
        {
            //Фон формы FIXME!!!
            if (c.GetType().ToString().Contains("WindowsFormsApplication1"))
            {
                c.BackgroundImage = DesignClass.FORM_BACKGROUND_IMG;
                c.Cursor = DesignClass.FORM_CURSOR;
                c.BackColor = DesignClass.FORM_COLOR;
                c.ContextMenuStrip = DesignClass.FORM_MENU;

                FormUniqueForm.GetFormDesignFromDb(ref c);
            }

            //Дизайн кнопок
            foreach (Control ctr in c.Controls)
            {
                #region DesignClass дефалт
                string ctr_type = ctr.GetType().ToString();
                if (ctr_type == "System.Windows.Forms.Button")
                {
                    ((Button)ctr).FlatStyle = DesignClass.FLAT_OF_BUTTON;
                    ((Button)ctr).BackgroundImage = DesignClass.BUTTON_BACKGROUND_IMG;
                    ((Button)ctr).BackgroundImageLayout = ImageLayout.Stretch;
                    ((Button)ctr).ForeColor = DesignClass.BUTTON_TEXT_COLOR;
                    ((Button)ctr).TextAlign = DesignClass.BUTTONIMAGE_ALLINE;
                    ((Button)ctr).Font = DesignClass.BUTTON_FONT;
                    ((Button)ctr).BackColor = DesignClass.BUTTON_COLOR;
                    ctr.ContextMenuStrip = DesignClass.BUTTON_MENU;
                }
                else if (ctr_type == "System.Windows.Forms.Label")
                {
                    ((Label)ctr).BackColor = Color.Transparent;
                    ((Label)ctr).ForeColor = DesignClass.LABEL_TEXT_COLOR;
                    ((Label)ctr).Font = DesignClass.FONT_OF_LABEL;
                    if(!DesignClass.LABEL_AUTO_SIZE)
                    {
                        ((Label)ctr).TextAlign = DesignClass.LABEL_TEXT_ALIGN;
                    }
                    else
                    {
                        ((Label)ctr).AutoSize = true;
                    }
                    ctr.ContextMenuStrip = DesignClass.LABEL_MENU;
                }
                else if (ctr_type == "System.Windows.Forms.PictureBox")
                {
                    ctr.ContextMenuStrip = DesignClass.PICTURE_SAVE_MENU;
                }
                else if (ctr_type == "System.Windows.Forms.Panel")
                {
                    ((Panel)ctr).BackgroundImage = DesignClass.PANEL_BACKGROUND_IMG;
                    ((Panel)ctr).BackColor = DesignClass.PANEL_COLOR;
                    ctr.ContextMenuStrip = DesignClass.PANEL_MENU;
                    if (DesignClass.PANEL_TRANSPARENCY)
                    {
                        ((Panel)ctr).BackColor = Color.Transparent;
                    }
                }
                #endregion

                var temp = ButtonUniqueForm.GetUniqueDesignFromDB(ctr.Name);

                ctr.BackColor = temp.BackColor;
                ctr.ForeColor = temp.ForeColor;
                ctr.Font = temp.Font;
                ctr.Visible = temp.Visible;

                pic(ctr);
            }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
        }
      
        private void buttonDefaultForm_Click(object sender, EventArgs e)
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
            DesignClass.LABEL_MENU = LabelContextMenuStrip;
            
            pic(this);
            pictureBox1.Load("http://www.forumdaily.com/wp-content/uploads/2017/03/Depositphotos_31031331_m-2015.jpg");
            pictureBox1.BackgroundImage = pictureBox1.Image;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        /// <summary>
        /// Дефолтный дизайн форм открываем
        /// </summary>
        private void buttonFormDefaultForm_Click(object sender, EventArgs e)
        {
            FormDefaultForm form = new FormDefaultForm();
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
                    //button.Add("BackgroundImage", imageText(ctr.BackgroundImage));
                    button.Add("Name", ctr.Name);
                    button.Add("Enabled", ctr.Enabled.ToString());
                    button.Add("Visible", ctr.Visible.ToString());
                    button.Add("BackgroundImageLayout", ctr.BackgroundImageLayout.ToString());
                    button.Add("FontSize", ctr.Font.Size.ToString());
                    button.Add("BackColor", ButtonUniqueForm.ColorToJSON(ctr.BackColor));//ctr.BackColor.Name);
                    button.Add("Type", "Button");
                    button.Add("ForeColor", ButtonUniqueForm.ColorToJSON(ctr.ForeColor));//ctr.ForeColor.Name);
                    button.Add("Font", ctr.Font.Name);
                    button.Add("FlatStyle", Convert.ToString(DesignClass.FLAT_OF_BUTTON));
                    json.Add(JObject.FromObject(button));
                }
                else if (ctr.GetType().ToString() == "System.Windows.Forms.Label")
                {
                    Dictionary<string, string> label = new Dictionary<string, string>();

                    label.Add("Name", ctr.Name);
                    label.Add("BackColor", ButtonUniqueForm.ColorToJSON(ctr.BackColor));//((Label)ctr).BackColor.Name);
                    label.Add("Enabled", ctr.Enabled.ToString());
                    label.Add("Visible", ctr.Visible.ToString());
                    label.Add("Type", "Label");
                    label.Add("FontSize", ctr.Font.Size.ToString());
                    label.Add("Font", ctr.Font.Name);
                    label.Add("ForeColor", ((Label)ctr).ForeColor.Name);
                    json.Add(JObject.FromObject(label));
                }
                else if (ctr.GetType().ToString() == "System.Windows.Forms.Panel")
                {
                    json.Add(formSerialize(ctr, json));
                    Dictionary<string, string> panel = new Dictionary<string, string>();
                    panel.Add("Name", ctr.Name);
                    panel.Add("Enabled", ctr.Enabled.ToString());
                    panel.Add("Visible", ctr.Visible.ToString());
                    panel.Add("Type", "panel");
                    panel.Add("Form", ctr.FindForm().Name);
                    json.Add(JObject.FromObject(panel));
                }
            }
            return json; 
        }

        /// <summary>
        /// Сохранение дефолтного дизайна в базу
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, JObject> typeSerialize()
        {
            Dictionary<string, JObject> AllTypesData = new Dictionary<string, JObject>();

            #region Button
            Dictionary<string, string> ButtonData = new Dictionary<string, string>();
            if (DesignClass.BUTTON_BACKGROUND_IMG_ADRESS != null)
            {
                ButtonData.Add("BackgroundImage", DesignClass.BUTTON_BACKGROUND_IMG_ADRESS.ToString());
            }

            //ButtonData.Add("BackgroundImageLayout", button1.BackgroundImageLayout.ToString());

            if (DesignClass.BUTTON_TEXT_COLOR != null)
            {
                ButtonData.Add("ForeColor", ButtonUniqueForm.ColorToJSON(DesignClass.BUTTON_TEXT_COLOR));//DesignClass.BUTTON_TEXT_COLOR.ToString());
            }
            if (DesignClass.BUTTON_FONT != null)
            {
                ButtonData.Add("Font", DesignClass.BUTTON_FONT.ToString());
            }
            if (DesignClass.BUTTON_COLOR != null)
            {
                ButtonData.Add("Color", ButtonUniqueForm.ColorToJSON(DesignClass.BUTTON_COLOR));//.ToString());
            }

            ButtonData.Add("ImageAlign", DesignClass.BUTTONIMAGE_ALLINE.ToString());//.ToString());
            ButtonData.Add("FlatStyle", Convert.ToString(DesignClass.FLAT_OF_BUTTON));//.ToString());
            
            #endregion

            #region Panel
            Dictionary<string, string> PanelData = new Dictionary<string, string>();
            if (DesignClass.PANEL_COLOR != null)
            {
                PanelData.Add("BackColor", ButtonUniqueForm.ColorToJSON(DesignClass.PANEL_COLOR));// DesignClass.PANEL_COLOR.ToString());
            }
            if (DesignClass.PANEL_BACKGROUND_ADDRESS != null)
            {
                PanelData.Add("BackGroundImageAddress", DesignClass.PANEL_BACKGROUND_ADDRESS);
            }
            if (DesignClass.PANEL_TRANSPARENCY != false)
            {
                PanelData.Add("Transparency", "true");
            }
            #endregion

            #region Label
            Dictionary<string, string> labelData = new Dictionary<string, string>();
            if (DesignClass.LABEL_COLOR != null)
            {
                labelData.Add("BackColor", ButtonUniqueForm.ColorToJSON(DesignClass.LABEL_COLOR));//DesignClass.LABEL_COLOR.ToString());
            }
            if (DesignClass.LABEL_TEXT_COLOR != null)
            {
                labelData.Add("ForeColor", ButtonUniqueForm.ColorToJSON(DesignClass.LABEL_TEXT_COLOR));//DesignClass.LABEL_TEXT_COLOR.ToString());
            }
            if (DesignClass.FONT_OF_LABEL != null)
            {
                labelData.Add("FontSize", DesignClass.FONT_OF_LABEL.Size.ToString());
                labelData.Add("FontName", DesignClass.FONT_OF_LABEL.Name);
            }
            
            if (!DesignClass.LABEL_AUTO_SIZE)
            {
                labelData.Add("TextAlign", DesignClass.LABEL_TEXT_ALIGN.ToString());
            }
            else
            {
                labelData.Add("TextAlign", "null");
            }
            #endregion

            AllTypesData.Add("button", JObject.FromObject(ButtonData));
            AllTypesData.Add("label", JObject.FromObject(labelData));
            AllTypesData.Add("panel", JObject.FromObject(PanelData)); 
                        
            foreach (string type in AllTypesData.Keys)
            {
                SQLClass.Delete("DELETE FROM " + Tables.Default + " WHERE type = '" + type + "'");
                SQLClass.Insert(String.Format("INSERT INTO " + Tables.Default + "(type, design, author) VALUES ('{0}','{1}','{2}')",
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

        #region Чтение дефолтного дизайна
        /// <summary>
        /// Чтение дизайна для Panel
        /// </summary>
        public void ReadPanelDefault()
        {
            List<String> Auths = SQLClass.Select("SELECT design FROM " + Tables.Default + " WHERE type = 'panel'");
            String designKnopki = Auths[0];
            
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
                            DesignClass.PANEL_COLOR = knownColor;
                        }
                    }
                }
                
                if (words[index] == "Transparency")
                {
                    DesignClass.PANEL_TRANSPARENCY = Convert.ToBoolean(words[index + 1]);
                }
                if (words[index] == "BackGroundImageAddress")
                {
                    DesignClass.PANEL_BACKGROUND_ADDRESS = words[index + 1] + ":" + words[index + 2];

                    PictureBox pb1 = new PictureBox();
                    pb1.Load(DesignClass.PANEL_BACKGROUND_ADDRESS);
                    DesignClass.PANEL_BACKGROUND_IMG = pb1.Image;
                    pb1.Dispose();
                }
                
            }        
        }

        /// <summary>
        /// ЧТение дефолтного дизайна для Label
        /// </summary>
        public void ReadLabelDefault()
        {
            List<String> Auths = SQLClass.Select("SELECT design FROM " + Tables.Default + " WHERE type = 'label'");
            String designKnopki = Auths[0];
            
            String[] words = designKnopki.Split(new char[] { ':', ',', ' ', '\"' }, StringSplitOptions.RemoveEmptyEntries);

            for (int index = 0; index < words.Length; index++)
            {
                if (words[index] == "BackColor")
                {
                    String colorFromDB = words[index + 1].Trim();
                    if (colorFromDB.StartsWith("Color"))
                    {
                        colorFromDB = colorFromDB.Replace("Color [", "").Replace("]", "");
                    }

                    foreach (String colorName in Enum.GetNames(typeof(KnownColor)))
                    {
                        if (colorName == colorFromDB)
                        {
                            Color knownColor = Color.FromKnownColor((KnownColor)Enum.Parse(typeof(KnownColor), colorName));
                            DesignClass.LABEL_COLOR = knownColor;
                        }
                    }
                }

                if (words[index] == "ForeColor")
                {
                    String colorFromDB = words[index + 1].Trim();
                    if (colorFromDB.StartsWith("Color"))
                    {
                        colorFromDB = colorFromDB.Replace("Color [", "").Replace("]", "");
                    }

                    foreach (String colorName in Enum.GetNames(typeof(KnownColor)))
                    {
                        if (colorName == colorFromDB)
                        {
                            Color knownColor = Color.FromKnownColor((KnownColor)Enum.Parse(typeof(KnownColor), colorName));
                            DesignClass.LABEL_TEXT_COLOR = knownColor;
                        }
                    }
                }

                if (words[index].Trim() == "FontName")
                {
                    DesignClass.NAME_FONT_OF_LABEL = words[index + 1];
                }

                if (words[index].Trim() == "FontSize")
                {
                    DesignClass.SIZE_FONT_OF_LABEL = (int)(Convert.ToDecimal(words[index + 1]));
                }
                if (words[index].Trim() == "TextAlign")
                {
                    DesignClass.LABEL_AUTO_SIZE = false;
                    switch (words[index + 1])
                    {
                        case "BottomCenter":
                            DesignClass.LABEL_TEXT_ALIGN = System.Drawing.ContentAlignment.BottomCenter;
                            break;
                        case "BottomLeft":
                            DesignClass.LABEL_TEXT_ALIGN = System.Drawing.ContentAlignment.BottomLeft;
                            break;
                        case "BottomRight":
                            DesignClass.LABEL_TEXT_ALIGN = System.Drawing.ContentAlignment.BottomRight;
                            break;
                        case "MiddleCenter":
                            DesignClass.LABEL_TEXT_ALIGN = System.Drawing.ContentAlignment.MiddleCenter;
                            break;
                        case "MiddleLeft":
                            DesignClass.LABEL_TEXT_ALIGN = System.Drawing.ContentAlignment.MiddleLeft;
                            break;
                        case "MiddleRight":
                            DesignClass.LABEL_TEXT_ALIGN = System.Drawing.ContentAlignment.MiddleRight;
                            break;
                        case "TopCenter":
                            DesignClass.LABEL_TEXT_ALIGN = System.Drawing.ContentAlignment.TopCenter;
                            break;
                        case "TopLeft":
                            DesignClass.LABEL_TEXT_ALIGN = System.Drawing.ContentAlignment.TopLeft;
                            break;
                        case "TopRight":
                            DesignClass.LABEL_TEXT_ALIGN = System.Drawing.ContentAlignment.TopRight;
                            break;
                        default:
                            DesignClass.LABEL_AUTO_SIZE = true;
                            break;
                    }
                }
            }

            if (DesignClass.NAME_FONT_OF_LABEL != null && DesignClass.SIZE_FONT_OF_LABEL != 0)
            {
                DesignClass.FONT_OF_LABEL = new Font(DesignClass.NAME_FONT_OF_LABEL, DesignClass.SIZE_FONT_OF_LABEL);
            }
        }       
        
        #endregion

        private void дизайнФормыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String FormName = ((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl.FindForm().Name;
            FormUniqueForm ftd = new FormUniqueForm(FormName);
            ftd.ShowDialog();
        }

        private void ggToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Panel pb = (Panel)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            PanelUniqueForm form = new PanelUniqueForm(pb);
            form.ShowDialog();
            pb = form.panel;

            PanelUniqueForm.UpdatePanelDesignInDb(pb);
        }

        private void changeUniqueBtnMenuItem_Click(object sender, EventArgs e)
        {
            Button pb = (Button)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            ButtonUniqueForm f = new ButtonUniqueForm(pb);
            f.ShowDialog();
            pb = f.newButton;
            if (!f.ReturnToDefault)
            {
                ButtonUniqueForm.UpdateButtonDesignInDb(pb);
            }
            
            pic(this);
        }

        private void сохранитьДефолтныйДизайнToolStripMenuItem_Click(object sender, EventArgs e)
        {
            typeSerialize();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int size = Convert.ToInt32(textBox2.Text);
            if (size >= 452)
            {
                this.MaximumSize = new Size(size, size);
            }
            else MessageBox.Show("Такое значение нельзя, похоронишь форму");           
        }

        private void MainForm_MaximumSizeChanged(object sender, EventArgs e)
        {
            button5_Click(sender, e);
            pic(this);
        }

        private void FormDefaultLabel_Click(object sender, EventArgs e)
        {
            FormDefaultLabel form = new FormDefaultLabel();
            form.ShowDialog();
        }

        private void changeLabelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Label pb = (Label)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            LabelUniqueForm f = new LabelUniqueForm(pb);
            f.ShowDialog();
            pb = f.newLabel;
            LabelUniqueForm.UpdateLabelDesignInDb(pb);

            pic(this);
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void sgdfgdgToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void LabelContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}