using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

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
        
        /// <summary>
        /// Вернутся к дефалту, меняется при нажатии кнопки
        /// </summary>
        public bool ReturnToDefault = false;

        public ButtonUniqueForm(Button buttonToEdit)
        {
            InitializeComponent();

            ButtonName = buttonToEdit.Name;
            FormName = buttonToEdit.FindForm().Name;
            newButton = buttonToEdit;
            colorDialog1.Color = buttonToEdit.BackColor;
            textBox1.Text = newButton.Text;
        }

        /// <summary>
        /// Преобразует цвет в формате Color в JSON строку
        /// </summary>
        /// <param name="col">Цвет</param>
        /// <returns>JSON строка цвета</returns>
        public static string ColorToJSON(Color col)
        {
            return JsonConvert.SerializeObject(new List<int> { col.A, col.R, col.G, col.B }).ToString();
        }

        /// <summary>
        /// Удаление дизайна конкретной кнопки из БД (возврат в дефолтное состояние)
        /// </summary>
        public static void DeleteUniqueButton(Control pb, String formName, String buttonName)
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
                "'Color = " + ColorToJSON(pb.BackColor) + 
                    ", Visible = " + pb.Visible +
                    ", BackgroundImage = " + pb.BackgroundImage +
                    ", Text = " + pb.Text +
                    ", Dock = " + pb.Dock.ToString() +
                "', 'admin', '" + pb.Name + "', '" + pb.FindForm().Name + "')");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            newButton.Text = textBox1.Text;
            Close();
        }

        /// <summary>
        /// Показываем Color Dialog
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            colorDialog1.SolidColorOnly = false;
            colorDialog1.ShowDialog();
            newButton.BackColor = colorDialog1.Color;
            ReturnToDefault = false;
        }

        private void ButtonUniqueForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Кнопка "Возврат к дизайну по умолчанию"
        /// </summary>
        private void button3_Click(object sender, EventArgs e)
        {
            DeleteUniqueButton(newButton, FormName, ButtonName);
            ReturnToDefault = true;
        }
    }
}