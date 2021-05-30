using System;
using System.Collections.Generic;

namespace Cursova
{
    public abstract class AbstractServiceDesk : ServiceFrontDesk
    {
        protected Stewardess Stewardess;
        protected static Random _random = new Random();
        protected Queue<Human> Humans;

        public int sizeQueue()
        {
            return Humans.Count;
        }

        public void add(Human human)
        {
            Humans.Enqueue(human);
        }

        public bool isWorked()
        {
            return Stewardess != null;
        }

        public void setStewaredss(Stewardess stewardess)
        {
            Stewardess = stewardess;
        }

        public async void startWork()
        {
            while (isWorked() && Humans.Count > 0)
            {
                AirlineClass @class = genearateAirlineClass();
                Passanger passanger = PassangerFactory.servicePassanger(Humans.Dequeue(), @class);
                
            }
        }

        private AirlineClass genearateAirlineClass()
        {
            return _random.Next(1, 2) switch
            {
                1 => AirlineClass.FIST,
                2 => AirlineClass.SECOND,
                _ => AirlineClass.SECOND
            };
        }

        private static class PassangerFactory
        {
            public static Passanger servicePassanger(Human human, AirlineClass @class)
            {
                Ticket ticket = new Ticket(@class);
                return @class switch
                {
                    AirlineClass.FIST => new FirstclassPassanger(human, ticket),
                    AirlineClass.SECOND => new SecondclassPassanger(human, ticket),
                    _ => new SecondclassPassanger(human, ticket)
                };
            }
        }
    }
}