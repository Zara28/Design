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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            pic(this);
        }

        public static void pic ( Control c)
        {
            //Фон формы FIXME!!!
            if (c.GetType().ToString().Contains("WindowsFormsApplication1"))
            {
                c.BackgroundImage = DesignClass.FORM_BACKGROUND_IMG;
                c.Cursor = DesignClass.FORM_CURSOR;
            }

            //Дизайн кнопок
            foreach (Control ctr in c.Controls)
            {
                if (ctr.GetType().ToString() == "System.Windows.Forms.Button")
                {
                    ((Button)ctr).BackgroundImage = DesignClass.BUTTON_BACKGROUND_IMG;
                    ((Button)ctr).BackgroundImageLayout = ImageLayout.Stretch;
                    ((Button)ctr).ForeColor = DesignClass.BUTTON_TEXT_COLOR;
                }
                else if (ctr.GetType().ToString() == "System.Windows.Forms.Label")
                {
                    ((Label)ctr).BackColor = Color.Transparent;
                    ((Label)ctr).ForeColor = DesignClass.LABEL_TEXT_COLOR;
                }
                else if (ctr.GetType().ToString() == "System.Windows.Forms.PictureBox")
                {
                    ctr.ContextMenuStrip = DesignClass.StripSave;
                }
                else if (ctr.GetType().ToString() == "System.Windows.Forms.Panel")
                {
                    try
                    {
                        ((Panel)ctr).BackgroundImage = DesignClass.PANEL_BACKGROUND_IMG;
                        ((Panel)ctr).BackColor = DesignClass.PANEL_COLOR;
                        if (DesignClass.PANEL_TRANSPARENCY)
                        {
                            ((Panel)ctr).BackColor = Color.Transparent;
                        }
                    }
                    catch (Exception)
                    {
                        
                    }                   
                }

                pic(ctr);
            }
        }
    

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
            DesignClass.StripSave = PictureBoxContextMenuStrip1;

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

        public static void picSave(Control c)
        {
            //Дизайн кнопок
            foreach (Control ctr in c.Controls)
            {
                if (ctr.GetType().ToString() == "System.Windows.Forms.PictureBox")
                {

                    c.ContextMenuStrip = DesignClass.StripSave;
                }


                picSave(ctr);
            }
        }
        
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
            
            pb.BackgroundImage.Save("../../SavedPictures/Scr" + Convert.ToString(DesignClass.PictureSaveIndex) + ".jpg");
            DesignClass.PictureSaveIndex++;
            
        }

        public void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
