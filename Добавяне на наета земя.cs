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
    public partial class Form19 : Form
    {
        public Form19()
        {
            InitializeComponent();
        }

        private void Form19_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var newPlot = new Plot();
            var ctx = new FCoopDBContext();
            newPlot.PlotId = textBox5.Text;
            newPlot.Location = textBox1.Text;
            newPlot.Municipality = textBox2.Text;
            newPlot.Type = int.Parse(textBox3.Text);
            newPlot.Area = decimal.Parse(textBox4.Text);

            ctx.Plots.Add(newPlot);
            ctx.SaveChanges();
            MessageBox.Show("Успешно добавяне.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new Form1();
            this.Hide();
            form.ShowDialog();
        }
    }
}
