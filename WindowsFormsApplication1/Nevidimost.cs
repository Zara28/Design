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
    /// <summary>
    /// Видимость кнопок с формы
    /// </summary>
    public partial class Nevidimost : Form
    {
        public Control CC;
        public Nevidimost(Control C)
        {
            CC = C;
            InitializeComponent();

            checkedListBox1.Items.Clear();
            AddButtonsToCombo(C);
        }

        void AddButtonsToCombo(Control C)
        {
            foreach (Control ctr in C.Controls)
            {
                if (ctr.GetType().ToString() == "System.Windows.Forms.Button")
                {
                    checkedListBox1.Items.Add(ctr.Text+" ("+ctr.Name+")", !ctr.Visible);
                }

                AddButtonsToCombo(ctr);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void invisibility(Control CR, int Index)
        {
            foreach (Control ctr in CR.Controls)
            {
                if (ctr.GetType().ToString() == "System.Windows.Forms.Button")
                {
                    if (ctr.Text + " (" + ctr.Name + ")" == checkedListBox1.Items[Index].ToString())
                    {
                        ctr.Visible = !ctr.Visible;
                    }
                }

                invisibility(ctr, Index);
            }
        }
        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            invisibility(CC, e.Index);
        }
    }
}
