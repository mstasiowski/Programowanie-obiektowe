﻿using System;

namespace lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = Person.Of("sdasdsadsa");

            Console.WriteLine(person);

            DateTime dateTime = DateTime.Parse("03-02-2022");
            Console.WriteLine(dateTime);

            DateTime newDate = dateTime.AddDays(2);
            Console.WriteLine(newDate + " " + dateTime);
            //6 = 2 + 4

            string name = "adam";
            string name1 = "adam";
            string v = name.Substring(0, 2);
            Console.WriteLine(name1 == name);

            Money money = Money.Of(10, Currency.PLN);
            //money * 5 -> *(money, 5)
            Money result = 5.2m * money;
            Console.WriteLine(result.Value);
            Money sum = money + result;
            Console.WriteLine(sum.Value);
            Console.WriteLine(sum < money);
            Console.WriteLine(money == Money.Of(10, Currency.PLN));
            Console.WriteLine(money != Money.Of(10, Currency.PLN));

            long a = 10L;
            a = 10000000;
            int b = 5;
            a = b;
            b = (int) a;


            //operator rzutowania
            decimal amount = money;
            double cost = (double) money;
            float price = (float)money;
            Console.WriteLine(amount);
            Console.WriteLine(cost);

            //ToString
            Console.WriteLine(money);

        }

        class Person
        {

            private Person(string name)
            {
                _Name = name;
            }

            public static Person Of(string name)
            {

                if (name != null && name.Length >= 2)
                {
                    return new Person(name);
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Imię zbyt krótkie!");
                }

            }

            private string _Name;
            public string Name
            {
                get
                {
                    return _Name;
                }

                set
                {
                    if (value != null && value.Length >= 2)
                    {
                        _Name = value;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Imię zbyt krótkie !");
                    }
                }
            }
        }


        public enum Currency
        {
            PLN = 1,
            USD = 2,
            EUR = 3
        }

        public class Money
        {
            private readonly decimal _value;
            private readonly Currency _currency;
            private Money(decimal value, Currency currency)
            {
                _value = value;
                _currency = currency;
            }

            public decimal Value
            {
                get
                {
                    return _value;
                }
            }

            public Currency Currency
            {
                get
                {
                    return _currency;
                }
            }




            public static Money? Of(decimal value, Currency currency)
            {
                return value < 0 ? null : new Money(value, currency);
            }

            public static Money operator *(Money a, decimal b)
            {
                return Money.Of(a._value * b, a._currency);
            }
            //aby mnożyc 5* money musimy ten public operator nowy napisać

            public static Money operator *(decimal b, Money a)
            {
                return Money.Of(a._value * b, a._currency);
            }

            public static bool operator >(Money a, Money b)
            {
                return a.Value > b.Value;
            }

            public static bool operator <(Money a, Money b)
            {
                return a.Value > b.Value;
            }


            public static bool operator ==(Money a, Money b)
            {
                return a.Value == b.Value && a.Currency == b.Currency;
            }

            public static bool operator !=(Money a, Money b)
            {
                return !(a == b);

            }


            public static implicit operator decimal(Money money)
            {
                return money.Value;
            }
            public static explicit operator double(Money money)
            {
                return (double)money.Value;
            }

            public static explicit operator float(Money money)
            {
                return (float)money.Value;
            }



        }
        //  lab1 zadanie 8, 9 do domu

      

    }



}
