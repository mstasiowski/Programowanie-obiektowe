using System;
using System.Collections;
using System.Collections.Generic;

namespace lab_5
{
    class Parking: IEnumerable<string>
    {
        private string[] _cars = { "Fiat", "Audi", "BMW" };
        public string this[char index]
        {
            //indeks jako litery alfabetu A,B,C itd.
            get { return _cars[index - 'a']; }
            set { _cars[index - 'a'] = value; }
        }

        public IEnumerator<string> GetEnumerator()
        {
            foreach(string car in _cars)
            { if(car != null)
                {
                    yield return car;

                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    internal class Program
    {
        class Team: IEnumerable<string>
        {
            public string Leader { get; init; }
            public string ScrumMaster { get; init; }    
            public string Developer { get; init; }

            public IEnumerator<string> GetEnumerator()
            {
               yield return Leader; //dla pierwszego wywolania MoveNext
                yield return ScrumMaster; //dla drugiego wywolania MoveNext
                yield return Developer; //dla trzeciego wywolania MoveNext
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return new GetEnumerator();
            }

            class TeamEnumerator : IEnumerator<string>
            {
                private Team _team;
                private int _count = -1;

                public TeamEnumerator(Team team)
                {
                    _team = team;
                }

                public string Current
                {
                    get 
                    {
                    
                    }
                    return _count switch 
                        {
                            0=> _team.Leader,
                            1=> _team.ScrumMaster,
                            2=> _team.Developer,
                            _ => null 
                            };
                };


                string IEnumerator<string>.Current => throw new NotImplementedException();

                object IEnumerator.Current => throw new NotImplementedException();

                void IDisposable.Dispose()
                {
                    throw new NotImplementedException();
                }

                bool IEnumerator.MoveNext()
                {
                    return ++_count < 3;
                }

                void IEnumerator.Reset()
                {
                     _count = -1;
                }
            }
        }
        static void Main(string[] args)
        {
            Team team = new Team() { Leader = "Nowak", Developer = "Kos", ScrumMaster = "Marzec" };
            IEnumerator<string> members = team.GetEnumerator();
            while (members.MoveNext())
            {
                Console.WriteLine(members.Current);
            }

           // members.Reset();
            foreach(string mem in team)
            {
                Console.WriteLine(mem);
            }
            Console.WriteLine(string.Join(",", team);
            Parking parking = new Parking();
            Console.WriteLine(string.Join(", ", parking));
        }
    }
}
