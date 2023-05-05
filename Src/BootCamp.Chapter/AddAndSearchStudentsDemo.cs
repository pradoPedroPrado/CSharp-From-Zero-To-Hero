using System;
using System.Collections.Generic;

namespace BootCamp.Chapter
{
    internal static class AddAndSearchStudentsDemo
    {
        public static void Run()
        {
            School<MiddleSchoolStudent> middleSchool = new MiddleSchool();
            School<HighSchoolStudent> highSchool = new HighSchool();
            //List<IStudent> allStudents = new List<IStudent>();

            Console.WriteLine("middleSchool students:");
            for (int i = 0; i < 10; i++)
            {
                MiddleSchoolStudent student = new MiddleSchoolStudent();
                Console.WriteLine(student.Id);
                middleSchool.Add(student);
                //allStudents.Add(student);
            }

            Console.WriteLine("highSchool students:");
            for (int i = 0; i < 10; i++)
            {
                HighSchoolStudent student = new HighSchoolStudent();
                Console.WriteLine(student.Id);
                highSchool.Add(student);
                //allStudents.Add(student);
            }

            ISchool<IStudent>[] schools = { middleSchool, highSchool };


            //int id = highSchool.Students[1].Id;
            int id = 80085;
            Console.WriteLine($"Student ID to search for: {id}");

            SearchInSchools(schools, id);

        }

        private static void SearchInSchools(ISchool<IStudent>[] schools, int id)
        {
            bool isThere = false;

            foreach (ISchool<IStudent> school in schools)
            {
                IStudent studentToSearch = school.GetStudent(id);

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