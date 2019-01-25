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

namespace WindowsFormsApplication1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
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
                c.ContextMenuStrip = DesignClass.BUTTONS_VISIBILITY_MENU;
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
                    if (DesignClass.PANEL_TRANSPARENCY)
                    {
                        ((Panel)ctr).BackColor = Color.Transparent;
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
            ButtonDesignForm form = new ButtonDesignForm();
            form.ShowDialog();

            pic(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DesignClass.PICTURE_SAVE_MENU = PictureBoxContextMenuStrip;
            DesignClass.BUTTONS_VISIBILITY_MENU = visibilityContextMenuStrip;
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
            PanelForm f = new PanelForm();
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

        string panda = "/9j/4AAQSkZJRgABAQEAyADIAAD/2wBDAAQDAwQDAwQEBAQFB"; 
        string svet = "/9j/4AAQSkZJRgABAQEAAAAAAAD/4QCqRXhpZgAATU0AKgAAA";
        string gun = "/9j/4AAQSkZJRgABAQEAAAAAAAD/4QDGRXhpZgAATU0AKgAAAAgABAEOAAIAAAA";

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
            }

            return imgName;
        }

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
                    #region Поиск картинок
                    var bytes = ImageToByteArray(ctr.BackgroundImage);
                    if (bytes != null)
                    {
                        string base64string = Convert.ToBase64String(bytes);
                        if (base64string.StartsWith(panda))
                        {
                            button.Add("Image", "panda");
                        }
                        else if (base64string.StartsWith(svet))
                        {
                            button.Add("Image", "svet");
                        }
                        else
                        {
                            button.Add("Image", "gun");
                        }
                    }
                    #endregion
                    button.Add("Name", ctr.Name);
                    button.Add("ImageLayout", ctr.BackgroundImageLayout.ToString());
                    button.Add("Type", "Button");
                    button.Add("Color", ctr.ForeColor.Name);
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
            Form1 f = new Form1(((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl.FindForm());
            f.ShowDialog();
        }
    }
}
