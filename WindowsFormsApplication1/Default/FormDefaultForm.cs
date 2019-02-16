using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace WindowsFormsApplication1
{
    public partial class FormDefaultForm : Form
    {
       public string[] cury =Assembly.GetExecutingAssembly().GetManifestResourceNames();
     
        public FormDefaultForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Load(textBox1.Text);
            }
            catch (Exception)
            {
                pictureBox1.Load("https://memepedia.ru/wp-content/uploads/2017/04/%D0%B5%D0%B1%D0%B0%D1%82%D1%8C-%D1%82%D1%8B-%D0%BB%D0%BE%D1%85-%D0%BE%D1%80%D0%B8%D0%B3%D0%B8%D0%BD%D0%B0%D0%BB.jpg");
            }

            DesignClass.FORM_BACKGROUND_IMG = pictureBox1.Image;
        }

        private void FormDesignForm_Load(object sender, EventArgs e)
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
            CursorComboBox.Items.AddRange(cury);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.ShowDialog();

            DesignClass.LABEL_TEXT_COLOR = MyDialog.Color;
            MainForm.pic(this);
        }

        private void CursorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {            
          
            DesignClass.FORM_CURSOR = (Cursor)CursorComboBox.SelectedItem;
             
          /*  if (CursorComboBox.SelectedIndex == 0)
            {
                DesignClass.FORM_CURSOR = Cursors.Cross;
            }
            else if (CursorComboBox.SelectedIndex == 1)
            {
                DesignClass.FORM_CURSOR = Cursors.Help;
            }
            else if (CursorComboBox.SelectedIndex == 2)
            {
                DesignClass.FORM_CURSOR = Cursors.No;
            }
            else if (CursorComboBox.SelectedIndex == 3)
            {
                DesignClass.FORM_CURSOR = Cursors.NoMoveVert;
            }
            else if (CursorComboBox.SelectedIndex == 4)
            {
                DesignClass.FORM_CURSOR = Cursors.SizeNWSE;
            }
            else if (CursorComboBox.SelectedIndex == 5)
            {
                DesignClass.FORM_CURSOR = Cursors.VSplit;
            }
            else if (CursorComboBox.SelectedIndex == 6)
            {
                DesignClass.FORM_CURSOR = Cursors.WaitCursor;
            }*/

            MainForm.pic(this);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (sender.Equals(button7))
            {
                this.BackgroundImageLayout = ImageLayout.Tile;
            }
            else if (sender.Equals(button3))
            {
                this.BackgroundImageLayout = ImageLayout.Zoom;
            }
            else if (sender.Equals(button4))
            {
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else if (sender.Equals(button5))
            {
                this.BackgroundImageLayout = ImageLayout.Center;
            }
            else if (sender.Equals(button6))
            {
                this.BackgroundImageLayout = ImageLayout.None;
            }

            this.BackgroundImage = pictureBox1.Image;
        }

        private void color_form_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.ShowDialog();
            DesignClass.FORM_COLOR = MyDialog.Color;
            this.BackColor = DesignClass.FORM_COLOR;
        }
    }
}
