using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class ButtonDefaultForm : Form
    {
        public ButtonDefaultForm()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Чтение дефолтного дизайна Button
        /// </summary>
        public static void ReadButtonDefault()
        {
            List<String> Auths = SQLClass.Select("SELECT design FROM " + Tables.Default + " WHERE type = 'Button'");
            if (Auths.Count == 0)
            {
                return;
            }

            String[] words = Auths[0].Split(new char[] { ':', ',', ' ', '\"' }, StringSplitOptions.RemoveEmptyEntries);

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

                if (words[index] == "FlatStyle")
                {
                    if (words[index + 1] == "Popup")
                    {
                        DesignClass.FLAT_OF_BUTTON = FlatStyle.Popup;
                    }
                    else if (words[index + 1] == "System")
                    {
                        DesignClass.FLAT_OF_BUTTON = FlatStyle.System;
                    }
                    else if (words[index + 1] == "Standard")
                    {
                        DesignClass.FLAT_OF_BUTTON = FlatStyle.Popup;
                    }
                    else if (words[index + 1] == "Flat")
                    {
                        DesignClass.FLAT_OF_BUTTON = FlatStyle.System;
                    }
                }
                
                if (words[index].Trim() == "ImageAlign")
                {
                    //DesignClass.BUTTONIMAGE_ALLINE = (ContentAlignment)(words[index + 1]);
                    if (words[index + 1] == "TopLeft")
                    {
                        DesignClass.BUTTONIMAGE_ALLINE = ContentAlignment.TopLeft;
                    }
                    else if (words[index + 1] == "TopCenter")
                    {
                        DesignClass.BUTTONIMAGE_ALLINE = ContentAlignment.TopCenter;
                    }
                    else if (words[index + 1] == "TopRight")
                    {
                        DesignClass.BUTTONIMAGE_ALLINE = ContentAlignment.TopRight;
                    }
                    else if (words[index + 1] == "MiddleLeft")
                    {
                        DesignClass.BUTTONIMAGE_ALLINE = ContentAlignment.MiddleLeft;
                    }
                    else if (words[index + 1] == "MiddleCenter")
                    {
                        DesignClass.BUTTONIMAGE_ALLINE = ContentAlignment.MiddleCenter;
                    }
                    else if (words[index + 1] == "MiddleRight")
                    {
                        DesignClass.BUTTONIMAGE_ALLINE = ContentAlignment.MiddleRight;
                    }
                    else if (words[index + 1] == "BottomLeft")
                    {
                        DesignClass.BUTTONIMAGE_ALLINE = ContentAlignment.BottomLeft;
                    }
                    else if (words[index + 1] == "BottomCenter")
                    {
                        DesignClass.BUTTONIMAGE_ALLINE = ContentAlignment.BottomCenter;
                    }
                    else if (words[index + 1] == "BottomRight")
                    {
                        DesignClass.BUTTONIMAGE_ALLINE = ContentAlignment.BottomRight;
                    }
                }                
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            MainForm.pic(this);
            if (FormUniqueForm.ASSA)
            {
                this.BackColor = Color.FromArgb(123, 234, 121);
                this.TransparencyKey = Color.FromArgb(123, 234, 121);
            }
            else
            {
                this.BackColor = new Color();
                this.TransparencyKey = new Color();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.ShowDialog();

            this.ForeColor = MyDialog.Color;
            DesignClass.BUTTON_TEXT_COLOR = MyDialog.Color;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PicForm form = new PicForm();
            form.ShowDialog();

            Size pic1Size = new Size(pictureBox1.Size.Width, 0);
            Size pic2Size = new Size(pictureBox2.Size.Width, 0);
            Size s1 = new System.Drawing.Size(DesignClass.LENGTH, 0);
            pictureBox2.Location = pictureBox1.Location + pic1Size + s1;
            pictureBox3.Location = pictureBox2.Location + pic2Size + s1;
            MainForm.pic(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox4.Load(textBox1.Text);
            }
            catch (Exception)
            {
                this.BackColor = new Color();
                this.TransparencyKey = new Color();
                pictureBox4.Image = pictureBox1.Image;
            }

            DesignClass.BUTTON_BACKGROUND_IMG = pictureBox4.Image;
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DesignClass.BUTTON_BACKGROUND_IMG = ((PictureBox)sender).BackgroundImage;
            this.Close();
           // DesignClass.BUTTON_BACKGROUND_IMG_ADRESS = ((PictureBox)sender).Tag.ToString();
          
            MainForm.pic(this);
        }


        private void buttonFont_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {   
                if (fontDialog1.Font.Size > 5 && fontDialog1.Font.Size < 38)
                {
                    DesignClass.BUTTON_FONT = fontDialog1.Font;
                    MainForm.pic(this);
                }
            }
        }

        /// <summary>
        /// Цвет кнопок деолтный
        /// </summary>
        private void buttonColor_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.Color = DesignClass.BUTTON_COLOR;
            MyDialog.ShowDialog();

            DesignClass.BUTTON_COLOR = MyDialog.Color;
            MainForm.pic(this);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if(comboBoxPicAlign.SelectedIndex == 0)
            {
                DesignClass.BUTTONIMAGE_ALLINE = System.Drawing.ContentAlignment.TopLeft;
            }
            else if (comboBoxPicAlign.SelectedIndex == 1)
            {
                DesignClass.BUTTONIMAGE_ALLINE = System.Drawing.ContentAlignment.TopCenter;
            }
            else if (comboBoxPicAlign.SelectedIndex == 2)
            {
                DesignClass.BUTTONIMAGE_ALLINE = System.Drawing.ContentAlignment.TopRight;
            }
            else if (comboBoxPicAlign.SelectedIndex == 3)
            {
                DesignClass.BUTTONIMAGE_ALLINE = System.Drawing.ContentAlignment.MiddleLeft;
            }
            else if (comboBoxPicAlign.SelectedIndex == 4)
            {
                DesignClass.BUTTONIMAGE_ALLINE = System.Drawing.ContentAlignment.MiddleCenter;
            }
            else if (comboBoxPicAlign.SelectedIndex == 5)
            {
                DesignClass.BUTTONIMAGE_ALLINE = System.Drawing.ContentAlignment.MiddleRight;
            }
            else if (comboBoxPicAlign.SelectedIndex == 6)
            {
                DesignClass.BUTTONIMAGE_ALLINE = System.Drawing.ContentAlignment.BottomLeft;
            }
            else if (comboBoxPicAlign.SelectedIndex == 7)
            {
                DesignClass.BUTTONIMAGE_ALLINE = System.Drawing.ContentAlignment.BottomCenter;
            }
            else if (comboBoxPicAlign.SelectedIndex == 8)
            {
                DesignClass.BUTTONIMAGE_ALLINE = System.Drawing.ContentAlignment.BottomRight;
            }


            MainForm.pic(this);
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void flatStyleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (flatStyleComboBox.Text)
            {
                case "System":
                    DesignClass.FLAT_OF_BUTTON = FlatStyle.System;
                    break;

                case "Standard":
                    DesignClass.FLAT_OF_BUTTON = FlatStyle.Standard;
                    break;

                case "Popup":
                     DesignClass.FLAT_OF_BUTTON = FlatStyle.Popup;
                    break;

                case "Flat":
                      DesignClass.FLAT_OF_BUTTON = FlatStyle.Flat;
                    break;
            }
            MainForm.pic(this);
               
        }
    }
}