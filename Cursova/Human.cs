namespace Cursova
{
    public class Human
    {
        protected string first_name;
        protected string last_name;

        public string FirstName => first_name;

        public string LastName => last_name;

        public Human(string firstName, string lastName)
        {
            first_name = firstName;
            last_name = lastName;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}