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
        String FormName;
        String ButtonName;
        public bool ReturnToDefault = false;

        public ButtonUniqueForm(Button buttonToEdit)
        {
            ButtonName = buttonToEdit.Name;
            FormName = buttonToEdit.FindForm().Name;
            newButton = buttonToEdit;
            InitializeComponent();

            textBox1.Text = newButton.Text;
        }

        /// <summary>
        /// Удаление дизайна конкретной кнопки из БД (возврат в дефолтное состояние)
        /// </summary>
        public static void delete(Control pb, String formName, String buttonName)
        {
            SQLClass.Delete("DELETE FROM " + Tables.Unique +
              " WHERE type = 'Button'" +
              " AND name = '" + buttonName +
              "' AND FormFrom = '" + formName + "'");
        }

        /// <summary>
        /// Обновление дизайна конкретной кнопки в БД
        /// </summary>
        public static void UpdateButtonDesignInDb(Control pb)
        {
            SQLClass.Delete("DELETE FROM " + Tables.Unique +
                " WHERE type = 'Button'" +
                " AND name = '" + pb.Name +
                "' AND FormFrom = '" + pb.FindForm().Name + "'");
            SQLClass.Insert("INSERT INTO " + Tables.Unique +
                " (type, design, author, name, FormFrom) VALUES " +
                "('Button', " +
                "'Color = " + pb.BackColor +
                    ", Visible = " + pb.Visible +
                    ", BackgroundImage = " + pb.BackgroundImage +
                    ", Text = " + pb.Text +
                "', 'admin', '" + pb.Name + "', '" + pb.FindForm().Name + "')");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            newButton.Text = textBox1.Text;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            newButton.BackColor = colorDialog1.Color;
            ReturnToDefault = false;
        }

        private void ButtonUniqueForm_Load(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            delete(newButton, FormName, ButtonName);
            ReturnToDefault = true;
        }

    }
}