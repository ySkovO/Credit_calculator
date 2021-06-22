using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invest
{
    public partial class Credit : Form
    {
        public Credit()
        {
            InitializeComponent();
            
        }

        private static double x; //investments
        private static double n; //investment period
        private static double r; //rate
        private static string agreementdate;
        private static string calculationdate;


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            x = Convert.ToDouble(textBox8.Text);
            n = Convert.ToDouble(textBox9.Text);
            r = Convert.ToDouble(textBox10.Text);
            agreementdate = dateTimePicker1.Value.ToString();
            calculationdate = dateTimePicker2.Value.ToString();
            label4.Text = "Credit calculation on " + calculationdate;

            CreditTable inst = new CreditTable(agreementdate, x, n, r, calculationdate);

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dataGridView1.DataSource = inst.ShowList();

            CreditCalculation instUp = inst;
            textBox16.Text = Convert.ToString(instUp.TotalAmount);
            textBox17.Text = Convert.ToString(instUp.LoanOverpayment);
            textBox18.Text = Convert.ToString(Math.Round(instUp.PMT, 2));
            textBox12.Text = Convert.ToString(inst.PaidDebt);
            textBox14.Text = Convert.ToString(inst.LeftDebt);
            textBox11.Text = Convert.ToString(inst.RestOfMonth);
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (textBox8.Text == "-")
            {
                MessageBox.Show("The amount of investment cannot be less than zero");
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (textBox9.Text == "-")
            {
                MessageBox.Show("The investment term cannot be less than zero");
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (textBox10.Text == "-")
            {
                MessageBox.Show("The investment rate cannot be less than zero");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
    }
}
