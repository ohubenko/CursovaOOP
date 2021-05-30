namespace Cursova
{
    public class Airplane
    {
        public string Model;

        public Airplane(string model)
        {
            Model = model;
        }

        public override string ToString()
        {
            return $"Airplane:{Model}";
        }
    }
}