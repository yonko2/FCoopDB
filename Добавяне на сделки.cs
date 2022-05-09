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
    public partial class Form22 : Form
    {
        public Form22()
        {
            InitializeComponent();
        }

        private void Form22_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var ctx = new FCoopDBContext();
            var newDeal = new Deal();
            var client = ctx.Clients
                .Where(x => x.IdcardNum == textBox2.Text)
                .FirstOrDefault();
            if (client == null) { MessageBox.Show("Няма такъв запис"); return; }
            var contract = ctx.Contracts
                .Where(x => x.ContractId == textBox1.Text)
                .FirstOrDefault();
            if (contract == null) { MessageBox.Show("Няма такъв запис"); return; }
            var plot = ctx.Plots
                .Where(x => x.PlotId == textBox3.Text)
                .FirstOrDefault();
            if (plot == null) { MessageBox.Show("Няма такъв запис"); return; }

            newDeal.Client = client;
            newDeal.Contract = contract;
            newDeal.Plot = plot;

            ctx.Attach(client);
            ctx.Attach(contract);
            ctx.Attach(plot);

            ctx.Add(newDeal);
            ctx.SaveChanges();
            MessageBox.Show("Успешно добавяне.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new Form1();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }
    }
}
