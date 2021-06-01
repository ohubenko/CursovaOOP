namespace Cursova
{
    public static class PassangerFactory
    {
        public static Passanger servicePassanger(Human human, Ticket ticket)
        {
            return ticket.Class switch
            {
                AirlineClass.FIRST => new FirstclassPassanger(human, ticket),
                AirlineClass.SECOND => new SecondclassPassanger(human, ticket),
                _ => new SecondclassPassanger(human, ticket)
            };
        }
    }
}