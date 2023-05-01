using System;
using System.Collections.Generic;
using static BootCamp.Chapter.MiddleSchoolStudent;

namespace BootCamp.Chapter
{
    class Program
    {
        static void Main(string[] args)
        {
            MiddleSchoolStudent middleSchoolStudent = new MiddleSchoolStudent();
            Console.WriteLine(middleSchoolStudent.Id);
            ISchool<MiddleSchoolStudent> middleSchool = new MiddleSchool();
            middleSchool.Add(middleSchoolStudent);

            HighSchoolStudent highSchoolStudent = new HighSchoolStudent();
            Console.WriteLine(highSchoolStudent.Id);
            ISchool<IStudent> highSchool = new HighSchool();
            highSchool.Add(highSchoolStudent);

            List<ISchool<IStudent>> schools = new List<ISchool<IStudent>>();

            schools.Add(highSchool);


            bool hasStudent = false;
            if (middleSchool.GetStudent(middleSchoolStudent.Id) != null) { hasStudent = true; }
            Console.WriteLine($"There is the student with id {middleSchoolStudent.Id} = {hasStudent}");
            hasStudent = false;
            if (middleSchool.GetStudent(37) != null) { hasStudent = true; }
            Console.WriteLine($"There is the student with id {37} = {hasStudent}");


        }
    }
}
