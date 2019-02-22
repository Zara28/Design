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
    public partial class FormUniqueForm : Form
    {
        /// <summary>
        /// Форма, с которой работаем
        /// </summary>
        String FormName;

        /// <summary>
        /// Прозрачность Жукова которая делает все кнопки дырявыми
        /// </summary>
        public static bool ASSA = false;

        public FormUniqueForm(String name)
        {
            InitializeComponent();
            FormName = name;
            //GetFormDesignFromDb(ref this);
            minimizeCheckBox.Checked = this.MinimizeBox;
        }

        /// <summary>
        /// Загрузка дизайна конкретной формы из БД
        /// </summary>
        public static void GetFormDesignFromDb(ref Control c)
        {
            List<String> uniqueDesign = SQLClass.Select("SELECT design FROM " + Tables.Unique + 
                " WHERE FormFrom = '" + c.Name + "' and Type = 'Form'");
            if (uniqueDesign.Count == 0)
            {
                return;
            }
            String[] words = uniqueDesign[0].Split(new string[] { ":", ",", " = ", "=" }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == "MinimizeBox")
                {
                    ((Form)c).MinimizeBox = (words[i + 1] == "True");
                }

                if (words[i] == "Color")
                {
                    foreach (String colorName in Enum.GetNames(typeof(KnownColor)))
                    {
                        String colorFromDB = words[i + 1];
                        if (colorFromDB.Trim().StartsWith("Color"))
                        {
                            colorFromDB = colorFromDB.Trim().Replace("Color [", "").Replace("]", "");
                        }

                        if (colorName == colorFromDB.Trim())
                        {
                            Color knownColor = Color.FromKnownColor((KnownColor)Enum.Parse(typeof(KnownColor), colorName));
                            c.BackColor = knownColor;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Сохранение дизайна формы в БД
        /// </summary>
        public static void UpdateFormDesignInDb(Form f, String fName)
        {
            String icon = "Masons";
            if (f.Icon == Properties.Resources.Face)
            {
                icon = "Face";
            }
            else if (f.Icon == Properties.Resources.Atom)
            {
                icon = "Atom";
            }

            SQLClass.Delete("DELETE FROM " + Tables.Unique + 
                " WHERE FormFrom = '" + fName + "' and type = 'Form'");
            SQLClass.Insert("INSERT INTO " + Tables.Unique + 
                " (type, design, FormFrom, Author, Name)" +
                " VALUES ('Form', " +
                    "'Color: " + Convert.ToString(f.BackColor) + "," +
                    "MaxWidth: " + f.MaximumSize.Width.ToString() + "," +
                    "MaxHeight: " + f.MaximumSize.Height.ToString() + "," +
                    "Icon: " + icon + "," +
                    "MinimizeBox: " + Convert.ToBoolean(f.MinimizeBox) + "'," +
                "'" + fName + "', '', '')");
        }

        private void FormThisDesign_Load(object sender, EventArgs e)
        {
        }

        private void buttonFont_Click(object sender, EventArgs e)
        {
            fo.ShowColor = true;
            fo.ShowDialog();
            this.Font = fo.Font;
            this.ForeColor = fo.Color;
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            cl.ShowDialog();
            this.BackColor = cl.Color;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            UpdateFormDesignInDb(this, FormName);
        }

        private void minimizeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.MinimizeBox = minimizeCheckBox.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Смена макс.ширины
        /// </summary>
        private void widthTextBox_TextChanged(object sender, EventArgs e)
        {
            int width = Convert.ToInt32(widthTextBox.Text);
            if (width < 200)
            {
                width = 200;
            }
            this.MaximumSize = new Size(width, this.Size.Height);
        }

        /// <summary>
        /// Смена макс.высоты
        /// </summary>
        private void heightTextBox_TextChanged(object sender, EventArgs e)
        {
            int height = Convert.ToInt32(heightTextBox.Text);
            if (height < 200)
            {
                height = 200;
            }
            this.MaximumSize = new Size(this.Size.Width, height);
        }

        /// <summary>
        /// Смена иконки
        /// </summary>
        private void iconChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
            { 
                this.Icon = Properties.Resources.Face;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                this.Icon = Properties.Resources.Atom; 
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                this.Icon = Properties.Resources.Masons; 
            }
        }

       
    }
}
