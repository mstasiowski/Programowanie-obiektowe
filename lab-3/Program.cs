using System;

namespace lab_3
{
    class Stack<T> /* where T: Student */
    {
        private  T[] arr = new T[10]; //string
        private int _last = -1;

        public void Push(T item) //Push(string item)
        {
             arr[++_last] = item;

        }

        public T Pop()
            {

            return arr[_last--];
        }

    }

    class Student
    {
        private string _firstname;
        public int Egzam;

        public void Push(Stack<string> stack)
        {
            stack.Push(_firstname);
        }

        public T GetReward<T>(T reward)
        {
           if(Egzam > 50)
            {
                return reward;
            }else
            {
                return default;
            }
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student() {Egzam = 60 };
            string v = student.GetReward("Gratulacje");
            Console.WriteLine(v);
            ValueTuple<string, decimal, int> product = ValueTuple.Create("Laptop", 1200m, 2);
            Console.WriteLine(product);
            (string, decimal, int) laptop = ("laptop", 1200m, 2);
            Console.WriteLine(product == laptop);
            (string name, decimal price, int quantity ) tuple = ("laptop", 3000m, 2);
            laptop = tuple;
            Console.WriteLine(laptop);

            var tuple1 = (name: "laptop", price: 1299m);
        }
    }
}
