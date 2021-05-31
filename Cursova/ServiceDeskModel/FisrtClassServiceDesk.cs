using System;
using System.Collections.Generic;
using System.Threading;

namespace Cursova
{
    public class FisrtClassServiceDesk : AbstractServiceDesk, ServiceFrontDesk
    {
        public FisrtClassServiceDesk(Stewardess stewardess) : base(stewardess)
        {
        }

        public void register(Passanger passanger, Queue<Passanger> passangersFoWaitngs)
        {
            if (passanger.getClassPassanger() == AirlineClass.FIST)
            {
                var registerTime = new Random().Next(1_000, 30_000);
                StatisticStorage.addRegisterTime(registerTime);
                Thread.Sleep(registerTime);
                passangersFoWaitngs.Enqueue(passanger);
            }
            else
            {
                var timeService = _random.Next(1000, 60_000);
                StatisticStorage.addRegisterTime(timeService);
                Thread.Sleep(timeService);
                passangersFoWaitngs.Enqueue(passanger);
            }
        }
    }
}