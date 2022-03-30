using System;

namespace lab_4
{
    enum Degree
    {
        A = 50,
        B=45,
        C=40,
        D=35,
        E=30,
        F=20
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Degree studentDegree = Degree.C;
            Console.WriteLine((int)studentDegree);
            foreach(string name in Enum.GetNames<Degree>())
            {
                Console.WriteLine(name);
            }
            foreach (Degree degree in Enum.GetValues<Degree>())
            {
                Console.WriteLine($"{degree}{(int)degree }");
            }

            Console.WriteLine("Wpisz oceny");
            string str = Console.ReadLine();
            studentDegree = Enum.Parse<Degree>(str);
            try
            {
                studentDegree = Enum.Parse<Degree>(str);
            Console.WriteLine($"Wpisałeś ocene {studentDegree} {(int)studentDegree}");

            }
            catch(ArgumentException e)
            {
                Console.WriteLine("Nieznana ocena!");
            }


        }
    }
}
