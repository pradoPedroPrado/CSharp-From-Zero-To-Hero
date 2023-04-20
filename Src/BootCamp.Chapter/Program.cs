using System;

namespace BootCamp.Chapter
{
    class Program
    {
        //static CredentialsManager manager = new CredentialsManager("C:\\Users\\Pedro Win\\Documents\\Repos\\CSharp-From-Zero-To-Hero\\Src\\BootCamp.Chapter\\Credentials.txt");

        static void Main(string[] args)
        {
            CredentialsManager manager = new CredentialsManager("C:\\Users\\Pedro Win\\Documents\\Repos\\CSharp-From-Zero-To-Hero\\Src\\BootCamp.Chapter\\Credentials.txt");

            manager.LoginOrRegister();

        }

    }
}
