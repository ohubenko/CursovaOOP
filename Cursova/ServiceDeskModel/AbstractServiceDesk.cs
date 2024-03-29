﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace Cursova
{
    public abstract class AbstractServiceDesk : ServiceFrontDesk
    {
        protected Stewardess Stewardess;
        protected static Random _random = new Random();
        protected Queue<Human> Humans;
        private static AutoResetEvent waitHendler = new AutoResetEvent(true);
        private static AutoResetEvent waitHendler2 = new AutoResetEvent(true);

        protected AbstractServiceDesk(Stewardess stewardess)
        {
            Stewardess = stewardess;
            Humans = new Queue<Human>();
        }

        public int sizeQueue() => Humans.Count;

        public void add(Human human) => Humans.Enqueue(human);

        public bool isWorked() => Stewardess != null;

        public void setStewaredss(Stewardess stewardess) => Stewardess = stewardess;

        public void sellTicket(ConcurrentQueue<Passanger> _passangersForWait)
        {
            while (isWorked())
            {
                if (Humans.Count > 0)
                {
                    waitHendler.WaitOne();
                    AirlineClass @class = genearateAirlineClass();

                    var timeService = _random.Next(1000);
                    StatisticStorage.addSelltime(timeService);
                    Human peekHuman = Humans.Dequeue();
                    Thread.Sleep(timeService);
                    Ticket ticket = new Ticket(@class);
                    if (peekHuman.canBuyTicket(ticket))
                    {
                        Passanger passanger = PassangerFactory.servicePassanger(peekHuman, ticket);
                        _passangersForWait.Enqueue(passanger);
                        StatisticStorage.addTotalSell();
                    }

                    waitHendler.Set();
                }
            }
        }

        public void register(Passanger passanger, Queue<Passanger> passangersFoWaitngs)
        {
            waitHendler2.WaitOne();
            var timeService = _random.Next(1000, 2_000);
            StatisticStorage.addRegisterTime(timeService);
            Thread.Sleep(timeService);
            passangersFoWaitngs.Enqueue(passanger);
            StatisticStorage.addTotalRegister();
            waitHendler2.Set();
        }

        private AirlineClass genearateAirlineClass()
        {
            return _random.Next(1, 2) switch
            {
                1 => AirlineClass.FIRST,
                2 => AirlineClass.SECOND,
                _ => AirlineClass.SECOND
            };
        }
    }
}