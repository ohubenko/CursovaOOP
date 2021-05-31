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

        protected AbstractServiceDesk(Stewardess stewardess)
        {
            Stewardess = stewardess;
            Humans = new Queue<Human>();
        }

        public int sizeQueue() => Humans.Count;

        public void add(Human human) => Humans.Enqueue(human);

        public bool isWorked() => Stewardess != null;

        public void setStewaredss(Stewardess stewardess) => Stewardess = stewardess;

        public void sellTicket()
        {
            while (isWorked() && Humans.Count > 0)
            {
                AirlineClass @class = genearateAirlineClass();
                var timeService = _random.Next(1000, 60_000);
                Thread.Sleep(timeService);
                Passanger passanger = PassangerFactory.servicePassanger(Humans.Dequeue(), @class);
            }
        }

        public void register(Passanger passanger, Queue<Passanger> passangersFoWaitngs)
        {
            var timeService = _random.Next(1000, 60_000);
            Thread.Sleep(timeService);
            passangersFoWaitngs.Enqueue(passanger);
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