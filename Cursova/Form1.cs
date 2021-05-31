using System;
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
                countSecondClassServiceTable);
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
            airport.startPlane();
        }

        private void addServiceDesk_Click(object sender, EventArgs e)
        {
            airport.addServiceDesk(chooseTypeServiceDesk.SelectedIndex);
        }

        private void addStewardess_Click(object sender, EventArgs e)
        {
            airport.addStewardes();
        }

        private void stopAirplaneGenerate_Click(object sender, EventArgs e)
        {
            Generator.stopAirplaneGenerate();
        }
    }
}