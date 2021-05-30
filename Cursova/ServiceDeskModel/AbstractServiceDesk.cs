using System;
using System.Collections.Generic;

namespace Cursova
{
    public abstract class AbstractServiceDesk : ServiceFrontDesk
    {
        protected Stewardess Stewardess;
        protected static Random _random = new Random();
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

        public async void startWork()
        {
            if (isWorked() && Humans.Count != 0)
            {
                new FirstclassPassanger("a", "a", new Ticket());
            }
        }
    }
}