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
    /// Смена дизайна конкретной кнопки
    /// </summary>
    public partial class ButtonUniqueForm : Form
    {
        public Button newButton;

        public ButtonUniqueForm(Button buttonToEdit)
        {
            newButton = buttonToEdit;
            InitializeComponent();

            textBox1.Text = newButton.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            newButton.BackColor = colorDialog1.Color;
            newButton.Text = textBox1.Text;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
        }

        private void ButtonUniqueForm_Load(object sender, EventArgs e)
        {
        }
    }
}
