using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class DesignClass
    {
        #region Формы

        /// <summary>
        /// Фоновая картинка формы
        /// </summary>
        public static Image FORM_BACKGROUND_IMG;

        #endregion

        #region Кнопки

        /// <summary>
        /// Фоновая картинка кнопки
        /// </summary>
        public static Image BUTTON_BACKGROUND_IMG;
        /// <summary>
        /// Цвет текста кнопки
        /// </summary>
        public static Color BUTTON_TEXT_COLOR;

        #endregion

        #region etc

        /// <summary>
        /// Расстояние между картинками
        /// </summary>
        public static int LENGTH;

        public static Color LABEL_TEXT_COLOR;

        #endregion

        #region Панели
        /// <summary>
        /// Цвет панели
        /// </summary>
        public static Color PANEL_COLOR;
        /// <summary>
        /// Картинка панели
        /// </summary>
        public static Image PANEL_BACKGROUND_IMG;
        /// <summary>
        /// Прозрачность панели
        /// </summary>
        public static bool PANEL_TRANSPARENCY;
        #endregion


    }
}
