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

    public abstract class Student : IStudent
    {
        public int Id { get; }

        public Student()
        {
            Random random = new Random();
            Id = random.Next(int.MaxValue);
        }


        public void LearnFrom<TTeacher, TSubject>(TTeacher teacher)
            where TTeacher : ITeacher<TSubject>
            where TSubject : ISubject
        {
            {
                string subjectType = typeof(TSubject).Name;
                string teacherType = typeof(TTeacher).Name;
                Console.WriteLine($"Student {Id} is learning {subjectType} from {teacherType}.");
            }

        }
    }

    public class MiddleSchoolStudent : Student { }

    public class HighSchoolStudent : Student { }

}
