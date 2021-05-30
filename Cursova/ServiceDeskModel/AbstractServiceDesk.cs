using System;
using System.Collections.Generic;
using System.Threading;

namespace Cursova
{
    public abstract class AbstractServiceDesk : ServiceFrontDesk
    {
        protected Stewardess Stewardess;
        protected static Random _random = new Random();
        protected Queue<Human> Humans;

        public int sizeQueue() => Humans.Count;

        public void add(Human human) => Humans.Enqueue(human);

        public bool isWorked() => Stewardess != null;

        public void setStewaredss(Stewardess stewardess) => Stewardess = stewardess;

        public async void startWork()
        {
            while (isWorked() && Humans.Count > 0)
            {
                AirlineClass @class = genearateAirlineClass();
                Passanger passanger = PassangerFactory.servicePassanger(Humans.Dequeue(), @class);
                var timeService = _random.Next(1000, 60_000);
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
    }
}