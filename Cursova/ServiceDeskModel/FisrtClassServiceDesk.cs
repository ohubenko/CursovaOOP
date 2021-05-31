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

        void register(Passanger passanger, Queue<Passanger> passangersFoWaitngs)
        {
            if (passanger.getClassPassanger() == AirlineClass.FIST)
            {
                var registerTime = new Random().Next(1_000,30_000);
                Thread.Sleep(registerTime);
                passangersFoWaitngs.Enqueue(passanger);
            }
        }
    }
}