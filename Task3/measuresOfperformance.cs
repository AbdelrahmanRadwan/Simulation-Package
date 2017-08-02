using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulationTask1
{
    public partial class measuresOfperformance : Form
    {
        public measuresOfperformance()
        {
            InitializeComponent();
        }

        public void measurePerformance(double avgAble, double avgBaker, double avgWait, double maxLength,
           double probabilityOfWait, double probabilityOfIdleAble, double probabilityOfIdleBaker)
        {

            label9.Text = avgAble.ToString();
            label10.Text = avgBaker.ToString();
            label11.Text = avgWait.ToString();
            label12.Text = maxLength.ToString();
            label13.Text = probabilityOfWait.ToString();
            label14.Text = probabilityOfIdleAble.ToString();
            label15.Text = probabilityOfIdleBaker.ToString();
        }


        private void measuresOfperformance_Load(object sender, EventArgs e)
        {

        }
    }
}
