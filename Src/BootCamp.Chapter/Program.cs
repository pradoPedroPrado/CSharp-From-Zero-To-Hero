using System;
using System.Linq;

namespace BootCamp.Chapter
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddAndSearchStudentsDemo.RunDemo();

            MathTeacher mathTeacher = new MathTeacher();
            mathTeacher.ProduceMaterial();
            MusicTeacher musicTeacher = new MusicTeacher();
            musicTeacher.ProduceMaterial();
            EnglishTeacher englishTeacher = new EnglishTeacher();
            englishTeacher.ProduceMaterial();

        }
    }
}
