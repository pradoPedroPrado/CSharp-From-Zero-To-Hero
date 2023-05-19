using System;

namespace BootCamp.Chapter
{
    public class Person
    {
        public string Name { get; set; }
        public string SureName { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string StreetAddress { get; set; }
        
        public Person(string name, string sureName, DateTime birthday, string gender, string country, string email, string streetAddress)
        {
            Name = name;
            SureName = sureName;
            Birthday = birthday;
            Gender = gender;
            Country = country;
            Email = email;
            StreetAddress = streetAddress;
        }

        public int Age
        {
            get
            {
                TimeSpan edad = DateTime.Today - Birthday;
                return (int)(edad.TotalDays / 365);
            }
        }
    }

}