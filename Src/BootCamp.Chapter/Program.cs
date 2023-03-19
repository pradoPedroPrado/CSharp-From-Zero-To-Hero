using System;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Xml.Linq;

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
            //var items = new[] { "1", "2", "3", "4" };
            var balances = new[] { "Tom, 1, 0" };

            //string[] items = null;
            //Console.WriteLine(ComposeListString(items));

            Console.WriteLine(FindPersonWithBiggestLoss(balances));
            //Console.WriteLine(FindPersonWithBiggestLoss(PeoplesBalances.Balances));

        }

        public static string FindHighestBalanceEver(string[] balances)
        {
            if (balances == null || balances.Length == 0)
            {
                return "N/A.";
            }
            string name;
            float highestPersonalBalance;
            float? highestBalance = null;
            string[] persosnsWithHighestBalance = null;

            for (int i = 0; i < balances.Length; i++)
            {
                string[] balance = balances[i].Split(", ");
                name = balance[0];
                highestPersonalBalance = GetHighestPersonalBalance(balance);

                if (highestBalance == null)
                {
                    highestBalance = highestPersonalBalance;
                    persosnsWithHighestBalance = new string[] { name };
                }
                else if (highestPersonalBalance == highestBalance)
                {
                    persosnsWithHighestBalance = AppendToStringArray(persosnsWithHighestBalance, name);   
                }
                else if (highestPersonalBalance > highestBalance)
                {
                    persosnsWithHighestBalance = new[] { name };
                    highestBalance = highestPersonalBalance;
                }
            }
            CultureInfo ci = (CultureInfo)CultureInfo.InvariantCulture.Clone();
            ci.NumberFormat.CurrencyNegativePattern = 1;
            ci.NumberFormat.CurrencyGroupSeparator = "";
            CultureInfo.CurrentCulture = ci;
            return $"{ComposeListString(persosnsWithHighestBalance)} had the most money ever. {highestBalance:c0}.";
            //return $"{ComposeListString(persosnsWithHighestBalance)} had the most money ever. ¤{highestBalance}.";
        }
        public static string FindPersonWithBiggestLoss(string[] balances)
        {
            if (balances == null || balances.Length == 0)
            {
                return "N/A.";
            }
            string name;
            float biggestPersonalLoss;
            float? biggestLoss = null;
            string[] persosnsWithLowestBalance = null;

            for (int i = 0; i < balances.Length; i++)
            {
                string[] balance = balances[i].Split(", ");

                if (balance.Length < 3) break;

                name = balance[0];
                biggestPersonalLoss = GetBiggestPersonalLoss(balance);

                if (biggestLoss == null)
                {
                    biggestLoss = biggestPersonalLoss;
                    persosnsWithLowestBalance = new string[] { name };
                }
                else if (biggestPersonalLoss == biggestLoss)
                {
                    persosnsWithLowestBalance = AppendToStringArray(persosnsWithLowestBalance, name);   
                }
                else if (biggestPersonalLoss < biggestLoss)
                {
                    persosnsWithLowestBalance = new[] { name };
                    biggestLoss = biggestPersonalLoss;
                }
            }

            if (biggestLoss == null)
            {
                return "N/A.";
            }
            CultureInfo ci = (CultureInfo)CultureInfo.InvariantCulture.Clone();
            ci.NumberFormat.CurrencyNegativePattern = 1;
            CultureInfo.CurrentCulture = ci;
            return $"{ComposeListString(persosnsWithLowestBalance)} lost the most money. {biggestLoss:c0}.";
        }

        private static float GetHighestPersonalBalance(string[] personalBalance)
        {
            float highestPersonalBalance;
            bool isNumber = float.TryParse(personalBalance[1], out highestPersonalBalance);
            for (int i = 1; i < personalBalance.Length; i++)
            {
                float number;
                isNumber = float.TryParse(personalBalance[i], out number);
                if (number > highestPersonalBalance)
                {
                    highestPersonalBalance = number;
                }
            }
            return highestPersonalBalance;
        }
        private static float GetBiggestPersonalLoss(string[] personalBalance)
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            float BiggestPersonalLoss = 0;
            float[] personalBalanceArr = new float[personalBalance.Length-1];
            bool isNumber;


            for (int i = 1; i < personalBalance.Length; i++)
            {
                float number;
                isNumber = float.TryParse(personalBalance[i], out number);
                if (isNumber)
                {
                    personalBalanceArr[i-1] = number;
                }
            }

            float difference;
            for (int i = 1; i < personalBalanceArr.Length; i++)
            {
                difference = personalBalanceArr[i] - personalBalanceArr[i - 1];

                if (difference < BiggestPersonalLoss)
                {
                    BiggestPersonalLoss = difference;
                }
            }
            return BiggestPersonalLoss;
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

        static string ComposeListString(string[] items)
        {
            if (items == null)
            {
                return "";
            }
            int length = items.Length;
            switch (length)
            {
                case 0:
                    return "";
                case 1:
                    return items[0];
                case 2:
                    return string.Join(" and ", items);
                default:
                    var firstsArr = new string[items.Length-1];
                    for (int i = 0; i < firstsArr.Length; i++)
                    {
                        firstsArr[i] = items[i];
                    }

                    string firsts = string.Join(", ", firstsArr);
                    var last = $" and {items[^1]}";
                    return firsts + last;
            }
        }

        //static string ComposeListString(string[] items) //this is an optimization of my method that Bing chat sugested 
        //{
        //    if (items == null || items.Length == 0)
        //    {
        //        return "";
        //    }
        //    var sb = new StringBuilder();
        //    sb.AppendJoin(", ", items[..^1]); // append all items except the last one
        //    if (items.Length > 1)
        //    {
        //        sb.Append(" and "); // append the conjunction
        //    }
        //    sb.Append(items[items.Length - 1]); // append the last item
        //    return sb.ToString();
        //}

        static string[] AppendToStringArray(string[] items, string item)
        {
            string[] newArray = new string[items.Length + 1];
            for (int i = 0; i < items.Length; i++)
            {
                newArray[i] = items[i];
            }
            newArray[^1] = item;
            return newArray;

        }

    }
}
