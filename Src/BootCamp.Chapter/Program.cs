using System;
using System.Collections.Generic;
using System.IO;
using Console = System.Console;

namespace BootCamp.Chapter
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = GetString("name");
            string surename = GetString("surename");
            int age = GetInt("age");
            int weight = GetInt("weight");
            int height = GetInt("height in cm");
            Console.WriteLine($"{name} {surename} is {age}, weight is {weight} kg and height is {height} cm.");
            ReturnBMI(weight, height);

            name = GetString("name");
            surename = GetString("surename");
            age = GetInt("age");
            weight = GetInt("weight");
            height = GetInt("height in cm");
            Console.WriteLine($"{name} {surename} is {age}, weight is {weight} kg and height is {height} cm.");
            ReturnBMI(weight, height);

        }

        public static string GetString(string text)
        {
            Console.WriteLine($"Enter person's {text}:");
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Name cannot be empty.");
                return "-";
            }
            else return input;
            
        }
        public static int GetInt(string text)
        {
            Console.WriteLine($"Enter person {text}:");
            var input = Console.ReadLine();
            var isInt = int.TryParse(input, out int result);
            if (!isInt)
            {
                Console.WriteLine($"{input} is not a valid number.");
                return -1;
            }
            else return result;

        }

        public static string ReturnBMI(float weight, float height)
        {
            string error1 = "";
            string error2 = "";

            if (weight <= 0)
            {
                error1 = $"{Environment.NewLine}  Weight cannot be equal or less than zero, but was {weight}.";
            }
            if (height <= 0)
            {
                error2 = $"{Environment.NewLine}  Weight cannot be equal or less than zero, but was {height}.";
            }
            if (weight <= 0 || height <= 0)
            {
                return "Failed calculating BMI. Reason:" + error1 + error2;
            }
            else
            {
                float heightMt = height / 100.0f;
                float BMI = weight / (heightMt * heightMt);
                return $"BMI is {BMI:f2}";
            }
        }

    }

}
