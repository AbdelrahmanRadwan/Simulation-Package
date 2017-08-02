using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simulationTask2
{
    public partial class Output : Form
    {
        public Output()
        {
            InitializeComponent();
        }
        public void simulate(int day, double rnd1, string typeOfDay, double rnd2, int demand, double revenue,
            double lostProfit, double salv, double dailyProfit)
        {

            dataGridView1.ColumnCount = 9;
            dataGridView1.Columns[0].Name = "Day Number";
            dataGridView1.Columns[1].Name = "random number for type";
            dataGridView1.Columns[2].Name = "type of day";
            dataGridView1.Columns[3].Name = "random number for demand";
            dataGridView1.Columns[4].Name = "demand";
            dataGridView1.Columns[5].Name = "revenue";
            dataGridView1.Columns[6].Name = "lost profit";
            dataGridView1.Columns[7].Name = "Salvage";
            dataGridView1.Columns[8].Name = "Daily profit";
          

            string[] row = new string[] { day.ToString(), 
                                           rnd1.ToString(),
                                          typeOfDay,
                                          rnd2.ToString(),
                                          demand.ToString(),
                                          revenue.ToString(),
                                          lostProfit.ToString(),
                                          salv.ToString(),
                                          dailyProfit.ToString()
                                          };

            dataGridView1.Rows.Add(row);

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
      public void calculations(double totalRev,double totalCost,double totalLostProfit,double totalSalvage,
          double netProfit,int numExcess,int numUnsold)
        {
            label2.Text = totalRev.ToString();
            label4.Text = totalCost.ToString();
            label6.Text = totalLostProfit.ToString();
            label8.Text = totalSalvage.ToString();
            label10.Text = netProfit.ToString();
            label12.Text = numExcess.ToString();
            label14.Text = numUnsold.ToString();
        }
        private void Output_Load(object sender, EventArgs e)
        {

        }
    }
}
