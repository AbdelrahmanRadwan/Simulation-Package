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
    public partial class Form1 : Form
    {

        newsPaperSeller newSeller = new newsPaperSeller();
        
       
         public Form1()
        {
            InitializeComponent();
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            newSeller.initialize();
        }

        private void BDayInfo_Click(object sender, EventArgs e)
        
        {
            if (newSeller.DistributionOfDemand(double.Parse(tbGoodDemandProb.Text), double.Parse(tbFairDemandProb.Text),
                double.Parse(tbPoorDemandProb.Text),int.Parse(tbDayDemand.Text)) == false)
            {
                tbFairDemandProb.Enabled = false;
                tbPoorDemandProb.Enabled = false;
                tbGoodDemandProb.Enabled = false;
                tbDayDemand.Enabled = false;
                MessageBox.Show("ERROR: sum of probabilities is greater than 1");
                Dispose();
            }
           
               tbGoodDemandProb.Text = "";
               tbPoorDemandProb.Text = "";
               tbFairDemandProb.Text = "";
               tbDayDemand.Text = "";
  

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            if(newSeller.probabilitiesOfTypes(comboBox1.Text,double.Parse(tbDayProb.Text)) == false)
            {
                tbDayProb.Enabled = false;
                MessageBox.Show("ERROR: sum of probabilities is greater than 1");
                Dispose();
            }
            tbDayProb.Text = "";
            comboBox1.Text = "";
        }

        private void BShow_Click(object sender, EventArgs e)
        {
           newSeller.simulateTable(int.Parse(tbNumDay.Text),double.Parse(tbPurchase.Text), double.Parse(tbPrice.Text) ,
               double.Parse(tbScrap.Text), double.Parse(tbPurchased.Text)); 
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbDayDemand_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

      
    }
}
