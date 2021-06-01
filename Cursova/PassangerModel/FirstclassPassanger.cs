namespace Cursova
{
    public class FirstclassPassanger : AbstractPassanger
    {
        public FirstclassPassanger(string firstName, string lastName, Ticket ticket) : base(firstName, lastName, ticket)
        {
        }

        public FirstclassPassanger(Human human, Ticket ticket) : base(human, ticket)
        {
        }
    }
}