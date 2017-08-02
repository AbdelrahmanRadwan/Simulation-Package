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
    public partial class Form1 : Form
    {
        refrigeratorSimulation newSimulate = new refrigeratorSimulation();
        showOutput newshow = new showOutput();

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            newSimulate.simulateTrials(int.Parse(textBox7.Text),int.Parse(textBox6.Text), int.Parse(textBox1.Text), int.Parse(textBox2.Text),
                int.Parse(textBox3.Text),int.Parse(textBox4.Text), int.Parse(textBox5.Text));

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //try
            //{
            int number;
            double probabilty;

            number = int.Parse(textBox8.Text);
            probabilty = double.Parse(textBox9.Text);

            if (newSimulate.Demand(number, probabilty) == false)
            {
                MessageBox.Show("ERROR: sum of probabilities is greater than 1");
                Dispose();
            }
            textBox8.Text = "";
            textBox9.Text = "";

            //catch
            //{
            //    MessageBox.Show("ERROR: please fill all text boxes correct");
            //    Dispose();
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //try
            //{
            int number;
            double probabilty;

            number = int.Parse(textBox10.Text);
            probabilty = double.Parse(textBox11.Text);

            if (newSimulate.leadTime(number, probabilty) == false)
            {
                MessageBox.Show("ERROR: sum of probabilities is greater than 1");
                Dispose();
            }
            textBox10.Text = "";
            textBox11.Text = "";

            //catch
            //{
            //    MessageBox.Show("ERROR: please fill all text boxes correct");
            //    Dispose();
            //}
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
