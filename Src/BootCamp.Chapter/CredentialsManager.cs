using System;
using System.IO;
using System.Text.RegularExpressions;

namespace BootCamp.Chapter
{
    public class CredentialsManager
    {
        private readonly string _credentialsFile;

        public CredentialsManager(string credentialsFile)
        {
            if (String.IsNullOrEmpty(credentialsFile)) { throw new ArgumentException("File path can't be empty or null."); }
            _credentialsFile = credentialsFile;
        }

        // TODO: load credentials and check for equality.
        public bool Login(Credentials credentials)
        {
            string[] lines = File.ReadAllLines(_credentialsFile);
            if (lines.Length == 0) { return false; }
            string inputUsername = credentials.Username;
            string inputPassword = credentials.Password;
            foreach (string line in lines)
            {
                string[] UserPass = line.Split(',');
                if (UserPass[0] == inputUsername)
                {
                    if (UserPass[1] == inputPassword) { return true; }
                }
            }
            return false;
        }

        // TODO: store credentials in credentials file.
        public void Register(Credentials credentials)
        {
            string line = Credentials.ToString(credentials);
            string[] lines = File.ReadAllLines(_credentialsFile);
            if (lines.Length == 0)
            {
                File.AppendAllText(_credentialsFile, line);
            }
            else
            {
                File.AppendAllText(_credentialsFile, Environment.NewLine + line);
            }
        }

        public void RegistrationProcess()
        {
            string validUserName = UserNameValidation();
            string validPassword = PasswordValidation();
            bool isCredentials = Credentials.TryParse($"{validUserName},{validPassword}", out Credentials credentials);
            if (isCredentials)
            {
                Register(credentials);
                Console.WriteLine("Registration was successful.");
            }
        }

        private string UserNameValidation()
        {
            Console.WriteLine("Enter user name.");
            Console.WriteLine("User name can only contain letters, numbers or characters \".$@_\".");
            bool isValidUserName = TryParseUserName(Console.ReadLine(), out var userName);
            if (isValidUserName)
            {
                Console.WriteLine("Username accepted.");
                return userName;
            }
            else
            {
                Console.WriteLine("Entered user name is invalid.");
                return UserNameValidation();
            }
        }
        private bool TryParseUserName(string input, out string userName)
        {
            userName = default;
            Regex r = new Regex("[^a-zA-Z0-9.$@_]$");
            if (r.IsMatch(input) || String.IsNullOrEmpty(input))
            {
                // validation failed
                return false;
            }
            else
            {
                userName = input;
                return true;
            }
        }
        private string PasswordValidation()
        {
            Console.WriteLine("Enter password:");
            string password = ReadPassword();
            Console.WriteLine("Confirm password:");
            string confirmPassword = ReadPassword();
            if (password == confirmPassword)
            {
                Console.WriteLine("Password accepted.");
                return password;
            }
            else
            {
                Console.WriteLine($"Password doesn't match.");
                return PasswordValidation();
            }
        }

        public void LoginOrRegister()
        {
            Console.WriteLine("Do you have an acount?");
            Console.WriteLine("Enter \"Y\" to log in or \"N\" to register.");
            string option = Console.ReadLine();
            if (option == "Y")
            {
                //login
                LogInProcess();
            }
            else if (option == "N")
            {
                //register
                RegistrationProcess();
            }
            else
            {
                Console.WriteLine("Invalid input.");
                LoginOrRegister();
            }

        }

        private void LogInProcess()
        {
            Console.WriteLine("Enter your username:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter your password:");
            string password = ReadPassword();
            Credentials credentials = new Credentials(username, password);
            bool isLoggedIn = Login(credentials);
            if (isLoggedIn)
            {
                Console.WriteLine("Log in successful");
            }
            else
            {
                Console.WriteLine("Wrong username or password.");
                LogInProcess();
            }
        }

        private static string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key != ConsoleKey.Backspace)
                {
                    Console.Write("*");
                    password += info.KeyChar;
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(password))
                    {
                        // remove one character from the list of password characters
                        password = password.Substring(0, password.Length - 1);
                        // get the location of the cursor
                        int pos = Console.CursorLeft;
                        // move the cursor to the left by one character
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                        // replace it with space
                        Console.Write(" ");
                        // move the cursor to the left by one character again
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                    }
                }
                info = Console.ReadKey(true);
            }
            // add a new line because user pressed enter at the end of their password
            Console.WriteLine();
            return password;
        }
    }
}

