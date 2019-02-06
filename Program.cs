using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Tables.read();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SQLClass.OpenConnection();
            Application.Run(new MainForm());
            SQLClass.CloseConnection();

        }
    }
}
