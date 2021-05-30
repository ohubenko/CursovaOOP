namespace Cursova
{
    public abstract class Human
    {
        protected string FirstName;
        protected string LastName;

        protected Human(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}