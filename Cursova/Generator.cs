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
        private static Label asdd;
        public static async Task generateAirplane(Queue<Airplane> queue, Label label)
        {
            asdd = label;
            TimerCallback timerCallback = addAirplane;
            Timer timer = new Timer(timerCallback, queue, 0, 1000);
        }

        private static void addAirplane(object? state)
        {
            Queue<Airplane> airplanes = (Queue<Airplane>) state;
            asdd.Text = (airplanes.Count).ToString();
            if (airplanes != null && airplanes.Count < 10)
            {
                airplanes.Enqueue(new Airplane(new Random().Next(999, 9999).ToString()));
            }
        }
    }
}