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
        public static int nomer_konfig_image;
        public static Color FORM_COLOR;




        #endregion




        #region Панель
        public static Color PANEL_COLOR;
        #endregion

        #region Кнопки

        /// <summary>
        /// Фоновая картинка кнопки
        /// </summary>
        public static Image BUTTON_BACKGROUND_IMG;

        public static String BUTTON_BACKGROUND_IMG_ADRESS;
        /// <summary>
        /// Цвет текста кнопки
        /// </summary>
        public static Color BUTTON_TEXT_COLOR;

        #endregion
        public string buttonn = "BUTTON" + "@@" + BUTTON_TEXT_COLOR.R + "!!!"
                                                 + BUTTON_TEXT_COLOR.G + "!!!"
                                                 + BUTTON_TEXT_COLOR.B + 
                                                 "$$$" +
                                                 BUTTON_BACKGROUND_IMG_ADRESS;
    }
}
