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
        public static double Convert(Degree degree)
        {
            return degree switch
            {
                Degree.A => 5.0,
                Degree.B => 4.5,
                Degree.C => 4.0,
                Degree.D => 4.0,
                Degree.E => 3.5,
                Degree.F => 3.0,
                _ => 1.0
            };
        }

        public static string DegreeType(Degree degree)
        {
            return degree switch
            {
                Degree.A or Degree.B or Degree.C or Degree.E => "Pozytywny",
                _ => "Negatywny"
            };
        }

        public static Degree GetDegree(int points)
        {
            return points switch
            {
                > 90 => Degree.A,
                > 80 and <= 90 => Degree.B,
                > 70 and <= 80 => Degree.C,
                > 60 and <= 70 => Degree.D,
                > 50 and <= 60 => Degree.E,
                _ => Degree.F
            };
        }

        public static (string, bool)[] Egzams((string name, int points, char egzam)[] egzamInfo)
            {
            (string, bool)[] result = new (string, bool)[egzamInfo.Length];
        int i = 0;
        foreach(var item in egzamInfo)
            {
                result[i++] = (item.name, item switch
                {
                    { points: > 20, egzam: 'C' } => true,
                    { points: > 30, egzam: 'A' } => true,
                    { points: > 40, egzam: 'B' } => true,
                    _ => false

                }
                 );
             }
            return result;

            }


        record Student(string Name, int ECTS);

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

            Student student = new Student("Karol", 23);
            // student.Name = "Adam"; Nie da się tak zmieniec przypisanej wartosci do rekordu
            Console.WriteLine(student);

        }
    }
}
