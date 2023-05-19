using System;
using System.Globalization;

namespace BootCamp.Chapter
{
    class Program
    {
        static void Main(string[] args)
        {
            //ContactsCenter contacts = new ContactsCenter(@"C:\Users\Pedro Win\Documents\Repos\CSharp-From-Zero-To-Hero\Src\BootCamp.Chapter\Input\MOCK_DATA.csv");
            Person person = new Person("Chrisy","Frise", DateTime.ParseExact("4/24/1946", "M/d/yyyy", CultureInfo.InvariantCulture),"Male","Philippines","cfrise0@europa.eu","62895 Troy Parkway");
            Console.WriteLine(PeoplePredicates.IsA(person));
            Console.WriteLine(PeoplePredicates.IsB(person));
            Console.WriteLine(PeoplePredicates.IsC(person));
        }
    }
}
