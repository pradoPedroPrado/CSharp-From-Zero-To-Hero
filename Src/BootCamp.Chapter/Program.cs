namespace BootCamp.Chapter
{
    class Program
    {
        static void Main(string[] args)
        {
            CredentialsManager manager = new CredentialsManager("C:\\Users\\Pedro Win\\Documents\\Repos\\CSharp-From-Zero-To-Hero\\Src\\BootCamp.Chapter\\Credentials.txt");

            manager.LoginOrRegister();
        }
    }
}
