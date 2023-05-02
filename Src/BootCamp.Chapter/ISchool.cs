using System.Collections.Generic;

namespace BootCamp.Chapter.School1
{
    public interface ISchool<out TStudent> where TStudent : IStudent
    {
        void Add(IStudent student);
        TStudent GetStudent(int id);
    }

    public abstract class School<TStudent> : ISchool<TStudent> where TStudent : IStudent
    {
        List<TStudent> _students;

        public School()
        {
            _students = new List<TStudent>();
        }

        public void Add(TStudent student)
        {
            _students.Add(student);
        }
        public void Add(IStudent student)
        {
            _students.Add((TStudent)student);
        }

        public TStudent GetStudent(int id)
        {
            return _students.Find(x => x.Id == id);
        }
    }

    public class MiddleSchool : School<MiddleSchoolStudent>
    {
        public MiddleSchool() : base()
        {
        }
    }
    public class HighSchool : School<HighSchoolStudent>
    {
        public HighSchool()
        {
        }
    }

}