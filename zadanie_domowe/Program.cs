using System;
using System.Collections.Generic;

namespace zadanie_domowe
{
    internal class Program
    {
        public class Coins
        {
            
            private int face_value;
            public Coins(int face_value)
            {
                this.face_value = face_value;
            }
            public int Value
            {
                set { face_value = value; }
                get { return face_value; }
            }
            public static Coins One()
            {
                return new(1);
            }
            public static Coins Two()
            {
                return new(2);
            }
            public static Coins Five()
            {
                return new(5);
            }
            public static int operator +(Coins a, Coins b)
            {
                return a.Value + b.Value;
            }
            public static Coins[] Of(int sum)
            {

                List<Coins> list = new();
                while (sum > 0)
                {
                    if (sum - 5 >= 0)
                    { 
                        list.Add(Five()); sum -= 5; continue;
                    }
                    if (sum - 2 >= 0) 
                    {
                        list.Add(Two()); sum -= 2; continue;
                    }
                    if (sum - 1 >= 0)
                    { 
                        list.Add(One()); sum -= 1; continue;
                    }

                }
                return list.ToArray();
            }
        }

        static void Main(string[] args)
        {
             var wynik = Coins.Of(6);
             Array.ForEach(wynik, element => Console.WriteLine(element.Value));



        }
    }
}
