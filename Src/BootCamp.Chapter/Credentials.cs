using System;
using System.Text;

namespace BootCamp.Chapter
{
    // TODO: make a struct and add validation and other needed methods (if needed)
    public readonly struct Credentials
    {
        public readonly string Username;
        public readonly string Password;

        public Credentials(string username, string password)
        {
            if (String.IsNullOrEmpty(username)) { throw new ArgumentException("username can't be null or empty."); }
            Username = username;
            Password = EncodePassword(password);
        }

        // TODO: Implement properly.
        public static bool TryParse(string input, out Credentials credentials)
        {
            if (String.IsNullOrEmpty(input))
            {
                credentials = default;
                return false;
            }
            string[] credentialsArr = input.Split(',');
            if (credentialsArr.Length != 2)
            {
                credentials = default;
                return false;
            }
            credentials = new Credentials(credentialsArr[0], credentialsArr[1]);
            return true;
        }

        public static string ToString(Credentials credentials) => $"{credentials.Username},{credentials.Password}";

        private static string EncodePassword(string input)
        {
            byte[] strArr = Encoding.Unicode.GetBytes(input);
            return String.Join(" ", strArr);
        }

    }
}
