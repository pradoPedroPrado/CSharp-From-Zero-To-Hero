using System;

namespace BootCamp.Chapter
{
    public interface IStudent
    {
        int Id { get; }

        void LearnFrom<TTeacher, TSubject>(TTeacher teacher)
            where TTeacher : ITeacher<TSubject>
            where TSubject : ISubject;
    }

    public class MiddleSchoolStudent : IStudent
    {
        public int Id { get; }

        public MiddleSchoolStudent(int id)
        {
            Id = id;
        }

        public MiddleSchoolStudent()
        {
            Random random = new Random();
            Id = random.Next(int.MaxValue);
        }

        public void LearnFrom<TTeacher, TSubject>(TTeacher teacher)
            where TTeacher : ITeacher<TSubject>
            where TSubject : ISubject
        {
            throw new NotImplementedException();
        }

    }

    public class HighSchoolStudent : IStudent
    {
        public int Id { get; }

        public HighSchoolStudent(int id)
        {
            Id = id;
        }

        public HighSchoolStudent()
        {
            Random random = new Random();
            Id = random.Next(int.MaxValue);
        }

        public void LearnFrom<TTeacher, TSubject>(TTeacher teacher)
            where TTeacher : ITeacher<TSubject>
            where TSubject : ISubject
        {
            throw new NotImplementedException();
        }
    }

}
