using static System.Console;

namespace Cursova
{
    public abstract class AbstractPassanger : Human, Passanger
    {
        protected Ticket Ticket;

        public AbstractPassanger(string firstName, string lastName, Ticket ticket) : base(firstName, lastName)
        {
            Ticket = ticket;
        }

        protected AbstractPassanger(Human human, Ticket ticket) : base(human.FirstName, human.LastName)
        {
            Ticket = ticket;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, ticket:{Ticket}";
        }

        public void BuyTicket()
        {
            WriteLine("Ticket has been buy");
        }
    }
}