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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
              if (int.Parse(comboBox1.Text) == 1)
                {
                    if (comboBox3.Text == "all number of customers")
                    {
                        newServer.singleServerAllCustomers(int.Parse(textBox3.Text),Math.Round(double.Parse(textBox1.Text),3),
                            Math.Round(double.Parse(textBox4.Text),3));
                    }
                    else
                    {
                        newServer.singleServerEndOfTime(int.Parse(textBox3.Text), Math.Round(double.Parse(textBox1.Text),3),
                            Math.Round(double.Parse(textBox4.Text),3));
                    }
                }
                else
                {
                    if (comboBox3.Text == "all number of customers")
                    {
                        newServer.multiServerQueueAllCustomers(comboBox2.Text, int.Parse(textBox3.Text),Math.Round(double.Parse( textBox1.Text),3),
                            Math.Round(double.Parse(textBox4.Text),3),Math.Round(double.Parse(textBox6.Text),3));
                    }
                    else
                    {
                        newServer.multiServerQueueEndOfTime(comboBox2.Text, int.Parse(textBox3.Text), Math.Round(double.Parse(textBox1.Text),3), 
                            Math.Round(double.Parse(textBox4.Text),3),Math.Round(double.Parse(textBox6.Text),3));
                    }
                }
            }
            
        

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
