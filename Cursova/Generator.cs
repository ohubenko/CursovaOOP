using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Threading.Timer;

namespace Cursova
{
    public class Generator
    {
        private static Label _countAirplane;
        private static Label _countQueueHuman;
        private static Label _skipped;
        
        private static Timer _airplaneTimer;
        private static Timer _passangerTimer;

        public static async Task GenerateAirplane(Queue<Airplane> queue, Label label)
        {
            _countAirplane = label;
            TimerCallback timerCallback = AddAirplane;
            _airplaneTimer = new Timer(timerCallback, queue, 0, 1000);
        }

        public static async Task GeneratePassanger(List<ServiceFrontDesk> desks, Label label, Label skipped)
        {
            //TODO: add ограніченіє
            _countQueueHuman = label;
            _skipped = skipped;
            TimerCallback timerCallback = AddHuman;
            _passangerTimer = new Timer(timerCallback, desks, 0, 15_000);
        }

        private static void AddAirplane(object? state)
        {
            Queue<Airplane> airplanes = (Queue<Airplane>) state;
            if (airplanes != null)
            {
                _countAirplane.Text = airplanes.Count.ToString();
                if (airplanes.Count < 10)
                {
                    airplanes.Enqueue(new Airplane(new Random().Next(999, 9999).ToString()));
                }
            }
        }

        private static void AddHuman(object? state)
        {
            List<ServiceFrontDesk> desks = (List<ServiceFrontDesk>) state;
            if (desks != null && desks.Count > 0)
            {
                ServiceFrontDesk minimalDesk = desks.OrderBy(desk => desk.sizeQueue()).First();
                minimalDesk.add(new Human("Passanger", "random"));
                _countQueueHuman.Text = desks.Sum(desk => desk.sizeQueue()).ToString();
            }
            else
            {
                var i = int.Parse(_skipped.Text);
                i++;
                _skipped.Text = i.ToString();
            }
        }

        public static async void StopAirplaneGenerate()
        {
            await _airplaneTimer.DisposeAsync();
        }

        public static async void StopHumanGenerate()
        {
            await _passangerTimer.DisposeAsync();
        }
    }
}