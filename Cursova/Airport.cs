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
        private Label _labelCountAirplane;
        
        public async void process(Label label)
        {
            _labelCountAirplane = label;
            await Generator.generateAirplane(_airplanes,label);
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
            
        }
    }
}