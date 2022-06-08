using System;

namespace lab_7
{
    delegate double operation(double a, double b);
    delegate bool stringPredictate(string s);
    internal class Program
    {
        public static double Add(double a ,double b)
        {
            return a + b;
        }

        public static double Mul(double a, double b)
        {
            return a * b;
        }

        public static bool fiveCharacters(string s)
        {
            return s.Length == 5;
        }
        static void Main(string[] args)
        {
            operation op = Add;
            Console.WriteLine(op.Invoke(4,6));//1

            op = Mul;
            Console.WriteLine(op.Invoke(4, 6));//2

            stringPredictate predicate = fiveCharacters;
            Console.WriteLine(predicate.Invoke("character"));



            //////////////////////////
            Func<double, double, double> funcOperator = delegate(double a, double b)
            { return a * b; };

            Func<int, string> FormatDelegate = delegate (int number)
            { return string.Format("{0:x}", number); };

            Console.WriteLine(FormatDelegate.Invoke(14));
            Predicate<string> OnlyFive = fiveCharacters;
            Predicate<int> InRange = delegate (int a)
            {
                return a >= 0 && a <= 100;
            };
            Console.WriteLine(InRange.Invoke(67));

            Func<int, int, int, bool> Inrange1 = delegate (int value, int min, int max)
            {
                return value >= min && value <= max;

            
            };

            Action<string> Print = delegate (string s)
            {
                Console.WriteLine("");
            };

            Action<string> PrintLambda = (s) => Console.WriteLine(s);

            Func<int,int,int,bool> InRangeLambda = (value, min, max) => value >= min && value <= max;
            operation DIY = (a, b) =>

             {
                 if (b != 0)
                 {
                     return a / b;
                 } else
                 {
                     throw new Exception("b is zero");
 
                 }


             };

            Console.WriteLine(DIY.Invoke(2,3));




        }
    }
}
