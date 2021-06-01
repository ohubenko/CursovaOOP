namespace Cursova
{
    public class Stewardess : Human
    {
        public Stewardess(string firstName, string lastName) : base(firstName, lastName)
        {
        }

        public override bool canBuyTicket(Ticket ticket)
        {
            double neeedPay = ticket.Cost * 0.6;
            return ballance >= neeedPay;
        }
    }
}