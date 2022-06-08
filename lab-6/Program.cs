using System;
using System.Collections.Generic;

namespace lab_6
{
    internal class Program
    {
        class Student :IComparable<Student>//mozna tez dac record zamiast class i nie trzeba wtedy implementowac equels 
        {
            public string Name { get; set; }
            public int Ects { get; set; }

            public int CompareTo(Student other)
            {
                return Name.CompareTo(other.Name);
            }

            public override bool Equals(object obj)
            {
                return obj is Student student &&
                       Name == student.Name &&
                       Ects == student.Ects;
            }

            public override int GetHashCode()
            {
                Console.WriteLine("Student HashCode");
                return HashCode.Combine(Name, Ects);
            }

            public override string ToString()
            {
                return $" Name = {Name}, Ects = {Ects}";
            }


        }

        static void Main(string[] args)
        {
            ICollection<string> names = new List<string>();
            names.Add("Ewa");
            names.Add("Karol");
            names.Add("Robert");
            Console.WriteLine(names.Contains("Karol"));
            names.Remove("Ewa");
            
            foreach(string name in names)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("----------------------------------");

            ICollection<Student> students = new List<Student>();

            students.Add(new Student() { Name="Adam", Ects= 20});
            students.Add(new Student() { Name="Marek", Ects= 12});
            students.Add(new Student() { Name="Ewa", Ects= 13});
            students.Add(new Student() { Name="Kasia", Ects= 19});

            Console.WriteLine(students.Contains(new Student() { Name = "Marek", Ects = 12 }));
            students.Remove(new Student() { Name = "Kasia", Ects = 19 });

            foreach(Student student in students)
            {
                Console.WriteLine(student.Name+ " " +student.Ects);
            }
            
            List<Student> list  = (List<Student>)students;
            Console.WriteLine(list[0]);
           // list[0] = new Student() { };
            list.Insert(0,new Student() {Name= "Ania" ,Ects= 11 });

            int index = list.IndexOf(new Student() { Name="Ewa", Ects= 13});
            Console.WriteLine(index);

            ISet<string> setNames = new HashSet<string>();        //zbiór

            setNames.Add("Ewa");
            setNames.Add("Karol");
            setNames.Add("Robert");
            setNames.Add("Robert");
            Console.WriteLine(string.Join(", ", setNames));
            Console.WriteLine("========================================");

            ISet<Student>studentGroup = new HashSet<Student>();

            studentGroup.Add(list[0]);
            studentGroup.Add(list[1]);
            studentGroup.Add(list[2]);
            studentGroup.Add(list[0]);
            studentGroup.Add(new Student() { Name="Ania", Ects=11});

            foreach(Student student in studentGroup)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine("--------------Contains---------------");
            Console.WriteLine(studentGroup.Contains(list[2]));

            list.Add(new Student { Name = "Ela", Ects = 56 });
            list.Add(new Student { Name = "Igor", Ects = 16 });
            List<Student> result = new List<Student>();
            foreach(Student student1 in list)
            {
                if(studentGroup.Contains(student1))
                {
                  result.Add(student1);
                }
            }

            ISet<Student> set = new HashSet<Student>(list);
            ISet<Student> commonSet = new HashSet<Student>(studentGroup);
            commonSet.IntersectWith(set);

            Console.WriteLine(String.Join(", ", commonSet));

            ISet<Student> sortedset = new SortedSet<Student>(studentGroup);

            foreach(Student s in sortedset)
            {
                Console.WriteLine(s);
            }
            Dictionary<Student, List<string>> phones = new Dictionary<Student, list<string>>();
            phones[list[0]] = new List<string>();
            phones[list[0]].Add = "3435453476";

            phones[new Student() { Name = "Karol", Ects = 34 }] = "2324234257";

            foreach(var item in phones)
            {
                Console.WriteLine(item.Key+" "+item.Value);
            }

            Console.WriteLine(string.Join(", ", phones.Keys));
            Console.WriteLine(string.Join(", ", phones.Values));


        }
    }
}
