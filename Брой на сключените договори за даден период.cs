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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            var form = new Form1();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var start = DateTime.Parse(textBox1.Text);
            var end = DateTime.Parse(textBox2.Text);
            using (var ctx = new FCoopDBContext())
            {
                dataGridView1.DataSource = new List<Contract>(){ctx.Contracts
                    .Where(x => x.Date > start && x.Date < end)
                    .FirstOrDefault() }
                     .Select(x => new
                     {
                         Count = x.ContractId.Count()
                     }).Distinct().ToList();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }
    }
}
