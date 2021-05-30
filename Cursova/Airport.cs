using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace Cursova
{
    public class Airport
    {
        private List<ServiceFrontDesk> _frontDesks;
        private Queue<Passanger> _passangersForWait;
        private Queue<Airplane> _airplanes = new Queue<Airplane>();
        private Queue<Stewardess> _stewardesses;
        private Label _label;
        public async void process(Label label)
        {
            _label = label;
            await Generator.generateAirplane(_airplanes,label);
            Thread.Sleep(5000);
        }

        public int getCountAirPlane()
        {
            return _airplanes.Count;
        }

        public void poshe()
        {
            _airplanes.Dequeue();
            var i = Int32.Parse(_label.Text);
            i--;
            _label.Text = i.ToString();
        }
    }
}