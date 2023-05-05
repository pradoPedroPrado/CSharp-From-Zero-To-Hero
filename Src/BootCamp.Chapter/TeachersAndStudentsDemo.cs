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

            MiddleSchoolStudent middleSchoolStudent = new MiddleSchoolStudent();
            middleSchoolStudent.LearnFrom<MathTeacher, Math>(mathTeacher);
            middleSchoolStudent.LearnFrom<MusicTeacher, Music>(musicTeacher);
            middleSchoolStudent.LearnFrom<EnglishTeacher, English>(englishTeacher);
        }
    }
}