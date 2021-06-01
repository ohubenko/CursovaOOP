using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace Cursova
{
    public partial class Form1 : Form
    {
        Airport airport;

        public Form1()
        {
            InitializeComponent();
            airport = new Airport(countOfAirplane, stewardessCount, serviceTableCount, countFirstClassServiceTable,
                countSecondClassServiceTable, totalHumanQeue, skippedHuman);
            chooseTypeServiceDesk.SelectedIndex = 1;
            StatisticStorage.setTotalSellLabel(totalSellTicket);
            StatisticStorage.setTotalFlyingLabel(totalFlyingPassanger);
            StatisticStorage.setTotalRegisterLabel(totalRegisterPassanger);
            airport.CriticalSize = 10;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var thread = new Thread(o => { airport.process(); });
            thread.Name = "Genearator";
            thread.IsBackground = true;
            thread.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            airport.StartPlane();
        }

        private void addServiceDesk_Click(object sender, EventArgs e)
        {
            airport.AddServiceDesk(chooseTypeServiceDesk.SelectedIndex);
        }

        private void addStewardess_Click(object sender, EventArgs e)
        {
            airport.AddStewardes();
        }

        private void stopAirplaneGenerate_Click(object sender, EventArgs e)
        {
            Generator.StopAirplaneGenerate();
        }

        private void addHumanToQeue_Click(object sender, EventArgs e)
        {
            airport.AddHuman();
        }

        private void totalSellTicket_TextChanged(object sender, EventArgs e)
        {
            avgSellTime.Text = StatisticStorage.getAvgSellTime().ToString(CultureInfo.CurrentCulture);
            maxTimeSell.Text = StatisticStorage.getMaximumSellTime().ToString();
            totalHumanQeue.Text = airport.GetTotalSizeQueueToDesks().ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Generator.StopHumanGenerate();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            await airport.StartGenerationHuman();
        }


        private async void button4_Click(object sender, EventArgs e)
        {
            await airport.StartGenerationAirplane();
        }

        private void start_Click(object sender, EventArgs e)
        {
            airport.startSell();
            var thread = new Thread(() =>
            {
                while (true)
                {
                    avgTimeRegister.Invoke(new Action(() =>
                        avgTimeRegister.Text =
                            StatisticStorage.getAvgRegisterTime().ToString(CultureInfo.CurrentCulture)
                    ));
                    maxTimeReg.Invoke(new Action(() =>
                        maxTimeReg.Text = StatisticStorage.getMaximumRegisterTime().ToString()));
                    Thread.Sleep(3_000);
                }
            });
            thread.IsBackground = true;
            thread.Start();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            airport.CriticalSize = int.Parse(textBox1.Text);
            Generator.CriticalSize = int.Parse(textBox1.Text);
        }
    }
}