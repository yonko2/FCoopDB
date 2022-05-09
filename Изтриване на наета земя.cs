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
    public partial class Form20 : Form
    {
        public Form20()
        {
            InitializeComponent();
        }

        private void Form20_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var ctx = new FCoopDBContext();
            var searchedPlotID = textBox1.Text;
            var searchedPlot = ctx.Plots
                .Where(x => x.PlotId == searchedPlotID)
                .FirstOrDefault();
            if (searchedPlot == null) { MessageBox.Show("Няма такъв запис"); return; }
            ctx.Plots.Remove(searchedPlot);
            ctx.SaveChanges();
            MessageBox.Show("Успешно изтриване.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new Form1();
            this.Hide();
            form.ShowDialog();
        }
    }
}
