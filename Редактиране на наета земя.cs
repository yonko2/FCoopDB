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
    public partial class Form21 : Form
    {
        public Form21()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var ctx = new FCoopDBContext();
            var searchedPlotID = textBox5.Text;
            var searchedPlot = ctx.Plots
                .Where(x => x.PlotId == searchedPlotID)
                .FirstOrDefault();
            if (searchedPlot == null) { MessageBox.Show("Няма такъв запис"); return; }
            searchedPlot.Location = textBox1.Text;
            searchedPlot.Municipality = textBox2.Text;
            searchedPlot.Type = int.Parse(textBox3.Text);
            searchedPlot.Area = decimal.Parse(textBox4.Text);

            ctx.SaveChanges();
            MessageBox.Show("Успешно добавяне.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new Form1();
            this.Hide();
            form.ShowDialog();
        }

        private void Form21_Load(object sender, EventArgs e)
        {
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox1.ReadOnly = true;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
                textBox1.ReadOnly = true;
            }
            else
            {
                textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;
                textBox4.ReadOnly = false;
                textBox1.ReadOnly = false;
            }
        }
    }
}
