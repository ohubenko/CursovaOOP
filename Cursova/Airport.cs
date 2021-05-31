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
            loadLabel(labelCountAirplane, labelCountStewardess, labelCountDesk, labelCountFirstClassDesk,
                labelCountSecondClassDesk);
            InitCollection();
        }

        private void InitCollection()
        {
            _airplanes = new Queue<Airplane>();
            _frontDesks = new List<ServiceFrontDesk>();
            _passangersForWait = new Queue<Passanger>();
            _stewardesses = new Queue<Stewardess>();
        }

        private void loadLabel(Label labelCountAirplane, Label labelCountStewardess, Label labelCountDesk,
            Label labelCountFirstClassDesk, Label labelCountSecondClassDesk)
        {
            _labelCountAirplane = labelCountAirplane;
            _labelCountStewardess = labelCountStewardess;
            _labelCountDesk = labelCountDesk;
            _labelCountFirstClassDesk = labelCountFirstClassDesk;
            _labelCountSecondClassDesk = labelCountSecondClassDesk;
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
            var i = Int32.Parse(_labelCountStewardess.Text);
            i++;
            _labelCountStewardess.Text = i.ToString();
        }

        public void addServiceDesk(int num)
        {
            if (_stewardesses.Count > 0){
                switch (num)
                {
                    case 0:
                        _frontDesks.Add(new FisrtClassServiceDesk(_stewardesses.Dequeue()));
                        changeCount(_labelCountFirstClassDesk);
                        break;
                    case 1:
                        _frontDesks.Add(new SecondClassServiceDesk(_stewardesses.Dequeue()));
                        changeCount(_labelCountSecondClassDesk);
                        break;
                    default:
                        _frontDesks.Add(new SecondClassServiceDesk(_stewardesses.Dequeue()));
                        changeCount(_labelCountSecondClassDesk);
                        break;
                }

                _labelCountDesk.Text = _frontDesks.Count.ToString();
            }
            else
            {
                MessageBox.Show("No stewardess to service this desk");
            }
        }

        private void changeCount(Label label)
        {
            var i = int.Parse(label.Text);
            i++;
            label.Text = i.ToString();
        }
    }
}