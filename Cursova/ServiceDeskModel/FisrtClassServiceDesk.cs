using System.Collections.Generic;

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
                
            }
        }
    }
}