namespace Cursova
{
    public class SecondclassPassanger : AbstractPassanger
    {
        public SecondclassPassanger(string firstName, string lastName, Ticket ticket) : base(firstName, lastName, ticket)
        {
        }
        public SecondclassPassanger(Human human, Ticket ticket) : base(human, ticket)
        {
        }
    }
}