using System.Collections.Generic;

namespace Cursova
{
    public abstract class AbstractServiceDesk : ServiceFrontDesk
    {
        protected Stewardess Stewardess;
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

        public void startWork()
        {
            //TODO: Обслуговування черги
            throw new System.NotImplementedException();
        }
    }
}