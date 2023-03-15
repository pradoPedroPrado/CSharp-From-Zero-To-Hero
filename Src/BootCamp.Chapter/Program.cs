using System;
using System.ComponentModel;
using System.Text;

namespace BootCamp.Chapter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Print each of the statistical output using Text Table with padding 3:
            // - FindHighestBalanceEver
            // - FindPersonWithBiggestLoss
            // - FindRichestPerson
            // - FindMostPoorPerson
            var message = $"Hello{Environment.NewLine}World!";
            var framed = Framer(message, 0);
            Console.WriteLine(framed);
        }
        public static string Framer(string message, int padding)

        {
            var arr = message.Split($"{Environment.NewLine}");
            int longerLineSize = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Length > longerLineSize)
                {
                    longerLineSize = arr[i].Length;
                }
            }

            var frame = new string[arr.Length + 2];

            frame[0] = "  +";
            for (var i = 0; i < longerLineSize; i++)
            {
                frame[0] += "-";
            }
            frame[0] += "+";

            for (var i = 0; i < arr.Length; i++)
            {
                frame[i + 1] = $"{Environment.NewLine}  |" + arr[i];
                for (var j = 0; j < longerLineSize - arr[i].Length; j++)
                {
                    frame[i + 1] += " ";
                }
                frame[i + 1] += "|";
            }

            frame[frame.Length-1] = $"{Environment.NewLine}{frame[0]}";

            return String.Join("", frame);
        }


    }
}
