using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleApp9
{   
    // Iterator
    internal class Program
    {
        public interface IIteraleCollection<T>
        {
            IIterator<T> Iterator { get; }
        }

        public interface IIterator<T>
        {
            T Next();
        }
        class Student
        {
            public string Name { get; set; }
            public int Mark { get; set; }

            public int[] Priorities { get; set; }

            public int Speciality { get; set; }

            public Student(string name, int mark, int[] priorities, int speciality)
            {
                Name = name;
                Mark = mark;
                Priorities = priorities;
                Speciality = speciality;
            }

            public override string ToString()
            {
                return $"{Name} on {Speciality} spec.";
            }
        }
        class StudentCollection : IIteraleCollection<Student>
        {
            private IIterator<Student> _Iterator;
            public IIterator<Student> Iterator { get { return _Iterator; } }

            public StudentCollection(Student[] Collection)
            {
                this._Iterator = new PrintStudentsInOrder(Collection);
            }
        }

        class StudentComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                return new CaseInsensitiveComparer().Compare(((Student)x).Name,
                       ((Student)y).Name);
            }
        }

        class PrintStudentsInOrder : IIterator<Student>
        {
            private Student[] Collection;
            private int Pos;
            public Student Next()
            {
                if (Pos <= 0)
                    return null;
                return this.Collection[--this.Pos];
            }
            public PrintStudentsInOrder(Student[] Collection)
            {
                this.Collection = Collection.Clone() as Student[];
                Array.Sort(this.Collection, (p1, p2) => (p2.Speciality - p1.Speciality));
                this.Pos = Collection.Length;
            }
        }
        class PrintStudentsByName : IIterator<Student>
        {
            private Student[] Collection;
            private int Pos;
            public Student Next()
            {
                if (Pos <= 0)
                    return null;
                return this.Collection[--this.Pos];
            }
            public PrintStudentsByName(Student[] Collection)
            {
                this.Collection = Collection.Clone() as Student[];
                Array.Sort(this.Collection, (p1, p2) => String.Compare(p1.Name, p2.Name));
                this.Pos = Collection.Length;
            }
        }
        static void Main(string[] args)
        {
            var list = new StudentCollection(new Student[4] {
                new Student("Yurii", 100, new int[5] {111, 112, 113, 114, 115}, 111),
                new Student("Andrii", 90, new int[5] { 112, 113, 114, 115, 111}, 111),
                new Student("Tetiana", 96, new int[5] {111, 123, 123, 123, 123}, 112),
                new Student("Oleksandr", 75, new int[5] {111, 123, 123, 123, 123}, 112)
            });
            Student person = list.Iterator.Next();
            while (person != null)
            {
                Console.WriteLine(person);
                person = list.Iterator.Next();
            }
        }
    }
}
