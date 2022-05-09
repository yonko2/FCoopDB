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
    public partial class Form8 : Form
    {
        public Form8()
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
                    .Include(cs => cs.Deal.Client);

                var currentYear = DateTime.Now.Year;

                dataGridView1.DataSource = info
                    .Where(x => x.Date.Value.Year + x.Term == currentYear)
                    .Select(x => new
                    {
                        Номернадоговор = x.ContractId,
                        Именасобственик = x.Deal.Client.Name,
                        Дата = x.Date,
                        Период = x.Term
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

        private void Form8_Load(object sender, EventArgs e)
        {

        }
    }
}
