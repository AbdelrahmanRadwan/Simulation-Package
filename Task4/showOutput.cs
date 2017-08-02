using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace taskSimulation4
{
    public partial class showOutput : Form
    {
        

        public showOutput()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        public void simulate(int[,] day, int[,] cycle, int[,] dayWithinCycle, int[,] beginingInventory, int[,] randomDemand, int[,] DemandVar,
        int[,] endingInventory, int[,] Shortage, int[,] orderQunat, int[,] randomLead, int[,] LeadTime, int[,] daysUntilArrive, int days)
        {
            
                int t = Convert.ToInt32(comboBox1.SelectedValue);

                for (int i = 0; i < days; i++)
                {
                    string[] row = new string[] { day[t,i].ToString(), 
                                          cycle[t,i].ToString(),
                                          dayWithinCycle[t,i].ToString(),
                                          beginingInventory[t,i].ToString(),
                                          randomDemand[t,i].ToString(),
                                          DemandVar[t,i].ToString(),
                                          endingInventory[t,i].ToString(),
                                          Shortage[t,i].ToString(),
                                          orderQunat[t,i].ToString(),
                                          randomLead[t,i].ToString(),
                                          LeadTime[t,i].ToString(),
                                          daysUntilArrive[t,i].ToString()};

                                          dataGridView1.Rows.Add(row);
                }
            
        }
        public void outputAverage(double endingAvg, double shortageAvg)
        {
            label3.Text = endingAvg.ToString();
            label4.Text = shortageAvg.ToString();
        
        }
        public void outputAverageAll(double endingForAll, double shortageForAll)
        {
            label7.Text = endingForAll.ToString();
            label9.Text = shortageForAll.ToString();
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void showOutput_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

    }
}
