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
    public partial class serversChart : Form
    {
        public serversChart()
        {
            InitializeComponent();
        }

        private void serversChart_Load(object sender, EventArgs e)
        {

        }
        //btshuf able kan fady emta w tedy value be zero w lw msh fady tedy value be one 
        public void plotChartAble(int [] ableCustomers,int ableCustNum,int [] beginService , int [] endService,int custnum)
        {

            chart1.BackColor = SystemColors.Highlight;
            chart1.Series.Add("Server Busy Time - Able");

            chart1.Series["Server Busy Time - Able"].SetDefault(true);
            chart1.Series["Server Busy Time - Able"].Enabled = true;

            chart1.ChartAreas[0].AxisX.Minimum = 1;
            chart1.ChartAreas[0].AxisX.Maximum = endService[custnum];
            chart1.ChartAreas[0].AxisX.Interval = 1;

            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 1;
            chart1.ChartAreas[0].AxisY.Interval = 1;


            chart1.Visible = true;
            int first, second;
            bool idle = true;

            for (int q = 0; q <= endService[custnum]; q++)
            {
                idle = true;

                for (int i = 0; i < ableCustNum; i++)
                {
                    if (beginService[ableCustomers[i]] <= q && endService[ableCustomers[i]] >= q)
                    {

                        idle = false;
                        break;
                    }

                }
                    if (idle == false)
                    {
                        first = q;
                        second = 1;
                        chart1.Series["Server Busy Time - Able"].Points.AddXY(first, second);
                    }
                    else
                    {
                        first = q;
                        second = 0;
                        chart1.Series["Server Busy Time - Able"].Points.AddXY(first, second);
                    }
                
            }

            Controls.Add(chart1);


        }

        //btshuf baker kan fady emta w tedy value be zero w lw msh fady tedy value be one 
        public void plotChartBaker(int[] bakerCustomers, int bakerCustNum, int[] beginService, int[] endService, int custnum)
        {

            chart2.BackColor = SystemColors.Highlight;
            chart2.Series.Add("Server Busy Time - Baker");

            chart2.Series["Server Busy Time - Baker"].SetDefault(true);
            chart2.Series["Server Busy Time - Baker"].Enabled = true;

            chart2.ChartAreas[0].AxisX.Minimum = 1;
            chart2.ChartAreas[0].AxisX.Maximum = endService[custnum];
            chart2.ChartAreas[0].AxisX.Interval = 1;

            chart2.ChartAreas[0].AxisY.Minimum = 0;
            chart2.ChartAreas[0].AxisY.Maximum = 1;
            chart2.ChartAreas[0].AxisY.Interval = 1;


            chart2.Visible = true;
            int first, second;
            bool idle = true;

            for (int q = 0; q <= endService[custnum]; q++)
            {
                idle = true;

                for (int i = 0; i < bakerCustNum; i++)
                {
                    if (beginService[bakerCustomers[i]] <= q && endService[bakerCustomers[i]] >= q)
                    {

                        idle = false;
                        break;
                    }

                }
                if (idle == false)
                {
                    first = q;
                    second = 1;
                    chart2.Series["Server Busy Time - Baker"].Points.AddXY(first, second);
                }
                else
                {
                    first = q;
                    second = 0;
                    chart2.Series["Server Busy Time - Baker"].Points.AddXY(first, second);
                }

            }

            Controls.Add(chart2);


        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }
    }
}
