using System;
using System.Linq;
using System.Text;

namespace BootCamp.Chapter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DecimalToBinary(0));
            Console.WriteLine(DecimalToBinary(1));
            Console.WriteLine(DecimalToBinary(2));
            Console.WriteLine(DecimalToBinary(3));
            Console.WriteLine(DecimalToBinary(4));
            Console.WriteLine(DecimalToBinary(5));

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
                long[] temp = new long[digits.Length+1];
                for (long i = 1; i < temp.Length; i++)
                {
                    temp[i] = digits[i-1];
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
        }

    }
}
