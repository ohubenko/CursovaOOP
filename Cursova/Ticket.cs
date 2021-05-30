using System;

namespace Cursova
{
    /// <summary>
    ///  Клас квитка для продажу
    /// </summary>
    public class Ticket
    {
        /// <value>Калькулятор номера квитка</value>>
        private static int counter = 0;

        /// <value>Номер квитка</value>>
        public int TiecktId;

        /// <value>Клас авіаперельоту</value>>
        private AirlineClass _class;

        /// <value>Ціна</value>>
        private double cost;


        public Ticket(AirlineClass @class, double cost)
        {
            TiecktId = counter;
            _class = @class;
            this.cost = cost;
            counter++;
        }

        public Ticket()
        {
            TiecktId = counter;
            _class = AirlineClass.SECOND;
            cost = new Random().NextDouble() * 1000;
            counter++;
        }

        public AirlineClass Class => _class;

        public double Cost => cost;


        public override string ToString()
        {
            return $"Number of ticket: {TiecktId}, airline class: {_class}, cost: {cost}$ ";
        }
    }
}