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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var ctx = new FCoopDBContext())
            {
                var info = ctx.Contracts
                    .Include(c => c.Deal)
                    .ThenInclude(d => d.Plot).ToList();

                dataGridView1.DataSource = info
                    .GroupBy(x => x.Plant)
                    .Select(x => new
                    {
                        Key = x.Key,
                        Area = x.Select(y => y.Deal.Plot.Area).Sum()
                    }).ToList();

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new Form2().Show();
            Hide();
        }

        private void Form11_Load(object sender, EventArgs e)
        {

        }
    }
}
