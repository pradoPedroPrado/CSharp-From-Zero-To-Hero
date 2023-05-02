using BootCamp.Chapter.School2;
using System;
using System.Linq;

namespace BootCamp.Chapter
{
    class Program
    {
        static void Main(string[] args)
        {


            School<MiddleSchoolStudent> middleSchool = new MiddleSchool();
            School<HighSchoolStudent> highSchool = new HighSchool();


            for (int i = 0; i < 10; i++)
            {
                MiddleSchoolStudent student = new MiddleSchoolStudent();
                middleSchool.Add(student);
            }
            Console.WriteLine("middleSchool students:");
            foreach (MiddleSchoolStudent student in middleSchool.Students)
            {
                Console.WriteLine(student.Id);
            }

            for (int i = 0; i < 10; i++)
            {
                HighSchoolStudent student = new HighSchoolStudent();
                highSchool.Add(student);
            }
            Console.WriteLine("highSchool students:");
            foreach (HighSchoolStudent student in highSchool.Students)
            {
                Console.WriteLine(student.Id);
            }


            bool isThere = false;
            int id = highSchool.Students.ElementAt(1).Id;
            //int id = 80085;
            Console.WriteLine($"Student ID to search for: {id}");

            IStudentGetter<IStudent>[] schools = { middleSchool, highSchool };

            foreach (IStudentGetter<IStudent> school in schools)
            {
                IStudent studentToSearch = school.GetStudent(id);
                //IStudent studentToSearch = school.GetStudent(middleSchool.Students.ElementAt(1).Id);

                if (studentToSearch != null)
                {
                    isThere = true;
                    string nameOfSchool = school.GetType().Name;
                    Console.WriteLine($"Found student with id: {studentToSearch.Id} on {nameOfSchool}");
                    break;
                }
            }

            if (!isThere) { Console.WriteLine($"Student with ID {id} not found."); }


        }
    }
}
