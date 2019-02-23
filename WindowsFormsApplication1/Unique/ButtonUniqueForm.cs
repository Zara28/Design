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
        public static void UpdateButtonDesignInDb(Button pb)
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
                    ", FlatStyle = " + pb.FlatStyle +
                "', 'admin', '" + pb.Name + "', '" + pb.FindForm().Name + "')");
        }

        /// <summary>
        /// Получение уникального дизайна кнопки из базы данных
        /// </summary>
        /// <param name="name">Имя кнопки</param>
        /// <param name="words">Массив слов (что-то связанное с JSON)</param>
        /// <returns>
        /// Новая кнопка со свойствами уникальной кнопки с названием <paramref name="name"/> из базы
        /// Её НЕЛЬЗЯ использовать как <code>ctr = GetUniqueDesignFromDB(...)</code>
        /// Нужно по отдельности задавать её свойства вашей кнопке.
        /// </returns>
        public static Button GetUniqueDesignFromDB(string name)
        {
            Button temp = new Button();
            string temp_design = "";
            try
            {
                temp_design = SQLClass.Select(string.Format("SELECT design FROM `{1}` WHERE `name`='{0}'", name, Tables.Unique))[0];
            } catch (ArgumentOutOfRangeException)
            {
                return new Button();
            }
            string[] words = temp_design.Split(new string[] { ":", ",", " = ", "=", "[", "]" }, StringSplitOptions.RemoveEmptyEntries);

            var FontName = "";
            var FontSize = 0;

            #region Код декодировки temp_design
            for (int i = 0; i < words.Length; i++)
            {
                #region Задаём цвет
                if (words[i].Trim() == "Color")
                {
                    try
                    {
                        temp.BackColor = Color.FromArgb(
                            Convert.ToInt32(words[i + 1]),
                            Convert.ToInt32(words[i + 2]),
                            Convert.ToInt32(words[i + 3]), Convert.ToInt32(words[i + 4]));
                    }
                    catch (Exception)
                    {
                        foreach (String colorName in Enum.GetNames(typeof(KnownColor)))
                        {
                            String colorFromDB = words[i + 1].Trim();
                            if (colorFromDB.StartsWith("Color"))
                            {
                                colorFromDB = colorFromDB.Replace("Color [", "").Replace("]", "");
                            }
                    
                            if (colorName == colorFromDB)
                            {
                                Color knownColor = Color.FromKnownColor((KnownColor) Enum.Parse(typeof(KnownColor), colorName));
                                temp.BackColor = knownColor;
                            }
                        }
                    }
                }

                if (words[i].Trim() == "ForeColor")
                {
                    try
                    {
                        temp.ForeColor = Color.FromArgb(
                            Convert.ToInt32(words[i + 1]),
                            Convert.ToInt32(words[i + 2]),
                            Convert.ToInt32(words[i + 3]), Convert.ToInt32(words[i + 4]));
                    }
                    catch (Exception)
                    {
                        foreach (String colorName in Enum.GetNames(typeof(KnownColor)))
                        {
                            String colorFromDB = words[i + 1].Trim();
                            if (colorFromDB.StartsWith("Color"))
                            {
                                colorFromDB = colorFromDB.Replace("Color [", "").Replace("]", "");
                            }

                            if (colorName == colorFromDB)
                            {
                                Color knownColor = Color.FromKnownColor((KnownColor) Enum.Parse(typeof(KnownColor), colorName));
                                temp.ForeColor = knownColor;
                            }
                        }
                    }
                }
                #endregion

                #region Задаём видимость
                if (words[i].Trim() == "Visible")
                {
                    temp.Visible = (words[i + 1] == "True");
                }
                #endregion

                #region Задаём шрифт
                if (words[i].Trim() == "FontName")
                {
                    FontName = words[i + 1];
                }
                #endregion

                #region Задаём размер шрифта
                if (words[i].Trim() == "FontSize")
                {
                    FontSize = (int) (Convert.ToDecimal(words[i + 1]));
                }
                #endregion

                #region Задаем стиль кнопки
                if (words[i].Trim() == "FlatStyle")
                {
                    if (words[i + 1] == "Popup")
                    {
                        ((Button) temp).FlatStyle = FlatStyle.Popup;
                    }
                    else if (words[i + 1] == "System")
                    {
                        ((Button) temp).FlatStyle = FlatStyle.System;
                    }
                    else if (words[i + 1] == "Standard")
                    {
                        ((Button) temp).FlatStyle = FlatStyle.Standard;
                    }
                    else if (words[i + 1] == "Flat")
                    {
                        ((Button) temp).FlatStyle = FlatStyle.Flat;
                    }
                }
                #endregion
            }

            if (FontName != "" && FontSize > 0)
            {
                temp.Font = new Font(FontName, FontSize);
            }
            #endregion

            return temp;
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "System":
                    newButton.FlatStyle = FlatStyle.System;
                    break;

                case "Standard":
                    newButton.FlatStyle = FlatStyle.Standard;
                    break;

                case "Popup":
                    newButton.FlatStyle = FlatStyle.Popup;
                    break;

                case "Flat":
                    newButton.FlatStyle = FlatStyle.Flat;
                    break;
            }
               
        }
    }
}