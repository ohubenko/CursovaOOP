namespace Cursova
{
    public static class PassangerFactory
    {
        public static Passanger servicePassanger(Human human, AirlineClass @class)
        {
            Ticket ticket = new Ticket(@class);
            return @class switch
            {
                AirlineClass.FIST => new FirstclassPassanger(human, ticket),
                AirlineClass.SECOND => new SecondclassPassanger(human, ticket),
                _ => new SecondclassPassanger(human, ticket)
            };
        }
    }
}