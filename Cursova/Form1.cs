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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var thread = new Thread(o => { airport.process(); });
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
        }

        private void totalRegisterPassanger_Click(object sender, EventArgs e)
        {
            avgTimeRegister.Text = StatisticStorage.getAvgRegisterTime().ToString(CultureInfo.CurrentCulture);
            maxTimeReg.Text = StatisticStorage.getMaximumRegisterTime().ToString();
        }


        private async void countOfAirplane_TextChanged(object sender, EventArgs e)
        {
            // var thread = new Thread(o => { airport.arrival(); });
            // thread.Start();
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
    }
}