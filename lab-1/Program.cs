using System;

namespace lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = Person.Of("");

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
        }

                    class Person
                    {
            
                        private Person(string name)
                        {
                            _Name = name;
                        }
            
                        public static  Person Of(string name)
                        {

                            if(name !=null && name.Length >= 2)
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
                                if(value != null  && value.Length >= 2)
                                {
                                    _Name = value;
                                }else
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


            public static Money? Of(decimal value, Currency currency)
            {
                return value < 0 ? null : new Money(value, currency);
            }



        }

    }



}
