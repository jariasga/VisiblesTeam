using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkaArt.Classes
{
    public class LogHandler
    {
        public static bool Write(string text)
        {
            try
            {
                StreamWriter stream = new StreamWriter("Log.txt", true);
                stream.Write(text);
                stream.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool Write(string text, params object[] parameters)
        {
            try
            {
                StreamWriter stream = new StreamWriter("Log.txt", true);
                stream.Write(text, parameters);
                stream.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool WriteLine()
        {
            try
            {
                StreamWriter stream = new StreamWriter("Log.txt", true);
                stream.WriteLine();
                stream.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public static bool WriteLine(string text)
        {
            try
            {
                StreamWriter stream = new StreamWriter("Log.txt", true);
                stream.WriteLine(text);
                stream.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool WriteLine(string text, params object[] parameters)
        {
            try
            {
                StreamWriter stream = new StreamWriter("Log.txt", true);
                stream.WriteLine(text, parameters);
                stream.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
