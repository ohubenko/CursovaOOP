using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

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

        public void sellTicket(Queue<Passanger> _passangersForWait)
        {
            while (isWorked())
            {
                if (Humans.Count > 0)
                {
                    AirlineClass @class = genearateAirlineClass();
                    var timeService = _random.Next(1000, 60_000);
                    StatisticStorage.addSelltime(timeService);
                    Thread.Sleep(timeService);
                    Passanger passanger = PassangerFactory.servicePassanger(Humans.Dequeue(), @class);
                    _passangersForWait.Enqueue(passanger);
                }
            }
        }

        public void register(Passanger passanger, Queue<Passanger> passangersFoWaitngs)
        {
            var timeService = _random.Next(1000, 60_000);
            StatisticStorage.addRegisterTime(timeService);
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