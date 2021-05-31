﻿using System.Collections.Generic;

namespace Cursova
{
    public interface ServiceFrontDesk
    {
        int sizeQueue();
        void add(Human passanger);
        bool isWorked();
        void setStewaredss(Stewardess stewardess);
        void sellTicket(Queue<Passanger> _passangersForWait);
        void register(Passanger passanger, Queue<Passanger> passangersFoWaitngs);
    }
}