using System;
using System.Collections.Generic;

namespace lab_6
{
    internal class Program
    {
        class Student //mozna tez dac record zamiast class i nie trzeba wtedy implementowac equels 
        {
            public string Name { get; set; }
            public int Ects { get; set; }

            public override bool Equals(object obj)
            {
                return obj is Student student &&
                       Name == student.Name &&
                       Ects == student.Ects;
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


        }
    }
}
