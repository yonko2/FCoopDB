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
    public partial class Редактиране_на_сделки : Form
    {
        public Редактиране_на_сделки()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new Form1();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var ctx = new FCoopDBContext();
            var client = ctx.Clients
                .Where(x => x.ClientId == int.Parse(textBox2.Text))
                .FirstOrDefault();
            if (client == null) { MessageBox.Show("Няма такъв запис"); return; }
            var plot = ctx.Plots
                .Where(x => x.PlotId == textBox3.Text)
                .FirstOrDefault();
            if (plot == null) { MessageBox.Show("Няма такъв запис"); return; }

            var searchedDeal = ctx.Deals
                .Where(x => x.ContractId == dataGridView1.CurrentRow.Cells[0].Value.ToString())
                .FirstOrDefault();

            ctx.Attach(client);
            ctx.Attach(plot);

            searchedDeal.Client = client;
            searchedDeal.ClientId = client.ClientId;
            searchedDeal.Plot = plot;
            searchedDeal.PlotId = plot.PlotId;

            ctx.Update(searchedDeal);
            ctx.SaveChanges();
            MessageBox.Show("Успешно добавяне.");
            LoadData(ctx);
        }
        private void LoadData(FCoopDBContext ctx)
        {
            dataGridView1.DataSource = ctx.Deals.ToList();
        }

        private void Редактиране_на_сделки_Load(object sender, EventArgs e)
        {
            LoadData(new FCoopDBContext());
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {            
        }
    }
}
