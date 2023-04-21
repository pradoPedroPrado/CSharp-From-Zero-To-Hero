using System;
using System.Text;

namespace BootCamp.Chapter
{
    class Program
    {
        //static CredentialsManager manager = new CredentialsManager("C:\\Users\\Pedro Win\\Documents\\Repos\\CSharp-From-Zero-To-Hero\\Src\\BootCamp.Chapter\\Credentials.txt");

        static void Main(string[] args)
        {
            //CredentialsManager manager = new CredentialsManager("C:\\Users\\Pedro Win\\Documents\\Repos\\CSharp-From-Zero-To-Hero\\Src\\BootCamp.Chapter\\Credentials.txt");

            //manager.LoginOrRegister();
            string str = "abc";
            byte[] strArr = Encoding.Unicode.GetBytes(str);
            string strEncoded = String.Join(" ", strArr);
            string[] strArr2 = strEncoded.Split(' ');
            byte[] bytes = new byte[strArr2.Length];
            for (int i = 0; i < strArr2.Length; i++)
            {
                bytes[i] = byte.Parse(strArr2[i]);
            }
            string strDecoded = Encoding.Unicode.GetString(bytes);

            if (strDecoded == str)
            {
                Console.WriteLine("success!");
            }
        }

    }
}
