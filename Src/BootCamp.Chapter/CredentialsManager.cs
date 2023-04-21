using System;
using System.Text;
using System.Text.RegularExpressions;

namespace BootCamp.Chapter
{
    public class CredentialsManager
    {
        private readonly string _credentialsFile;

        public CredentialsManager(string credentialsFile)
        {
            _credentialsFile = credentialsFile;
        }

        // TODO: load credentials and check for equality.
        public bool Login(Credentials credentials)
        {
            return false;
        }

        // TODO: store credentials in credentials file.
        public void Register(Credentials credentials)
        {

        }

        public void RegistrationProcess()
        {
            string validUserName = UserNameValidation();
            string validPassword = PasswordValidation();
            bool isCredentials = Credentials.TryParse($"{validUserName},{validPassword}", out Credentials credentials);
            if (isCredentials)
            {
                Register(credentials); 
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
            string password = Console.ReadLine();
            Console.WriteLine("Confirm password:");
            string confirmPassword = Console.ReadLine();
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
    }
}

