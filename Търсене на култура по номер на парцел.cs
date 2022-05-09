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
    public partial class Form4 : Form
    {
        FCoopDBContext context = new FCoopDBContext();
        public Form4()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = context.Contracts
               .Where(x => x.ContractId == textBox1.Text)
               .Select(x => new
               {
                   x.Plant
               }).ToList();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var form = new Form1();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
