using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public static class Lox
    {
        public static void colorAll(Control ct)
        {
            foreach (Control ctrl in ct.Controls)
            {
                if (ctrl.GetType().ToString() ==
                    "System.Windows.Forms.Panel")
                {
                    Random rand = new Random();
                    ((Panel)ctrl).Size = new Size(((Panel)ctrl).Size.Width + rand.Next(50, 150), ((Panel)ctrl).Size.Height + rand.Next(50, 150));
                }
                else
                {
                    colorAll(ctrl);
                }
            }
        }
    }
}
