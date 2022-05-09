using Microsoft.EntityFrameworkCore;
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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var ctx = new FCoopDBContext())
            {
                var info = ctx.Contracts
                    .Include(d => d.Deal)
                    .ThenInclude(p => p.Plot)
                    .Include(cs => cs.Deal.Client)
                    .ToList();

                var currentYear = DateTime.Now.Year;

                dataGridView1.DataSource = info
                    .Where(x => x.Date.Value.Year == currentYear)
                    .Select(x => new
                    {
                        Номер_на_договор = x.ContractId,
                        Имена_собственик = x.Deal.Client.Name,
                        Дата = x.Date,
                        Период = x.Term,
                        Площ = x.Deal.Plot.Area
                    }).ToList();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var form = new Form1();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void Form10_Load(object sender, EventArgs e)
        {

        }
    }
}
