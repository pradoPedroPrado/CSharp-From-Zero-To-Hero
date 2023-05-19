using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace BootCamp.Chapter
{
    public class ContactsCenter
    {
        private readonly List<Person> _people;

        public ContactsCenter(string peopleFile)
        {
            _people = new List<Person>();
            ParseFile(peopleFile);
        }

        private void ParseFile(string peopleFile)
        {
            if (peopleFile == null) { throw new ArgumentNullException(); }
            if (!File.Exists(peopleFile)) { throw new FileNotFoundException(); }
            if (peopleFile.Length == 0) { throw new Exception(); }
            string[] lines = File.ReadAllLines(peopleFile);
            bool header = true;
            foreach (string line in lines)
            {
                if (header)
                {
                    header = false;
                    continue;
                }
                string[] values = line.Split(',');
                DateTime.TryParseExact(values[2], "M/d/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime birthday);
                Person person = new Person(values[0], values[1], birthday, values[3], values[4], values[5], values[6]);
                _people.Add(person);
            }
        }

        /// <summary>
        /// Gets people by filter predicate.
        /// </summary>
        /// <returns></returns>
        public List<Person> Filter(Predicate<Person> predicate)
        {
            var people = new List<Person>();
            // ToDo: implement applying filter.
            foreach (Person person in _people)
            {
                if (predicate(person))
                {
                    people.Add(person); 
                }
            }
            return people;
        }
    }
}
