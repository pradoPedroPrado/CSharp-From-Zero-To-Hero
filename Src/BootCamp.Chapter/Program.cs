using System;
using System.Text;

namespace BootCamp.Chapter
{
    class Program
    {
        static void Main(string[] args)
        {
            string msg = "abc";
            string msgEncrypted = Encrypt(msg, 1);
            string msgDecrypted = Decrypt(msgEncrypted, 1);

            Console.WriteLine(msgEncrypted);
            Console.WriteLine(msgDecrypted);
        }

        public static string Encrypt(string message, byte shift)
        {
            if (message == null) return null;
            byte[] charNumbers = Encoding.ASCII.GetBytes(message);

            for (int i = 0; i < charNumbers.Length; i++)
            {
                int n = (int)charNumbers[i] % 256 + shift;
                charNumbers[i] = (byte)n;
            }
            var charsEncrypted = Encoding.ASCII.GetChars(charNumbers);
            string messageEncrypted = new string(charsEncrypted);
            return messageEncrypted;
        }

        public static string Decrypt(string message, byte shift) 
        {
            if (message == null) return null;
            byte[] charNumbers = Encoding.ASCII.GetBytes(message);

            for (int i = 0; i < charNumbers.Length; i++)
            {
                int n = (int)charNumbers[i] % 256 - shift;
                charNumbers[i] = (byte)n;
            }
            var charsDecrypted = Encoding.ASCII.GetChars(charNumbers);
            string messageDecrypted = new string(charsDecrypted);
            return messageDecrypted;
        }

    }
}
