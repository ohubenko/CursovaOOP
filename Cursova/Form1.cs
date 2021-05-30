using System;
using System.Threading;
using System.Windows.Forms;

namespace Cursova
{
    public partial class Form1 : Form
    {
        Airport airport = new Airport();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var thread = new Thread(o =>
            {
                airport.process(countOfAirplane);
            });
            thread.IsBackground = true;
            thread.Start();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            airport.poshe();
        }
        
    }
}