using System;
using System.IO;

namespace _03WritingTextToFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Кирилица";
            FileStream stream = null;

            try
            {
                stream = new FileStream("log.txt", FileMode.Create);
                var bytes = System.Text.Encoding.UTF8.GetBytes(text);
                stream.Write(bytes, 0, bytes.Length);
            }
            finally
            {
                stream.Close();
            }
        }
    }
}
