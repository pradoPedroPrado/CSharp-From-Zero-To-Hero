using BootCamp.Chapter.School1;
using System.Collections.Generic;

namespace BootCamp.Chapter.School2
{

    public interface IStudentAdder<in TStudent> where TStudent : IStudent
    {
        void Add(TStudent student);
    }
    public interface IStudentGetter<out TStudent> where TStudent : IStudent
    {
        TStudent GetStudent(int id);
    }

    public abstract class School<TStudent> : IStudentAdder<TStudent>, IStudentGetter<TStudent> where TStudent : IStudent 

    {
        public List<TStudent> Students { get; private set; }

        public School()
        {
            Students = new List<TStudent>();
        }


        public void Add(TStudent student)
        {
            Students.Add(student);
        }

        public TStudent GetStudent(int id)
        {
            return Students.Find(x => x.Id == id);
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

