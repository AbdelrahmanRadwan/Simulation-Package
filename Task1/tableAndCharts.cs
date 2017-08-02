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
    public partial class tableAndCharts : Form
    {
        public tableAndCharts()
        {
            InitializeComponent();
        }

        private void tableAndCharts_Load(object sender, EventArgs e)
        {

        }
        //b-plot el table 
        public void simulate(int customerNumber, double rnd1, int interArrivalTime, int arrivalTime, int serverIndex, int timeServiceBegin, double rnd2, int serviceDur, int timeServiceEnd, int totalDelay)
        {

            dataGridView1.ColumnCount = 10;
            dataGridView1.Columns[0].Name = "Customer Number";
            dataGridView1.Columns[1].Name = "random number";
            dataGridView1.Columns[2].Name = "Inter-Arrival Time";
            dataGridView1.Columns[3].Name = "Arrival Time";
            dataGridView1.Columns[4].Name = "Server Index";
            dataGridView1.Columns[5].Name = "Time Service Begins";
            dataGridView1.Columns[6].Name = "random number";
            dataGridView1.Columns[7].Name = "Service Time";
            dataGridView1.Columns[8].Name = "Time Service Ends";
            dataGridView1.Columns[9].Name = "Total Delay";

            string[] row = new string[] { customerNumber.ToString(), 
                                           rnd1.ToString(),
                                          interArrivalTime.ToString(),
                                          arrivalTime.ToString(),
                                          serverIndex.ToString(),
                                          timeServiceBegin.ToString(),
                                          rnd2.ToString(),
                                          serviceDur.ToString(),
                                          timeServiceEnd.ToString(),
                                          totalDelay.ToString()};

            dataGridView1.Rows.Add(row);

        }

        //bn-plot el customers quque "bt3ml zay el QueueSimulation bt3meloh bs btersemo kolo msh el max bs 
        public void plotChart(int end, int[] timeServiceBegin, int[] arrivalTime,int numCust)
        {

            chart1.BackColor = SystemColors.Highlight;
            chart1.Series.Add("Customers Queue Graph");

            chart1.Series["Customers Queue Graph"].SetDefault(true);
            chart1.Series["Customers Queue Graph"].Enabled = true;

            chart1.ChartAreas[0].AxisX.Minimum = 1;
            chart1.ChartAreas[0].AxisX.Maximum = end;
            chart1.ChartAreas[0].AxisX.Interval = 1;

            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 10;
            chart1.ChartAreas[0].AxisY.Interval = 1;


            chart1.Visible = true;
            int  numWaiting;
           
            for (int q = 0; q < end; q++)
            {
                numWaiting = 0;
                
                for (int i = 1; i < numCust; i++)
                {
                    if(timeServiceBegin[i] > q && arrivalTime[i] <=q )
                    numWaiting++;
                }    

                int first = q;
                int second = numWaiting;
                chart1.Series["Customers Queue Graph"].Points.AddXY(first, second);

            }

            Controls.Add(chart1);


        }
        //bn7seb el delay mnha w nersemoh
        public void plotDelayChart(int NumCustomers,int [] DelayDur)
        {
            int min = DelayDur.Min();
            int max = DelayDur.Max();
            
            chart2.BackColor = SystemColors.Highlight;
            chart2.Series.Add("Queue Size Histogram");

            chart2.Series["Queue Size Histogram"].SetDefault(true);
            chart2.Series["Queue Size Histogram"].Enabled = true;

            chart2.ChartAreas[0].AxisX.Minimum = 1;
            chart2.ChartAreas[0].AxisX.Maximum = max+1;
            chart2.ChartAreas[0].AxisX.Interval = 1;

            chart2.ChartAreas[0].AxisY.Minimum = 0;
            chart2.ChartAreas[0].AxisY.Maximum = NumCustomers;
            chart2.ChartAreas[0].AxisY.Interval = 1;

            
            chart2.Visible = true;
            int numCust;
            for (int i = 1; i <= max; i++)
            {
                numCust = 0;
                
                for(int j =1; j < NumCustomers ;j++)
                {
                    if(DelayDur[j] == i)
                    {
                        numCust++;
                    }
                    int first = i;
                    int second = numCust;
                    chart2.Series["Queue Size Histogram"].Points.AddXY(first, second);
                }

            }

            Controls.Add(chart2);


        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }
    }
}
