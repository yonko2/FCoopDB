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
    public partial class Form6 : Form
    {
        FCoopDBContext context = new FCoopDBContext();
        public Form6()
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
            var type = context.Deals
                 .Include(x => x.Plot)
                 .Where(x => x.ContractId == textBox1.Text)
                 .Select(x => x.Plot.Type)
                 .FirstOrDefault()
                 .ToString();
            double rent = 0;
            switch (type)
            {
                case "1":
                    rent = 35;
                    break;
                case "2":
                    rent = 45;
                    break;
                case "3":
                    rent = 55;
                    break;
                default:
                    break;
            }
            textBox2.Text = rent.ToString();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
