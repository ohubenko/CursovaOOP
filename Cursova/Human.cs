using System;

namespace Cursova
{
    public class Human
    {
        protected string first_name;
        protected string last_name;
        protected int ballance;

        public string FirstName => first_name;

        public string LastName => last_name;

        public Human(string firstName, string lastName)
        {
            first_name = firstName;
            last_name = lastName;
            ballance = new Random().Next(1000) + 500;
        }

        public virtual bool canBuyTicket(Ticket ticket)
        {
            double neeedPay = ticket.Cost * 1.0;
            return ballance >= neeedPay;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}