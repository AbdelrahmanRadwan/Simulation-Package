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
    public partial class Form1 : Form
    {
        server newServer = new server();

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int number;
            double probabilty;

            number = int.Parse(textBox1.Text);
            probabilty = double.Parse(textBox2.Text);

            if(newServer.interArrivalTime(number,probabilty) == false)
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                MessageBox.Show("ERROR: sum of probabilities is greater than 1");
                Dispose(); 
            }
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int number;
            double probabilty;

            number = int.Parse(textBox4.Text);
            probabilty = double.Parse(textBox5.Text);

            if (newServer.serviceTimeAble(number, probabilty) == false)
            {
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                MessageBox.Show("ERROR: sum of probabilities is greater than 1");
                Dispose(); 
            }
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int number;
            double probabilty;

            number = int.Parse(textBox6.Text);
            probabilty = double.Parse(textBox7.Text);

            if (newServer.serviceTimeBaker(number, probabilty) == false)
            {
                textBox6.Enabled = false;
                textBox7.Enabled = false;
                MessageBox.Show("ERROR: sum of probabilities is greater than 1");
                Dispose(); 
            }
            textBox6.Text = "";
            textBox7.Text = "";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //try
            //{
                if (int.Parse(comboBox1.Text) == 1)
                {
                    if (comboBox3.Text == "all number of customers")
                    {
                        newServer.singleServerAllCustomers(int.Parse(textBox3.Text));
                    }
                    else
                    {
                        newServer.singleServerEndOfTime(int.Parse(textBox3.Text));
                    }
                }
                else
                {
                    if (comboBox3.Text == "all number of customers")
                    {
                        newServer.multiServerQueueAllCustomers(comboBox2.Text, int.Parse(textBox3.Text));
                    }
                    else
                    {
                        newServer.multiServerQueueEndOfTime(comboBox2.Text, int.Parse(textBox3.Text));
                    }
                }
            }
            //catch
            //{
            //    MessageBox.Show("ERROR: please fill all text boxes");
            //    Dispose(); 
            //}
        

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
