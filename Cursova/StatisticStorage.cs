using System.Collections.Generic;
using System.Linq;

namespace Cursova
{
    public class StatisticStorage
    {
        private static List<int> sellTime;
        private static List<int> registerTime;

        public static void addSelltime(int time) => sellTime.Add(time);
        public static void addRegisterTime(int time) => registerTime.Add(time);

        public static double getAvgSellTime() => sellTime.Average();
        public static double getAvgRegisterTime() => registerTime.Average();

        public static int getMaximumSellTime() => sellTime.Max();
        public static int getMaximumRegisterTime() => sellTime.Max();
    }
}