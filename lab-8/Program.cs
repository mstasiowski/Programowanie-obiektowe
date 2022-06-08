using System;
using System.Collections.Generic;
using System.Linq;

namespace lab_8
{
    record Student(string name, int Ects);
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ints = { 4, 5, 6, 7, 8, 9 };

            Predicate<int> predicate = n =>
            {
                Console.WriteLine("Predykat dla " + n);
                return n % 2 == 0 && n > 4;
            };
            IEnumerable<int> enumerable = from n in ints
                                          where predicate.Invoke(n)
                                          select n;

            int sum = enumerable.Sum();
            Console.WriteLine("Suma = ", sum);
            Console.WriteLine("Ewaluacja");
            Console.WriteLine(String.Join(", ", enumerable));

            string[] strings = { "aa", "bbb", "cc", "ddddddddddd", "abc", "babf" };

            Console.WriteLine(string.Join(", ", from s in strings where s.Length == 3 select "str = " + s.ToUpper()));
            Console.WriteLine(String.Join(", ", from i in ints
                                                select i.ToString("X")));

            Student[] students =
                {
                new Student("Ewa", 12),
                new Student("Ewa", 72),
                new Student("Marek", 57),
                new Student("Kasia", 23),
                new Student("Kamil", 31),
                new Student("Adam", 44),
                new Student("Adam", 4),
                };

            Console.WriteLine(string.Join("\n",
                from s in students
                where s.Ects > 30
                orderby s.name
                select s.name));


            IEnumerable<IGrouping<string, Student>> group =
         from s in students
         group s by s.name;
            foreach (var item in group)
            { 
                Console.WriteLine(item.Key + " " + item.Count());

            }

            IEnumerable<(string Key, int)> namesGroup =
                from s in students
                group s by s.name into gr
                select (gr.Key, gr.Count());
            Console.WriteLine(String.Join("\n", namesGroup));


            IEnumerable<int> evens = ints.Where(n => n % 2 == 0).OrderBy(n => n);
            Console.WriteLine(string.Join(", ", evens));
            Console.WriteLine(string.Join("\n", students.OrderBy(s => s.name).ThenBy(s => s.Ects)));

            IEnumerable<(int Key, int)> fluentGroup = students
                .GroupBy(s => s.Ects)
                .Select(gr => (gr.Key, gr.Count()));
            Student tenstudent = students.ElementAtOrDefault(10);
            Console.WriteLine(tenstudent);
            students.All(s => s.Ects > 10);


            //czy w ints są same parzyste
            Console.WriteLine(ints.All(s => s % 2 == 0));

            // czy w ints jest przynajmniej jedna liczba parzysta
            Console.WriteLine(ints.Any(s => s % 2 ==0));

            Enumerable.Range(0, 100).Where(n => n % 2 == 0).Sum();

            Random random = new Random();
            random.Next(5);

            //wygeneruj tablice 1000 liczb losowych w zakresie od 0-9

            int[] bs = Enumerable.Range(0, 1000).Select(n => random.Next(10)).ToArray();

            Console.WriteLine(bs);

             IEnumerable<int> primes = Enumerable.Range(1, 100).Where(n =>
            {
                return Enumerable.Range(2, n - 1).All(i => n % i != 0);

            });
            Console.WriteLine(String.Join(", ",primes));



           
        }
        
           
        
        
    }
}
