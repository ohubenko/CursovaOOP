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
        private static Label countAirplane;
        private static Label countQueueHuman;
        private static Label skipped;
        private static Timer airplaneTimer;
        private static Timer passangerTimer;

        public static async Task generateAirplane(Queue<Airplane> queue, Label label)
        {
            countAirplane = label;
            TimerCallback timerCallback = addAirplane;
            airplaneTimer = new Timer(timerCallback, queue, 0, 1000);
        }

        public static async Task generatePassanger(List<ServiceFrontDesk> desks, Label label, Label skipped)
        {
            //TODO: add ограніченіє
            countQueueHuman = label;
            Generator.skipped = skipped;
            TimerCallback timerCallback = addHuman;
            airplaneTimer = new Timer(timerCallback, desks, 0, 15_000);
        }

        private static void addAirplane(object? state)
        {
            Queue<Airplane> airplanes = (Queue<Airplane>) state;
            if (airplanes != null)
            {
                countAirplane.Text = airplanes.Count.ToString();
                if (airplanes.Count < 10)
                {
                    airplanes.Enqueue(new Airplane(new Random().Next(999, 9999).ToString()));
                }
            }
        }

        private static void addHuman(object? state)
        {
            List<ServiceFrontDesk> desks = (List<ServiceFrontDesk>) state;
            if (desks != null && desks.Count > 0)
            {
                ServiceFrontDesk minimalDesk = desks.OrderBy(desk => desk.sizeQueue()).First();
                minimalDesk.add(new Human("Passanger", "random"));
                countQueueHuman.Text = desks.Sum(desk => desk.sizeQueue()).ToString();
            }
            else
            {
                var i = int.Parse(skipped.Text);
                i++;
                skipped.Text = i.ToString();
            }
        }

        public static async void stopAirplaneGenerate()
        {
            await airplaneTimer.DisposeAsync();
        }

        public static async void stopHumanGenerate()
        {
            await passangerTimer.DisposeAsync();
        }
    }
}