using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Cursova
{
    public interface ServiceFrontDesk
    {
        int sizeQueue();
        void add(Human passanger);
        bool isWorked();
        void setStewaredss(Stewardess stewardess);
        void sellTicket(ConcurrentQueue<Passanger> _passangersForWait);
        void register(Passanger passanger, Queue<Passanger> passangersFoWaitngs);
    }
}