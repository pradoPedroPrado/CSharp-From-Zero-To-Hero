using System;
using System.Collections.Generic;
using System.Text;

namespace BootCamp.Chapter
{
    public interface ITeacher<TSubject> where TSubject : ISubject
    {
        Material<TSubject> ProduceMaterial();
    }
    public abstract class Teacher<TSubject> : ITeacher<TSubject> where TSubject : ISubject
    {
        public Material<TSubject> ProduceMaterial()
        {
            Material<TSubject> material = new Material<TSubject>();
            string materialName = typeof(TSubject).Name;
            Console.WriteLine($"Teacher produced {materialName} material.");
            return material;
        }
    }

    public class MathTeacher : Teacher<Math>
    {
        public MathTeacher() : base() { }
    }
    public class ArtTeacher : Teacher<Art>
    {
        public ArtTeacher() : base() { }
    }
    public class EnglishTeacher : Teacher<English>
    {
        public EnglishTeacher() : base() { }
    }
    public class MusicTeacher : Teacher<Music>
    {
        public MusicTeacher() : base() { }
    }
    public class ProgrammingTeacher : Teacher<Programming>
    {
        public ProgrammingTeacher() : base() { }
    }
    public class PETeacher : Teacher<PE>
    {
        public PETeacher() : base() { }
    }
}
