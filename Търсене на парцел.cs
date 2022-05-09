using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ф_КООП.Models;

namespace WinFormsApp9
{
    public partial class Form5 : Form
    {
        FCoopDBContext context = new FCoopDBContext();
        public Form5()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                dataGridView1.DataSource = context.Plots.Where(x => x.PlotId == textBox1.Text).ToList();
                textBox1.Text = "";
            }
            else if (radioButton2.Checked)
            {
                dataGridView1.DataSource = context.Plots.Where(x => x.Location == textBox1.Text).ToList();
            }
            else if (radioButton3.Checked)
            {
                dataGridView1.DataSource = context.Plots.Where(x => x.Type == int.Parse(textBox1.Text)).ToList();
            }
            else if (radioButton4.Checked)
            {
                dataGridView1.DataSource = context.Plots.Where(x => Math.Floor((double)x.Area) == Math.Floor(double.Parse(textBox1.Text))).ToList();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var form = new Form1();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
