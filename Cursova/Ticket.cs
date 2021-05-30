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
        
        /// <value>Номер літака</value>>
        private int _planeNumber;

        public Ticket(AirlineClass @class, double cost, int planeNumber)
        {
            TiecktId = counter;
            _class = @class;
            this.cost = cost;
            _planeNumber = planeNumber;
            counter++;
        }

        public Ticket()
        {
            _planeNumber = 0;
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