﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    
    public partial class FormDesignForm : Form
    {
        public List<Cursors> curs = new List<Cursors>();
        public List<FileInfo> f = new List<FileInfo>();
        public FormDesignForm()
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

           
            
            
           
            //Cursor cur;
            //CursorComboBox.Items.Add(cur);
            if (CursorComboBox.SelectedIndex == 0)
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
            }
        }
    }
}
