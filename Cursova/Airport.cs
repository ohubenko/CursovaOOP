using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace Cursova
{
    public class Airport
    {
        private List<ServiceFrontDesk> _frontDesks;
        private Queue<Passanger> _passangersForWait;
        private Queue<Airplane> _airplanes;
        private Queue<Stewardess> _stewardesses;
        private Label _labelCountAirplane;
        private Label _labelCountStewardess;
        private Label _labelCountDesk;
        private Label _labelCountFirstClassDesk;
        private Label _labelCountSecondClassDesk;

        public Airport(Label labelCountAirplane, Label labelCountStewardess, Label labelCountDesk,
            Label labelCountFirstClassDesk, Label labelCountSecondClassDesk)
        {
            _labelCountAirplane = labelCountAirplane;
            _labelCountStewardess = labelCountStewardess;
            _labelCountDesk = labelCountDesk;
            _labelCountFirstClassDesk = labelCountFirstClassDesk;
            _labelCountSecondClassDesk = labelCountSecondClassDesk;
            _airplanes = new Queue<Airplane>();
            _frontDesks = new List<ServiceFrontDesk>();
            _passangersForWait = new Queue<Passanger>();
            _stewardesses = new Queue<Stewardess>();
        }

        public async void process()
        {
            await Generator.generateAirplane(_airplanes, _labelCountAirplane);
            Thread.Sleep(5000);
        }

        public int getCountAirPlane()
        {
            return _airplanes.Count;
        }

        public void startPlane()
        {
            _airplanes.Dequeue();
            var i = Int32.Parse(_labelCountAirplane.Text);
            i--;
            _labelCountAirplane.Text = i.ToString();
        }

        public void addStewardes()
        {
            Stewardess stewardess = new Stewardess("Stewardess", "Worker");
            _stewardesses.Enqueue(stewardess);
        }

        public void addServiceDesk(int num)
        {
            if (_stewardesses.Count > 0)
                switch (num)
                {
                    case 0:
                        _frontDesks.Add(new FisrtClassServiceDesk(_stewardesses.Dequeue()));
                        break;
                    case 1:
                        _frontDesks.Add(new SecondClassServiceDesk(_stewardesses.Dequeue()));
                        break;
                    default:
                        _frontDesks.Add(new SecondClassServiceDesk(_stewardesses.Dequeue()));
                        break;
                }
            else
            {
                MessageBox.Show("No stewardess to service this desk");
            }
        }
    }
}