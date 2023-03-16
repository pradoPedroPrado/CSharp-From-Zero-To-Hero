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
            var message = $"Hola{Environment.NewLine}vieja{Environment.NewLine}podrida";
            var framed = Frame(message, 1);
            Console.WriteLine(framed);
            //var items = new[] { "1","2", "3","4" };
            string[] items = null;
            Console.WriteLine(ComposeListString(items));
        }
        public static string Frame(string message, int padding)

        {
            if (message == "")
            {
                return "";
            }

                var arr = message.Split($"{Environment.NewLine}");
            int longerLineSize = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Length > longerLineSize)
                {
                    longerLineSize = arr[i].Length;
                }
            }

            var frame = new string[arr.Length + 2 + padding*2];

            //top and bottom lines
            frame[0] = "+";
            for (var i = 0; i < longerLineSize + padding*2; i++)
            {
                frame[0] += "-";
            }
            frame[0] += "+";
            frame[frame.Length - 1] = $"{Environment.NewLine}{frame[0]}{Environment.NewLine}";

            //padding lines
            string paddingLine = $"{Environment.NewLine}|";
            for (int j = 0; j < longerLineSize + padding * 2; j++)
            {
                paddingLine += " ";
            }
            paddingLine += "|";

            for (var i = 0; i < padding; i++)
            {
                frame[i + 1] = paddingLine;
                frame[frame.Length-2 -i] = paddingLine;
            }


            //boddy
            for (var i = 0; i < arr.Length; i++)
            {
                //begining of each text line
                frame[i + 1 + padding] = $"{Environment.NewLine}|";
                //add padding
                for (int j = 0; j < padding; j++)
                {
                    frame[i + 1 + padding] += " ";
                }
                //add text
                frame[i + 1 + padding] += arr[i];

                //ending and padding
                for (var k = 0; k < longerLineSize + padding - arr[i].Length; k++)
                {
                    frame[i + 1+ padding] += " ";
                }
                frame[i + 1 + padding] += "|";
            }

            return String.Join("", frame);
        }

        public static string ComposeListString(string[] items)
        {
            if (items == null)
            {
                return "";
            }
            int lengt =items.Length;
            switch (lengt)
            {                
                case 0:
                    return "";
                case 1:
                    return items[0];
                case 2:
                    return string.Join(" and ", items);
                default:
                    var firsts = "";
                    for (var i = 0; i < items.Length-1; i++)
                    {
                        firsts += $"{items[i]}, ";
                    }
                    var last = $"and {items[^1]}";
                    return firsts + last;
            }            
        }


    }
}
