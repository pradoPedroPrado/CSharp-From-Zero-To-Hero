namespace BootCamp.Chapter
{
    public interface ISchool<out TStudent> where TStudent : IStudent
    {
        TStudent GetStudent(int id);
    }
}