using System;
using System.Text;
using System.Text.RegularExpressions;

namespace BootCamp.Chapter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine(ArrowMovement.GetIndicator('a'));

        }

        public static string DecimalToBinary(long number)
        {

            long[] digits = new long[1];
            long rest = number % 2;
            digits[0] = rest;
            while (number > 1)
            {
                number /= 2;
                rest = number % 2;
                long[] temp = new long[digits.Length + 1];
                for (long i = 1; i < temp.Length; i++)
                {
                    temp[i] = digits[i - 1];
                }
                temp[0] = rest;
                digits = temp;
            }

            string binary = "";
            foreach (var item in digits)
            {
                binary += item.ToString();
            }
            return binary;

            //return Convert.ToString(number, 2); //could do this but I wanted to think a bit
        }
        public static long BinaryToDecimal(string binary)
        {
            if (String.IsNullOrEmpty(binary))
            {
                return 0;
            }
            if (binary == "0" || binary == "1")
            {
                return long.Parse(binary);
            }
            Regex r = new Regex("[^0-1]$");
            if (r.IsMatch(binary))
            {
                throw new InvalidBinaryNumberException(binary);
            }
            char[] chars = binary.ToCharArray();
            long decimalNumber = 0;
            for (int i = 0; i < chars.Length; i++)
            {
                long n = long.Parse(chars[i].ToString());
                n *= (long)Math.Pow(2, chars.Length - i - 1);
                decimalNumber += n;
            }
            return decimalNumber;
        }
        public static char GetArrows(char character)
        {
            
            char arrow;
            if (character == 'a' || character == 'A')
            {
                arrow = '\u21a4';
            }
            else if (character == 'w' || character == 'W')
            {
                arrow = '\u21a5';
            }
            else if (character == 'd' || character == 'D')
            {
                arrow = '\u21a6';
            }
            else if (character == 's' || character == 'S')
            {
                arrow = '\u21a7';
            }
            else
            {
                arrow = '\u21a5';
            }
            return arrow;
        }
        private static string ToHexedString(byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach (var b in bytes)
            {
                sb.Append($"{b:X} ");
            }

            return sb.ToString();
        }



    }
}
