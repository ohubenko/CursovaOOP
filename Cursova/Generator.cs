using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Threading.Timer;

namespace Cursova
{
    public class Generator
    {
        private static Label countAirplane;
        private static Timer airplaneTimer;
        private static Timer passangerTimer;
        public static async Task generateAirplane(Queue<Airplane> queue, Label label)
        {
            countAirplane = label;
            TimerCallback timerCallback = addAirplane;
            airplaneTimer = new Timer(timerCallback, queue, 0, 1000);
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

        public static async void stopAirplaneGenerate()
        {
            await airplaneTimer.DisposeAsync();
        }
    }
}