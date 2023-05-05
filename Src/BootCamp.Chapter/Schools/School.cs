using System.Collections.Generic;

namespace BootCamp.Chapter
{
    public abstract class School<TStudent> : ISchool<TStudent> where TStudent : Student
    {
        public List<TStudent> Students { get; }

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

}