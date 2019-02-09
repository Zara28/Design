using System;
using System.IO;

namespace WindowsFormsApplication1
{
    class Tables
    {
        public static String Default;
        public static String Unique;

        public static void read()
        {            
            FileStream file2 = new FileStream("tables.txt", FileMode.Open);
            StreamReader reader = new StreamReader(file2); // создаем «потоковый читатель» и связываем его с файловым потоком

            while (reader.Peek() >= 0)
            {
                string stroka_iz_faila = reader.ReadLine().Trim();
                if (stroka_iz_faila.Length > "Default".Length && stroka_iz_faila.Substring(0, "Default".Length) == "Default")
                {
                    Default = stroka_iz_faila.Substring("Default = ".Length);
                }
                if (stroka_iz_faila.Length > "Unique".Length && stroka_iz_faila.Substring(0, "Unique".Length) == "Unique")
                {
                    Unique = stroka_iz_faila.Substring("Unique = ".Length);
                }                
            }

            reader.Close();
        }
    }
}
