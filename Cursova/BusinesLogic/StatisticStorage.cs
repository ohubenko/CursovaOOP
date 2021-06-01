using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Cursova
{
    public class StatisticStorage
    {
        private static List<int> sellTime = new List<int>();
        private static List<int> registerTime = new List<int>();
        private static Label totalSell;
        private static Label totalFlying;
        private static Label totalRegister;

        public static void setTotalSellLabel(Label label)
        {
            totalSell = label;
        }

        public static void addTotalSell()
        {
            var i = int.Parse(totalSell.Text);
            i++;
            totalSell.Invoke(new Action(() => { totalSell.Text = i.ToString(); }));
        }

        public static void setTotalFlyingLabel(Label label)
        {
            totalFlying = label;
        }

        public static void addTotalFlying(int i)
        {
            totalFlying.Invoke(new Action(() => { totalFlying.Text = i.ToString(); }));
        }

        public static void setTotalRegisterLabel(Label label)
        {
            totalRegister = label;
        }

        public static void addTotalRegister()
        {
            var i = int.Parse(totalRegister.Text);
            i++;
            totalRegister.Invoke(new Action(() => { totalSell.Text = i.ToString(); }));
        }

        public static void addSelltime(int time) => sellTime.Add(time);
        public static void addRegisterTime(int time) => registerTime.Add(time);

        public static double getAvgSellTime() => sellTime.Average();
        public static double getAvgRegisterTime() => registerTime.Count > 0 ? registerTime.Average() : 0;

        public static int getMaximumSellTime() => sellTime.Max();
        public static int getMaximumRegisterTime() => registerTime.Count > 0 ? sellTime.Max() : 0;
    }
}