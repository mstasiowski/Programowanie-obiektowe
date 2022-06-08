using System;
using System.Collections.Generic;

namespace Lab2
{
    class Program
    {
        public abstract class Vehicle
        {
            public double Weight { get; init; } 
            public int MaxSpeed { get; init; }
            protected int _mileage;
            public int Mealeage
            {
                get { return _mileage; }
            }
            
            public abstract decimal Drive(int distance);
            public override string ToString()
            {
                return $"Vehicle{{ Weight: {Weight}, MaxSpeed: {MaxSpeed}, Mileage: {_mileage} }}";
            }
        }

        public class Car : Vehicle
        {
            public bool isFuel { get; set; }
            public bool isEngineWorking { get; set; }
            public override decimal Drive(int distance)
            {
                if (isFuel && isEngineWorking)
                {
                    _mileage += distance;
                    return (decimal)(distance / (double)MaxSpeed);
                }
                return -1;
            }
            public override string ToString()
            {
                return $"Car{{Weight: {Weight}, MaxSpeed: {MaxSpeed}, Mileage: {_mileage}}}";
            }
        }

        public class Bicycle : Vehicle
        {
            public bool isDriver { get; set; }
            public override decimal Drive(int distance)
            {
                if (isDriver)
                {
                    _mileage += distance;
                    return (decimal)(distance / (double)MaxSpeed);
                }
                return -1;
            }
            public override string ToString()
            {
                return $"Bicycle{{Weight: {Weight}, MaxSpeed: {MaxSpeed}, Mileage: {_mileage}}}"; ;
            }
        }

        public class Scooter : Vehicle
        {
            public bool isLight { get; set; }
            public bool isBrake { get; set; }

            public override decimal Drive(int distance)
            {
                if (isLight && isBrake)
                {
                    _mileage += distance;
                    return (decimal)(distance / (double)MaxSpeed);
                }
                return -1;
            }
            public override string ToString()
            {
                return $"Scooter{{ Weight: {Weight}, MaxSpeed: {MaxSpeed}, Mileage: {_mileage} }}";
            }
        }

        public class ElectricScooter : Scooter
        {
            private int _currentBatteryLevel { get; set; }
            public int maxRange { get; set; }

            public int MaxRange()
            {
                maxRange = (MaxSpeed / 10) * ((int)Weight / 10);
                return maxRange;
            }

            public override decimal Drive(int distance)
            {
                _currentBatteryLevel -= distance * (int)(Weight * 0.3);
                if (isLight && isBrake && (_currentBatteryLevel > 0))
                {
                    return (decimal)(distance / (double)MaxSpeed);
                }
                return -1;
            }

            public string BetteryLevel()
            {
                return $"Your battery level is {_currentBatteryLevel}%";
            }

            public void RechargeBattery()
            {
                _currentBatteryLevel = 100;
            }

            public override string ToString()
            {
                return $"ElectricScooter{{ Weight: {Weight}, MaxSpeed: {MaxSpeed}, Mileage: {_mileage}, MaxRange: {MaxRange()}}}";
            }
        }

       

        interface IFlyable
        {
            bool canFly();
        }

        interface ISwimmingable
        {
            bool canSwim();
        }

        public class Duck : IFlyable, ISwimmingable
        {
            public bool canFly()
            {
                return true;
            }

            public bool canSwim()
            {
                return true;
            }

            public override string ToString()
            {
                return "Duck, kwa kwa";
            }
        }

        public class Wasp : IFlyable
        {
            public bool canFly()
            {
                return true;
            }

            public override string ToString()
            {
                return "Wasp, bzz bzz";
            }
        }

        public class HydroPlane : IFlyable, ISwimmingable
        {
            public bool canFly()
            {
                return true;
            }

            public bool canSwim()
            {
                return true;
            }

            public override string ToString()
            {
                return "HydroPlane, wzium wzium";
            }
        }

        interface IAggregate
        {
            IIterator createIterator();
        }

        interface IIterator
        {
            int GetFirst();
            bool HasNext();
            int GetNext();
            int GetNextReverse();
            int EvenOdd();
            
        }

        class IntAggregate : IAggregate
        {
            internal int _a = 1;
            internal int _b = 2;
            internal int _c = 3;
            internal int _d = 4;
            internal int _e = 5;
            internal int _f = 6;

            public IIterator createIterator()
            {
                return new IntIterator(this);
            }
        }

        class IntIterator : IIterator
        {
            private IntAggregate _aggregate;
            private int count = 0;

            public IntIterator(IntAggregate aggregate)
            {
                _aggregate = aggregate;
            }

            public int GetFirst()
            {
                return _aggregate._a;
            }

            public int GetNext()
            {
                if (count == 6)
                {
                    return _aggregate._f;
                }
                switch (++count)
                {
                    case 1: return _aggregate._a;
                    case 2: return _aggregate._b;
                    case 3: return _aggregate._c;
                    case 4: return _aggregate._d;
                    case 5: return _aggregate._e;
                    case 6: return _aggregate._f;
                    default: throw new Exception();
                }
            }

            public bool HasNext()
            {
                return count < 6;
            }

            public int GetNextReverse()
            {
                if (count == 6)
                {
                    return _aggregate._a;
                }
                switch (++count)
                {
                    case 1: return _aggregate._f;
                    case 2: return _aggregate._e;
                    case 3: return _aggregate._d;
                    case 4: return _aggregate._c;
                    case 5: return _aggregate._b;
                    case 6: return _aggregate._a;
                    default: throw new Exception();
                }
            }

            public int EvenOdd()
            {
                if (count == 6)
                {
                    return _aggregate._e;
                }
                switch (++count)
                {
                    case 1: return _aggregate._b;
                    case 2: return _aggregate._d;
                    case 3: return _aggregate._f;
                    case 4: return _aggregate._a;
                    case 5: return _aggregate._c;
                    case 6: return _aggregate._e;
                    default: throw new Exception();
                }
            }

           
        }

        static void Main(string[] args)
        {
            Car car = new Car() { isEngineWorking = true, isFuel = true, MaxSpeed = 100 };
            
            Vehicle vehicle = car;
            Vehicle anotherVehicle = new Bicycle();
            Vehicle[] vehicles = new Vehicle[3];
            vehicles[0] = car;
            vehicles[1] = anotherVehicle;
            vehicles[2] = new Car();

            foreach (Vehicle v in vehicles)
            {
                Console.WriteLine(v);
                Console.WriteLine(v.Drive(14));
                if (v is Car)
                {
                 
                    Car currentCar = (Car)v;
                    Console.WriteLine(currentCar.isEngineWorking);
                }
            }

        


            Console.WriteLine();
            Console.WriteLine("Int iteration");
            IAggregate aggregate = new IntAggregate();
            IIterator iterator = aggregate.createIterator();
            while (iterator.HasNext())
            {
                Console.WriteLine(iterator.GetNext());
            }
            List<string> names = new List<string>()
            {
                "Adam",
                "Ewa",
                "Karol"
            };


            Console.WriteLine();
            Console.WriteLine("List iteration");
            List<string>.Enumerator enumerator = names.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
          

            //CW1
            ElectricScooter test = new ElectricScooter() { Weight = 50, MaxSpeed = 60, isBrake = true, isLight = true };
            Console.WriteLine(test);
            Console.WriteLine(test.BetteryLevel());
            test.RechargeBattery();
            Console.WriteLine(test.BetteryLevel());
            Console.WriteLine(test.Drive(5));
            Console.WriteLine(test.BetteryLevel());
            Console.WriteLine();

            //CW2
            IFlyable[] flyable = new IFlyable[3];
            flyable[0] = new Duck();
            flyable[1] = new Wasp();
            flyable[2] = new HydroPlane();
            int countAll = 0;

            foreach (var f in flyable)
            {
                if (f is IFlyable && f is ISwimmingable)
                {
                    countAll++;
                    Console.WriteLine(f);
                }
            }
            if (countAll == 1 || countAll == 0)
                Console.WriteLine($"There is {countAll} elements who can fly and swim");
            else
                Console.WriteLine($"There are {countAll} elements who can fly and swim");
            Console.WriteLine();

            //CW3
            Console.WriteLine("Reverse int iteration");
            IAggregate aggregate1 = new IntAggregate();
            IIterator iterator1 = aggregate1.createIterator();
            while (iterator1.HasNext())
            {
                Console.WriteLine(iterator1.GetNextReverse());
            }
            Console.WriteLine("Even first int iteration");
            IAggregate aggregate2 = new IntAggregate();
            IIterator iterator2 = aggregate2.createIterator();
            while (iterator2.HasNext())
            {
                Console.WriteLine(iterator2.EvenOdd());
            }
            
        }
    }
}