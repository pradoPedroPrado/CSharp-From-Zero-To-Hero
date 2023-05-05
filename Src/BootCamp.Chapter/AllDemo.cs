using BootCamp.Chapter.Hints;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BootCamp.Chapter
{
    internal static class AllDemo
    {

        public static void Run()
        {
            MathTeacher mathTeacher = new MathTeacher();
            mathTeacher.ProduceMaterial();
            MusicTeacher musicTeacher = new MusicTeacher();
            musicTeacher.ProduceMaterial();
            EnglishTeacher englishTeacher = new EnglishTeacher();
            englishTeacher.ProduceMaterial();
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

            List<IEnumerable<Student>> allStudents = new List<IEnumerable<Student>>();
            allStudents.Add(middleSchool.Students);
            allStudents.Add(highSchool.Students);

            List<Student> students = allStudents.SelectMany(x => x).ToList();

            foreach (IStudent student in students)
            {
            student.LearnFrom<MathTeacher, Math>(mathTeacher);
            student.LearnFrom<MusicTeacher, Music>(musicTeacher);
            student.LearnFrom<EnglishTeacher, English>(englishTeacher);
            }




        }
    }
}