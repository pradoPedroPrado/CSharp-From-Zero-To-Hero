﻿using System;
using System.Collections.Generic;

namespace BootCamp.Chapter
{
    internal static class TeachersAndStudentsDemo
    {

        public static void Run()
        {
            MathTeacher mathTeacher = new MathTeacher();
            mathTeacher.ProduceMaterial();
            MusicTeacher musicTeacher = new MusicTeacher();
            musicTeacher.ProduceMaterial();
            EnglishTeacher englishTeacher = new EnglishTeacher();
            englishTeacher.ProduceMaterial();
            List<IStudent> allStudents = new List<IStudent>();

            for (int i = 0; i < 10; i++)
            {
                MiddleSchoolStudent student = new MiddleSchoolStudent();
                Console.WriteLine(student.Id);
                allStudents.Add(student);
            }

            Console.WriteLine("highSchool students:");
            for (int i = 0; i < 10; i++)
            {
                HighSchoolStudent student = new HighSchoolStudent();
                Console.WriteLine(student.Id);
                allStudents.Add(student);
            }

            foreach (IStudent student in allStudents)
            {
            student.LearnFrom<MathTeacher, Math>(mathTeacher);
            student.LearnFrom<MusicTeacher, Music>(musicTeacher);
            student.LearnFrom<EnglishTeacher, English>(englishTeacher);
            }




        }
    }
}