using System.Collections.Generic;

namespace BootCamp.Chapter
{
    public interface ISchool<TStudent> where TStudent : IStudent
    {
        void Add(TStudent student);
        TStudent GetStudent(int id);
    }

    public abstract class School<TStudent> : ISchool<TStudent> where TStudent : IStudent
    {
        List<TStudent> _students;

        public School()
        {
            _students = new List<TStudent>();
        }

        public School(List<TStudent> students)
        {
            _students = students;
        }

        public void Add(TStudent student)
        {
            _students.Add(student);
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

        public MiddleSchool(List<MiddleSchoolStudent> students) : base(students)
        {
        }
    }
    public class HighSchool : School<HighSchoolStudent>
    {
        public HighSchool()
        {
        }

        public HighSchool(List<HighSchoolStudent> students) : base(students)
        {
        }
    }

}
